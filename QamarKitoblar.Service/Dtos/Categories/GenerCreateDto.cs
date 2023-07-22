﻿using System.ComponentModel.DataAnnotations;

namespace QamarKitoblar.Service.Dtos.Categories
{
    public class GenerCreateDto
    {
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
