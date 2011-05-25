
							/* SCRIPT TO CREATE TABLES */

/***************************************************************************************/
/* Table User */
USE [LI4]
GO

/****** Object:  Table [dbo].[user]    Script Date: 05/25/2011 11:50:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user]') AND type in (N'U'))
DROP TABLE [dbo].[user]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[user]    Script Date: 05/25/2011 11:50:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[user](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[regist_date] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




/***************************************************************************************/
/* Table Caracteristics */
USE [LI4]
GO

/****** Object:  Table [dbo].[caracteristics]    Script Date: 05/25/2011 11:49:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[caracteristics]') AND type in (N'U'))
DROP TABLE [dbo].[caracteristics]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[caracteristics]    Script Date: 05/25/2011 11:49:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[caracteristics](
	[caracteristics_id] [int] NOT NULL,
	[caracteristics_type] [varchar](50) NOT NULL,
	[catacyeristics_name] [varchar](150) NOT NULL,
	[value] [varchar](50) NULL,
	[value_order] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO





/***************************************************************************************/
/* Table Software */
USE [LI4]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_software_user]') AND parent_object_id = OBJECT_ID(N'[dbo].[software]'))
ALTER TABLE [dbo].[software] DROP CONSTRAINT [FK_software_user]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[software]    Script Date: 05/25/2011 11:49:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[software]') AND type in (N'U'))
DROP TABLE [dbo].[software]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[software]    Script Date: 05/25/2011 11:49:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[software](
	[id_software] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[link] [varchar](200) NOT NULL,
	[username] [varchar](50) NOT NULL,
 CONSTRAINT [PK_software] PRIMARY KEY CLUSTERED 
(
	[id_software] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[software]  WITH CHECK ADD  CONSTRAINT [FK_software_user] FOREIGN KEY([username])
REFERENCES [dbo].[user] ([username])
GO

ALTER TABLE [dbo].[software] CHECK CONSTRAINT [FK_software_user]
GO

/***************************************************************************************/
/* Table Software_list */
USE [LI4]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_software_list_software]') AND parent_object_id = OBJECT_ID(N'[dbo].[software_list]'))
ALTER TABLE [dbo].[software_list] DROP CONSTRAINT [FK_software_list_software]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[software_list]    Script Date: 05/25/2011 11:50:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[software_list]') AND type in (N'U'))
DROP TABLE [dbo].[software_list]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[software_list]    Script Date: 05/25/2011 11:50:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[software_list](
	[id_software] [int] NULL,
	[caracteristics_id] [int] NULL,
	[caracteristics_value] [varchar](150) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[software_list]  WITH CHECK ADD  CONSTRAINT [FK_software_list_software] FOREIGN KEY([id_software])
REFERENCES [dbo].[software] ([id_software])
GO

ALTER TABLE [dbo].[software_list] CHECK CONSTRAINT [FK_software_list_software]
GO
