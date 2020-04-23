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
		firstName	varchar(100)	NOT NULL,
		lastName	varchar(100)	NOT NULL,
		email		varchar(100)	NOT NULL,
		[password]	nvarchar(100)	NOT NULL,
		[address]	varchar(100)	NOT NULL,
		rating		DECIMAL(2,2)
)
GO

CREATE TABLE [dbo].[tblListings] (
		listingId		INT					NOT NULL	PRIMARY KEY		IDENTITY,
		userId			INT					NOT NULL,
		title			varchar(100)		NOT NULL,
		price			INT					NOT NULL	DEFAULT(0),
		category		varchar(50)			NOT NULL,
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

CREATE PROCEDURE spValidateLogin
	@email   varchar(100),
	@password   nvarchar(100),
	@success INT OUTPUT
AS    BEGIN
	IF EXISTS(SELECT NULL FROM tblUsers WHERE (email = @email) AND (password = @password)) BEGIN
		SET @success = (SELECT userId FROM tblUsers WHERE (email = @email) AND (password = @password))
	END ELSE BEGIN
		SET @success = 0 
	END
END
GO

CREATE PROCEDURE spCreateAccount
	@firstName   varchar(100),
	@lastName   varchar(100),
	@email   varchar(100),
	@password   nvarchar(100),
	@address varchar(100),
	@success BIT OUTPUT
AS    BEGIN
	IF EXISTS(SELECT NULL FROM tblUsers WHERE (email = @email)) BEGIN
		SET @success = 0
	END ELSE BEGIN
		INSERT INTO tblUsers(firstName, lastName, email, [password], [address]) VALUES (@firstName, @lastName, @email, @password, @address)
		SET @success = 1 
	END
END
GO

CREATE PROCEDURE spGetCart
	@userId INT
AS    BEGIN
	IF EXISTS(SELECT NULL FROM tblCart WHERE (userId = @userId)) BEGIN
		SELECT -1
	END ELSE BEGIN
		SELECT l.* FROM listings l, cart c WHERE c.userId = @userId AND l.listingId = c.listingId
	END
END
GO

CREATE PROCEDURE spAddRemoveCart
	@userId INT,
	@listingId INT
AS    BEGIN
	IF EXISTS(SELECT NULL FROM tblCart WHERE (listingId = @listingId)) BEGIN
		DELETE FROM tblCart WHERE listingId = @listingId
	END ELSE BEGIN
		INSERT INTO tblCart(listingId, userId) VALUES (@listingId, @userId)
	END
END
GO

CREATE PROCEDURE spGetWishlist
	@userId INT
AS    BEGIN
	IF EXISTS(SELECT NULL FROM tblWishList WHERE (userId = @userId)) BEGIN
		SELECT -1
	END ELSE BEGIN
		SELECT l.* FROM listings l, tblWishList w WHERE w.userId = @userId AND l.listingId = w.listingId
	END
END
GO

CREATE PROCEDURE spAddRemoveWishlist
	@userId INT,
	@listingId INT
AS    BEGIN
	IF EXISTS(SELECT NULL FROM tblWishList WHERE (listingId = @listingId)) BEGIN
		DELETE FROM tblWishList WHERE listingId = @listingId
	END ELSE BEGIN
		INSERT INTO tblWishList(listingId, userId) VALUES (@listingId, @userId)
	END
END
GO

CREATE PROCEDURE spGetListings
AS    BEGIN
	SELECT * FROM tblListings
END
GO