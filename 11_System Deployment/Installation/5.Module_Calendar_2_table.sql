/****** Object:  Table [dbo].[Appointment]    Script Date: 06/23/2010 15:49:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](4000) NOT NULL,
	[StartTime] [datetime] NOT NULL CONSTRAINT [DF_Table_1_Start]  DEFAULT (getdate()),
	[EndTime] [datetime] NOT NULL CONSTRAINT [DF_Table_1_End]  DEFAULT (getdate()),
	[RecurrenceRule] [nvarchar](4000) NULL,
	[RecurrenceParentID] [int] NULL,
	[AppointmentTypeId] [int] NOT NULL CONSTRAINT [DF_Appointment_AppointmentTypeId]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Appointment_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Appointment_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Appointment_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Appointment_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Calendar]
) ON [Calendar]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppointmentType]    Script Date: 06/23/2010 15:49:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppointmentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AppointmentType_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AppointmentType_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AppointmentType_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AppointmentType_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AppointmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Calendar]
) ON [Calendar]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 06/23/2010 15:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Room_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Room_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Room_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Room_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Calendar]
) ON [Calendar]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomBooking]    Script Date: 06/23/2010 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](4000) NOT NULL,
	[StartTime] [datetime] NOT NULL CONSTRAINT [DF_RoomBooking_StartTime]  DEFAULT (getdate()),
	[EndTime] [datetime] NOT NULL CONSTRAINT [DF_RoomBooking_EndTime]  DEFAULT (getdate()),
	[RecurrenceRule] [nvarchar](4000) NULL,
	[RecurrenceParentID] [int] NULL,
	[RoomId] [int] NOT NULL CONSTRAINT [DF_Table_1_AppointmentTypeId]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_RoomBooking_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_RoomBooking_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_RoomBooking_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_RoomBooking_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_RoomBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Calendar]
) ON [Calendar]
GO
SET ANSI_PADDING OFF
GO
