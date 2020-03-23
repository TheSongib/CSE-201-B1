USE master
GO

IF DB_ID('Store') IS NOT NULL	DROP DATABASE Store
GO

CREATE DATABASE Store
GO

USE [Store]
GO

CREATE TABLE [dbo].[tblUsers] (
		userId		INT				NOT NULL	PRIMARY KEY		IDENTITY,
		email		varchar(100)	NOT NULL,
		[password]	varchar(100)	NOT NULL,
		[address]	varchar(50)		NOT NULL
)
GO

CREATE TABLE [dbo].[tblListings] (
		listingId		INT					NOT NULL	 PRIMARY KEY		IDENTITY,
		userId			INT					NOT NULL,
		title			varchar(100)		NOT NULL,
		decscription	varchar(1000)
)
GO

CREATE TABLE [dbo].[tblImages] (
		imageId		INT					NOT NULL	 PRIMARY KEY		IDENTITY,
		listingId	INT					NOT NULL,
		imageName	VARCHAR(50)			NOT NULL
)
GO

CREATE TABLE [dbo].[tblCart] (
		cartId		INT					NOT NULL	 PRIMARY KEY		IDENTITY,
		userId		INT					NOT NULL,
		listingId	INT					NOT NULL
)
GO

CREATE TABLE [dbo].[tblWishList] (
		wishListId		INT					NOT NULL	 PRIMARY KEY		IDENTITY,
		userId			INT					NOT NULL,
		listingId		INT					NOT NULL
)
GO

