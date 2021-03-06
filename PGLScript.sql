/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[UserLogin]
GO
/****** Object:  StoredProcedure [dbo].[UserDetails]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[UserDetails]
GO
/****** Object:  StoredProcedure [dbo].[SearchPilot]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[SearchPilot]
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[GetUserById]
GO
/****** Object:  StoredProcedure [dbo].[GetStaffById]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[GetStaffById]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[GetAllUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetAllStaffs]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[GetAllStaffs]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[DeleteUser]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStaff]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[DeleteStaff]
GO
/****** Object:  StoredProcedure [dbo].[Booking_GetAllByStaffID]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[Booking_GetAllByStaffID]
GO
/****** Object:  StoredProcedure [dbo].[Booking_GetAll]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[Booking_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Booking_CheckAvailability]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[Booking_CheckAvailability]
GO
/****** Object:  StoredProcedure [dbo].[Booking_Cancel]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[Booking_Cancel]
GO
/****** Object:  StoredProcedure [dbo].[Booking_AddUpdate]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[Booking_AddUpdate]
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateUser]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[AddUpdateUser]
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateStaff]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP PROCEDURE [dbo].[AddUpdateStaff]
GO
ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [df_DefCanc]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[Staffs]
GO
/****** Object:  Table [dbo].[BookingPilotMapping]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[BookingPilotMapping]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[Booking]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetUserTokens]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitStaffIDString]    Script Date: 5/7/2018 5:53:22 PM ******/
DROP FUNCTION [dbo].[SplitStaffIDString]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitStaffIDString]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitStaffIDString]
 (@String varchar(8000), @Delimiter char(1))       
 returns @temptable TABLE (items varchar(100))       
 AS       
 BEGIN       
     DECLARE @idx int       
     DECLARE @slice varchar(8000)       

     Select @idx = 1       
         if len(@String)<1 or @String is null  return       

     while @idx!= 0       
     BEGIN       
         set @idx = charindex(@Delimiter,@String)       
         if @idx!=0       
             set @slice = left(@String,@idx - 1)       
         else       
             set @slice = @String       

         if(len(@slice)>0)  
             Insert into @temptable(Items) values(@slice)       

         set @String = right(@String,len(@String) - @idx)       
         if len(@String) = 0 break       
     END   
  return 
 END
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[DeletedOn] [datetime2](7) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[RegisteredDate] [datetime2](7) NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookedOn] [datetime] NOT NULL,
	[BookedFor] [datetime] NOT NULL,
	[IsCanceled] [bit] NOT NULL,
	[CanceledOn] [datetime] NULL,
	[BookedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[BookingPilotMapping]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingPilotMapping](
	[BookPilotMappingID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
 CONSTRAINT [PK_BookingPilotMapping] PRIMARY KEY CLUSTERED 
(
	[BookPilotMappingID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](150) NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Designation] [nvarchar](255) NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NULL,
	[DeletedOn] [datetime] NULL,
	[Photo] [nvarchar](255) NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](255) NOT NULL,
	[RoleType] [int] NOT NULL,
	[RegisteredDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NULL,
	[DeletedOn] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180504105950_InitialUser', N'2.0.2-rtm-10011')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'1678a681-deaa-40c1-9503-6e66db764627', N'50f07df6-34b7-4711-ab93-ee028288d6ed', N'Client', N'CLIENT')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'4bf436c6-ecc0-426a-9b3a-10d3abd3b9d9', N'0b614292-e7c6-4503-9f74-91b020295fc9', N'Staff', N'STAFF')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'98af9590-4ab2-48ee-bf19-e86d95ba16b5', N'c6e68da0-a2a5-481d-b002-29d6f0ad1bd6', N'Superuser', N'SUPERUSER')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'47f9ba40-d8e1-40d4-bd4a-8f9599b1ba95', N'1678a681-deaa-40c1-9503-6e66db764627')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f5ed4093-ab4a-414f-acdf-23c033988c6a', N'1678a681-deaa-40c1-9503-6e66db764627')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6845ed3f-6b20-45ce-937c-0c53f34edfad', N'98af9590-4ab2-48ee-bf19-e86d95ba16b5')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DeletedOn], [Email], [EmailConfirmed], [FirstName], [IsDeleted], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [RegisteredDate], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'47f9ba40-d8e1-40d4-bd4a-8f9599b1ba95', 0, N'016b2fff-7b05-4a51-b65d-c7e897578c4e', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), N'test@gmail.com', 0, N'Test', 0, N'Test', 1, NULL, N'TEST@GMAIL.COM', N'TEST@GMAIL.COM', N'AQAAAAEAACcQAAAAEKwn2wRf8EEzaBVG1h0DOeEMTj/UUjcFnsfrwmkHJbtuKIF+c6F8MQ/IIIzM3c7R6A==', N'+9779823456712', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), N'06a2dbb1-e82b-4f40-8bc7-b671d8db75a1', 0, N'test@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DeletedOn], [Email], [EmailConfirmed], [FirstName], [IsDeleted], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [RegisteredDate], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'6845ed3f-6b20-45ce-937c-0c53f34edfad', 0, N'f385f057-00dc-4714-872d-e28c03ca7437', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), N'superuser@gmail.com', 0, N'superuser', 0, N'superuser', 1, NULL, N'SUPERUSER@GMAIL.COM', N'SUPERUSER', N'AQAAAAEAACcQAAAAEKeR9JQ7FpRR9FVfQoTLgUdFtn9Dzbow4VtqlXLK0iQXnOCpTqOkeB3gDqykwCK0ig==', N'+9779823456712', 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), N'9288a5e0-30fd-4704-9286-b66bf4687b02', 0, N'superuser')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DeletedOn], [Email], [EmailConfirmed], [FirstName], [IsDeleted], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [RegisteredDate], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'f5ed4093-ab4a-414f-acdf-23c033988c6a', 0, N'b2daa2b9-b7a1-410c-b280-13756b6c2283', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), N'elijah@outlook.com', 0, N'Elijah', 0, N'Mikaelson', 1, NULL, N'ELIJAH@OUTLOOK.COM', N'ELIJAH', N'AQAAAAEAACcQAAAAEPuLm7yCtJbi+XP7h6g/gqad7E6GHnJLvHbNF/tUvUddkrdVpNQRoUcTnV8xD1t+DQ==', N'234789', 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), N'83414c2b-d71e-4911-a7ef-933193085a0e', 0, N'elijah')
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookID], [BookedOn], [BookedFor], [IsCanceled], [CanceledOn], [BookedBy]) VALUES (1, CAST(N'2018-05-07 17:10:26.440' AS DateTime), CAST(N'2018-05-07 00:00:00.000' AS DateTime), 0, CAST(N'2018-05-07 17:47:31.143' AS DateTime), N'6845ed3f-6b20-45ce-937c-0c53f34edfad')
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[BookingPilotMapping] ON 

INSERT [dbo].[BookingPilotMapping] ([BookPilotMappingID], [BookID], [StaffID]) VALUES (1, 1, 1)
INSERT [dbo].[BookingPilotMapping] ([BookPilotMappingID], [BookID], [StaffID]) VALUES (2, 1, 2)
INSERT [dbo].[BookingPilotMapping] ([BookPilotMappingID], [BookID], [StaffID]) VALUES (3, 1, 5)
SET IDENTITY_INSERT [dbo].[BookingPilotMapping] OFF
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([StaffID], [UserID], [FirstName], [LastName], [Address], [Phone], [Email], [Designation], [HireDate], [IsDeleted], [DeletedOn], [Photo]) VALUES (1, N'6845ed3f-6b20-45ce-937c-0c53f34edfad', N'Karan', N'Shahi', N'Pokhara', N'9234', N'kiran.shahi@gmail.com', N'Pilot', CAST(N'2018-04-07 22:05:46.427' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Staffs] ([StaffID], [UserID], [FirstName], [LastName], [Address], [Phone], [Email], [Designation], [HireDate], [IsDeleted], [DeletedOn], [Photo]) VALUES (2, N'6845ed3f-6b20-45ce-937c-0c53f34edfad', N'Diran', N'Shahi', N'Pokhara', N'9234', N'kiran.shahi@gmail.com', N'Pilot', CAST(N'2018-04-07 22:11:04.810' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Staffs] ([StaffID], [UserID], [FirstName], [LastName], [Address], [Phone], [Email], [Designation], [HireDate], [IsDeleted], [DeletedOn], [Photo]) VALUES (3, N'6845ed3f-6b20-45ce-937c-0c53f34edfad', N'Kiran', N'Shahi', N'Pokhara', N'9234', N'kiran.shahi@gmail.com', N'Operation', CAST(N'2018-04-07 22:13:54.383' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Staffs] ([StaffID], [UserID], [FirstName], [LastName], [Address], [Phone], [Email], [Designation], [HireDate], [IsDeleted], [DeletedOn], [Photo]) VALUES (4, N'6845ed3f-6b20-45ce-937c-0c53f34edfad', N'Kiran', N'Shahi', N'Pokhara', N'9234', N'kiran.shahi@gmail.com', N'Operation', CAST(N'2018-04-07 22:25:34.330' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Staffs] ([StaffID], [UserID], [FirstName], [LastName], [Address], [Phone], [Email], [Designation], [HireDate], [IsDeleted], [DeletedOn], [Photo]) VALUES (5, N'6845ed3f-6b20-45ce-937c-0c53f34edfad', N'Klaus', N'Mikaelson', N'New Orleans', N'7878', N'klaus@gmail.com', N'Pilot', CAST(N'2018-05-06 11:16:11.110' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [RoleType], [RegisteredDate], [IsDeleted], [DeletedOn]) VALUES (1, N'Supreuser', N'Superuser', N'superuser', N'superuser', N'superuer', 1, CAST(N'2018-04-05 22:19:54.913' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [RoleType], [RegisteredDate], [IsDeleted], [DeletedOn]) VALUES (2, N'Kiran', N'Shahi', N'kiran.shahi.c3@gmail.com', N'kiran', N'44235', 3, CAST(N'2018-04-07 11:18:09.203' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [RoleType], [RegisteredDate], [IsDeleted], [DeletedOn]) VALUES (3, N'test', N'test', N'test@gmail.com', N'test', N'98989', 3, CAST(N'2018-04-07 11:22:29.027' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [RoleType], [RegisteredDate], [IsDeleted], [DeletedOn]) VALUES (4, N'test1', N'test1', N'test1@outlook.com', N'test1', N'test1', 3, CAST(N'2018-04-07 11:23:28.900' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Booking] ADD  CONSTRAINT [df_DefCanc]  DEFAULT ((0)) FOR [IsCanceled]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateStaff]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddUpdateStaff]
	@staffID INT,
	@firstName NVARCHAR(255),
	@lastName NVARCHAR(255),
	@address NVARCHAR(255),
	@phone NVARCHAR(255),
	@email NVARCHAR(255),
	@designation NVARCHAR(255),
	@status INT OUT
AS
BEGIN
	SET NOCOUNT ON;
	IF @staffID = 0
		IF EXISTS (SELECT Id FROM AspNetUsers WHERE Email = @email)
			BEGIN
				--- SET status 0 when staff already exists ---
				SET @status = 0
			END
		ELSE
			BEGIN
				INSERT INTO Staffs (FirstName, LastName, Address, Phone, Email, Designation, HireDate) 
				VALUES (@firstName, @lastName, @address,  @phone, @email, @designation, GETDATE())
				--- SET status 1 when staff added successfully. ---
				SET @status = 1;
			END
	ELSE
		BEGIN
			UPDATE Staffs
			SET FirstName = @firstName, LastName = @lastName, Address = @address, Phone = @phone, Email = @email, Designation = @designation WHERE StaffID = @staffID;
			--- SET status 2 when staff updated successfully. ---
			SET @status = 2;
		END
END

GO
/****** Object:  StoredProcedure [dbo].[AddUpdateUser]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddUpdateUser]
	@userID INT,
	@firstName NVARCHAR(255),
	@lastName NVARCHAR(255),
	@email NVARCHAR(255),
	@password NVARCHAR(255),
	@phone NVARCHAR(255),
	@roleType INT,
	@status INT OUT
AS
BEGIN
	SET NOCOUNT ON;
	IF @userID = 0
		IF EXISTS (SELECT Id FROM AspNetUsers WHERE Email = @email)
			BEGIN
				--- SET status 0 when user already exists ---
				SET @status = 0
			END
		ELSE
			BEGIN
				INSERT INTO Users (FirstName, LastName, Email, Password, Phone, RegisteredDate, RoleType) 
				VALUES (@firstName, @lastName, @email, @password, @phone, GETDATE(), @roleType)
				--- SET status 1 when user added successfully. ---
				SET @status = 1;
			END
	ELSE
		BEGIN
			UPDATE Users 
			SET FirstName = @firstName, LastName = @lastName, Email = @email, Phone = @phone WHERE UserID = @userID;
			--- SET status 2 when user updated successfully. ---
			SET @status = 2;
		END
END

GO
/****** Object:  StoredProcedure [dbo].[Booking_AddUpdate]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Booking_AddUpdate](
@BookID INT,
@BookedFors DATE,
@BookedBy NVARCHAR(150),
@StaffIDs NVARCHAR(150),
@status INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @BookIDs INT, @BookStatus INT, @IntLocation INT, @StaffID INT;
	IF @BookID = 0
	BEGIN
	BEGIN TRANSACTION
BEGIN TRY
SELECT @BookStatus = COUNT(StaffID) FROM [Booking] AS BK INNER JOIN [BookingPilotMapping] BPM ON BK.BookID = BPM.BookID WHERE BK.BookedFor = @BookedFors AND StaffID IN (SELECT Items FROM [dbo].[SplitStaffIDString](@StaffIDs, ','));
   IF @BookStatus = 0
   BEGIN
      INSERT INTO [dbo].[Booking]([BookedFor], [BookedOn], [BookedBy]) VALUES(@BookedFors, GETDATE(), @BookedBy);
      SELECT @BookIDs = SCOPE_IDENTITY();
   	WHILE (CHARINDEX(',',    @StaffIDs, 1) > 0)
        BEGIN
              SET @IntLocation =   CHARINDEX(',',    @StaffIDs, 0)   		  
			  INSERT INTO [dbo].[BookingPilotMapping]([StaffID], [BookID])
			    SELECT RTRIM(LTRIM(SUBSTRING(@StaffIDs,   0, @IntLocation))), @BookIDs
              SET @StaffIDs = STUFF(@StaffIDs,   1, @IntLocation,   '') 
        END
   SET @status = 0;
   END
   ELSE
   BEGIN
   SET @status = 1;
   END
 COMMIT TRANSACTION;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ERRORMESSAGE;
   ROLLBACK TRANSACTION;
END CATCH;
	END
	ELSE
	BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	UPDATE [dbo].[Booking] SET [BookedOn] = GETDATE(), [BookedFor] = @BookedFors, [BookedBy] = @BookedBy;
    UPDATE [dbo].[BookingPilotMapping] SET [BookID] = @BookID, [StaffID] = @StaffID;
	SET @status = 2;
 COMMIT TRANSACTION;
END TRY
BEGIN CATCH
        ROLLBACK TRANSACTION;
END CATCH;	
	END
	END;    

GO
/****** Object:  StoredProcedure [dbo].[Booking_Cancel]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Booking_Cancel] (
@BookID INT
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [Booking] SET IsCanceled = 1, CanceledOn = GETDATE() WHERE BookID = @BookID;
END

GO
/****** Object:  StoredProcedure [dbo].[Booking_CheckAvailability]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Booking_CheckAvailability]
@BookedFor DATE,
@StaffID INT,
@status INT OUT
AS
BEGIN
Declare @BookStatus INT;
SELECT @BookStatus = COUNT(StaffID) FROM [Booking] AS BK INNER JOIN [BookingPilotMapping] BPM ON BK.BookID = BPM.BookID WHERE BK.BookedFor = @BookedFor AND StaffID = @StaffID;
IF @BookStatus = 0
BEGIN 
SET @status = 0;
END
ELSE
BEGIN
SET @status = 1;
END
END

GO
/****** Object:  StoredProcedure [dbo].[Booking_GetAll]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Booking_GetAll]	
AS
BEGIN
	SET NOCOUNT ON;
SELECT Aur.UserId, Aur.RoleId, Au.UserName, Ar.Name AS RoleName, St.StaffID, St.FirstName, St.Designation, Bpm.BookID, Bk.BookedOn, Bk.BookedFor
 FROM AspNetUsers Au INNER JOIN
  AspNetUserRoles Aur ON Au.Id = Aur.UserId INNER JOIN AspNetRoles  Ar ON Aur.RoleId = Ar.Id INNER JOIN
  Staffs St ON Au.Id = St.UserID INNER JOIN
BookingPilotMapping Bpm ON St.StaffID = Bpm.StaffID INNER JOIN Booking Bk ON Bpm.BookId = Bk.BookId WHERE Bk.IsCanceled = 0;
END

GO
/****** Object:  StoredProcedure [dbo].[Booking_GetAllByStaffID]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Booking_GetAllByStaffID]
(
@StaffID INT
)
AS
BEGIN
	SET NOCOUNT ON;
SELECT Aur.UserId, Aur.RoleId, Au.UserName, Ar.Name AS RoleName, St.StaffID, St.FirstName, St.Designation, Bpm.BookID, Bk.BookedOn, Bk.BookedFor
 FROM AspNetUsers Au INNER JOIN
  AspNetUserRoles Aur ON Au.Id = Aur.UserId INNER JOIN AspNetRoles  Ar ON Aur.RoleId = Ar.Id INNER JOIN
  Staffs St ON Au.Id = St.UserID INNER JOIN
BookingPilotMapping Bpm ON St.StaffID = Bpm.StaffID INNER JOIN Booking Bk ON Bpm.BookId = Bk.BookId WHERE Bk.IsCanceled = 0 AND St.StaffID = @StaffID;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteStaff]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStaff]
@StaffID int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Staffs SET IsDeleted = 1, DeletedOn = GETDATE() WHERE StaffID = @StaffID;
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
@UserID int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users SET IsDeleted = 1, DeletedOn = GETDATE() WHERE UserID = @UserID;
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllStaffs]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- EXEC GetAllStaffs 
CREATE PROCEDURE [dbo].[GetAllStaffs]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Staffs;
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM AspNetUsers;
END


GO
/****** Object:  StoredProcedure [dbo].[GetStaffById]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStaffById]
@staffId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Staffs WHERE StaffID = @staffId
END


GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserById]
@userId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Users WHERE UserID = @userId
END


GO
/****** Object:  StoredProcedure [dbo].[SearchPilot]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- EXEC SearchPilot 0
CREATE PROCEDURE [dbo].[SearchPilot]
@dateTime DATE,
@offSet INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Staffs WHERE Designation = 'Pilot'
	ORDER BY StaffID
	OFFSET @offSet * 10 ROWS
	FETCH NEXT 10 ROWS ONLY;
END


GO
/****** Object:  StoredProcedure [dbo].[UserDetails]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- EXEC UserDetails 'test1@outlook.com'
CREATE PROCEDURE [dbo].[UserDetails]
	@email NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Users WHERE Email = @email AND IsDeleted = 0;
END


GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 5/7/2018 5:53:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserLogin]
	@email NVARCHAR(255),
	@password NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT(UserID) FROM Users WHERE Email = @email AND Password = @password AND IsDeleted = 0;
END


GO
