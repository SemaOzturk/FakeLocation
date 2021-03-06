﻿using AutoMapper;
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
            CreateMap<Tag, TagReadModel>();
            CreateMap<TagCreateModel, Tag>();
            CreateMap<TagSetCoordinateModel, Tag>();
        }
    }
}