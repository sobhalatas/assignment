using ShopBridgeDB.DbOperation;
using ShopBridgeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridgeWebApp.Controllers
{
    public class ProviderController : ApiController
    {
        ProductRepository repository = null;

        public ProviderController()
        {
            repository = new ProductRepository();
        }


        [HttpGet]
        public IHttpActionResult GetAllProduct()
        {
            var result = repository.GetAllProduct();

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetProduct(int ProductId)
        {
            ProductModel result = repository.GetProductById(ProductId);
            return Ok(result);
        }



        [HttpPost]
        public IHttpActionResult AddNewProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddProduct(model);
                if (id > 0)
                {
                    ModelState.Clear();
                }
            }
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult DeleteProduct(int ProductId)
        {
            repository.DeleteProduct(ProductId);

            return Ok();
        }


        //[HttpGet]
        //public IHttpActionResult UpdateProduct(int ProductId)
        //{
        //    ProductModel result = repository.GetProductById(ProductId);
        //    return Ok(result);
        //}



        [HttpPost]
        public IHttpActionResult UpdateProduct1(ProductModel prd)
        {
            repository.UpdateProduct(prd.Product_Id, prd);
            return Ok();
        }

        //[HttpPut]
        //public IHttpActionResult UpdateProduct1(ProductModel prd)
        //{
        //    repository.UpdateProductTbl(prd);
        //    return Ok();
        //}

        //[HttpPut]
        //public IHttpActionResult UpdateProduct(int ProductId)
        //{
        //  var prd=  repository.GetProductById(ProductId);
        //    return Ok(prd);
        //}

    }
}
