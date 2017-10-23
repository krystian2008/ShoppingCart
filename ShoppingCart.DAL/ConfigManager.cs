using ShoppingCart.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ShoppingCart.DAL
{
    /// <summary>
    /// Class providing configuration
    /// </summary>
    public static class ConfigManager
    {
        public const string CONNECTION_STRING_NAME = "ShoppingCartDBEntities";

        public static string ConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings != null &&
                    ConfigurationManager.ConnectionStrings.Count > 0 && 
                    ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME] != null)
                {
                    return ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
                }

                return string.Empty;
            }
        }
    }
}
