using System.Collections.Generic;
using System.Linq;
using FakeApplication.DTO.ApplicationEntities;
using FakeApplication.Repository;

namespace FakeLocation.Application.Services.Interfaces
{
    public interface IAnchorService
    {
        Anchor Get(int id);
        IEnumerable<Anchor> GetAll();
        void Set(IEnumerable<Anchor> anchors);
        void Set(params Anchor[] anchors)
        {
            Set(anchors.AsEnumerable());
        }

        Anchor Add(Anchor anchor);
        void SetCoordinate(int id, double x, double y, double z);
    }
}