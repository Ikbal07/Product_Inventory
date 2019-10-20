SET IDENTITY_INSERT [dbo].[ProductCategory] ON
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (2, N'Electronics', N'Electronic Items ')
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (1002, N'Furniture', N'Furniture Items')
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (1003, N'Toys', N'All kinds of toys')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (1, N'Samsung Smart TV', CAST(800.00 AS Decimal(18, 2)), 2)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (2, N'Teddy Bear', CAST(60.00 AS Decimal(18, 2)), 1003)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (3, N'RC Car ', CAST(80.00 AS Decimal(18, 2)), 1003)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (4, N'LG Washing Machine', CAST(600.00 AS Decimal(18, 2)), 2)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (5, N'Coffee table ', CAST(400.00 AS Decimal(18, 2)), 1002)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Retailer] ON
INSERT INTO [dbo].[Retailer] ([Id], [Name], [ContactNumber]) VALUES (1, N'ABC Electronics Pvt LTD', N'02134567890')
INSERT INTO [dbo].[Retailer] ([Id], [Name], [ContactNumber]) VALUES (2, N'Auckland  Furniture Pvt LTD', N'02134567899')
INSERT INTO [dbo].[Retailer] ([Id], [Name], [ContactNumber]) VALUES (3, N'Toys r us Pvt LTD', N'02134267890')
SET IDENTITY_INSERT [dbo].[Retailer] OFF
SET IDENTITY_INSERT [dbo].[ProductRetailerRegistration] ON
INSERT INTO [dbo].[ProductRetailerRegistration] ([Id], [ProductId], [RetailerId], [DeliveryStatus]) VALUES (1, 1, 1, 1)
INSERT INTO [dbo].[ProductRetailerRegistration] ([Id], [ProductId], [RetailerId], [DeliveryStatus]) VALUES (2, 2, 3, 0)
SET IDENTITY_INSERT [dbo].[ProductRetailerRegistration] OFF
