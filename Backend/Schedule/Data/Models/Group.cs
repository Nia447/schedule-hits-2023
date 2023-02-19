﻿using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Audience
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
