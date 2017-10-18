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

        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public List<T> Items { get; set; }

        public void SetErrorMessage(string message, int code = 0)
        {
            ErrorMessage = message;
            ErrorCode = code;
        }
    }
}
