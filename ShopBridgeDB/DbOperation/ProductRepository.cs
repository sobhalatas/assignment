using ShopBridgeModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeDB.DbOperation
{
    public class ProductRepository
    {
        public int AddProduct(ProductModel model)
        {
            using (var context = new SHOP_BRIDGEEntities())
            {



                Product_tbl prd = new Product_tbl()
                {
                    Product_Name = model.Product_Name,
                    Product_Categories = model.Product_Categories,
                    Price = model.Price,
                    Product_Discription = model.Product_Discription,
                    Product_MFG_Date = model.Product_MFG_Date,

                };

                context.Product_tbl.Add(prd);

                context.SaveChanges();

                return prd.Product_Id;
            }
        }

        //Get Product

        public IEnumerable<ProductModel> GetAllProduct()
        {
            using (var context = new SHOP_BRIDGEEntities())
            {
                var result = context.Product_tbl.Select(model => new ProductModel()
                {
                    Product_Id = model.Product_Id,
                    Product_Name = model.Product_Name,
                    Product_Categories = model.Product_Categories,
                    Price = model.Price,
                    Product_Discription = model.Product_Discription,
                    Product_MFG_Date = model.Product_MFG_Date
                }).ToList();



                return result;
            }
        }


        public ProductModel GetProductById(int ProductId)
        {
            using (var context = new SHOP_BRIDGEEntities())
            {
                var result = context.Product_tbl.Where(model => model.Product_Id == ProductId).Select(model => new ProductModel()
                {
                    Product_Id = model.Product_Id,
                    Product_Name = model.Product_Name,
                    Product_Categories = model.Product_Categories,
                    Price = model.Price,
                    Product_Discription = model.Product_Discription,
                    Product_MFG_Date = model.Product_MFG_Date
                }).FirstOrDefault();

                return result;
            }
        }


        public void DeleteProduct(int ProductId)
        {
            using (var context = new SHOP_BRIDGEEntities())
            {
                // var product = context.Product_tbl.Where(model => model.Product_Id == ProductId).FirstOrDefault();

                var prd = new Product_tbl()
                {
                    Product_Id = ProductId
                };
                context.Entry(prd).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


        //public void UpdateProduct(int ProductId,ProductModel model)
        //{
        //    using (var context = new SHOP_BRIDGEEntities())
        //    {
        //        var product = new Product_tbl();

        //        if (product != null)
        //        {
        //            product.Product_Id = model.Product_Id;
        //            product.Product_Categories = model.Product_Categories;
        //            product.Product_Name = model.Product_Name;
        //            product.Product_Discription = model.Product_Discription;
        //            product.Price = model.Price;
        //            product.Product_MFG_Date = model.Product_MFG_Date;

        //        }

        //        context.Entry(product).State = EntityState.Modified;
        //        context.SaveChanges();
        //       // return true;

        //    }

        //}


        public bool UpdateProduct(int Product_Id, ProductModel prd)
        {
            using (var context = new SHOP_BRIDGEEntities())
            {

               var product = context.Product_tbl.Where(x => x.Product_Id == Product_Id).FirstOrDefault();
               // var product = new Product_tbl();

                if (product != null)
                {
                    product.Product_Id = prd.Product_Id;
                    product.Product_Categories = prd.Product_Categories;
                    product.Product_Name = prd.Product_Name;
                    product.Product_Discription = prd.Product_Discription;
                    product.Price = prd.Price;
                    product.Product_MFG_Date = prd.Product_MFG_Date;



                }

                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                 return true;

            }

        }

        //public bool UpdateProductTbl( ProductModel prd)
        //{
        //    using (var context = new SHOP_BRIDGEEntities())
        //    {

        //          var product = context.Product_tbl.Where(x => x.Product_Id == prd.Product_Id).FirstOrDefault();

               
        //           // product.Product_Id = prd.Product_Id;
        //            product.Product_Categories = prd.Product_Categories;
        //            product.Product_Name = prd.Product_Name;
        //            product.Product_Discription = prd.Product_Discription;
        //            product.Price = prd.Price;
        //            product.Product_MFG_Date = prd.Product_MFG_Date;

        //        context.SaveChanges();
        //        // context.Entry(product).State = EntityState.Modified;
        //        return true;


        //    }



        //}





    }



}


