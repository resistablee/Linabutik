namespace _201224_LinaButikPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        CityID = c.Short(nullable: false),
                        CountryID = c.Short(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        TelephoneNumber = c.String(nullable: false, maxLength: 14),
                        Mail = c.String(nullable: false, maxLength: 100),
                        PostCode = c.String(nullable: false, maxLength: 5),
                        Address = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.CountryID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.CargoInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        CargoCompanyID = c.Short(),
                        TruckNumber = c.String(maxLength: 20),
                        GMT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.Features", t => t.CargoCompanyID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.CustomerID)
                .Index(t => t.AddressID)
                .Index(t => t.CargoCompanyID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        OrderStatusID = c.Short(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piece = c.Short(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CargoID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CargoInfoes", t => t.CargoID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.OrderStatusID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID)
                .Index(t => t.OrderStatusID)
                .Index(t => t.CargoID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PaymentTypeID = c.Short(nullable: false),
                        OrderStatusID = c.Short(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddressID = c.Int(nullable: false),
                        GMT = c.DateTime(nullable: false),
                        Hostname = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.OrderStatusID)
                .ForeignKey("dbo.Features", t => t.PaymentTypeID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.PaymentTypeID)
                .Index(t => t.OrderStatusID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 20),
                        Mail = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 20),
                        TelephoneNumber = c.String(nullable: false, maxLength: 14),
                        DateOfBirth = c.DateTime(nullable: false),
                        GenderID = c.Short(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.GenderID)
                .Index(t => t.GenderID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        CommentTitle = c.String(maxLength: 50),
                        Comment = c.String(maxLength: 250),
                        Point = c.Byte(nullable: false),
                        CommentVisibility = c.Boolean(nullable: false),
                        GMT = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryID = c.Short(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 100),
                        BrandID = c.Int(nullable: false),
                        ColorID = c.Short(nullable: false),
                        SizeID = c.Short(nullable: false),
                        Price = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Stock = c.Int(nullable: false),
                        SaleStatus = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.CategoryID)
                .ForeignKey("dbo.Features", t => t.ColorID)
                .ForeignKey("dbo.Features", t => t.SizeID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID)
                .Index(t => t.ColorID)
                .Index(t => t.SizeID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        URL = c.String(maxLength: 100),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Piece = c.Short(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        FeatureTypeID = c.Int(nullable: false),
                        Property = c.String(maxLength: 50),
                        Des = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeatureTypes", t => t.FeatureTypeID, cascadeDelete: true)
                .Index(t => t.FeatureTypeID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperationTypeID = c.Short(nullable: false),
                        PersonTypeID = c.Short(nullable: false),
                        Person = c.String(maxLength: 50),
                        Hostname = c.String(maxLength: 20),
                        GMT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.OperationTypeID)
                .ForeignKey("dbo.Features", t => t.PersonTypeID)
                .Index(t => t.OperationTypeID)
                .Index(t => t.PersonTypeID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 20),
                        AuthorityID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.AuthorityID, cascadeDelete: true)
                .Index(t => t.AuthorityID);
            
            CreateTable(
                "dbo.FeatureTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        City = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        CityID = c.Short(nullable: false),
                        Country = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.CargoInfoes", "OrderID", "dbo.OrderDetails");
            DropForeignKey("dbo.CargoInfoes", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderStatusID", "dbo.Features");
            DropForeignKey("dbo.Orders", "PaymentTypeID", "dbo.Features");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.Features");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "GenderID", "dbo.Features");
            DropForeignKey("dbo.Products", "SizeID", "dbo.Features");
            DropForeignKey("dbo.Products", "ColorID", "dbo.Features");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Features");
            DropForeignKey("dbo.Features", "FeatureTypeID", "dbo.FeatureTypes");
            DropForeignKey("dbo.Managers", "AuthorityID", "dbo.Features");
            DropForeignKey("dbo.CargoInfoes", "CargoCompanyID", "dbo.Features");
            DropForeignKey("dbo.Operations", "PersonTypeID", "dbo.Features");
            DropForeignKey("dbo.Operations", "OperationTypeID", "dbo.Features");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Baskets", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Baskets", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Favorites", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Favorites", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Comments", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.OrderDetails", "CargoID", "dbo.CargoInfoes");
            DropForeignKey("dbo.CargoInfoes", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Countries", new[] { "CityID" });
            DropIndex("dbo.Managers", new[] { "AuthorityID" });
            DropIndex("dbo.Operations", new[] { "PersonTypeID" });
            DropIndex("dbo.Operations", new[] { "OperationTypeID" });
            DropIndex("dbo.Features", new[] { "FeatureTypeID" });
            DropIndex("dbo.Baskets", new[] { "ProductID" });
            DropIndex("dbo.Baskets", new[] { "CustomerID" });
            DropIndex("dbo.Favorites", new[] { "ProductID" });
            DropIndex("dbo.Favorites", new[] { "CustomerID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "SizeID" });
            DropIndex("dbo.Products", new[] { "ColorID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "CustomerID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropIndex("dbo.Customers", new[] { "GenderID" });
            DropIndex("dbo.Orders", new[] { "AddressID" });
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Orders", new[] { "PaymentTypeID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "CargoID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderStatusID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.CargoInfoes", new[] { "CargoCompanyID" });
            DropIndex("dbo.CargoInfoes", new[] { "AddressID" });
            DropIndex("dbo.CargoInfoes", new[] { "CustomerID" });
            DropIndex("dbo.CargoInfoes", new[] { "OrderID" });
            DropIndex("dbo.Addresses", new[] { "CustomerID" });
            DropIndex("dbo.Addresses", new[] { "CountryID" });
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.FeatureTypes");
            DropTable("dbo.Managers");
            DropTable("dbo.Operations");
            DropTable("dbo.Features");
            DropTable("dbo.Brands");
            DropTable("dbo.Baskets");
            DropTable("dbo.Favorites");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.Comments");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.CargoInfoes");
            DropTable("dbo.Addresses");
        }
    }
}
