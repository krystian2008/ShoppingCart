using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Models;
using ShoppingCart.DAL;
using ShoppingCart.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL
{
    public class ProductsService : ServiceBase<IProductService>, IProductService
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

        public ResultWrapper<ProductItemModel> GetProducts()
        {
            //TODO: get data from _productsRepository not from StoreDBSingleton

            var result = new ResultWrapper<ProductItemModel>();
            result.Items = StoreDBSingleton.Instance.ProductItems;

            return result;
        }
    }
}
