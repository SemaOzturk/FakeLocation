using System.Collections.Generic;
using FakeApplication.DTO.ApplicationEntities;

namespace FakeLocation.Application.Services.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll(bool includeDeactive);
        Tag Insert(Tag tag);
        Tag Update(Tag tag);
        bool UpsertMany(params Tag[] tags);
    }
}