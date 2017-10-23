# ShoppingCart

ShoppingCart is three layer application:
- ShoppingCart.DAL - Data Access Layer
- ShoppingCart.BLL - Business Logic Layer
- ShoppingCart.Web - Web Application in ASP.NET MVC

Assumptions:
The main view presents products with filtering and sorting capabilities and also we can use direct link to Swagger UI (only local use).
Button <Add To Cart> in gridview column is for future use (at this moment redirects to view with products).

At this moment all data are stored in database ShoppingCartDB. 
The database has three tables stores with some rows of data:
- Products - contains four products from file products.cs
- ShoppingsCarts - contains two shopping carts named: "cartname_01", "cartname_02"
- CartItems - contains two products for shopping cart "cartname_01"

All business operations was implemented by proper services in BLL.
The DAL was build from the database ShoppingCartDB and reverse engineering  to generate the classes (entities) and its mapping.

Used components:
- EntityFramework
- AutoMapper
- log4net
- Ninject
- Swagger
- MVCGrid

TODO:
- Search suggestions for filtering
- Get, clear the content of existing shopping cart
- Implement button <Add To Cart>
- Authorization