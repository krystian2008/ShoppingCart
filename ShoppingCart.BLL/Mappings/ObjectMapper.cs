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
        public static D SimpleMap<S, D>(S source) where S : class where D : class
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<S, D>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<S, D>(source);
        }

        public static CartItemModel MapCart(CartItem source)
        {
            var dest = ObjectMapper.SimpleMap<CartItem, CartItemModel>(source);
            dest.UnitPrice = source.Product.Price;

            return dest;
        }
    }
}
