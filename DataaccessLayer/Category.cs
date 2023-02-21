using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataaccessLayer
{
    public class Category
    {
        [Key]

        public int id { get; set; }
        [Required]
        public string Category_Name { get; set; }
    }
}
