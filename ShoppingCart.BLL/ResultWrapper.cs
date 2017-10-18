using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL
{
    public class ResultWrapper<T> where T : class
    {
        public ResultWrapper()
        {
            Items = new List<T>();
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<T> Items { get; set; }
    }
}
