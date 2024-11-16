using CRUD_with_DTO.DTOs;
using CRUD_with_DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_with_DTO.Controllers
{
    public class CustomerController : Controller
    {
        LabTaskEntities db = new LabTaskEntities();

        public static Customer Convert(CustomerDTO customerDTO)
        {
            return new Customer
            {
                CustomerId = customerDTO.CustomerId,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Address = customerDTO.Address,
                DateJoined = customerDTO.DateJoined,
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName
            };
        }

        public static CustomerDTO Convert(Customer customer)
        {
            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                DateJoined = customer.DateJoined,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public static List<CustomerDTO> Convert(List<Customer> customers)
        {
            var customerDTOs = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                customerDTOs.Add(Convert(customer));
            }
            return customerDTOs;
        }

        [HttpGet]
        public ActionResult List()
        {
            var customers = db.Customers.ToList();
            var customerDTOs = Convert(customers);
            return View(customerDTOs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerDTO());
        }

        [HttpPost]
        public ActionResult Create(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var customer = Convert(customerDTO);
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(customerDTO);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Convert(customer));
        }
        [HttpPost]
        public ActionResult Edit(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var customer = Convert(customerDTO);
                var dbvalue = db.Customers.Find(customer.CustomerId);
                dbvalue.Email = customer.Email;
                dbvalue.Phone = customer.Phone;
                dbvalue.Address = customer.Address;
                dbvalue.DateJoined = customer.DateJoined;
                dbvalue.FirstName = customer.FirstName;
                dbvalue.LastName = customer.LastName;

                db.SaveChanges();
                return RedirectToAction("List");
           }
            return View(customerDTO);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Convert(customer));
        }
        [HttpPost]
        public ActionResult Delete(int id, string del)
        {
            if (del.Equals("Yes"))
            {
                var Yes = db.Customers.Find(id);
                db.Customers.Remove(Yes);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Convert(customer));

        }

        }
}