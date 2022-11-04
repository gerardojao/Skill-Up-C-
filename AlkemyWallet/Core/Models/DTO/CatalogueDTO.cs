using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{

   
    public class CatalogueDTO
    {       
        public string Product_description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Points { get; set; }
    }

    public class CatalogueForCreationDTO
    {
        [MaxLength(100)]
        [MinLength(2)]        
        [Required(ErrorMessage = "Product name or description is required")]       
        public string Product_description { get; set; }      
       
        [Required(ErrorMessage = "A Valid Image is Required,The Name its too Long or the File its Too Big")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "The Amount of Points are Required")]
        [Range(0, 9999)]
        public int Points { get; set; }
    }

    public class CatalogueForUpdateDTO
    {
        
        [StringLength(100, MinimumLength = 2)]
        public string? Product_description { get; set; }        
        public IFormFile? ImageFile { get; set; }
        [Range(0, 9999)]
        public int? Points { get; set; }
    }
}
