﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "İsim alanı boş olamaz")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Karakter uzunluğu 10-50 aralığında olmalıdır.")]
        public string? Name { get; set; } = null!;

        
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stok alanı boş olamaz")]
        [Range(1, 200, ErrorMessage = "Stok alanı 1-200 aralığında olmalıdır.")]
        public int? Stock { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "PublishDate alanı boş olamaz")]
        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "Color alanı boş olamaz")]
        public string? Color { get; set; }
        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Expire alanı boş olamaz")]
        public int? Expire { get; set; }

        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string ImagePath { get; set; }
    }
}
