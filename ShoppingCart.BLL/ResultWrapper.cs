using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL
{
    /// <summary>
    /// Class stores information about the result of a query from services
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultWrapper<T> where T : class
    {
        public int Code { get; private set; }
        public string Message { get; private set; }
        public List<T> Items { get; set; }

        public ResultWrapper()
        {
            Code = 200;
            Message = string.Empty;
            Items = new List<T>();
        }

        public void SetResult(string message, int code = 200)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
