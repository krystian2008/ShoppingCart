using ShoppingCart.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.BLL.Models;
using ShoppingCart.DAL.Interfaces;
using ShoppingCart.DAL.EntityModels;
using ShoppingCart.DAL;
using AutoMapper;
using ShoppingCart.BLL.Mappings;

namespace ShoppingCart.BLL
{
    /// <summary>
    /// Service class for Products <see cref="ProductItemModel"/>
    /// </summary>
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _repoProd;

        public ProductsService()
        {
            _repoProd = new Repository<Product>();
        }

        public ResultWrapper<ProductItemModel> GetProducts(int id = 0)
        {
            var result = new ResultWrapper<ProductItemModel>();

            var products = (id == 0) ? _repoProd.GetAll() : _repoProd.GetAll().Where(x => x.Id == id);
            products.ToList().ForEach(x => result.Items.Add(ObjectMapper.SimpleMap<Product, ProductItemModel>(x)));

            result.SetResultMessage(string.Empty, result.Items.Count > 0 ? 200 : 0);

            return result;
        }
    }
}
