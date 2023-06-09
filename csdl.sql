USE [DBWebNhaHang]
GO
/****** Object:  Table [dbo].[BookingFoods]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingFoods](
	[BookingFoodId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[FoodId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BookingFoods] PRIMARY KEY CLUSTERED 
(
	[BookingFoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[Date] [nvarchar](max) NULL,
	[Time] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[NumberPeople] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Branches] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[FoodId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[TypeFoodId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Foods] PRIMARY KEY CLUSTERED 
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](max) NULL,
	[FoodId] [int] NOT NULL,
	[Session] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Menus] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Created_at] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[FoodId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[Amount] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[IsPayment] [int] NOT NULL,
	[Created_at] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeFoods]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeFoods](
	[TypeFoodId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TypeFoods] PRIMARY KEY CLUSTERED 
(
	[TypeFoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/7/2023 6:30:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[Phone] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingFoods] ON 

INSERT [dbo].[BookingFoods] ([BookingFoodId], [BookingId], [FoodId]) VALUES (1, 1, 2)
INSERT [dbo].[BookingFoods] ([BookingFoodId], [BookingId], [FoodId]) VALUES (2, 1, 1)
INSERT [dbo].[BookingFoods] ([BookingFoodId], [BookingId], [FoodId]) VALUES (4, 3, 1)
SET IDENTITY_INSERT [dbo].[BookingFoods] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([BookingId], [UserID], [BranchId], [Date], [Time], [Note], [NumberPeople], [Status], [FullName], [Phone], [Email]) VALUES (1, 8, 1, N'5/7/2023 5:00:30 PM', N'19:00', N'Không có', 4, 0, N'Lê Văn A', N'0394073645', N'nguyencaonguyen@gmail.com')
INSERT [dbo].[Bookings] ([BookingId], [UserID], [BranchId], [Date], [Time], [Note], [NumberPeople], [Status], [FullName], [Phone], [Email]) VALUES (3, 8, 1, N'5/7/2023 6:08:17 PM', N'21:08', N'ok', 4, 0, N'Lê Văn A', N'0394073645', N'nguyencaonguyen@gmail.com')
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([BranchId], [Name], [Address]) VALUES (1, N'Thành phố Sài Gòn', N'18 Trần Hưng Đạo')
INSERT [dbo].[Branches] ([BranchId], [Name], [Address]) VALUES (2, N'Thành phố Đà Nẵng', N'436 Điện Biên Phủ')
INSERT [dbo].[Branches] ([BranchId], [Name], [Address]) VALUES (3, N'Thành phố Hà Nội', N'225 Trường Chinh')
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 

INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (1, N'Lagu Bò', 500000, N'638190706040708931lagu-bo.jpg', N'Thịt bò là một trong những loại thực phẩm chứa nhiều dưỡng chất tốt cho sức khỏe. Trong đó, phải kể đến nguồn Protein rất dồi dào. Điểm đặc biệt của Protein trong thịt bò đó là nó chứa nhiều Acid Amin, Acid gốc Nitro, giúp biến Protein trong thức ăn thành đường hữu cơ để cung cấp cho các hoạt động hàng ngày.

Ngoài ra, thịt bò còn chứa Acid Linoleic và Palmiotelic chống lại ung thư và các mầm bệnh khác. Khi thịt bò kết hợp cùng các nguyên liệu rau củ và được tẩm ướp gia vị trong món lagu bò sẽ trở nên càng thơm ngon và hấp dẫn hơn.', 1, 2)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (2, N'Tôm xào miến', 400000, N'638190705937168787cooky-recipe-cover-r51153.jpg', N'Tôm xào miến Hồng Kông là món ăn được nhiều người yêu thích bởi vị tươi giòn của rau củ, từng sợi miến mềm dai hoà quyện cùng với vị ngọt của tôm. Đây sẽ là một món ngon hấp dẫn mà lại dễ làm, ngay cả khi bạn có rất ít thời gian chuẩn bị. Các chị em hãy tham khảo cách làm miến xào tôm thịt sau của Vedan để thay đổi những bữa cơm cho gia đình mình.', 1, 2)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (3, N'Gà hấp', 600000, N'6381907058521668281-1200x676-64.jpg', N'Ngon', 1, 2)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (4, N'Ghẹ rang muối', 300000, N'638190705372984801cuagherangmuoi-9246.jpg', N'Ngon', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (5, N'Sườn non chiên', 200000, N'638190705217644269c.jpg', N'Ngon', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (6, N'Cá hồi nướng', 700000, N'638190704893759605Ca-hoi-sot-TERIYAKI-Dashilab.jpg', N'Cá hồi nướng ngon', 1, 1)
SET IDENTITY_INSERT [dbo].[Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 

INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (4, N'24-4-2023', 1, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (5, N'24-4-2023', 2, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (6, N'24-4-2023', 3, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (7, N'24-4-2023', 4, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (8, N'24-4-2023', 5, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (9, N'24-4-2023', 6, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (10, N'24-4-2023', 4, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (11, N'24-4-2023', 5, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (12, N'24-4-2023', 1, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (13, N'24-4-2023', 2, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (14, N'24-4-2023', 3, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (15, N'24-4-2023', 6, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (16, N'24-4-2023', 3, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (17, N'24-4-2023', 6, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (18, N'24-4-2023', 5, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (19, N'24-4-2023', 1, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (20, N'24-4-2023', 4, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (21, N'24-4-2023', 2, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (22, N'25-4-2023', 1, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (23, N'25-4-2023', 2, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (24, N'25-4-2023', 3, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (25, N'25-4-2023', 4, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (26, N'25-4-2023', 5, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (27, N'25-4-2023', 6, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (28, N'25-4-2023', 4, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (29, N'25-4-2023', 5, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (30, N'25-4-2023', 1, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (31, N'25-4-2023', 2, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (32, N'25-4-2023', 3, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (33, N'25-4-2023', 6, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (34, N'25-4-2023', 3, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (35, N'25-4-2023', 6, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (36, N'25-4-2023', 5, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (37, N'25-4-2023', 1, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (38, N'25-4-2023', 4, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (39, N'25-4-2023', 2, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (41, N'7-5-2023', 5, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (42, N'7-5-2023', 2, N'Tối')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (43, N'7-5-2023', 6, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (44, N'7-5-2023', 4, N'Sáng')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (45, N'7-5-2023', 3, N'Trưa')
INSERT [dbo].[Menus] ([MenuId], [Date], [FoodId], [Session]) VALUES (46, N'7-5-2023', 1, N'Tối')
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsId], [Title], [Image], [Content], [Created_at]) VALUES (1, N'TRẢI NGHIỆM MIỄN PHÍ', N'638190723941709621menu-online.jpg', N'<p>Việt Nam đang trở th&agrave;nh điểm đến của những đầu bếp Michelin nổi danh thế giới, tạo nền tảng đưa những thương hiệu ẩm thực trong nước vươn tầm thế giới.</p>

<p><strong>Những trải nghiệm hạng sang</strong></p>

<p>Năm 2019, nhiều thực kh&aacute;ch tới nh&agrave; h&agrave;ng Pink Pearl tại JW Marriott Phu Quoc Emerald Bay c&oacute; cơ hội thưởng thức thực đơn cao cấp của đầu bếp 2 sao Michelin Oph&eacute;lie Bares. Những măng t&acirc;y trắng Landes, trứng c&aacute; Oscietre, nhum biển Nhật Bản, b&ograve; Wagyu cao cấp xuất hiện ở đ&acirc;y thậm ch&iacute; c&ograve;n hơn nhiều nh&agrave; h&agrave;ng cao cấp ở nước Ph&aacute;p.</p>

<p>Th&aacute;ng 9/2022, đầu bếp nổi tiếng - đại sứ ẩm thực Ukraina Kovryzhenko Yurii cũng mang tới H&agrave; Nội hương vị trứ danh từ &quot;giỏ b&aacute;nh m&igrave; ch&acirc;u &Acirc;u&quot;, trong đ&oacute; c&oacute; borsch, m&oacute;n s&uacute;p củ cải mới được UNESCO c&ocirc;ng nhận &quot;di sản văn h&oacute;a thế giới&quot;. Địa điểm m&agrave; vị đầu bếp n&agrave;y lựa chọn l&agrave; tại một nh&agrave; h&agrave;ng sang trọng thuộc kh&aacute;ch sạn Capella Hanoi.</p>

<p><img alt="Đầu bếp Yurii chuẩn bị những món ăn hấp dẫn nhất phục vụ thực khách tại tại Capella Hanoi. Ảnh: Sun Group" src="https://i1-dulich.vnecdn.net/2023/02/01/Image-630036379-ExtractWord-1-2311-9402-1675239280.png?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=gM2pIScZHS1F77m1E38SiA" /></p>

<p>Đầu bếp Yurii chuẩn bị những m&oacute;n ăn hấp dẫn nhất phục vụ thực kh&aacute;ch tại tại Capella Hanoi. Ảnh:&nbsp;<em>Sun Group</em></p>

<p>Cũng tại Capella, khi Sun Hospitality Group - thương hiệu du lịch nghỉ dưỡng của Tập đo&agrave;n Sun Group - khai trương nh&agrave; h&agrave;ng Koki cuối th&aacute;ng 7/2022, thực kh&aacute;ch lại c&oacute; dịp thưởng thức t&agrave;i nghệ của Junichi Yoshida - đầu bếp hạng sao Michelin với phong c&aacute;ch ẩm thực Teppanyaki độc đ&aacute;o.</p>
', N'4/18/2023')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [FoodId], [Quantity]) VALUES (1, 1, 6, 2)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [FoodId], [Quantity]) VALUES (2, 2, 4, 3)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [FoodId], [Quantity]) VALUES (3, 2, 5, 2)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UserId], [PhoneNumber], [Address], [Note], [Amount], [Status], [IsPayment], [Created_at], [Name]) VALUES (1, 8, N'0394073645', N'18 Trần Hưng Đạo', N'Ship trong giờ hành chính', 1400000, 3, 1, N'5/7/2023 5:10:00 PM', N'Lê Văn A')
INSERT [dbo].[Orders] ([OrderId], [UserId], [PhoneNumber], [Address], [Note], [Amount], [Status], [IsPayment], [Created_at], [Name]) VALUES (2, 8, N'0394073645', N'436 Điện Biên Phủ', N'Ok', 1300000, 3, 1, N'5/7/2023 6:06:35 PM', N'Lê Văn A')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (2, N'Nhân viên')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (3, N'Khách hàng')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeFoods] ON 

INSERT [dbo].[TypeFoods] ([TypeFoodId], [Name]) VALUES (1, N'Món mang đi')
INSERT [dbo].[TypeFoods] ([TypeFoodId], [Name]) VALUES (2, N'Món ăn tại bàn')
SET IDENTITY_INSERT [dbo].[TypeFoods] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Fullname], [Name], [Password], [Email], [Gender], [Phone], [Address], [Status], [RoleId]) VALUES (3, N'Nhân VIên', N'nhanvien', N'e1adc3949ba59abbe56e057f2f883e', N'nhanvien@gmail.com', 1, 394073645, N'Hà Nội', 1, 2)
INSERT [dbo].[Users] ([UserId], [Fullname], [Name], [Password], [Email], [Gender], [Phone], [Address], [Status], [RoleId]) VALUES (5, N'Quản trị viên', N'admin', N'e1adc3949ba59abbe56e057f2f883e', N'admin@gmail.com', 1, 394073645, N'Hà Nội', 1, 1)
INSERT [dbo].[Users] ([UserId], [Fullname], [Name], [Password], [Email], [Gender], [Phone], [Address], [Status], [RoleId]) VALUES (8, N'Lê Văn A', N'levana', N'e1adc3949ba59abbe56e057f2f883e', N'nguyencaonguyen@gmail.com', 1, 394073645, N'Hà Nội', 1, 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[BookingFoods]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BookingFoods_dbo.Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([BookingId])
GO
ALTER TABLE [dbo].[BookingFoods] CHECK CONSTRAINT [FK_dbo.BookingFoods_dbo.Bookings_BookingId]
GO
ALTER TABLE [dbo].[BookingFoods]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BookingFoods_dbo.Foods_FoodId] FOREIGN KEY([FoodId])
REFERENCES [dbo].[Foods] ([FoodId])
GO
ALTER TABLE [dbo].[BookingFoods] CHECK CONSTRAINT [FK_dbo.BookingFoods_dbo.Foods_FoodId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Bookings_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([BranchId])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo.Bookings_dbo.Branches_BranchId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Bookings_dbo.Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo.Bookings_dbo.Users_UserID]
GO
ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Foods_dbo.TypeFoods_TypeFoodId] FOREIGN KEY([TypeFoodId])
REFERENCES [dbo].[TypeFoods] ([TypeFoodId])
GO
ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_dbo.Foods_dbo.TypeFoods_TypeFoodId]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Menus_dbo.Foods_FoodId] FOREIGN KEY([FoodId])
REFERENCES [dbo].[Foods] ([FoodId])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_dbo.Menus_dbo.Foods_FoodId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Foods_FoodId] FOREIGN KEY([FoodId])
REFERENCES [dbo].[Foods] ([FoodId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Foods_FoodId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId]
GO
