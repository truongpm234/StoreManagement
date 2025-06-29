USE [MyStore]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 24-Jun-25 3:23:28 PM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [SQLArcExtensionUserRole]    Script Date: 24-Jun-25 3:23:28 PM ******/
CREATE ROLE [SQLArcExtensionUserRole]
GO
ALTER ROLE [SQLArcExtensionUserRole] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[AccountMember]    Script Date: 24-Jun-25 3:23:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountMember](
	[MemberID] [nvarchar](20) NOT NULL,
	[MemberPassword] [nvarchar](80) NOT NULL,
	[FullName] [nvarchar](80) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[MemberRole] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 24-Jun-25 3:23:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24-Jun-25 3:23:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitPrice] [money] NULL,
	[ProductName] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AccountMember] ([MemberID], [MemberPassword], [FullName], [EmailAddress], [MemberRole]) VALUES (N'admin01', N'pass123', N'Nguyen Van A', N'admin.a@example.com', 1)
INSERT [dbo].[AccountMember] ([MemberID], [MemberPassword], [FullName], [EmailAddress], [MemberRole]) VALUES (N'user001', N'userpass', N'Tran Thi B', N'user.b@example.com', 2)
INSERT [dbo].[AccountMember] ([MemberID], [MemberPassword], [FullName], [EmailAddress], [MemberRole]) VALUES (N'user002', N'securepwd', N'Le Van C', N'user.c@example.com', 2)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Electronics')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Books')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Clothing')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Home Goods')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (101, 1, 50, 699.9900, N'Smartphone X')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (102, 1, 25, 1200.0000, N'Laptop Pro')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (201, 2, 100, 15.5000, N'The Great Novel')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (202, 2, 75, 29.9900, N'Learn SQL Basics')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (301, 3, 200, 19.9900, N'T-Shirt Cotton')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (302, 3, 150, 49.9900, N'Jeans Slim Fit')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (401, 4, 30, 75.0000, N'Coffee Maker')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (402, 4, 40, 99.0000, N'Blender X200')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (403, 2, 2, 1999.0000, N'Smartphone Xr 256GB')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (405, 1, 2, 1299.0000, N'VivoBook')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (407, 1, 1, 1399.0000, N'Smartphone Vivo X200 Pro Mini')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (408, 1, 12, 1111.0000, N'Smartphone Xrs')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [UnitsInStock], [UnitPrice], [ProductName]) VALUES (409, 1, 1, 2999.0000, N'Smartphone 16 Pro Max')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
