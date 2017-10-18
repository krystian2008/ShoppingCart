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

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {
            MVCGridDefinitionTable.Add("ProductsMVCGrid", new MVCGridBuilder<ProductItemModel>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add().WithColumnName("Identifier")
                        .WithSorting(true)
                        .WithHeaderText("Identifier")
                        .WithValueExpression(i => i.Id.ToString())
                        .WithVisibility(false);
                    cols.Add().WithColumnName("Name")
                        .WithSorting(true)
                        .WithFiltering(true)
                        .WithHeaderText("Name")
                        .WithValueExpression(i => i.Name);
                    cols.Add().WithColumnName("Description")
                        .WithSorting(true)
                        .WithFiltering(true)
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);
                    cols.Add().WithColumnName("Price")
                        .WithSorting(true)
                        .WithFiltering(true)
                        .WithHeaderText("Price")
                        .WithValueExpression(i => i.Price.ToString());
                    cols.Add().WithColumnName("Stock")
                        .WithSorting(true)
                        .WithFiltering(true)
                        .WithHeaderText("Stock")
                        .WithValueExpression(i => i.Stock.ToString());
                    cols.Add("Edit").WithHtmlEncoding(false)
                    .WithSorting(false)
                    .WithHeaderText(" ")
                    .WithValueExpression((p, c) => c.UrlHelper.Action("AddToCart", "Products", new { productId = p.Id }))
                    .WithValueTemplate("<a href='{Value}' class='btn btn-primary' role='button'>Add To Cart</a>");
                })
                .WithSorting(true, "Name", SortDirection.Asc)
                .WithPaging(true, 10, true, 100)
                .WithFiltering(true)
                .WithAdditionalQueryOptionNames("filterName", "filterDesc")
                .WithRetrieveDataMethod((context) =>
                {
                    var service = new ProductsService();
                    var result = service.GetProducts();
                    var options = context.QueryOptions;
                    var query = result.Items.AsQueryable();
                    var name = options.GetAdditionalQueryOptionString("filterName");
                    var desc = options.GetAdditionalQueryOptionString("filterDesc");

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                    }

                    if (!string.IsNullOrWhiteSpace(desc))
                    {
                        query = query.Where(x => x.Description.ToLower().Contains(desc.ToLower()));
                    }

                    if (!string.IsNullOrWhiteSpace(options.SortColumnName))
                    {
                        switch (options.SortColumnName.ToLower())
                        {
                            case "identifier":
                                if (options.SortDirection == SortDirection.Asc)
                                    query = query.OrderBy(p => p.Id);
                                else
                                    query = query.OrderByDescending(p => p.Id);
                                break;
                            case "name":
                                if (options.SortDirection == SortDirection.Asc)
                                    query = query.OrderBy(p => p.Name);
                                else
                                    query = query.OrderByDescending(p => p.Name);
                                break;
                            case "description":
                                if (options.SortDirection == SortDirection.Asc)
                                    query = query.OrderBy(p => p.Description);
                                else
                                    query = query.OrderByDescending(p => p.Description);
                                break;
                            case "price":
                                if (options.SortDirection == SortDirection.Asc)
                                    query = query.OrderBy(p => p.Price);
                                else
                                    query = query.OrderByDescending(p => p.Price); 
                                break;
                            case "stock":
                                if (options.SortDirection == SortDirection.Asc)
                                    query = query.OrderBy(p => p.Stock);
                                else
                                    query = query.OrderByDescending(p => p.Stock);
                                break;
                        }
                    }

                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }

                    return new QueryResult<ProductItemModel>()
                    {
                        Items = query.ToList(),
                        TotalRecords = query.Count()
                    };
                })
            );
        }
    }
}