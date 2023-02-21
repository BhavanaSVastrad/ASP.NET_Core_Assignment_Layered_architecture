using System;
using System.ComponentModel.DataAnnotations;

namespace DataaccessLayer
{
    public class Product
    {
        [Key]


        public int Id { get; set; }
        [Required (ErrorMessage ="Enter the Product Image")]
        
        public string Product_Image { get; set; }

        [Required(ErrorMessage ="Enter the Product Name")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Enter the Product Description")]
        public string Product_Description { get; set; }

        [Required(ErrorMessage = "Enter the Product Price")]
        public string Product_Price { get; set; }



    }
}
