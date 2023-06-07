﻿using System;

namespace PetStore.Services.Models
{
    public class PetDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
    }
}