using System.Threading.Tasks;

namespace FakeLocation.Application.Services.Interfaces
{
    public interface IFakeLocationCreatorService{
        void StartGenerating(string host, int port, double errorMargin = .1d, double errorOverDistanceMultiplier = 0);
        void StopGenerating();
        bool IsGenerating { get; }
    }
}