# ShoppingCart

ShoppingCart is three layer application:
- ShoppingCart.DAL - Data Access Layer
- ShoppingCart.BLL - Business Logic Layer
- ShoppingCart.Web - Web Application in ASP.NET MVC

Assumptions:
The main view presents products with filtering and sorting capabilities and also we can use direct link to Swagger UI.
Button <Add To Cart> in grid column is not implemented (redirects to main view).

At this moment all data are stored in class ShoppingCart.BLL.StoreDBSingleton. Any CRUD operation is also done on this class.
During start the web application (http://localhost:53142/) there are filled two products to cart named "cartname_01" and also products from file "products.csv".
All business operations was implemented by proper services in BLL.

Used components:
- log4net
- Ninject
- Swagger
- MVCGrid

TODO:
- add database project to solution (tables, views, relations,...)
- use ORM - EntityFramework (ex. database first to create objects to use in ShoppingCart.DAL to store data and also fill model objects in ShoppingCart.BLL)
- implement get data to services from ShoppingCart.DAL (also mapping data from db to proper models)
- implement CRUD operations and missing business logic using proper repositories for products, carts,... .
- opisać przyszłe wykorzystanie repositorium