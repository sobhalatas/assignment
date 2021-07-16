using ShopBridgeDB;
using ShopBridgeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ShopBridgeWebApp.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume
        HttpClient hc = new HttpClient();


        [HttpGet]
        public ActionResult GetAllProduct()
        {
            List<ProductModel> prdlist = new List<ProductModel>();
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/GetAllProduct");
            var consume = hc.GetAsync("GetAllProduct");
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<ProductModel>>();
                prdlist = display.Result;
            }

            return View(prdlist);
        }



        public ActionResult GetProduct(int ProductId)
        {
            ProductModel model = new ProductModel();
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/GetProduct");
            var consume = hc.GetAsync("GetProduct?ProductId=" + ProductId.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductModel>();
                display.Wait();
                model = display.Result;
            }

            return View(model);
        }



        public ActionResult AddNewProduct()
        {
            return View();
        }

        public ActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(ProductModel model)
        {
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/AddNewProduct");
            var consume = hc.PostAsJsonAsync("AddNewProduct", model);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProduct");
            }
            else
            {
                return HttpNotFound();
            }
        }


        public ActionResult DeleteProduct(int ProductId)
        {
            ProductModel model = new ProductModel();
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/GetProduct");
            var consume = hc.GetAsync("DeleteProduct?ProductId=" + ProductId.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductModel>();
                display.Wait();
                model = display.Result;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int ProductId,ProductModel model)
        {
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/DeleteProduct");
            var consume = hc.DeleteAsync("DeleteProduct?ProductId=" + ProductId.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                // ViewBag.IsSuccess = "<script>alert('Data Deleted Successfully')</script>";
                 return RedirectToAction("GetAllProduct");

            }
           
                return View();
            
        }
        [HttpGet]

        public ActionResult UpdateProduct(int ProductId)
        {
            ProductModel model = new ProductModel();
           // Product_tbl model = new Product_tbl();
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/GetProduct");
            var consume = hc.GetAsync("UpdateProduct1?ProductId=" + ProductId.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
               // var display = test.Content.ReadAsAsync<ProductModel>();
                var display = test.Content.ReadAsAsync<ProductModel>();

                display.Wait();
                model = display.Result;
            }

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult UpdateProduct(ProductModel prd,int productid)
        {
        
            hc.BaseAddress = new Uri("http://localhost:49304/Api/Provider/UpdateProduct1");
           // var consume1 = hc.PutAsync("UpdateProduct1?ProductId=" + productid.ToString(),prd);
           // var consume1 = hc.PutAsJsonAsync("UpdateProduct1?ProductId=" + productid.ToString(), prd);
            var consume1 = hc.PutAsJsonAsync("UpdateProduct", prd);
            consume1.Wait();
            var test1 = consume1.Result;
            if (test1.IsSuccessStatusCode)
            {
                // ViewBag.IsSuccess = "<script>alert('Data Deleted Successfully')</script>";
                var display = test1.Content.ReadAsAsync<ProductModel>();
                display.Wait();
                prd = display.Result;
                return RedirectToAction("GetAllProduct");

            }

            return View();

        }




    }
}