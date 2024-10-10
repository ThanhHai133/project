using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using EF_CodeFirst.Models;

namespace EF_CodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();  
        // GET: Products
        public ActionResult Index(string search = "", string SortColumn = "ProductID", string IconClass = "fa-sort-asc", int page = 1)
        {
          
            //List<Product> products = db.Products.ToList();
            //Search
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
            //Sort
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductID).ToList();

                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductID).ToList();
                }


            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductName).ToList();

                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            }
            else if (SortColumn == "Price")
            {

                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.Price).ToList();

                }
                else
                {
                    products = products.OrderByDescending(row => row.Price).ToList();
                }
            }
            //paging
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(products);
        }
        public ActionResult Detail(int id)
        {
            
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
        public ActionResult Create()
        {
            
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }   
            else
            {
                ViewBag.Createfail = "tao that bai vui long nhap du thong tin";
            }
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            return View(p);
        }

        public ActionResult Edit(int id)
        {
           
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            Product product = db.Products.FirstOrDefault(row => row.ProductID == id);

            // Kiểm tra xem sản phẩm có tồn tại không
            if (product == null)
            {
                return HttpNotFound(); // Nếu không tìm thấy sản phẩm, trả về lỗi 404
            }

            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
           
            Product product = db.Products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();

            product.ProductName = pro.ProductName;
            product.Price = pro.Price;
            product.DateOfPurchase = pro.DateOfPurchase;
            product.AvailabilityStatus = pro.AvailabilityStatus;
            product.CategoryID = pro.CategoryID;
            product.BrandID = pro.BrandID;
            product.Active = pro.Active;

            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
           
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);

        }
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}