﻿using System.ComponentModel.DataAnnotations;

namespace OfficeGameTracker.Entities
{
    public class Discipline
    {
        [Key]
        public Guid DisciplineId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Points { get; set; }

        [Required]
        public int DailyLimit { get; set; }

        public string? Image { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }
    }
}
