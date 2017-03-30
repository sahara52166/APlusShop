using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.products.OrderByDescending(p=>p.ProductID).Take(3).ToList());
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration objreg)
        {
            db.registrations.Add(objreg);
            db.SaveChanges();
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public ActionResult Shop_List()
        {
            ProductList objlist = new ProductList()
            {
                products = db.products.ToList(),
                details = db.details.ToList()
            };
            return View(objlist);
        }
        [HttpGet]
        public ActionResult AddNewProduct()
        {
            ViewBag.category = new SelectList(db.categories, "CategoryID", "CategoryName");
            return View();

        }
        [HttpPost]
        public ActionResult AddNewProduct(ProductList Vm,HttpPostedFileBase Image)
        {
            ViewBag.category = new SelectList(db.categories, "CategoryID", "CategoryName");

            Product product = new Product();
            product.CategoryID = Vm.CategoryID;
            product.ProdctName = Vm.ProdctName;
            product.Price = Vm.Price;
            if (Image != null)
            {

                string ImageName = System.IO.Path.GetFileName(Image.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);

                // save image in folder
                Image.SaveAs(physicalPath);
                product.Image = ImageName;
            }
            db.products.Add(product);
            db.SaveChanges();
            Detail prodetail = new Detail()
            {
                ProductID = product.ProductID,
                Quantity = Vm.Quantity,
                model = Vm.model,
                Feature = Vm.Feature,
                detail = Vm.detail,
                
                
        };
           


                db.details.Add(prodetail);
            db.SaveChanges();
            return View(Vm);
        }
        
        public ActionResult ProductView(int? ProID)
        {

            Product objproduct = new Product();

            Detail objdetail = new Detail();
            objdetail = db.details.Single(x => x.ProductID == ProID);
            objproduct = db.products.Find(ProID);
            
            ProductList objprolist = new ProductList()
            {
                CategoryName = objproduct.category.CategoryName,
                detail=objdetail.detail,
                Feature = objdetail.Feature,
                Image = objproduct.Image,
                model = objdetail.model,
                Price=objproduct.Price,
                ProdctName=objproduct.ProdctName,
                Quantity = objdetail.Quantity,
            };
          objprolist.products = db.products.Where(x => x.category.CategoryName == objproduct.category.CategoryName && x.ProductID != ProID).ToList();

            return View(objprolist);
        }
        //public ActionResult PartialPart(int? ProID)
        //{
        //    ProductList  list= new ProductList();
        //    list.products = 
        //    return PartialView(list);
        //}
    }
}