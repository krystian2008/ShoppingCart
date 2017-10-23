using AutoMapper;
using ShoppingCart.BLL.Models;
using ShoppingCart.DAL.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.Mappings
{
    /// <summary>
    /// Helper class to map entity do model
    /// </summary>
    public static class ObjectMapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Product, ProductItemModel>();
                cfg.CreateMap<CartItem, CartItemModel>().ForMember(d => d.UnitPrice, opt => opt.MapFrom(s => s.Product.Price));
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static CartItemModel Map(this CartItem source)
        {
            return Mapper.Map<CartItemModel>(source);
        }

        public static ProductItemModel Map(this Product source)
        {
            return Mapper.Map<ProductItemModel>(source);
        }
    }
}
