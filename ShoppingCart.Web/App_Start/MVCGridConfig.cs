[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ShoppingCart.Web.MVCGridConfig), "RegisterGrids")]

namespace ShoppingCart.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using ShoppingCart.BLL.Models;
    using ShoppingCart.BLL;
    using ShoppingCart.BLL.Interfaces;
    using ShoppingCart.Web.Grids;

    /// <summary>
    /// Class responsible for grid config
    /// </summary>
    public static class MVCGridConfig 
    {
        /// <summary>
        /// Register grid to view products
        /// </summary>
        public static void RegisterGrids()
        {
            MVCGridProductsConfig.RegisterGrid(GetGridDefaults(), GetColDefauls());
        }

        private static GridDefaults GetGridDefaults()
        {
            GridDefaults gridDefaults = new GridDefaults()
            {
                Paging = true,
                ItemsPerPage = 10,
                Sorting = true,
            };

            return gridDefaults;
        }

        private static ColumnDefaults GetColDefauls()
        {
            ColumnDefaults colDefauls = new ColumnDefaults()
            {
                EnableSorting = true,
                AllowChangeVisibility = false,
            };

            return colDefauls;
        }
    }
}