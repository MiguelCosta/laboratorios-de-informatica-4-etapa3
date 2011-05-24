
							/* SCRIPT TO DROP TABLES */

/***************************************************************************************/
/* Table Software_list*/
USE [LI4]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_software_list_caracteristics]') AND parent_object_id = OBJECT_ID(N'[dbo].[software_list]'))
ALTER TABLE [dbo].[software_list] DROP CONSTRAINT [FK_software_list_caracteristics]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_software_list_software]') AND parent_object_id = OBJECT_ID(N'[dbo].[software_list]'))
ALTER TABLE [dbo].[software_list] DROP CONSTRAINT [FK_software_list_software]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[software_list]    Script Date: 05/24/2011 16:36:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[software_list]') AND type in (N'U'))
DROP TABLE [dbo].[software_list]
GO



/***************************************************************************************/
/* Table Software*/
USE [LI4]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_software_user]') AND parent_object_id = OBJECT_ID(N'[dbo].[software]'))
ALTER TABLE [dbo].[software] DROP CONSTRAINT [FK_software_user]
GO

USE [LI4]
GO

/****** Object:  Table [dbo].[software]    Script Date: 05/24/2011 16:37:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[software]') AND type in (N'U'))
DROP TABLE [dbo].[software]
GO


/***************************************************************************************/
/* Table caracteristics*/
USE [LI4]
GO

/****** Object:  Table [dbo].[caracteristics]    Script Date: 05/24/2011 16:38:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[caracteristics]') AND type in (N'U'))
DROP TABLE [dbo].[caracteristics]
GO


/***************************************************************************************/
/* Table user*/
USE [LI4]
GO

/****** Object:  Table [dbo].[user]    Script Date: 05/24/2011 16:39:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user]') AND type in (N'U'))
DROP TABLE [dbo].[user]
GO


