using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="İsim alanı boş olamaz")]
        [StringLength(50,MinimumLength =10,ErrorMessage ="Karakter uzunluğu 10-50 aralığında olmalıdır.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Price alanı boş olamaz")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Stok alanı boş olamaz")]
        [Range(1,200,ErrorMessage="Stok alanı 1-200 aralığında olmalıdır.")]
        public int? Stock { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "PublishDate alanı boş olamaz")]
        public DateTime? PublishDate { get; set; }
        [Required(ErrorMessage = "Color alanı boş olamaz")]
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Expire alanı boş olamaz")]
        public int? Expire { get; set; }
        [EmailAddress(ErrorMessage ="Email adresi uygun formatta değil")]
        public string Email { get; set; }
    }
}
