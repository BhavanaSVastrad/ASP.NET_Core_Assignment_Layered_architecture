using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessModel
{
    public class CategoryBO
    {
        public int id { get; set; }
        [Required]
        public string Category_Name { get; set; }
    }
}

