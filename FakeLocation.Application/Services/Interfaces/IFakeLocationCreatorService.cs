using System.Threading.Tasks;

namespace FakeLocation.Application.Services.Interfaces
{
    public interface IFakeLocationCreatorService{
        Task StartGenerating(string host, int port);
        void StopGenerating();
        bool IsGenerating { get; }
    }
}