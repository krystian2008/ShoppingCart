using ShoppingCart.DAL.EntityModels;
using ShoppingCart.DAL.Interfaces;
using System;

namespace ShoppingCart.DAL
{
    public class CartsRepository : RepositoryBase<CartEntity>, ICartsRepository
    {
        public CartsRepository()
        {
        }
    }
}
