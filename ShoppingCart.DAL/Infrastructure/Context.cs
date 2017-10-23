using ShoppingCart.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Infrastructure
{
    /// <summary>
    /// Class for storing DbContext
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Context<T> : IContext<T> where T : class
    {
        private const string CONNECTION_STRING_NAME = "ShoppingCartDBEntities";

        public DbContext DbCtx { get; private set; }
        public IDbSet<T> DbSet { get; private set; }

        public Context()
        {
            string cs = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            DbCtx = new DbContext(cs);
            DbSet = DbCtx.Set<T>();
        }

        public void Dispose()
        {
            DbCtx.Dispose();
        }
    }
}
