using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL
{
    public class ResultWrapper<T> where T : class
    {
        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public List<T> Items { get; set; }

        public ResultWrapper()
        {
            ErrorCode = 200;
            ErrorMessage = string.Empty;
            Items = new List<T>();
        }        

        public void SetErrorMessage(string message, int code = 200)
        {
            this.ErrorMessage = message;
            this.ErrorCode = code;
        }
    }
}
