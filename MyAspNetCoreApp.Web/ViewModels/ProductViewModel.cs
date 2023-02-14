﻿using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="İsim alanı boş olamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Price alanı boş olamaz")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Stok alanı boş olamaz")]
        public int? Stock { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "PublishDate alanı boş olamaz")]
        public DateTime? PublishDate { get; set; }
        [Required(ErrorMessage = "Color alanı boş olamaz")]
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Expire alanı boş olamaz")]
        public int? Expire { get; set; }
    }
}
