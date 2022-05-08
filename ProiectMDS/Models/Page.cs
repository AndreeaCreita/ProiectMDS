using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Page
    {
        public int Id { get; set; } //va fi automat recunoscut ca primary key <3
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Content { get; set; }

        public int Sorting { get; set; }

    }
}
