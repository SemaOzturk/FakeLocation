using System.Collections.Generic;
using System.Linq;
using FakeApplication.DTO.ApplicationEntities;
using FakeApplication.Repository.Entities;
using FakeApplication.Repository.Interfaces;
using FakeLocation.Application.Services.Interfaces;

namespace FakeLocation.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IEnumerable<Tag> GetAll(bool includeDeactive)
        {
            var query = _tagRepository.GetAllQueryable();
            if (includeDeactive)
            {
                query = query.Where(x => !x.IsActive);
            }

            return query.AsEnumerable().Select(Build);
        }

        public Tag Get(int id)
        {
            return Build(_tagRepository.Get(id));
        }

        public Tag Insert(Tag tag)
        {
            TagRE tagRe = _tagRepository.Insert(Build(tag));
            return Build(tagRe);
        }

        public Tag Update(Tag tag)
        {
            var res = _tagRepository.Update(Build(tag));
            return Build(res);
        }

        public bool UpsertMany(params Tag[] tags)
        {
            if (tags.Length > 0)
            {
                foreach (Tag tag in tags)
                {
                    _tagRepository.Upsert(Build(tag));
                }
            }

            return true;
        }

        private Tag Build(TagRE tagRe)
        {
            var tag = new Tag();
            tag.Id = tagRe.Id;
            tag.X = tagRe.X;
            tag.Y = tagRe.Y;
            tag.Z = tagRe.Z;
            tag.SignalFrequency = tagRe.SignalFrequency;
            return tag;
        }

        private TagRE Build(Tag tag)
        {
            var tagRE = new TagRE();
            tagRE.Id = tag.Id;
            tagRE.X = tag.X;
            tagRE.Y = tag.Y;
            tagRE.Z = tag.Z;
            tagRE.SignalFrequency = tag.SignalFrequency;
            return tagRE;
        }
    }
}