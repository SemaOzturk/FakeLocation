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

        public bool IsGenerating { get; private set; } = false;

        public FakeLocationService(IAnchorService anchorService, ITagService tagService)
        {
            _anchorService = anchorService;
            _tagService = tagService;
        }

        public async Task StartGenerating(string host, int port)
        {
            _anchors = _anchorService.GetAll().ToDictionary(x => x.Id);
            _tags = _tagService.GetAll(false).ToDictionary(x => x.Id);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(new IPEndPoint(IPAddress.Parse(host), port));
            uint dataCount = 0;
            IsGenerating = true;
            while (IsGenerating)
            {
                dataCount++;
                foreach (Tag tag in _tags.Values)
                {
                    foreach (Anchor anchor in _anchors.Values)
                    {
                        var distance = GenerateDistance(tag, anchor, .1);
                        var packet = CreateLocationMessage(tag, anchor, distance, dataCount);
                        await _socket.SendAsync(packet, SocketFlags.None);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public void StopGenerating()
        {
            IsGenerating = false;
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

        private static byte[] CreateLocationMessage(Tag tag, Anchor anchor, ushort distance, uint dataCountNumber)
        {
            byte[] packet = new byte[26];
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
            packet[21] = 241;
            packet[22] = 241;
            packet[23] = 241;
            packet[24] = 241;
            packet[25] = 241;

            return packet;
        }
    }
}