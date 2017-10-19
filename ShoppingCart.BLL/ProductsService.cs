using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Models;
using ShoppingCart.DAL;
using ShoppingCart.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCart.BLL
{
    public class ProductsService : ServiceBase<IProductsService>, IProductsService
    {
        private IProductsRepository _productsRepository;

        public ProductsService()
            :this (new ProductsRepository())
        {
        }

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? new ProductsRepository();
        }

        public void Add(ProductItemModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductItemModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductItemModel entity)
        {
            throw new NotImplementedException();
        }

        IList<ProductItemModel> IService<ProductItemModel>.GetAll()
        {           
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all Products by id
        /// </summary>
        /// <param name="id">id = 0 - get all elements</param>
        /// <returns></returns>
        public ResultWrapper<ProductItemModel> GetProducts(int id = 0)
        {
            //TODO: get data from _productsRepository not from StoreDBSingleton

            var result = new ResultWrapper<ProductItemModel>();
            result.Items = (id == 0) ? StoreDBSingleton.Instance.ProductItems : StoreDBSingleton.Instance.ProductItems.FindAll(x => x.Id == id);

            return result;
        }
    }
}
