USE [DBWebNhaHang]
GO
/****** Object:  Table [dbo].[BookingFoods]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[Bookings]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[Branches]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[Foods]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[Menus]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[News]    Script Date: 4/24/2023 8:35:21 AM ******/
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
	[Created_by] [int] NOT NULL,
 CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 4/24/2023 8:35:21 AM ******/
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
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[TypeFoods]    Script Date: 4/24/2023 8:35:21 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 4/24/2023 8:35:21 AM ******/
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
	[Image] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Created_at] [datetime] NOT NULL,
	[Created_by] [int] NOT NULL,
	[Updated_at] [datetime] NOT NULL,
	[Updated_by] [int] NOT NULL,
	[PayTotal] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([BranchId], [Name], [Address]) VALUES (1, N'Thành Phố HcM', N'1')
INSERT [dbo].[Branches] ([BranchId], [Name], [Address]) VALUES (2, N'Thành Phố Đà Nẵng', N'2')
INSERT [dbo].[Branches] ([BranchId], [Name], [Address]) VALUES (3, N'Thành phố Hà Nội', N'3')
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 

INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (1, N'Lagu Bò', 500000, N'https://daotaobeptruong.vn/wp-content/uploads/2020/06/lagu-bo.jpg', N'Thịt bò là một trong những loại thực phẩm chứa nhiều dưỡng chất tốt cho sức khỏe. Trong đó, phải kể đến nguồn Protein rất dồi dào. Điểm đặc biệt của Protein trong thịt bò đó là nó chứa nhiều Acid Amin, Acid gốc Nitro, giúp biến Protein trong thức ăn thành đường hữu cơ để cung cấp cho các hoạt động hàng ngày.

Ngoài ra, thịt bò còn chứa Acid Linoleic và Palmiotelic chống lại ung thư và các mầm bệnh khác. Khi thịt bò kết hợp cùng các nguyên liệu rau củ và được tẩm ướp gia vị trong món lagu bò sẽ trở nên càng thơm ngon và hấp dẫn hơn.', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (2, N'Tôm xào miến', 400000, N'https://image.cooky.vn/recipe/g6/51153/s/cooky-recipe-cover-r51153.jpg', N'Tôm xào miến Hồng Kông là món ăn được nhiều người yêu thích bởi vị tươi giòn của rau củ, từng sợi miến mềm dai hoà quyện cùng với vị ngọt của tôm. Đây sẽ là một món ngon hấp dẫn mà lại dễ làm, ngay cả khi bạn có rất ít thời gian chuẩn bị. Các chị em hãy tham khảo cách làm miến xào tôm thịt sau của Vedan để thay đổi những bữa cơm cho gia đình mình.', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (3, N'Gà hấp', 600000, N'https://cdn.tgdd.vn/2020/12/CookProduct/1-1200x676-64.jpg', N'Ngon', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (4, N'Ghẹ rang muối', 30000, N'https://nhahangthoangviet.vn/upload/product/cuagherangmuoi-9246.jpg', N'Ngon', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (5, N'Sườn non chiên', 200000, N'https://lzd-img-global.slatic.net/g/p/dfab9ef52e4834401f03f61beb6adf08.png_1200x1200q80.png_.webp', N'Ngon', 1, 1)
INSERT [dbo].[Foods] ([FoodId], [Name], [Price], [Image], [Description], [Status], [TypeFoodId]) VALUES (6, N'Cá hồi nướng', 70000, N'https://dashilabvn.com/wp-content/uploads/2019/04/Ca-hoi-sot-TERIYAKI-Dashilab.jpg', N'Ngon', 1, 1)
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
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsId], [Title], [Image], [Content], [Created_at], [Created_by]) VALUES (1, N'TRẢI NGHIỆM MIỄN PHÍ', N'https://thucdononline.com/public/responsive_filemanager/source/tin-tuc/menu-online.jpg', N'<td>
			<p>&nbsp;</p>

			<h2 style="text-align:center"><strong>Chương trình Trải Nghiệm Miễn Phí</strong></h2>

			<h3 style="text-align:center"><strong>Dành cho thành viên mới</strong></h3>

			<p>&nbsp;</p>

			<p>Để tận dụng thời gian giản cách&nbsp;khách&nbsp;hàng có thể tìm hiểu, làm quen với dịch vụ menu online cho hướng kinh doanh sắp tới. MenuOnline có chương trình "Trải nghiệm miễn phí" dành cho các nhà hàng, quán ăn, cafe, bar, resort, khu du lịch... khi đăng ký thành viên mới</p>

			<table align="center" border="0" cellpadding="1" cellspacing="1" style="width:500px">
				<tbody>
					<tr>
						<td><img alt="" src="https://thucdononline.com/public/responsive_filemanager/source/tin-tuc/menu-online.jpg" style="height:333px; width:500px"></td>
					</tr>
				</tbody>
			</table>

			<p>&nbsp;</p>

			<p>Với thực khách, menu in cuốn&nbsp;đã rất quen thuộc và&nbsp;sử dụng cũng đơn giản,chỉ cần mở ra và lật trang qua lại là biết được nội dung. Còn với menu online nếu đứng ở góc độ sử dụng của thực khách thời&nbsp;nay thì cũng quá xa lạ mà đôi khi có thể nói là dễ dàng&nbsp;và vô cùng tiện lợi. Chỉ với cái smartphone trên tay là có thể sử dụng menu online mọi lúc mọi nơi.</p>

			<p>Còn đối với nhà hàng, menu online&nbsp;là một cuộc cách mạng về công nghệ trong cho nhà hàng, hay lãnh vực ăn uống nói chung. Ngoài chức năng cơ bản là đặt món cho thực khách tại nhà hàng hay ở xa, menu online còn hỗ trợ cho việc marketing, quảng bá&nbsp;nhà hàng để tìm&nbsp;thêm khách hàng mới. Đặc biệt menu online còn tích hợp chức năng quản lý đơn hàng, tổng kết doanh thu một cách chi tiết...</p>

			<p>Để hiểu rỏ qui trình&nbsp;hoạt động và sử dụng thành thạo hết những tính năng của menu online thì cần có thời gian&nbsp;và thao tác thực thế và đó cũng là mục đích của&nbsp;chương trình "<a href="https://thucdononline.com/trai-nghiem-mien-phi.html">Trải nghiệm miễn phí</a> ".&nbsp;</p>

			<p>Điều kiện tham gia thật là đơn giản. Anh Chị chỉ cần điền thông tin vào mẫu "<a href="https://thucdononline.com/">Đăng ký thành viên</a>" trên trang chủ của <a href="https://thucdononline.com" target="_blank">https://thucdononline.com</a></p>

			<table align="center" border="0" cellpadding="1" cellspacing="1" style="width:400px">
				<tbody>
					<tr>
						<td><img alt="Đăng ký thành viên" src="https://thucdononline.com/public/responsive_filemanager/source/tin-tuc/Dang-ky-thanh-vien.png" style="height:180px; width:400px"></td>
					</tr>
				</tbody>
			</table>

			<p style="text-align:center"><em>Nhập thông tin đăng ký thành viên</em></p>

			<p>&nbsp;</p>

			<p>Sau khi nhận được thông tin đăng ký. <a href="https://thucdononline.com/">Menu Online</a> sẽ liêc lạc lại với Anh Chị qua Email hoặc Zalo (nếu có) xác nhận thông để mở tài khoản cho Anh Chị. Sau khi có tài khoản <a href="https://thucdononline.com/">Menu Online</a>, Anh Chị có thể tự quản trị và&nbsp;cập nhật menu của mình lên hệ thống <a href="https://thucdononline.com/">Menu Online</a> theo hướng dẫn "<a href="https://thucdononline.com/huong-dan-quan-tri-menu-online.html" target="_blank">https://thucdononline.com/huong-dan-quan-tri-menu-online.html</a>"</p>

			<p>Nếu Anh Chị cần <a href="https://thucdononline.com/">Menu Online</a> hỗ trợ cập nhật menu lên hệ thống, Anh Chị gởi thông tin menu&nbsp;:</p>

			<h4><strong>- Logo</strong></h4>

			<h4><strong>- Hình làm slide quảng cáo nhà hàng</strong></h4>

			<h4><strong>- Tên nhóm món</strong></h4>

			<h4><strong>- Tên&nbsp;món, giá</strong></h4>

			<h4><strong>- Hình món ăn ( nếu có):&nbsp;</strong>tên file hình là tên món</h4>

			<div>&nbsp;</div>

			<p>Thông tin&nbsp;menu, hình ảnh món ăn được chuẩn bị càng chi tiết, rỏ ràng, đầy đủ thì&nbsp;thời gian cập nhật menu sẽ nhanh hơn.</p>

			<p><strong>Email Menu Online</strong> :&nbsp;<a href="http://mail.google.com/" target="_blank"><strong><span style="color:#ffa07a">menuonlinevietnam@gmail.com</span></strong></a></p>

			<p>&nbsp;</p>

			<table align="center" border="0" cellpadding="1" cellspacing="1" style="width:500px">
				<tbody>
				<p style="text-align:center"><em>Phân loại chi tiết menu</em></p>

			<p style="text-align:center">&nbsp;</p>

			<p>Anh Chị sẽ được sử dụng menu online miễn phí hoàn toàn&nbsp;trong thời gian 1 tháng kể từ ngày Menu Online cung cấp tài khoản. Sau thời gian trải nghiệm,&nbsp;nếu Anh Chị muốn sử dụng tiếp thì <a href="https://thucdononline.com/">Menu Online</a> sẽ tính phí từ thời gian gia hạn này. Mức phí từ 349K/ tháng. Link chi tiết bảng giá:&nbsp;<a href="https://thucdononline.com/bang-ph-dich-vu-menu-online.html" target="_blank">https://menuonline.vn/bang-ph-dich-vu-menu-online.html</a></p>

			<div>Cần thêm thông tin chi tiết Anh Chị hãy liên hệ <a href="https://thucdononline.com/">Menu Online</a>:</div>

			<div><span style="font-size:16px">Email:&nbsp;<a href="http://mail.google.com/" target="_blank"><strong>menuonlinevietnam@gmail.com</strong></a></span></div>

			<div><span style="font-size:16px">Hotline-Zalo: <strong>0909 688 990</strong></span></div>
			', N'4/18/2023', 1)
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (2, N'Employee')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (3, N'Customer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeFoods] ON 

INSERT [dbo].[TypeFoods] ([TypeFoodId], [Name]) VALUES (1, N'Món mang đi')
INSERT [dbo].[TypeFoods] ([TypeFoodId], [Name]) VALUES (2, N'Món ăn tại bàn')
SET IDENTITY_INSERT [dbo].[TypeFoods] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Fullname], [Name], [Password], [Email], [Gender], [Phone], [Address], [Image], [Status], [RoleId], [Created_at], [Created_by], [Updated_at], [Updated_by], [PayTotal]) VALUES (3, N'Nhân VIên', N'Minh Nha', N'25f9e794323b453885f5181f1b624db', N'minhnha2308@gmail.com', 1, 1223415449, N'Sài gòn', NULL, 1, 3, CAST(N'2023-04-22T22:47:13.463' AS DateTime), 0, CAST(N'2023-04-22T23:49:37.547' AS DateTime), 0, 0)
INSERT [dbo].[Users] ([UserId], [Fullname], [Name], [Password], [Email], [Gender], [Phone], [Address], [Image], [Status], [RoleId], [Created_at], [Created_by], [Updated_at], [Updated_by], [PayTotal]) VALUES (4, N'Nhân VIên1', N'minhnha120', N'25f9e794323b453885f5181f1b624db', N'nguyenminhnhacmu@gmail.com', 1, 1223415449, N'Sài 1', NULL, 1, 3, CAST(N'2023-04-22T22:48:27.697' AS DateTime), 0, CAST(N'2023-04-22T23:46:11.560' AS DateTime), 0, 0)
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
