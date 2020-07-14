using System.Collections.Generic;
using System.Linq;
using FakeApplication.DTO.ApplicationEntities;
using FakeApplication.Repository.Entities;
using FakeApplication.Repository.Interfaces;
using FakeLocation.Application.Services.Interfaces;

namespace FakeLocation.Application.Services
{
    public class AnchorService : IAnchorService
    {
        private readonly IAnchorRepository _anchorRepository;

        public AnchorService(IAnchorRepository anchorRepository)
        {
            _anchorRepository = anchorRepository;
        }

        public Anchor Get(int id)
        {
            return Build(_anchorRepository.Get(id));
        }

        public IEnumerable<Anchor> GetAll()
        {
            return _anchorRepository.GetAll().Where(x=>x.Id>600).Select(Build);
        }

        private Anchor Build(AnchorRE entity)
        {
            return new Anchor()
            {
                Id = entity.Id,
                X = entity.X,
                Y = entity.Y,
                Z = entity.Z
            };
        }

        public void Set(IEnumerable<Anchor> anchors)
        {
            foreach (Anchor anchor in anchors)
            {
                _anchorRepository.Upsert(Build(anchor));
            }
        }

        public void SetCoordinate(int id, double x, double y, double z)
        {
            var found = _anchorRepository.Get(id);
            if (found != null)
            {
                found.X = x;
                found.Y = y;
                found.Z = z;

                _anchorRepository.Update(found);
            }
        }

        public Anchor Add(Anchor anchor)
        {
            var newAnchor = _anchorRepository.Insert(Build(anchor));
            return Build(newAnchor);
        }

        private AnchorRE Build(Anchor entity)
        {
            return new AnchorRE()
            {
                Id = entity.Id,
                X = entity.X,
                Y = entity.Y,
                Z = entity.Z
            };
        }
    }
}