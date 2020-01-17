using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuneScapeWiki.Models
{
    public class UpdateGameAccountViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Attack { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Defence { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Strength { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Slayer { get; set; }
    }
}
