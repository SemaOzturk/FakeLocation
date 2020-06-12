using AutoMapper;
using FakeApplication.DTO.ApplicationEntities;
using FakeLocation.Shared.UIModels;

namespace FakeLocation.API
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            CreateMap<Anchor, AnchorReadModel>();
            CreateMap<AnchorCreateModel, Anchor>();
        }
    }
}