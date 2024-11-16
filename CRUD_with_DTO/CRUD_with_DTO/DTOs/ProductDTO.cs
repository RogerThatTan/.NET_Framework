using CRUD_with_DTO.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_with_DTO.DTOs
{
    public class ProductDTO : Controller
    {

        public int ProductId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage="Name cannot exceed 100 Characters")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 Characters")]
        public string Description { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public double Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock Quantity must be a positive number")]
        public int StockQuantity { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 Characters")]
        [RegularExpression("^(Electronics|Clothing|Groceries|Furniture|Toys)$",
        ErrorMessage = "Category must be one of the following: Electronics, Clothing, Groceries, Furniture, Toys.")]
        public string Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCustomer> ProductCustomers { get; set; }

    }
}