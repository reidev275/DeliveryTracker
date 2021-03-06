/****** Object:  Table [dbo].[Delivery]    Script Date: 6/13/2013 11:46:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Delivery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[Date] [datetime] NOT NULL,
	[SeqNum] [int] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[Company] [varchar](80) NULL,
	[Salesman] [varchar](20) NULL,
	[Addr1] [varchar](50) NULL,
	[Addr2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](2) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](20) NULL,
	[Contact] [varchar](50) NULL,
	[PoNumber] [varchar](20) NULL,
	[Signature] [varchar](max) NULL,
	[Truck] [int] NOT NULL,
	[Completed] [datetime] NULL,
	[Printed] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryItem]    Script Date: 6/13/2013 11:46:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeliveryItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Allocated] [float] NOT NULL,
	[Delivered] [float] NOT NULL,
	[UnitOfMeasure] [varchar](20) NULL,
	[Line] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeviceAuthentication]    Script Date: 6/13/2013 11:46:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeviceAuthentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[IsValid] [bit] NOT NULL,
	[Name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/13/2013 11:46:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Hash] [varchar](30) NOT NULL,
	[Salt] [varchar](40) NOT NULL,
	[HintQuestion] [varchar](50) NOT NULL,
	[HintAnswer] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAuthentication]    Script Date: 6/13/2013 11:46:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAuthentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](40) NOT NULL,
	[UserId] [int] NOT NULL,
	[truck] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DeviceAuthentication] ADD  DEFAULT ((1)) FOR [IsValid]
GO
ALTER TABLE [dbo].[UserAuthentication] ADD  CONSTRAINT [ColumnDefault_fe7430db-e03d-41e0-9d73-7444779c981b]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[UserAuthentication] ADD  CONSTRAINT [ColumnDefault_e9cacad9-25a8-4f9c-889c-f3addf795290]  DEFAULT (getdate()) FOR [Updated]
GO
ALTER TABLE [dbo].[DeliveryItem]  WITH CHECK ADD FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Delivery] ([Id])
GO
