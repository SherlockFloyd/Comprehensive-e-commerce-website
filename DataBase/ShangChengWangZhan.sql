
USE [ShangChengWangZhan]
GO
/****** Object:  Table [dbo].[Shopping_User]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[Sex] [int] NULL,
	[BirthDay] [datetime] NULL,
	[Point] [int] NULL,
	[Email] [nvarchar](250) NULL,
	[EmailIsChecked] [int] NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[Password] [nvarchar](50) NULL,
	[RegTime] [datetime] NULL,
	[LastLoginTime] [datetime] NULL,
	[LastLoginIP] [nvarchar](20) NULL,
	[LoginTime] [datetime] NULL,
	[LoginIP] [nvarchar](20) NULL,
	[LoginTimes] [int] NULL,
	[Status] [int] NULL,
	[RealName] [nvarchar](20) NULL,
	[Post] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'书币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Point'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱地址是否验证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'EmailIsChecked'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'RegTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'LastLoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'LoginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'LoginTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User', @level2type=N'COLUMN',@level2name=N'Post'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'会员信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_User'
GO
SET IDENTITY_INSERT [dbo].[Shopping_User] ON
INSERT [dbo].[Shopping_User] ([UserID], [UserName], [Sex], [BirthDay], [Point], [Email], [EmailIsChecked], [Phone], [Address], [Password], [RegTime], [LastLoginTime], [LastLoginIP], [LoginTime], [LoginIP], [LoginTimes], [Status], [RealName], [Post]) VALUES (10, N'001@qq.com', 0, CAST(0x0000ADCF00DB36C0 AS DateTime), 0, N'001@qq.com', 0, N'', N'', N'000', CAST(0x0000ADCF00DB36C0 AS DateTime), CAST(0x0000ADCF00DC7C88 AS DateTime), N'127.0.0.1', CAST(0x0000ADCF00DCFB5C AS DateTime), N'127.0.0.1', 3, 1, N'', 0)
INSERT [dbo].[Shopping_User] ([UserID], [UserName], [Sex], [BirthDay], [Point], [Email], [EmailIsChecked], [Phone], [Address], [Password], [RegTime], [LastLoginTime], [LastLoginIP], [LoginTime], [LoginIP], [LoginTimes], [Status], [RealName], [Post]) VALUES (11, N'yh01@qq.com', 0, CAST(0x0000ADCF00DEB034 AS DateTime), 0, N'yh01@qq.com', 0, N'', N'', N'000', CAST(0x0000ADCF00DEB034 AS DateTime), CAST(0x0000ADCF00DEC7A4 AS DateTime), N'127.0.0.1', CAST(0x0000ADCF00E57BF3 AS DateTime), N'127.0.0.1', 2, 1, N'', 0)
SET IDENTITY_INSERT [dbo].[Shopping_User] OFF
/****** Object:  Table [dbo].[Shopping_Snapshot]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Snapshot](
	[SnapshotID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[CommodityID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](10, 2) NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[IsGrade] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SnapshotID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快照ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'SnapshotID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'OrderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图书ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'CommodityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'TotalPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否评价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot', @level2type=N'COLUMN',@level2name=N'IsGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'订单快照信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Snapshot'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Snapshot] ON
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (14, 13, 37, 5, CAST(4.80 AS Decimal(10, 2)), CAST(24.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (15, 14, 39, 1, CAST(33.00 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (16, 15, 57, 2, CAST(53.00 AS Decimal(10, 2)), CAST(106.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (17, 15, 37, 2, CAST(4.80 AS Decimal(10, 2)), CAST(9.60 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (18, 15, 47, 2, CAST(99.80 AS Decimal(10, 2)), CAST(199.60 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (19, 15, 49, 2, CAST(20.00 AS Decimal(10, 2)), CAST(40.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (20, 15, 77, 2, CAST(2.80 AS Decimal(10, 2)), CAST(5.60 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (21, 15, 58, 1, CAST(3.20 AS Decimal(10, 2)), CAST(3.20 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (22, 16, 47, 1, CAST(99.80 AS Decimal(10, 2)), CAST(99.80 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (23, 17, 42, 1, CAST(24.00 AS Decimal(10, 2)), CAST(24.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (24, 18, 45, 4, CAST(25.50 AS Decimal(10, 2)), CAST(102.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (25, 19, 34, 1, CAST(1.80 AS Decimal(10, 2)), CAST(1.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (26, 19, 83, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (27, 19, 80, 1, CAST(4.50 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (28, 19, 35, 1, CAST(2.40 AS Decimal(10, 2)), CAST(2.40 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (29, 19, 37, 1, CAST(4.80 AS Decimal(10, 2)), CAST(4.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (30, 19, 36, 1, CAST(3.20 AS Decimal(10, 2)), CAST(3.20 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (31, 19, 91, 1, CAST(4.50 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (32, 20, 85, 1, CAST(4.20 AS Decimal(10, 2)), CAST(4.20 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (33, 21, 45, 3, CAST(25.50 AS Decimal(10, 2)), CAST(76.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (34, 21, 83, 2, CAST(2.80 AS Decimal(10, 2)), CAST(5.60 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (35, 21, 34, 5, CAST(1.80 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (36, 22, 51, 1, CAST(14.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (37, 23, 89, 2, CAST(13.50 AS Decimal(10, 2)), CAST(27.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (38, 23, 47, 2, CAST(99.80 AS Decimal(10, 2)), CAST(199.60 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (39, 23, 79, 4, CAST(2.80 AS Decimal(10, 2)), CAST(11.20 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (40, 24, 45, 1, CAST(25.50 AS Decimal(10, 2)), CAST(25.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (41, 24, 37, 1, CAST(4.80 AS Decimal(10, 2)), CAST(4.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (42, 25, 39, 4, CAST(33.00 AS Decimal(10, 2)), CAST(132.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (43, 25, 85, 2, CAST(4.20 AS Decimal(10, 2)), CAST(8.40 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (44, 25, 88, 1, CAST(8.50 AS Decimal(10, 2)), CAST(8.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (45, 26, 39, 1, CAST(33.00 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (46, 27, 89, 2, CAST(13.50 AS Decimal(10, 2)), CAST(27.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (47, 27, 79, 4, CAST(2.80 AS Decimal(10, 2)), CAST(11.20 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (48, 27, 47, 2, CAST(99.80 AS Decimal(10, 2)), CAST(199.60 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (49, 28, 49, 1, CAST(20.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (50, 29, 77, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (51, 30, 45, 1, CAST(25.50 AS Decimal(10, 2)), CAST(25.50 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (52, 31, 80, 1, CAST(4.50 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (53, 32, 91, 1, CAST(4.50 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (54, 33, 85, 1, CAST(4.20 AS Decimal(10, 2)), CAST(4.20 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (55, 34, 84, 1, CAST(5.50 AS Decimal(10, 2)), CAST(5.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (56, 35, 47, 1, CAST(99.80 AS Decimal(10, 2)), CAST(99.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (57, 36, 47, 1, CAST(99.80 AS Decimal(10, 2)), CAST(99.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (58, 37, 90, 1, CAST(3.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (59, 38, 83, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (60, 39, 82, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (61, 40, 87, 1, CAST(11.30 AS Decimal(10, 2)), CAST(11.30 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (62, 41, 87, 1, CAST(11.30 AS Decimal(10, 2)), CAST(11.30 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (63, 42, 91, 1, CAST(4.50 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (64, 42, 37, 1, CAST(4.80 AS Decimal(10, 2)), CAST(4.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (65, 43, 86, 2, CAST(5.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (66, 43, 57, 1, CAST(53.00 AS Decimal(10, 2)), CAST(53.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (67, 43, 29, 2, CAST(23.00 AS Decimal(10, 2)), CAST(46.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (68, 43, 25, 1, CAST(33.00 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (69, 43, 28, 1, CAST(11.00 AS Decimal(10, 2)), CAST(11.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (70, 44, 24, 1, CAST(30.00 AS Decimal(10, 2)), CAST(30.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (71, 45, 37, 2, CAST(4.00 AS Decimal(10, 2)), CAST(8.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (72, 45, 49, 4, CAST(20.00 AS Decimal(10, 2)), CAST(80.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (73, 45, 29, 1, CAST(23.00 AS Decimal(10, 2)), CAST(23.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (74, 46, 52, 4, CAST(16.50 AS Decimal(10, 2)), CAST(66.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (75, 47, 37, 3, CAST(4.00 AS Decimal(10, 2)), CAST(12.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (76, 47, 28, 2, CAST(11.00 AS Decimal(10, 2)), CAST(22.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (77, 48, 37, 2, CAST(4.00 AS Decimal(10, 2)), CAST(8.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (78, 48, 25, 2, CAST(33.00 AS Decimal(10, 2)), CAST(66.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (79, 48, 47, 1, CAST(99.00 AS Decimal(10, 2)), CAST(99.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (80, 49, 45, 1, CAST(25.50 AS Decimal(10, 2)), CAST(25.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (81, 49, 47, 1, CAST(99.00 AS Decimal(10, 2)), CAST(99.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (82, 50, 90, 1, CAST(3.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (83, 50, 84, 1, CAST(5.50 AS Decimal(10, 2)), CAST(5.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (84, 51, 83, 4, CAST(2.80 AS Decimal(10, 2)), CAST(11.20 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (85, 52, 82, 2, CAST(2.80 AS Decimal(10, 2)), CAST(5.60 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (86, 53, 91, 1, CAST(4.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (87, 54, 84, 1, CAST(5.50 AS Decimal(10, 2)), CAST(5.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (88, 55, 79, 2, CAST(2.80 AS Decimal(10, 2)), CAST(5.60 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (89, 56, 47, 2, CAST(99.00 AS Decimal(10, 2)), CAST(198.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (90, 57, 82, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (91, 58, 83, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (92, 59, 91, 1, CAST(4.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (93, 60, 91, 1, CAST(4.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (94, 61, 83, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (95, 62, 99, 2, CAST(1.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (96, 63, 99, 9, CAST(1.00 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (97, 64, 90, 1, CAST(3.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (98, 65, 52, 1, CAST(16.50 AS Decimal(10, 2)), CAST(16.50 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (99, 66, 79, 2, CAST(2.80 AS Decimal(10, 2)), CAST(5.60 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (100, 66, 49, 1, CAST(20.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (101, 67, 83, 2, CAST(2.80 AS Decimal(10, 2)), CAST(5.60 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (102, 68, 91, 3, CAST(4.00 AS Decimal(10, 2)), CAST(12.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (103, 68, 89, 3, CAST(13.50 AS Decimal(10, 2)), CAST(40.50 AS Decimal(10, 2)), 1)
INSERT [dbo].[Shopping_Snapshot] ([SnapshotID], [OrderID], [CommodityID], [Quantity], [Price], [TotalPrice], [IsGrade]) VALUES (104, 69, 77, 1, CAST(2.80 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[Shopping_Snapshot] OFF
/****** Object:  Table [dbo].[Shopping_ShoppingCart]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_ShoppingCart](
	[ShoppingCartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CommodityID] [int] NULL,
	[Price] [decimal](10, 2) NULL,
	[Quantity] [int] NULL,
	[IsChecked] [int] NULL,
	[GuestID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShoppingCartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart', @level2type=N'COLUMN',@level2name=N'ShoppingCartID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图书ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart', @level2type=N'COLUMN',@level2name=N'CommodityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'游客ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart', @level2type=N'COLUMN',@level2name=N'GuestID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'购物车信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_ShoppingCart'
GO
SET IDENTITY_INSERT [dbo].[Shopping_ShoppingCart] ON
INSERT [dbo].[Shopping_ShoppingCart] ([ShoppingCartID], [UserID], [CommodityID], [Price], [Quantity], [IsChecked], [GuestID]) VALUES (112, 7, 45, CAST(25.50 AS Decimal(10, 2)), 1, 0, NULL)
INSERT [dbo].[Shopping_ShoppingCart] ([ShoppingCartID], [UserID], [CommodityID], [Price], [Quantity], [IsChecked], [GuestID]) VALUES (136, 9, 42, CAST(24.00 AS Decimal(10, 2)), 2, 1, N'')
SET IDENTITY_INSERT [dbo].[Shopping_ShoppingCart] OFF
/****** Object:  Table [dbo].[Shopping_Rate]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Rate](
	[RateID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotID] [int] NULL,
	[Grade] [int] NULL,
	[RateContent] [ntext] NULL,
	[RateTime] [datetime] NULL,
	[ReplyContent] [ntext] NULL,
	[ReplyTime] [datetime] NULL,
	[UserID] [int] NULL,
	[CommodityID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'RateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快照ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'SnapshotID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'Grade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'RateContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'RateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'ReplyContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'ReplyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图书ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate', @level2type=N'COLUMN',@level2name=N'CommodityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'评价信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Rate'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Rate] ON
INSERT [dbo].[Shopping_Rate] ([RateID], [SnapshotID], [Grade], [RateContent], [RateTime], [ReplyContent], [ReplyTime], [UserID], [CommodityID]) VALUES (7, 21, 5, N'中性笔很好用，好写', CAST(0x0000AA3D00C6972D AS DateTime), N'', CAST(0x0000AA3D00C6972D AS DateTime), 5, 58)
INSERT [dbo].[Shopping_Rate] ([RateID], [SnapshotID], [Grade], [RateContent], [RateTime], [ReplyContent], [ReplyTime], [UserID], [CommodityID]) VALUES (8, 18, 5, N'书很新，正版书籍，值得购买', CAST(0x0000AA3D00C6C934 AS DateTime), N'', CAST(0x0000AA3D00C6C934 AS DateTime), 5, 47)
INSERT [dbo].[Shopping_Rate] ([RateID], [SnapshotID], [Grade], [RateContent], [RateTime], [ReplyContent], [ReplyTime], [UserID], [CommodityID]) VALUES (9, 20, 5, N'保质期很近，很不错', CAST(0x0000AA3D00C6E649 AS DateTime), N'', CAST(0x0000AA3D00C6E649 AS DateTime), 5, 77)
INSERT [dbo].[Shopping_Rate] ([RateID], [SnapshotID], [Grade], [RateContent], [RateTime], [ReplyContent], [ReplyTime], [UserID], [CommodityID]) VALUES (13, 86, 5, N'真的不错', CAST(0x0000ADCD00CAF07C AS DateTime), N'', CAST(0x0000ADCD00CAF07C AS DateTime), 8, 91)
INSERT [dbo].[Shopping_Rate] ([RateID], [SnapshotID], [Grade], [RateContent], [RateTime], [ReplyContent], [ReplyTime], [UserID], [CommodityID]) VALUES (15, 104, 4, N'好喝', CAST(0x0000ADCF00E596B7 AS DateTime), N'', CAST(0x0000ADCF00E596B7 AS DateTime), 11, 77)
INSERT [dbo].[Shopping_Rate] ([RateID], [SnapshotID], [Grade], [RateContent], [RateTime], [ReplyContent], [ReplyTime], [UserID], [CommodityID]) VALUES (16, 103, 5, N'订单', CAST(0x0000ADCF00E615A9 AS DateTime), N'', CAST(0x0000ADCF00E615A9 AS DateTime), 11, 89)
SET IDENTITY_INSERT [dbo].[Shopping_Rate] OFF
/****** Object:  Table [dbo].[Shopping_Order]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[Status] [int] NULL,
	[OrderTime] [datetime] NULL,
	[Remark] [ntext] NULL,
	[ShipPeopele] [nvarchar](20) NULL,
	[ShipAddress] [nvarchar](250) NULL,
	[ShipMobile] [nvarchar](20) NULL,
	[UserPoint] [int] NULL,
	[SavingByCoupon] [decimal](10, 0) NULL,
	[RealPay] [decimal](10, 0) NULL,
	[CouponID] [int] NULL,
	[CouponNo] [nvarchar](50) NULL,
	[PaidTime] [datetime] NULL,
	[ShopID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'OrderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单总价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'TotalPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'OrderTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'ShipPeopele'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'ShipAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'ShipMobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'书币使用数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'UserPoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠券优惠金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'SavingByCoupon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际付款金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'RealPay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠券ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'CouponID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠券编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'CouponNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'PaidTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID 谁发布的商品等价于UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order', @level2type=N'COLUMN',@level2name=N'ShopID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'订单信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Order'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Order] ON
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (60, N'202110261257497440', 8, CAST(4.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCD00D5A354 AS DateTime), N'', N'123@qq.com', N'北京', N'15840405566', 0, CAST(0 AS Decimal(10, 0)), CAST(4 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCD00D5A354 AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (62, N'202110261324143022', 8, CAST(2.00 AS Decimal(10, 2)), 2, CAST(0x0000ADCD00DCE4AE AS DateTime), N'', N'123@qq.com', N'北京', N'15840405566', 0, CAST(0 AS Decimal(10, 0)), CAST(2 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCD00DCE4AE AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (63, N'202110261328090076', 8, CAST(9.00 AS Decimal(10, 2)), 2, CAST(0x0000ADCD00DDF740 AS DateTime), N'', N'123@qq.com', N'北京', N'15840405566', 0, CAST(0 AS Decimal(10, 0)), CAST(9 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCD00DDF740 AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (64, N'202110281111210551', 8, CAST(3.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCF00B8647B AS DateTime), N'5555', N'123@qq.com', N'北京', N'15840405566', 0, CAST(0 AS Decimal(10, 0)), CAST(3 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCF00B8647B AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (66, N'202110281319481979', 10, CAST(25.60 AS Decimal(10, 2)), 2, CAST(0x0000ADCF00DBACC1 AS DateTime), N'尽快发货！', N'001@qq.com', N'北京', N'13266559988', 0, CAST(0 AS Decimal(10, 0)), CAST(26 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCF00DBACC1 AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (67, N'202110281320181804', 10, CAST(5.60 AS Decimal(10, 2)), 2, CAST(0x0000ADCF00DBCF95 AS DateTime), N'', N'001@qq.com', N'北京', N'13266559988', 0, CAST(0 AS Decimal(10, 0)), CAST(6 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCF00DBCF95 AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (68, N'202110281332592105', 11, CAST(52.50 AS Decimal(10, 2)), 5, CAST(0x0000ADCF00DF4AE4 AS DateTime), N'尽快发货', N'yh01@qq.com', N'北京', N'13899886655', 0, CAST(0 AS Decimal(10, 0)), CAST(53 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCF00DF4AE4 AS DateTime), 0)
INSERT [dbo].[Shopping_Order] ([OrderID], [OrderNo], [UserID], [TotalPrice], [Status], [OrderTime], [Remark], [ShipPeopele], [ShipAddress], [ShipMobile], [UserPoint], [SavingByCoupon], [RealPay], [CouponID], [CouponNo], [PaidTime], [ShopID]) VALUES (69, N'202110281333236518', 11, CAST(2.80 AS Decimal(10, 2)), 5, CAST(0x0000ADCF00DF6704 AS DateTime), N'', N'yh01@qq.com', N'北京', N'13899886655', 0, CAST(0 AS Decimal(10, 0)), CAST(3 AS Decimal(10, 0)), 0, N'', CAST(0x0000ADCF00DF6704 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Shopping_Order] OFF
/****** Object:  Table [dbo].[Shopping_Notice]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Notice](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [ntext] NULL,
	[CreateTime] [datetime] NULL,
	[AdminID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NoticeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Notice', @level2type=N'COLUMN',@level2name=N'NoticeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Notice', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Notice', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Notice', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Notice', @level2type=N'COLUMN',@level2name=N'AdminID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'公告信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Notice'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Notice] ON
INSERT [dbo].[Shopping_Notice] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (2, N'校园购物网站已经正式上线', N'<p><SPAN style="FONT-SIZE: 12px; TEXT-DECORATION: none; FONT-FAMILY: &amp;quot; FONT-VARIANT: normal; WHITE-SPACE: normal; WORD-SPACING: 0px; TEXT-TRANSFORM: none; FLOAT: none; FONT-WEIGHT: 400; COLOR: rgb(0,0,0); FONT-STYLE: normal; TEXT-ALIGN: left; ORPHANS: 2; DISPLAY: inline; LETTER-SPACING: normal; BACKGROUND-COLOR: rgb(255,255,255); TEXT-INDENT: 0px; -webkit-text-stroke-width: 0px; sans: ; tahoma: " serif?,tahoma,verdana,helvetica;font-size:12px;font-style:normal;font-variant:normal;font-weight:400;letter-spacing:normal;line-height:18px;orphans:2;text-align:left;text-decoration:none;text-indent:0px;text-transform:none;-webkit-text-stroke-width:0px;white-space:normal;word-spacing:0px;?="" sans="">校园购物网站已经正式上线啦，各位朋友们可以尽情享受快捷购物啦！</span></p><p><SPAN style="FONT-FAMILY: ; FLOAT: none; COLOR: #000000; DISPLAY: inline !important; BACKGROUND-COLOR: #ffffff" serif?,tahoma,verdana,helvetica;font-size:12px;font-style:normal;font-variant:normal;font-weight:400;letter-spacing:normal;line-height:18px;orphans:2;text-align:left;text-decoration:none;text-indent:0px;text-transform:none;-webkit-text-stroke-width:0px;white-space:normal;word-spacing:0px;?="" sans="">校园购物网站已经正式上线啦，各位朋友们可以尽情享受快捷购物啦！</span></p><p>&nbsp;</p><p><SPAN style="FONT-SIZE: 12px; FONT-VARIANT: normal; WHITE-SPACE: normal; WORD-SPACING: 0px; TEXT-TRANSFORM: none; FLOAT: none; COLOR: rgb(0,0,0); TEXT-ALIGN: left; ORPHANS: 2; DISPLAY: inline; LETTER-SPACING: normal; BACKGROUND-COLOR: rgb(255,255,255); TEXT-INDENT: 0px; -webkit-text-stroke-width: 0px" serif?,tahoma,verdana,helvetica;font-size:12px;font-style:normal;font-variant:normal;font-weight:400;letter-spacing:normal;line-height:18px;orphans:2;text-align:left;text-decoration:none;text-indent:0px;text-transform:none;-webkit-text-stroke-width:0px;white-space:normal;word-spacing:0px;?="" sans=""></span>&nbsp;</p>', CAST(0x0000AA39014250E4 AS DateTime), 0)
INSERT [dbo].[Shopping_Notice] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (3, N'五一劳动节，休息休息吧', N'各位朋友们有需要请上校园购物网站敬请购买哦哦', CAST(0x0000AA420154693D AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Shopping_Notice] OFF
/****** Object:  Table [dbo].[Shopping_News]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_News](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [ntext] NULL,
	[CreateTime] [datetime] NULL,
	[AdminID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NoticeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Shopping_News] ON
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (3, N'折扣不断！嗨购全场！', N'校园购物商城！价格更超值，送货更准时！各种商品尽在校园购物网站，欢迎各位选购！', CAST(0x0000AA390143A601 AS DateTime), 0)
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (5, N'夏季嗨购', N'胜多负少大师傅发的高度很过分', CAST(0x0000AA4201554348 AS DateTime), 0)
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (6, N'母亲节优惠请戳详情', N'', CAST(0x0000AA50016F3C17 AS DateTime), 0)
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (7, N'毕业季好礼不断', N'', CAST(0x0000AA50016F529E AS DateTime), 0)
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (8, N'端午节即将有新品上市', N'', CAST(0x0000AA50016F7BC2 AS DateTime), 0)
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (9, N'优惠新活动！', N'', CAST(0x0000AA50016F9F95 AS DateTime), 0)
INSERT [dbo].[Shopping_News] ([NoticeID], [Title], [Content], [CreateTime], [AdminID]) VALUES (10, N'新品上架，', N'', CAST(0x0000AA50016FB173 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Shopping_News] OFF
/****** Object:  Table [dbo].[Shopping_Delivery]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Delivery](
	[DeliveryID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Name] [nvarchar](20) NULL,
	[Tel] [nvarchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[IsDefault] [int] NULL,
	[CreateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DeliveryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'DeliveryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否默认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'IsDefault'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'收货地址信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Delivery'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Delivery] ON
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (4, 4, N'123123@163.com', N'1231231231', N'规范化个', 0, CAST(0x0000AA330015D954 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (5, 5, N'凡哥', N'15292329557', N'阿拉尔市', 1, CAST(0x0000AA3D00C602A0 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (8, 4, N'123', N'13369945654', N'西12宿舍楼', 1, CAST(0x0000AA3E00C8F7C2 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (9, 6, N'炒饭', N'13333665454', N'塔大西12宿舍楼113', 1, CAST(0x0000AA42014E2C0C AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (10, 5, N'cf@163.com', N'15292329557', N'阿拉尔市', 0, CAST(0x0000AA4300DA4815 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (11, 7, N'user@163.com', N'12312121231', N'塔里木大学逸夫楼101', 1, CAST(0x0000AA4801247B50 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (12, 8, N'123@qq.com', N'15840405566', N'北京', 1, CAST(0x0000ADCD00C5277C AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (14, 8, N'1@qq.com', N'', N'', 0, CAST(0x0000ADCD00C8460C AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (15, 8, N'', N'', N'', 0, CAST(0x0000ADCD00CA39AF AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (16, 9, N'123132@QQ.com', N'222', N'111', 0, CAST(0x0000ADCF00BA0E13 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (17, 10, N'001@qq.com', N'13266559988', N'北京', 0, CAST(0x0000ADCF00DBACC0 AS DateTime))
INSERT [dbo].[Shopping_Delivery] ([DeliveryID], [UserID], [Name], [Tel], [Address], [IsDefault], [CreateTime]) VALUES (18, 11, N'yh01@qq.com', N'13899886655', N'北京', 1, CAST(0x0000ADCF00DF4AE4 AS DateTime))
SET IDENTITY_INSERT [dbo].[Shopping_Delivery] OFF
/****** Object:  Table [dbo].[Shopping_Consult]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Consult](
	[ConsultID] [nchar](10) NULL,
	[CommodityID] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[UserID] [nchar](10) NULL,
	[Content] [nchar](10) NULL,
	[IsReply] [nchar](10) NULL,
	[ReplyContent] [nchar](10) NULL,
	[ReplyTime] [nchar](10) NULL,
	[ReplyIsRead] [nchar](10) NULL,
	[CreateTime] [nchar](10) NULL,
	[UserName] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shopping_Commodity]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Commodity](
	[CommodityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CommodityNo] [nvarchar](250) NULL,
	[CateID] [int] NULL,
	[MarketPrice] [decimal](10, 2) NULL,
	[Price] [decimal](10, 2) NULL,
	[OnSale] [int] NULL,
	[OnSaleTime] [datetime] NULL,
	[Remark] [ntext] NULL,
	[RateTotal] [int] NULL,
	[GradeTotal] [decimal](10, 2) NULL,
	[CreateTime] [datetime] NULL,
	[Photo] [nvarchar](50) NULL,
	[Stock] [int] NULL,
	[SaleTotal] [int] NULL,
	[Visits] [int] NULL,
	[ForSerach] [nvarchar](max) NULL,
	[UpdateTime] [datetime] NULL,
	[Point] [nchar](10) NULL,
	[UserID] [int] NULL,
	[IsHot] [nchar](10) NULL,
	[IsNew] [nchar](10) NULL,
	[IsRecommend] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[CommodityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'CommodityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'CommodityNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'CateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市场价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'MarketPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上架状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'OnSale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上架时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'OnSaleTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'RateTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价总分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'GradeTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售总量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'SaleTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Visits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'搜索辅助' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'ForSerach'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'Point'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否热门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'IsHot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否新品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'IsNew'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity', @level2type=N'COLUMN',@level2name=N'IsRecommend'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'图书信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Commodity'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Commodity] ON
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (24, N'所有失去的都会以另一种方式归来', N'201904242019338436', 2, CAST(33.00 AS Decimal(10, 2)), CAST(30.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCD00D9DC37 AS DateTime), N'<p><img width="720" alt="" src="/Pic/Commodity/Detail/2019042617180231113348.png" border="0" /></p>', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA39014FE380 AS DateTime), N'/Images/Commodity/2019042420225693235377.jpg', 19, 1, 1, N'0', CAST(0x0000AA5100AEC034 AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (25, N'郭沫若精选集', N'201904242022591218', 2, CAST(35.00 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCD00D9DBE0 AS DateTime), N'<p><img width="720" alt="" src="/Pic/Commodity/Detail/2019042617135478487886.jpg" border="0" /><br /><br /><br /><br />&nbsp;</p>', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3901503B64 AS DateTime), N'/Images/Commodity/2019042420241126838166.jpg', 17, 3, 1, N'0', CAST(0x0000ADCF00DACCA3 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (26, N'将来的你，一定会感谢现在拼命的自己', N'201904242024136293', 2, CAST(34.00 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCD00D9DC37 AS DateTime), N'<p><img width="720" alt="" src="/Pic/Commodity/Detail/2019042617172230871257.jpg" border="0" /><br /></p>', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3901510BFC AS DateTime), N'/Images/Commodity/2019042420270911264245.jpg', 20, 0, 1, N'', CAST(0x0000AA4300D89AA7 AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (27, N'天才在左，疯子在右', N'201904242027102176', 2, CAST(29.00 AS Decimal(10, 2)), CAST(25.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCD00D9DC37 AS DateTime), N'<p><img width="720" alt="" src="/Pic/Commodity/Detail/2019042617163387623428.jpg" border="0" /><br /></p>', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA390151FC38 AS DateTime), N'/Images/Commodity/2019042420303451479979.jpg', 20, 0, 1, N'0', CAST(0x0000ADCD00C8E7E5 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (30, N'红心火龙果/kg', N'201904242033226249', 3, CAST(35.00 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 1, CAST(0x0000ADCD00D9D280 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042617151491864435.jpg" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3901531ED8 AS DateTime), N'/Images/Commodity/2019042420344256149387.jpg', 25, 0, 1, N'0', CAST(0x0000ADCF00DED4FD AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (33, N'晨光按动中性笔', N'201904242037093679', 4, CAST(3.50 AS Decimal(10, 2)), CAST(3.20 AS Decimal(10, 2)), 2, CAST(0x0000AA390153F8D0 AS DateTime), N'<img alt="" src="/Pic/Commodity/Detail/2019042616454775475799.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042616460090363077.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/201904261646124844293.gif" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042616463113139291.gif" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042616464448968658.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/201904261646565858886.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042616470844833853.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/201904261647215917094.jpg" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA390153F8D0 AS DateTime), N'/Images/Commodity/2019042420374870866515.jpg', 100, 0, 1, N' 晨光按动中性笔 201904242037093679 ', CAST(0x0000AA3B0114B454 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (34, N'娃哈哈AD钙奶', N'201904242037530478', 7, CAST(2.00 AS Decimal(10, 2)), CAST(1.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3901543F20 AS DateTime), N'<img alt="" src="/Pic/Commodity/Detail/2019042613101586350560.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613103228165400.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613105137536954.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613110729785740.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613111936168174.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613112997014688.jpg" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3901543F20 AS DateTime), N'/Images/Commodity/2019042420384822927532.jpg', 44, 6, 1, N'0', CAST(0x0000ADCF00DEDA6E AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (35, N'畅意乳酸菌/瓶', N'201904242038497489', 7, CAST(2.50 AS Decimal(10, 2)), CAST(2.40 AS Decimal(10, 2)), 2, CAST(0x0000AA3901548A20 AS DateTime), N'<img alt="" src="/Pic/Commodity/Detail/2019042613041842544180.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/201904261304399652731.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613045225077725.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042613050584214371.jpg" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3901548A20 AS DateTime), N'/Images/Commodity/2019042420395242739971.jpg', 49, 1, 2, N' 畅意乳酸菌/瓶 201904242038497489 ', CAST(0x0000AA3B00D7ABB8 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (36, N'达利园花生牛奶（盒装）', N'201904242039539847', 7, CAST(3.50 AS Decimal(10, 2)), CAST(3.20 AS Decimal(10, 2)), 2, CAST(0x0000AA390155052C AS DateTime), N'<div class="auth-wrap tb-spu-food" style="clear:both;margin-bottom:2px;border-bottom:1px solid #ffffff;color:#000000;font-family:tahoma, arial, " sans-serif;font-size:12px;font-style:normal;font-variant-ligatures:normal;font-variant-caps:normal;font-weight:400;letter-spacing:normal;orphans:2;text-align:start;text-indent:0px;text-transform:none;white-space:normal;widows:2;word-spacing:0px;-webkit-text-stroke-width:0px;background-color:#ffffff;text-decoration-style:initial;text-decoration-color:initial;"="" 宋体,="" gb",="" sans="" hiragino=""><div><img alt="" src="/Pic/Commodity/Detail/2019042612561798830268.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612563844480296.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612564960277199.jpg" border="0" /><br /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612571142533147.jpg" border="0" /><br /><br /></div></div><ul class="attributes-list" style="margin:0px;padding:0px 15px;list-style:none;clear:both;color:#000000;font-family:tahoma, arial, " sans-serif;font-size:12px;font-style:normal;font-variant-ligatures:normal;font-variant-caps:normal;font-weight:400;letter-spacing:normal;orphans:2;text-align:start;text-indent:0px;text-transform:none;white-space:normal;widows:2;word-spacing:0px;-webkit-text-stroke-width:0px;background-color:#ffffff;text-decoration-style:initial;text-decoration-color:initial;"="" 宋体,="" gb",="" sans="" hiragino=""><li title="风味牛奶" style="margin:0px 20px 0px 0px;padding:0px;display:inline;float:left;width:206px;height:24px;overflow:hidden;text-indent:5px;line-height:24px;white-space:nowrap;text-overflow:ellipsis;"><div><br /><img alt="" src="/Pic/Commodity/Detail/2019042612552133980296.jpg" border="0" /><br /><br /></div></li></ul>', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA390155052C AS DateTime), N'/Images/Commodity/2019042420413741686165.jpg', 49, 1, 7, N' 达利园花生牛奶（盒装） 201904242039539847 ', CAST(0x0000AA3B00D5C690 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (37, N'六个核桃/瓶', N'201904242041400550', 7, CAST(5.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)), 2, CAST(0x0000AA42015C9AF8 AS DateTime), N'<p><img alt="" src="/Pic/Commodity/Detail/2019042612420915652483.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612475921585886.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612482472940773.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612483683939213.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612485038824394.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612490466110879.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612491618313883.jpg" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612492744216731.jpg" border="0" /></p>', 2, CAST(10.00 AS Decimal(10, 2)), CAST(0x0000AA3901554B7C AS DateTime), N'/Images/Commodity/2019042420423752353048.jpg', 36, 14, 1, N'0', CAST(0x0000ADCF00DE6F17 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (38, N'迷你口袋面包/个', N'201904242042394539', 6, CAST(1.50 AS Decimal(10, 2)), CAST(1.30 AS Decimal(10, 2)), 2, CAST(0x0000AA3901558164 AS DateTime), N'<img alt="" src="/Pic/Commodity/Detail/2019042612191581599706.png" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612195250181455.png" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612201767831429.png" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612204181630213.png" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612210482691128.png" border="0" /><br /><img alt="" src="/Pic/Commodity/Detail/2019042612211738757119.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3901558164 AS DateTime), N'/Images/Commodity/2019042420432376348763.jpg', 100, 0, 3, N' 迷你口袋面包/个 201904242042394539 ', CAST(0x0000AA3B00CBC988 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (39, N'巴黎圣母院', N'201904261151326845', 2, CAST(34.90 AS Decimal(10, 2)), CAST(33.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3B00C6BF4C AS DateTime), N'<img alt="" src="/Pic/Commodity/Detail/2019042612111431857254.jpg" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B00C6BF4C AS DateTime), N'/Images/Commodity/2019042612033726829462.jpg', 49, 1, 1, N'0', CAST(0x0000AA5901327938 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (40, N'解忧杂货铺', N'201904261726362033', 2, CAST(37.50 AS Decimal(10, 2)), CAST(35.70 AS Decimal(10, 2)), 2, CAST(0x0000AA3B011FD078 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619423360239852.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B011FD078 AS DateTime), N'/Images/Commodity/20190426194239945570.jpg', 10, 0, 0, N' 解忧杂货铺 201904261726362033 ', CAST(0x0000AA5100AF463C AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (42, N'围城', N'201904261731596970', 2, CAST(39.00 AS Decimal(10, 2)), CAST(24.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619433381764324.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B01213260 AS DateTime), N'/Images/Commodity/2019042619433843749407.jpg', 10, 1, 1, N'0', CAST(0x0000ADCF00BE8874 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (43, N'认知天性', N'201904261733005625', 2, CAST(31.50 AS Decimal(10, 2)), CAST(30.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619452260154467.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B0121B21C AS DateTime), N'/Images/Commodity/2019042619452937046267.jpg', 20, 0, 1, N'0', CAST(0x0000AA4700C933D0 AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (44, N'情绪', N'201904261735571083', 2, CAST(68.00 AS Decimal(10, 2)), CAST(62.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619443126973220.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B01228890 AS DateTime), N'/Images/Commodity/2019042619443421735911.jpg', 20, 0, 0, N' 情绪 201904261735571083 ', CAST(0x0000AA3B01455A20 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (45, N'追风筝的人', N'201904261738229688', 2, CAST(28.00 AS Decimal(10, 2)), CAST(25.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619490613063694.jpg" border="0" /><br /><br />', 1, CAST(5.00 AS Decimal(10, 2)), CAST(0x0000AA3B0123741C AS DateTime), N'/Images/Commodity/2019042619491136825179.jpg', 10, 10, 1, N'0', CAST(0x0000ADCF00DAE6A3 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (46, N'摆渡人', N'201904261742243398', 2, CAST(44.50 AS Decimal(10, 2)), CAST(40.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619480622966747.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B01241250 AS DateTime), N'/Images/Commodity/2019042619480890411091.jpg', 20, 0, 1, N' 摆渡人 201904261742243398 ', CAST(0x0000AA3B014654A0 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (47, N'平凡的世界', N'201904261745104045', 2, CAST(108.00 AS Decimal(10, 2)), CAST(99.00 AS Decimal(10, 2)), 2, CAST(0x0000AA42015C9AF8 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619471526997511.png" border="0" /><br /><br />', 2, CAST(10.00 AS Decimal(10, 2)), CAST(0x0000AA3B0124A01C AS DateTime), N'/Images/Commodity/2019042619472097923920.jpg', 7, 13, 1, N'0', CAST(0x0000ADCF00B875B2 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (48, N'自在独行', N'201904261748211079', 2, CAST(28.80 AS Decimal(10, 2)), CAST(26.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/201904261946218659514.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B0125A0C0 AS DateTime), N'/Images/Commodity/2019042619462363375248.jpg', 20, 0, 0, N' 自在独行 201904261748211079 ', CAST(0x0000AA3B0145DA54 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (49, N'水蜜桃/kg', N'201904261753335905', 3, CAST(22.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619570622076316.png" border="0" /><br /><br />', 1, CAST(5.00 AS Decimal(10, 2)), CAST(0x0000AA3B01272CD8 AS DateTime), N'/Images/Commodity/2019042619570854560541.jpg', 42, 8, 1, N'0', CAST(0x0000ADCF00DB6CDA AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (50, N'山竹/kg', N'201904261754451445', 3, CAST(48.00 AS Decimal(10, 2)), CAST(45.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619561441444454.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B01278840 AS DateTime), N'/Images/Commodity/2019042619561659912349.jpg', 50, 0, 0, N' 山竹/kg 201904261754451445 ', CAST(0x0000AA3B0148913F AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (51, N'冰糖心苹果/kg', N'201904261757167151', 3, CAST(15.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619552935325207.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B01283358 AS DateTime), N'/Images/Commodity/2019042619553457753551.jpg', 49, 1, 1, N' 冰糖心苹果/kg 201904261757167151 ', CAST(0x0000AA3B01485F48 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (52, N'哈密瓜/kg', N'201904261801149735', 3, CAST(18.00 AS Decimal(10, 2)), CAST(16.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619544077719715.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B01291200 AS DateTime), N'/Images/Commodity/2019042619544293231529.jpg', 46, 4, 1, N'0', CAST(0x0000ADCF00B9736A AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (53, N'黄桃/kg', N'201904261807091975', 3, CAST(18.00 AS Decimal(10, 2)), CAST(16.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/20190426195343072942.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B012AC140 AS DateTime), N'/Images/Commodity/2019042619534638183488.jpg', 50, 0, 1, N' 黄桃/kg 201904261807091975 ', CAST(0x0000AA3B0147E0B8 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (54, N'荔枝/kg', N'201904261809529851', 3, CAST(28.80 AS Decimal(10, 2)), CAST(27.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619522955196087.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B012B75B8 AS DateTime), N'/Images/Commodity/2019042619523231685547.jpg', 50, 0, 0, N' 荔枝/kg 201904261809529851 ', CAST(0x0000AA3B01479245 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (55, N'皇冠梨/kg', N'201904261811455513', 3, CAST(15.00 AS Decimal(10, 2)), CAST(13.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619513224778064.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B012BF1F0 AS DateTime), N'/Images/Commodity/2019042619514255061601.jpg', 50, 0, 1, N' 皇冠梨/kg 201904261811455513 ', CAST(0x0000AA3B0147A74C AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (56, N'西贡蕉/kg', N'201904261814285784', 3, CAST(22.00 AS Decimal(10, 2)), CAST(19.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CD6 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042619500082427746.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3B012CB928 AS DateTime), N'/Images/Commodity/2019042619501057419045.jpg', 50, 0, 0, N' 西贡蕉/kg 201904261814285784 ', CAST(0x0000AA3B0146E446 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (57, N'英雄6006钢笔', N'201904281055502731', 4, CAST(56.00 AS Decimal(10, 2)), CAST(53.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042810585686033678.png" border="0" /><br /><br />', 1, CAST(5.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B50374 AS DateTime), N'/Images/Commodity/2019042810590377237893.jpg', 47, 3, 1, N'0', CAST(0x0000ADCF00DB75D7 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (58, N'晨光黑金系列中性笔', N'201904281059089159', 4, CAST(3.50 AS Decimal(10, 2)), CAST(3.20 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811002913972481.png" border="0" /><br /><br />', 1, CAST(5.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B579D0 AS DateTime), N'/Images/Commodity/2019042811004414969898.jpg', 49, 1, 2, N' 晨光黑金系列中性笔 201904281059089159 ', CAST(0x0000AA3D00D494B4 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (59, N'Stalogy 0.5mm中性笔', N'201904281100475445', 4, CAST(28.00 AS Decimal(10, 2)), CAST(23.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811042334839086.png" border="0" /><br /><br /><br /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B67DF8 AS DateTime), N'/Images/Commodity/2019042811042624125424.jpg', 50, 0, 0, N' Stalogy 0.5mm中性笔 201904281100475445 ', CAST(0x0000AA3D00D4615D AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (60, N'直液式荧光笔', N'201904281104296221', 4, CAST(5.00 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811054597530689.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B6DF3C AS DateTime), N'/Images/Commodity/2019042811054933336454.jpg', 50, 0, 0, N' 直液式荧光笔 201904281104296221 ', CAST(0x0000AA3D00D4A9D2 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (61, N'晨光优品全针管中性笔', N'201904281105523226', 4, CAST(3.00 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811061212468336.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B73CFC AS DateTime), N'/Images/Commodity/2019042811070978127768.jpg', 50, 0, 0, N' 晨光优品全针管中性笔 201904281105523226 ', CAST(0x0000AA3D00D4B9FB AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (62, N'晨光A1709考试专用中性笔', N'201904281107125058', 4, CAST(5.00 AS Decimal(10, 2)), CAST(4.30 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811080172977391.png" border="0" /><br /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B7C168 AS DateTime), N'/Images/Commodity/2019042811090297442375.jpg', 50, 0, 0, N' 晨光A1709考试专用中性笔 201904281107125058 ', CAST(0x0000AA3D00D44E2F AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (63, N'得力 连中三元中性笔', N'201904281109055882', 4, CAST(4.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811092834311539.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B81244 AS DateTime), N'/Images/Commodity/2019042811101156368876.jpg', 50, 0, 0, N' 得力 连中三元中性笔 201904281109055882 ', CAST(0x0000AA410120AA59 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (64, N'得力 直液式 走珠中性笔', N'201904281110142772', 4, CAST(5.00 AS Decimal(10, 2)), CAST(4.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811105398329274.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B88D50 AS DateTime), N'/Images/Commodity/2019042811115683948916.jpg', 50, 0, 0, N' 得力 直液式 走珠中性笔 201904281110142772 ', CAST(0x0000AA3D00D473DF AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (65, N'疯狂鼓手原子笔', N'201904281111595830', 4, CAST(38.00 AS Decimal(10, 2)), CAST(35.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811121956893275.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B93BEC AS DateTime), N'/Images/Commodity/2019042811142588494843.jpg', 50, 0, 0, N' 疯狂鼓手原子笔 201904281111595830 ', CAST(0x0000AA3D00D43315 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (66, N'SlimLine纤美系列圆珠笔', N'201904281114349927', 4, CAST(22.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811151995165104.png" border="0" /><br /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00B9D1EC AS DateTime), N'/Images/Commodity/2019042811163320980348.jpg', 50, 0, 0, N' SlimLine纤美系列圆珠笔 201904281114349927 ', CAST(0x0000AA3D00D42346 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (67, N'三明治蛋糕/个', N'201904281116427811', 6, CAST(2.00 AS Decimal(10, 2)), CAST(1.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811170544466904.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BA37E0 AS DateTime), N'/Images/Commodity/2019042811180083814623.jpg', 100, 0, 0, N' 三明治蛋糕/个 201904281116427811 ', CAST(0x0000AA3D00D40E62 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (68, N'豪士小小面包/包', N'201904281118047039', 6, CAST(4.50 AS Decimal(10, 2)), CAST(4.30 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811182256671353.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BAA02C AS DateTime), N'/Images/Commodity/2019042811192938411894.jpg', 100, 0, 0, N' 豪士小小面包/包 201904281118047039 ', CAST(0x0000AA3D00D3FCBB AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (69, N'港荣 奶香蒸蛋糕/个', N'201904281119318105', 6, CAST(1.80 AS Decimal(10, 2)), CAST(1.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811194543511131.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BAF6E4 AS DateTime), N'/Images/Commodity/2019042811204398287894.jpg', 100, 0, 0, N' 港荣 奶香蒸蛋糕/个 201904281119318105 ', CAST(0x0000AA3D00D3EC75 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (70, N'蓝莓 夹心蒸蛋糕/个', N'201904281120470834', 6, CAST(2.50 AS Decimal(10, 2)), CAST(2.20 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811210383038596.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BB4C70 AS DateTime), N'/Images/Commodity/2019042811215697043664.jpg', 100, 0, 0, N' 蓝莓 夹心蒸蛋糕/个 201904281120470834 ', CAST(0x0000AA3D00D3D57F AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (71, N'抹茶 蒸蛋糕/个', N'201904281122001978', 6, CAST(2.50 AS Decimal(10, 2)), CAST(2.30 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811221473836675.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BB85DC AS DateTime), N'/Images/Commodity/2019042811224562232275.jpg', 100, 0, 0, N' 抹茶 蒸蛋糕/个 201904281122001978 ', CAST(0x0000AA3D00D3C1F3 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (72, N'蛋黄酥/盒', N'201904281122489394', 6, CAST(8.80 AS Decimal(10, 2)), CAST(8.20 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811230142434901.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BBD6B8 AS DateTime), N'/Images/Commodity/201904281123548496683.jpg', 100, 0, 0, N' 蛋黄酥/盒 201904281122489394 ', CAST(0x0000AA3D00D3B385 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (73, N'慕芬·巧芯蛋糕/个', N'201904281123589959', 6, CAST(3.50 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811241130181444.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BC36D0 AS DateTime), N'/Images/Commodity/2019042811251697668430.jpg', 100, 0, 0, N' 慕芬·巧芯蛋糕/个 201904281123589959 ', CAST(0x0000AA3D00D3A128 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (74, N'炼乳味  氧气吐司 /包', N'201904281125213062', 6, CAST(3.00 AS Decimal(10, 2)), CAST(2.70 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811253990971935.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BCA87C AS DateTime), N'/Images/Commodity/201904281126531693542.jpg', 100, 0, 0, N' 炼乳味  氧气吐司 /包 201904281125213062 ', CAST(0x0000AA3D00D38A12 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (75, N'全麦面包/个', N'201904281126560458', 6, CAST(6.50 AS Decimal(10, 2)), CAST(6.10 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811271529165445.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BCFF34 AS DateTime), N'/Images/Commodity/2019042811280796728483.jpg', 100, 0, 0, N' 全麦面包/个 201904281126560458 ', CAST(0x0000AA3D00D377CD AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (76, N'无糖无油 全麦吐司/个', N'201904281128104406', 6, CAST(15.00 AS Decimal(10, 2)), CAST(14.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811283497549272.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BD69D8 AS DateTime), N'/Images/Commodity/2019042811293879471540.jpg', 100, 0, 0, N' 无糖无油 全麦吐司/个 201904281128104406 ', CAST(0x0000AA3D00D354CA AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (77, N'统一绿茶  550ml', N'201904281129421695', 7, CAST(3.00 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811300331356232.png" border="0" /><br /><br />', 2, CAST(9.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BDCEA0 AS DateTime), N'/Images/Commodity/2019042811310456343604.jpg', 96, 4, 1, N'0', CAST(0x0000ADCF00E599FC AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (78, N'可口可乐 500ml', N'201904281131089247', 7, CAST(3.00 AS Decimal(10, 2)), CAST(2.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811312493190259.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BE1298 AS DateTime), N'/Images/Commodity/2019042811320249795635.jpg', 100, 0, 1, N' 可口可乐 500ml 201904281131089247 ', CAST(0x0000AA3D00D331A0 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (79, N'康师傅冰红茶 500ml', N'201904281132061904', 7, CAST(3.00 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811322191774210.png" border="0" /><br /><br />', 1, CAST(4.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BE5D98 AS DateTime), N'/Images/Commodity/2019042811330659938530.jpg', 88, 12, 1, N'0', CAST(0x0000ADCF00DB60FD AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (80, N'美年达 新罐装细长罐 330ml', N'201904281133128303', 7, CAST(5.00 AS Decimal(10, 2)), CAST(4.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/20190428113326025307.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BED070 AS DateTime), N'/Images/Commodity/2019042811344411023077.jpg', 98, 2, 3, N' 美年达 新罐装细长罐 330ml 201904281133128303 ', CAST(0x0000AA3D00D30D4C AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (81, N'统一阿萨姆（原味奶茶）500ml', N'201904281134485409', 7, CAST(5.00 AS Decimal(10, 2)), CAST(4.30 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811350191431006.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BF1468 AS DateTime), N'/Images/Commodity/2019042811354252373507.jpg', 100, 0, 1, N' 统一阿萨姆（原味奶茶）500ml 201904281134485409 ', CAST(0x0000AA3D00D30068 AS DateTime), NULL, NULL, N'0         ', NULL, NULL)
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (82, N'康师傅 茉莉蜜茶550ml', N'201904281135469987', 7, CAST(3.00 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811360179567549.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BF5E3C AS DateTime), N'/Images/Commodity/2019042811364565770406.jpg', 98, 2, 1, N'0', CAST(0x0000ADCF00DD8536 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (83, N'达利园 青梅绿茶500ml', N'201904281136494268', 7, CAST(3.00 AS Decimal(10, 2)), CAST(2.80 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811370842972554.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00BF9EB0 AS DateTime), N'/Images/Commodity/2019042811374052351497.jpg', 94, 6, 1, N'0', CAST(0x0000ADCF00DE80AD AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (84, N'晨光APYJP550 软抄本', N'201904281137475102', 8, CAST(6.00 AS Decimal(10, 2)), CAST(5.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811381247538664.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C021F0 AS DateTime), N'/Images/Commodity/2019042811393254367588.jpg', 98, 2, 1, N'0', CAST(0x0000ADCF00B82991 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (85, N'小清新 圆角抄写本', N'201904281139352633', 8, CAST(4.50 AS Decimal(10, 2)), CAST(4.20 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811394993970103.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C0AD64 AS DateTime), N'/Images/Commodity/2019042811413132916028.jpg', 98, 2, 1, N'', CAST(0x0000AA4300D7735A AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (86, N'线圈笔记本', N'201904281141344735', 8, CAST(5.50 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), 2, CAST(0x0000AA42015C9AF8 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811415382865111.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C10C50 AS DateTime), N'/Images/Commodity/2019042811425262156375.jpg', 98, 2, 1, N'0', CAST(0x0000ADCD00C8A038 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (87, N'简约 活页本', N'201904281142557807', 8, CAST(12.00 AS Decimal(10, 2)), CAST(11.00 AS Decimal(10, 2)), 2, CAST(0x0000AA5100AEF8BB AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811430865728573.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C15D2C AS DateTime), N'/Images/Commodity/2019042811440152055441.jpg', 100, 0, 0, N' 简约 活页本 201904281142557807 ', CAST(0x0000AA4300D427A3 AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (88, N'时间表管理计划本', N'201904281144058024', 8, CAST(8.80 AS Decimal(10, 2)), CAST(8.00 AS Decimal(10, 2)), 2, CAST(0x0000AA5100AEF894 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811441792917669.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C1B63C AS DateTime), N'/Images/Commodity/2019042811451763837643.jpg', 100, 0, 1, N'0', CAST(0x0000ADCD00C57B48 AS DateTime), N'0         ', 0, N'0         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (89, N'毛毡活页本', N'201904281145227261', 8, CAST(15.00 AS Decimal(10, 2)), CAST(13.50 AS Decimal(10, 2)), 2, CAST(0x0000AA3D00CF5CC4 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811453633081304.png" border="0" /><br /><br />', 1, CAST(5.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C1FDB8 AS DateTime), N'/Images/Commodity/2019042811461812696796.jpg', 93, 7, 0, N'0', CAST(0x0000ADCF00E615A9 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (90, N'青联软抄本', N'201904281146210911', 8, CAST(3.50 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 2, CAST(0x0000AA5100AEF894 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/2019042811463985140844.png" border="0" /><br /><br />', 0, CAST(0.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C26BE0 AS DateTime), N'/Images/Commodity/2019042811475240981943.jpg', 99, 1, 1, N'0', CAST(0x0000ADCF00DB55E7 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
INSERT [dbo].[Shopping_Commodity] ([CommodityID], [Name], [CommodityNo], [CateID], [MarketPrice], [Price], [OnSale], [OnSaleTime], [Remark], [RateTotal], [GradeTotal], [CreateTime], [Photo], [Stock], [SaleTotal], [Visits], [ForSerach], [UpdateTime], [Point], [UserID], [IsHot], [IsNew], [IsRecommend]) VALUES (91, N'得力缝线本', N'201904281147585403', 8, CAST(5.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)), 2, CAST(0x0000AA42015C9AF8 AS DateTime), N'<img width="720" alt="" src="/Pic/Commodity/Detail/201904281148212419489.png" border="0" /><br /><br />', 1, CAST(5.00 AS Decimal(10, 2)), CAST(0x0000AA3D00C2B104 AS DateTime), N'/Images/Commodity/2019042811485176498143.jpg', 94, 6, 1, N'0', CAST(0x0000ADCF00DEFB84 AS DateTime), N'0         ', 0, N'1         ', N'0         ', N'0         ')
SET IDENTITY_INSERT [dbo].[Shopping_Commodity] OFF
/****** Object:  Table [dbo].[Shopping_Cate]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Cate](
	[CateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Cate', @level2type=N'COLUMN',@level2name=N'CateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Cate', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Cate', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'图书类别信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Cate'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Cate] ON
INSERT [dbo].[Shopping_Cate] ([CateID], [Name], [CreateTime]) VALUES (2, N'书', CAST(0x0000AA390143CF44 AS DateTime))
INSERT [dbo].[Shopping_Cate] ([CateID], [Name], [CreateTime]) VALUES (3, N'水果', CAST(0x0000AA390143E6C7 AS DateTime))
INSERT [dbo].[Shopping_Cate] ([CateID], [Name], [CreateTime]) VALUES (4, N'笔', CAST(0x0000AA390143EFBC AS DateTime))
INSERT [dbo].[Shopping_Cate] ([CateID], [Name], [CreateTime]) VALUES (6, N'面包', CAST(0x0000AA3901440D0B AS DateTime))
INSERT [dbo].[Shopping_Cate] ([CateID], [Name], [CreateTime]) VALUES (7, N'饮料', CAST(0x0000AA3901441E10 AS DateTime))
INSERT [dbo].[Shopping_Cate] ([CateID], [Name], [CreateTime]) VALUES (8, N'本子', CAST(0x0000AA3A00017EF6 AS DateTime))
SET IDENTITY_INSERT [dbo].[Shopping_Cate] OFF
/****** Object:  Table [dbo].[Shopping_Attention]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Attention](
	[AttentionID] [int] IDENTITY(1,1) NOT NULL,
	[CommodityID] [int] NULL,
	[CommodityName] [nvarchar](250) NULL,
	[UserID] [int] NULL,
	[CreateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AttentionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Attention', @level2type=N'COLUMN',@level2name=N'AttentionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Attention', @level2type=N'COLUMN',@level2name=N'CommodityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Attention', @level2type=N'COLUMN',@level2name=N'CommodityName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Attention', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Attention', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'关注信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Attention'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Attention] ON
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (10, 47, N'平凡的世界', 5, CAST(0x0000AA3D01180FBA AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (11, 85, N'小清新 圆角抄写本', 5, CAST(0x0000AA3D01258243 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (12, 45, N'追风筝的人', 4, CAST(0x0000AA3D01357574 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (13, 37, N'六个核桃/瓶', 4, CAST(0x0000AA3E00C6CBEB AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (14, 39, N'巴黎圣母院', 4, CAST(0x0000AA3E00C6D5FE AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (15, 85, N'小清新 圆角抄写本', 4, CAST(0x0000AA3E00C6E6B5 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (17, 57, N'英雄6006钢笔', 5, CAST(0x0000AA4300D94777 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (18, 30, N'红心火龙果/kg', 5, CAST(0x0000AA4300D95898 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (19, 47, N'平凡的世界', 7, CAST(0x0000AA5100BA4BE9 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (20, 45, N'追风筝的人', 8, CAST(0x0000ADCD00C48192 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (21, 89, N'毛毡活页本', 8, CAST(0x0000ADCD00C5776C AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (22, 88, N'时间表管理计划本', 8, CAST(0x0000ADCD00C57CF7 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (23, 86, N'线圈笔记本', 8, CAST(0x0000ADCD00C5889A AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (24, 79, N'康师傅冰红茶 500ml', 8, CAST(0x0000ADCD00C888C9 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (25, 34, N'娃哈哈AD钙奶', 8, CAST(0x0000ADCD00C88E5E AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (26, 83, N'达利园 青梅绿茶500ml', 8, CAST(0x0000ADCD00C8BE56 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (27, 77, N'统一绿茶  550ml', 8, CAST(0x0000ADCD00C8C4E9 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (28, 37, N'六个核桃/瓶', 8, CAST(0x0000ADCD00C8D694 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (29, 28, N'朝花夕拾', 8, CAST(0x0000ADCD00C8DBFF AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (30, 30, N'红心火龙果/kg', 8, CAST(0x0000ADCD00C8DFB3 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (31, 29, N'假如给我三天光明', 8, CAST(0x0000ADCD00C8E389 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (32, 27, N'天才在左，疯子在右', 8, CAST(0x0000ADCD00C8E955 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (34, 49, N'水蜜桃/kg', 10, CAST(0x0000ADCF00DB6EEE AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (35, 57, N'英雄6006钢笔', 10, CAST(0x0000ADCF00DB786D AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (37, 30, N'红心火龙果/kg', 11, CAST(0x0000ADCF00DED794 AS DateTime))
INSERT [dbo].[Shopping_Attention] ([AttentionID], [CommodityID], [CommodityName], [UserID], [CreateTime]) VALUES (38, 34, N'娃哈哈AD钙奶', 11, CAST(0x0000ADCF00DEDCBD AS DateTime))
SET IDENTITY_INSERT [dbo].[Shopping_Attention] OFF
/****** Object:  Table [dbo].[Shopping_Admin]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](20) NULL,
	[Password] [nvarchar](50) NULL,
	[GroupID] [int] NULL,
	[LastLoginTime] [datetime] NULL,
	[LoginTime] [datetime] NULL,
	[LoginTimes] [int] NULL,
	[Status] [int] NULL,
	[CreateTime] [datetime] NULL,
	[LastLoginIP] [nvarchar](50) NULL,
	[LoginIP] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'AdminID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'AdminName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'GroupID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'LastLoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'LoginTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'管理员信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Admin'
GO
SET IDENTITY_INSERT [dbo].[Shopping_Admin] ON
INSERT [dbo].[Shopping_Admin] ([AdminID], [AdminName], [Password], [GroupID], [LastLoginTime], [LoginTime], [LoginTimes], [Status], [CreateTime], [LastLoginIP], [LoginIP]) VALUES (6, N'admin', N'123456', 0, CAST(0x0000ADCF00E46B64 AS DateTime), CAST(0x0000ADCF00E8499F AS DateTime), 13, 0, CAST(0x0000ADCD00DABBB4 AS DateTime), N'', N'')
INSERT [dbo].[Shopping_Admin] ([AdminID], [AdminName], [Password], [GroupID], [LastLoginTime], [LoginTime], [LoginTimes], [Status], [CreateTime], [LastLoginIP], [LoginIP]) VALUES (7, N'1', N'123456', 0, CAST(0x0000ADCF00E5CE7A AS DateTime), CAST(0x0000ADCF00E5CE7A AS DateTime), 0, 0, CAST(0x0000ADCF00E5CE7A AS DateTime), N'', N'')
SET IDENTITY_INSERT [dbo].[Shopping_Admin] OFF
/****** Object:  Table [dbo].[ZaiXianBangZhu]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ZaiXianBangZhu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BiaoTi] [varchar](50) NULL,
	[NeiRong] [varchar](max) NULL,
 CONSTRAINT [PK_ZaiXianBangZhu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shopping_VisitLog]    Script Date: 10/28/2021 14:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_VisitLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CommodityID] [int] NULL,
	[Visits] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[GuestID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog', @level2type=N'COLUMN',@level2name=N'LogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图书ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog', @level2type=N'COLUMN',@level2name=N'CommodityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog', @level2type=N'COLUMN',@level2name=N'Visits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'游客' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog', @level2type=N'COLUMN',@level2name=N'GuestID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description ', @value=N'浏览信息记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_VisitLog'
GO
SET IDENTITY_INSERT [dbo].[Shopping_VisitLog] ON
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (35, 4, 22, 4, CAST(0x0000AA33001E4396 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (38, 4, 23, 2, CAST(0x0000AA3300EA7AD7 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (40, 4, 38, 3, CAST(0x0000AA3B00CC0BD1 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (41, 4, 37, 6, CAST(0x0000AA3E00DA3B44 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (42, 4, 39, 9, CAST(0x0000AA3E00DA618C AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (43, 4, 27, 1, CAST(0x0000AA3B00CBF271 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (44, 4, 36, 3, CAST(0x0000AA3B00D594B5 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (45, 4, 34, 3, CAST(0x0000AA3D01358A56 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (46, 4, 33, 1, CAST(0x0000AA3B0114C8D9 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (47, 4, 25, 4, CAST(0x0000AA3B01494AED AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (48, 4, 26, 1, CAST(0x0000AA3B011D394F AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (49, 4, 53, 1, CAST(0x0000AA3B0149219C AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (52, 5, 57, 4, CAST(0x0000AA430136696C AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (53, 5, 55, 1, CAST(0x0000AA3D00C55D9E AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (54, 5, 37, 6, CAST(0x0000AA4500083D93 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (55, 5, 47, 7, CAST(0x0000AA4300D83618 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (56, 5, 49, 3, CAST(0x0000AA4500085552 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (57, 5, 77, 3, CAST(0x0000AA41010A9C2F AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (58, 5, 58, 1, CAST(0x0000AA3D00C5CD10 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (59, 5, 87, 3, CAST(0x0000AA410132903E AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (60, 5, 24, 2, CAST(0x0000AA4301366942 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (61, 5, 45, 7, CAST(0x0000AA4300D9652F AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (62, 5, 34, 5, CAST(0x0000AA3D011BEDA6 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (63, 5, 42, 1, CAST(0x0000AA3D00DBAD3E AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (64, 5, 46, 1, CAST(0x0000AA3D0118355E AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (65, 5, 36, 4, CAST(0x0000AA3D011BD476 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (66, 5, 83, 5, CAST(0x0000AA4300D8360C AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (67, 5, 35, 2, CAST(0x0000AA3D011BBDC1 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (68, 5, 81, 1, CAST(0x0000AA3D011AC49B AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (69, 5, 78, 1, CAST(0x0000AA3D011AE210 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (70, 5, 79, 1, CAST(0x0000AA3D011AF416 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (71, 5, 82, 2, CAST(0x0000AA4101316155 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (72, 5, 80, 3, CAST(0x0000AA4101204795 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (73, 5, 91, 3, CAST(0x0000AA410137410D AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (74, 5, 85, 3, CAST(0x0000AA4300D835FB AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (75, 4, 85, 3, CAST(0x0000AA4100BF0242 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (76, 4, 45, 2, CAST(0x0000AA3E00C6BA68 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (77, 4, 83, 2, CAST(0x0000AA3E00C05C87 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (78, 4, 89, 2, CAST(0x0000AA4100C16457 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (79, 4, 88, 1, CAST(0x0000AA3E00C0548C AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (80, 4, 79, 3, CAST(0x0000AA4100C19221 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (81, 4, 51, 1, CAST(0x0000AA3E00C06A55 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (82, 4, 47, 2, CAST(0x0000AA4100C19F89 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (83, 4, 57, 3, CAST(0x0000AA3E00CC539F AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (84, 4, 58, 1, CAST(0x0000AA3E00CBF1E0 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (85, 4, 49, 1, CAST(0x0000AA4100C35B5B AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (86, 5, 84, 6, CAST(0x0000AA4101373676 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (87, 5, 90, 2, CAST(0x0000AA410130C736 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (92, 6, 47, 1, CAST(0x0000AA42014D3FD1 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (93, 6, 91, 1, CAST(0x0000AA42014D3FD5 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (94, 6, 86, 1, CAST(0x0000AA42014D3FD9 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (95, 6, 85, 1, CAST(0x0000AA42014D3FDF AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (96, 6, 37, 1, CAST(0x0000AA42014D4004 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (97, 0, 90, 1, CAST(0x0000AA4201749F71 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (106, 5, 39, 1, CAST(0x0000AA4300D83601 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (107, 5, 89, 2, CAST(0x0000AA4300D8364B AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (108, 5, 86, 1, CAST(0x0000AA4300D8361F AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (109, 5, 25, 2, CAST(0x0000AA4300D977C8 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (110, 5, 28, 2, CAST(0x0000AA4300D9802F AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (111, 5, 30, 2, CAST(0x0000AA4300D955E7 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (112, 5, 27, 2, CAST(0x0000AA4300D89FD0 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (113, 5, 26, 1, CAST(0x0000AA4300D89ADC AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (114, 5, 29, 2, CAST(0x0000AA4500086199 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (117, 5, 43, 1, CAST(0x0000AA4301366949 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (119, 7, 43, 1, CAST(0x0000AA48011C0313 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (120, 7, 52, 1, CAST(0x0000AA48011C03CE AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (121, 7, 97, 1, CAST(0x0000AA4801308EAF AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (122, 7, 98, 1, CAST(0x0000AA480130FFAD AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (125, 7, 86, 1, CAST(0x0000AA500171FFC5 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (126, 7, 96, 1, CAST(0x0000AA500171FFE9 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (127, 7, 37, 1, CAST(0x0000AA5001720098 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (128, 7, 28, 1, CAST(0x0000AA5001721AF2 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (129, 7, 25, 1, CAST(0x0000AA500172DE67 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (134, 7, 47, 2, CAST(0x0000AA5100BA4711 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (135, 7, 24, 1, CAST(0x0000AA5100BA46E5 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (136, 7, 89, 2, CAST(0x0000AA590130C808 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (137, 7, 45, 3, CAST(0x0000AA5901326B7D AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (138, 7, 39, 1, CAST(0x0000AA590132798C AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (146, 8, 84, 4, CAST(0x0000ADCF00B82995 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (147, 8, 79, 7, CAST(0x0000ADCF00B83534 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (148, 8, 29, 2, CAST(0x0000ADCD00C8E278 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (149, 8, 47, 4, CAST(0x0000ADCF00B875B7 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (150, 8, 91, 5, CAST(0x0000ADCD00D59EFC AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (151, 8, 27, 2, CAST(0x0000ADCD00C8E7E7 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (152, 8, 90, 3, CAST(0x0000ADCF00B84212 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (153, 8, 45, 2, CAST(0x0000ADCD00C87D69 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (154, 8, 89, 2, CAST(0x0000ADCD00C89872 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (155, 8, 88, 1, CAST(0x0000ADCD00C57B4A AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (156, 8, 86, 2, CAST(0x0000ADCD00C8A03A AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (157, 8, 83, 6, CAST(0x0000ADCF00B814E3 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (158, 8, 82, 2, CAST(0x0000ADCD00D57266 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (159, 8, 34, 1, CAST(0x0000ADCD00C88D24 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (160, 8, 77, 1, CAST(0x0000ADCD00C8C388 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (161, 8, 37, 2, CAST(0x0000ADCD00DE80DE AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (162, 8, 28, 2, CAST(0x0000ADCD00D99BDD AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (163, 8, 30, 1, CAST(0x0000ADCD00C8DE92 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (164, 8, 99, 8, CAST(0x0000ADCD00DE3C0D AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (165, 9, 52, 1, CAST(0x0000ADCF00B9736E AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (166, 9, 45, 1, CAST(0x0000ADCF00BA135C AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (167, 9, 79, 1, CAST(0x0000ADCF00BE0E0D AS DateTime), NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (168, 9, 42, 2, CAST(0x0000ADCF00BE8875 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (173, 10, 45, 1, CAST(0x0000ADCF00DB55E1 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (174, 10, 25, 1, CAST(0x0000ADCF00DB55E3 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (175, 10, 90, 2, CAST(0x0000ADCF00DB55E8 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (176, 10, 91, 1, CAST(0x0000ADCF00DB55E6 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (177, 10, 79, 1, CAST(0x0000ADCF00DB60FE AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (178, 10, 49, 1, CAST(0x0000ADCF00DB6CDE AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (179, 10, 57, 1, CAST(0x0000ADCF00DB75E1 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (180, 10, 83, 1, CAST(0x0000ADCF00DBBF48 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (181, 10, 82, 1, CAST(0x0000ADCF00DD853E AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (186, 11, 83, 1, CAST(0x0000ADCF00DECD71 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (187, 11, 37, 1, CAST(0x0000ADCF00DECD72 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (188, 11, 89, 1, CAST(0x0000ADCF00DECD73 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (189, 11, 91, 3, CAST(0x0000ADCF00DEFB87 AS DateTime), N'')
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (190, 11, 30, 1, CAST(0x0000ADCF00DED508 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (191, 11, 34, 1, CAST(0x0000ADCF00DEDA79 AS DateTime), NULL)
INSERT [dbo].[Shopping_VisitLog] ([LogID], [UserID], [CommodityID], [Visits], [UpdateTime], [GuestID]) VALUES (192, 11, 77, 2, CAST(0x0000ADCF00E59A04 AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[Shopping_VisitLog] OFF
/****** Object:  View [dbo].[Shopping_View_Rate]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_Rate]
AS

SELECT  R.*,U.UserName
  FROM   Shopping_Rate R LEFT JOIN Shopping_User U ON R.UserID=U.UserID
GO
/****** Object:  View [dbo].[Shopping_View_Order]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_Order]

AS

SELECT O.*,U.UserName FROM Shopping_Order O LEFT JOIN Shopping_User U ON O.UserID=U.UserID
GO
/****** Object:  View [dbo].[Shopping_View_Consult]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_Consult]

AS 

SELECT C.*,B.Photo FROM Shopping_Consult C LEFT JOIN Shopping_Commodity B ON B.CommodityID=C.CommodityID
GO
/****** Object:  View [dbo].[Shopping_View_Commodity]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_Commodity]

AS

SELECT B.*,C.Name CateName,U.UserName,U.RealName FROM Shopping_Commodity B LEFT JOIN Shopping_Cate C ON B.CateID=C.CateID left join Shopping_User U on B.UserID=U.UserID
GO
/****** Object:  View [dbo].[Shopping_View_Attention]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_Attention]
 
 AS
 
 SELECT A.*,B.Photo FROM Shopping_Attention A LeFT JOIN Shopping_Commodity B ON A.CommodityID=B.CommodityID
GO
/****** Object:  View [dbo].[Shopping_View_VisitLog]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_VisitLog]

AS

SELECT V.*,B.Photo,B.Name,B.Price,B.MarketPrice FROM Shopping_VisitLog V Left Join Shopping_Commodity B ON V.CommodityID=B.CommodityID
GO
/****** Object:  View [dbo].[Shopping_View_Snapshot]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_Snapshot]
AS
SELECT S.*,O.UserName,B.CommodityNo,B.Name, B.Point, B.Photo,O.UserID,O.Status,R.Grade,B.Stock
  FROM Shopping_Snapshot S LEFT JOIN Shopping_View_Order O ON S.OrderID=O.OrderID LEFT JOIN Shopping_View_Commodity B ON S.CommodityID=B.CommodityID Left JOIN Shopping_Rate R ON S.SnapshotID=R.SnapshotID
GO
/****** Object:  View [dbo].[Shopping_View_ShoppingCart]    Script Date: 10/28/2021 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Shopping_View_ShoppingCart]
AS

SELECT S.*,
		B.Name,
		B.Photo,
		B.UserID ShopID,
		B.Stock
  FROM Shopping_ShoppingCart S LEFT JOIN Shopping_View_Commodity B ON S.CommodityID=B.CommodityID
GO
/****** Object:  Default [DF_BookShop_ShoppingCart_IsChecked]    Script Date: 10/28/2021 14:14:43 ******/
ALTER TABLE [dbo].[Shopping_ShoppingCart] ADD  CONSTRAINT [DF_BookShop_ShoppingCart_IsChecked]  DEFAULT ((0)) FOR [IsChecked]
GO
/****** Object:  Default [DF_BookShop_Order_UserPoint]    Script Date: 10/28/2021 14:14:43 ******/
ALTER TABLE [dbo].[Shopping_Order] ADD  CONSTRAINT [DF_BookShop_Order_UserPoint]  DEFAULT ((0)) FOR [UserPoint]
GO
/****** Object:  Default [DF_Shopping_Order_ShopID]    Script Date: 10/28/2021 14:14:43 ******/
ALTER TABLE [dbo].[Shopping_Order] ADD  CONSTRAINT [DF_Shopping_Order_ShopID]  DEFAULT ((0)) FOR [ShopID]
GO
/****** Object:  Default [DF_BookShop_Book_SaleTotal]    Script Date: 10/28/2021 14:14:43 ******/
ALTER TABLE [dbo].[Shopping_Commodity] ADD  CONSTRAINT [DF_BookShop_Book_SaleTotal]  DEFAULT ((0)) FOR [SaleTotal]
GO
/****** Object:  Default [DF_BookShop_Book_Visits]    Script Date: 10/28/2021 14:14:43 ******/
ALTER TABLE [dbo].[Shopping_Commodity] ADD  CONSTRAINT [DF_BookShop_Book_Visits]  DEFAULT ((0)) FOR [Visits]
GO
