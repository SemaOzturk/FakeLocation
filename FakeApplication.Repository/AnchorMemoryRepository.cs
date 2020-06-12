using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FakeApplication.Repository.Entities;
using FakeApplication.Repository.Interfaces;

namespace FakeApplication.Repository
{
    public class AnchorMemoryRepository : IAnchorRepository
    {
        private static readonly ConcurrentDictionary<int, AnchorRE> AnchorRes = new ConcurrentDictionary<int, AnchorRE>();
        
        public AnchorRE Get(int id)
        {
            return AnchorRes.TryGetValue(id, out var anchor) ? anchor : null;
        }

        public IEnumerable<AnchorRE> GetAll()
        {
            return AnchorRes.Values;
        }

        public AnchorRE Update(AnchorRE entity)
        {
            if (AnchorRes.ContainsKey(entity.Id))
            {
                AnchorRes[entity.Id] = entity;
                return entity;
            }

            return null;
        }

        public AnchorRE Insert(AnchorRE entity)
        {
            if (!AnchorRes.ContainsKey(entity.Id))
            {
                AnchorRes.TryAdd(entity.Id, entity);
                return entity;
            }

            return null;
        }

        public AnchorRE Upsert(AnchorRE entity)
        {
            if (AnchorRes.ContainsKey(entity.Id))
            {
                AnchorRes[entity.Id] = entity;
            }
            else
            {
                AnchorRes.TryAdd(entity.Id, entity);
            }

            return entity;
        }

        public bool Delete(int id)
        {
            return AnchorRes.TryRemove(id, out _);
        }
    }
}