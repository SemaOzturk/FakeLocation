﻿using FakeApplication.DTO.ApplicationEntities.Interfaces;

namespace FakeApplication.DTO.ApplicationEntities
{
    public class Anchor : ICoordinate
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}