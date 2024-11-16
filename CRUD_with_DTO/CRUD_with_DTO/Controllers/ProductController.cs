using CRUD_with_DTO.DTOs;
using CRUD_with_DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_with_DTO.Controllers
{
    public class ProductController : Controller
    {
        LabTaskEntities db = new LabTaskEntities();

        public static Product Convert(ProductDTO productDTO)
        {
            return new Product
            {
                ProductId = productDTO.ProductId,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                StockQuantity = productDTO.StockQuantity,
                Category = productDTO.Category
            };
        }
        public static ProductDTO Convert(Product product)
        {
            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category
            };
        }

        public static List<ProductDTO> Convert(List<Product> products)
        {
            var productDTOs = new List<ProductDTO>();
            foreach (var product in products)
            {
                productDTOs.Add(Convert(product));
            }
            return productDTOs;
        }

        [HttpGet]
        public ActionResult List()
        {
            var products = db.Products.ToList();
            var productDTOs = Convert(products);
            return View(productDTOs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductDTO());
        }

        [HttpPost]
        public ActionResult Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = Convert(productDTO);
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("List");

            }
            return View(productDTO);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            return View(Convert(product));
        }
        [HttpPost]
        public ActionResult Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = Convert(productDTO);
                var dbvalue = db.Products.Find(product.ProductId);
                dbvalue.Name = product.Name;
                dbvalue.Description = product.Description;
                dbvalue.Price = product.Price;
                dbvalue.StockQuantity = product.StockQuantity;
                dbvalue.Category = product.Category;
                db.SaveChanges();
                return RedirectToAction("List");

            }
            return View(productDTO);


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            return View(Convert(product));
        }

        [HttpPost]
        public ActionResult Delete(int id,string del)
        {
            if (del.Equals("Yes"))
            {
                var Yes = db.Products.Find(id);
                db.Products.Remove(Yes);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var details = db.Products.Find(id);
            return View(Convert(details));
        }

        }

    

}