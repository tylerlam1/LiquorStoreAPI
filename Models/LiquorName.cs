﻿using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorName
    {
        [Key]
        public int liquor_id { get; set; }

        public string name { get; set; }
    }
}
