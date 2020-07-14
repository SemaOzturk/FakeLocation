using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using FakeApplication.DTO.ApplicationEntities;
using FakeApplication.DTO.ApplicationEntities.Interfaces;
using FakeLocation.Application.Services.Interfaces;

namespace FakeLocation.Application.Services
{
    public class FakeLocationService : IFakeLocationCreatorService
    {
        private string _hostIp;
        private int _hostPort;
        private Dictionary<int, Anchor> _anchors = new Dictionary<int, Anchor>();
        private Dictionary<int, Tag> _tags = new Dictionary<int, Tag>();
        private Socket _socket;
        private static readonly Random _random = new Random();
        private readonly IAnchorService _anchorService;
        private readonly ITagService _tagService;
        private static volatile bool _isGenerating = false;
        private static readonly ManualResetEvent ResetEvent = new ManualResetEvent(true);

        public bool IsGenerating
        {
            get => _isGenerating;
            private set => _isGenerating = value;
        }

        public FakeLocationService(IAnchorService anchorService, ITagService tagService)
        {
            _anchorService = anchorService;
            _tagService = tagService;
        }
        
        public void StartGenerating(string host, int port, double errorMargin = .1d, double errorOverDistanceMultiplier = 0)
        {
          
            _isGenerating=false;
            ResetEvent.WaitOne();
            ResetEvent.Reset();
            _anchors = _anchorService.GetAll().ToDictionary(x => x.Id);
            _tags = _tagService.GetAll(false).ToDictionary(x => x.Id);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(new IPEndPoint(IPAddress.Parse(host), port));
            uint dataCount = 0;
            _isGenerating = true;
            ResetEvent.Set();
            StartSending(errorMargin, dataCount).ConfigureAwait(false);
        }

        private async Task StartSending(double errorMargin, uint dataCount)
        {
            while (_isGenerating)
            {
                ResetEvent.WaitOne();
                ResetEvent.Reset();
                dataCount++;
                foreach (Tag tag in _tags.Values)
                {
                    foreach (Anchor anchor in _anchors.Values)
                    {
                        var distance = GenerateDistance(tag, anchor, errorMargin);
                        var packet = CreateLocationMessage(tag, anchor, distance, dataCount);
                        await _socket.SendAsync(packet, SocketFlags.None);
                    }
                }

                await Task.Delay(1000);
                ResetEvent.Set();
            }
        }

        public void StopGenerating()
        {
            _isGenerating = false;
        }

        private ushort GenerateDistance(ICoordinate coord1, ICoordinate coord2, double errorMargin)
        {
            var dx = coord1.X - coord2.X;
            var dy = coord1.Y - coord2.Y;
            var dz = coord1.Z - coord2.Z;
            var distance = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            var randomness = (_random.NextDouble() * 2 - 1) * errorMargin;
            distance += randomness * distance;

     

            return (ushort) distance;
        }
        public void DisconnectCoordinator(double distance)
        {
            Random randDisconnect = new Random();
            
            
            var delayTimer = new System.Timers.Timer
            {
                Interval = 1000,
                AutoReset = true,
            };
            delayTimer.Elapsed += ((o, e) => { distance = 0; });
            delayTimer.Start();
        }
        //4,1,0,0,82,152,1,65,255,8,4,247,0,0,159,153,46,198,1,103,255,8,4,247,0,0,128,21,124,219,3,176,255,8,4,247,0,0,10,148,124,248,3,156,255,8,4,247,0,0,206,96,82,152,1,61,255,8,4,247,0,0,159,151,82
        //,152,0,252,255,8,4,247,0,0,159,73,1,2,3,4,241,241,241,241,241,0,0,0,0,0
        private static byte[] CreateLocationMessage(Tag tag, Anchor anchor, ushort distance, uint dataCountNumber)
        {
            byte[] packet = new byte[30];
            var dataCount = BitConverter.GetBytes(1);
            var mobileNodeId = BitConverter.GetBytes(tag.Id);
            var accz = BitConverter.GetBytes(distance); // Rastgele üretilecek
            var readerNodeId = BitConverter.GetBytes(anchor.Id);
            var dataCountNo = BitConverter.GetBytes(dataCountNumber);
            var index = 0;
            packet[0] = 240;
            packet[1] = 240;
            packet[2] = 240;
            packet[3] = 240;
            packet[4] = 240;
            packet[5] = 4;
            packet[6] = 1;
            packet[9] = mobileNodeId[1];
            packet[10] = mobileNodeId[0];
            packet[11] = accz[1];
            packet[12] = accz[0];
            packet[14] = 8;
            packet[15] = readerNodeId[1];
            packet[16] = readerNodeId[0];
            packet[17] = dataCountNo[3];
            packet[18] = dataCountNo[2];
            packet[19] = dataCountNo[1];
            packet[20] = dataCountNo[0];
            packet[25] = 241;
            packet[26] = 241;
            packet[27] = 241;
            packet[28] = 241;
            packet[29] = 241;

            return packet;
        }
    }
}