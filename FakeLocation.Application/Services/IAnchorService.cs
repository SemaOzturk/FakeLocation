using System.Collections.Generic;
using System.Linq;
using FakeApplication.DTO.ApplicationEntities;
using FakeApplication.Repository;
using FakeApplication.Repository.Entities;
using FakeApplication.Repository.Interfaces;

namespace FakeLocation.Application.Services
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

        bool Add(Anchor anchor);
    }

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
            return _anchorRepository.GetAll().Select(Build);
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

        public bool Add(Anchor anchor)
        {
            return _anchorRepository.Insert(Build(anchor)) != null;
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