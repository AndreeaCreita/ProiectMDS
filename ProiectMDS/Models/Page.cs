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
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Content { get; set; }
        public int Sorting { get; set; }

    }
}
