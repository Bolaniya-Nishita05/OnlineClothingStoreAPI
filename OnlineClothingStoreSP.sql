------------------------------Brand------------------------------
--1)SELECT ALL
create procedure [dbo].[PR_Brand_SelectAll]
as
begin
	select
		[dbo].[Brand].[BrandID],
		[dbo].[Brand].[BrandName],
		[dbo].[Brand].[Description]
	from [dbo].[Brand]
end

--2)GET BY ID
create procedure [dbo].[PR_Brand_GetByID]
    @BrandID int
as
begin
    select
        [dbo].[Brand].[BrandID],
        [dbo].[Brand].[BrandName],
        [dbo].[Brand].[Description]
    from [dbo].[Brand]
    where [dbo].[Brand].[BrandID] = @BrandID
end

--3)INSERT
create procedure [dbo].[PR_Brand_Insert]
    @BrandName varchar(50),
    @Description varchar(100)
as
begin
    insert into [dbo].[Brand] (
        [BrandName],
        [Description]
    )
    values (
        @BrandName,
        @Description
    )
end

--4)UPDATE
alter procedure [dbo].[PR_Brand_Update]
    @BrandID int,
    @BrandName nvarchar(50),
    @Description nvarchar(100)
as
begin
    update [dbo].[Brand]
    set 
        [BrandName] = @BrandName,
        [Description] = @Description
    where 
        [BrandID] = @BrandID
end

--5)DELETE
create procedure [dbo].[PR_Brand_Delete]
    @BrandID int
as
begin
    delete from [dbo].[Brand]
    where [BrandID] = @BrandID
end

--6)DROPDOWN
create procedure [dbo].[PR_Brand_Dropdown]
as
begin
    select 
        [BrandID], 
        [BrandName]
    from [dbo].[Brand]
end


------------------------------Category------------------------------
--1)SELECT ALL
create procedure [dbo].[PR_Category_SelectAll]
as
begin
	select
		[dbo].[Category].[CategoryID],
		[dbo].[Category].[CategoryName],
		[dbo].[Category].[Description]
	from [dbo].[Category]
end

--2)GET BY ID
create procedure [dbo].[PR_Category_GetByID]
    @CategoryID int
as
begin
    select
        [dbo].[Category].[CategoryID],
        [dbo].[Category].[CategoryName],
        [dbo].[Category].[Description]
    from [dbo].[Category]
    where [dbo].[Category].[CategoryID] = @CategoryID
end

--3)INSERT
create procedure [dbo].[PR_Category_Insert]
    @CategoryName varchar(50),
    @Description varchar(100)
as
begin
    insert into [dbo].[Category] (
        [CategoryName],
        [Description]
    )
    values (
        @CategoryName,
        @Description
    )
end

--4)UPDATE
alter procedure [dbo].[PR_Category_Update]
    @CategoryID int,
    @CategoryName nvarchar(50),
    @Description nvarchar(100)
as
begin
    update [dbo].[Category]
    set 
        [CategoryName] = @CategoryName,
        [Description] = @Description
    where 
        [CategoryID] = @CategoryID
end

--5)DELETE
create procedure [dbo].[PR_Category_Delete]
    @CategoryID int
as
begin
    delete from [dbo].[Category]
    where [CategoryID] = @CategoryID
end

--6)DROPDOWN
alter procedure [dbo].[PR_Category_Dropdown]
as
begin
    select 
        [CategoryID], 
        [CategoryName]
    from [dbo].[Category]
	order by [CategoryName]
end


------------------------------Product------------------------------
--1)SELECT ALL
create or alter procedure [dbo].[PR_Product_SelectAll]
as
begin
    select 
        [ProductID],
        [ProductName],
        [Product].[Description],
        [Product].[CategoryID],
		[CategoryName],
        [Product].[BrandID],
		[BrandName],
        [Price],
        [StockQuantity],
        [ImgUrl],
        [IsActive]
    from [dbo].[Product]
	left outer join [Category]
	on [Product].CategoryID=[Category].CategoryID
	left outer join [Brand]
	on [Product].BrandID=[Brand].BrandID
end


--2)GET BY ID
create or alter procedure [dbo].[PR_Product_GetByID]
	@ProductID int
as
begin
    select 
        [ProductID],
        [ProductName],
        [Product].[Description],
        [Product].[CategoryID],
		[CategoryName],
        [Product].[BrandID],
		[BrandName],
        [Price],
        [StockQuantity],
        [ImgUrl],
        [IsActive]
    from [dbo].[Product]
	left outer join [Category]
	on [Product].CategoryID=[Category].CategoryID
	left outer join [Brand]
	on [Product].BrandID=[Brand].BrandID
	where [ProductID]=@ProductID
end

--3)INSERT
alter procedure [dbo].[PR_Product_Insert]
    @ProductName NVARCHAR(50),
    @Description NVARCHAR(100) = NULL,
    @CategoryID INT,
    @BrandID INT,
    @Price DECIMAL(18, 2),
    @StockQuantity INT,
    @ImgUrl NVARCHAR(500) = NULL,
    @IsActive BIT = 1
as
begin
    insert into [dbo].[Product] (
        [ProductName],
        [Description],
        [CategoryID],
        [BrandID],
        [Price],
        [StockQuantity],
        [ImgUrl],
        [IsActive]
    )
    values (
        @ProductName,
        @Description,
        @CategoryID,
        @BrandID,
        @Price,
        @StockQuantity,
        @ImgUrl,
        @IsActive
    )
end

--4)UPDATE
create or alter procedure [dbo].[PR_Product_Update]
    @ProductID INT,
    @ProductName NVARCHAR(50),
    @Description NVARCHAR(100) = NULL,
    @CategoryID INT,
    @BrandID INT,
    @Price DECIMAL(18, 2),
    @StockQuantity INT,
    @ImgUrl NVARCHAR(500) = NULL,
    @IsActive BIT
as
begin
    update [dbo].[Product]
    set 
        [ProductName] = @ProductName,
        [Description] = @Description,
        [CategoryID] = @CategoryID,
        [BrandID] = @BrandID,
        [Price] = @Price,
        [StockQuantity] = @StockQuantity,
        [ImgUrl] = @ImgUrl,
        [IsActive] = @IsActive
    where 
        [ProductID] = @ProductID
end

--5)DELETE
create procedure [dbo].[PR_Product_Delete]
    @ProductID INT
as
begin
    delete from [dbo].[Product]
    where [ProductID] = @ProductID
end

--6)DROPDOWN
alter procedure [dbo].[PR_Product_Dropdown]
as
begin
    select 
        [ProductID],
        [ProductName]
    from [dbo].[Product]
    where [IsActive] = 1
    order by [ProductName]
end


--7)SELECT BY CATEGORY_ID
CREATE OR ALTER PROCEDURE [dbo].[PR_Product_SelectByCategoryID]
    @CategoryID INT
AS
BEGIN
    SELECT 
        [ProductID],
        [ProductName],
        [Product].[Description],
        [Product].[CategoryID],
        [CategoryName],
        [Product].[BrandID],
        [BrandName],
        [Price],
        [StockQuantity],
        [ImgUrl],
        [IsActive]
    FROM [dbo].[Product]
    LEFT OUTER JOIN [Category]
        ON [Product].[CategoryID] = [Category].[CategoryID]
    LEFT OUTER JOIN [Brand]
        ON [Product].[BrandID] = [Brand].[BrandID]
    WHERE [Product].[CategoryID] = @CategoryID;
END;


--8)SELECT BY BRAND_ID
CREATE OR ALTER PROCEDURE [dbo].[PR_Product_SelectByBrandID]
    @BrandID INT
AS
BEGIN
    SELECT 
        [ProductID],
        [ProductName],
        [Product].[Description],
        [Product].[CategoryID],
        [CategoryName],
        [Product].[BrandID],
        [BrandName],
        [Price],
        [StockQuantity],
        [ImgUrl],
        [IsActive]
    FROM [dbo].[Product]
    LEFT OUTER JOIN [Category]
        ON [Product].[CategoryID] = [Category].[CategoryID]
    LEFT OUTER JOIN [Brand]
        ON [Product].[BrandID] = [Brand].[BrandID]
    WHERE [Product].[BrandID] = @BrandID;
END;



------------------------------Order------------------------------
--1)SELECT ALL
create or alter procedure [dbo].[PR_Order_SelectAll]
as
begin
    select 
        [OrderID],
		[Order].[ProductID],
		[ProductName],
        [Order].[UserID],
		[UserName],
		[Quantity],
        [TotalAmount],
		[Order].[Size],
		[Color]
    from [dbo].[Order]
	left outer join [Product]
	on [Order].ProductID=[Product].ProductID
	left outer join [User]
	on [Order].UserID=[User].UserID
end

--2)GET BY ID
create or alter procedure [dbo].[PR_Order_GetByID]
	@OrderID int
as
begin
    select 
        [OrderID],
		[ProductID],
        [UserID],
		[Quantity],
        [TotalAmount],
		[Size],
		[Color]
    from [dbo].[Order]
	where OrderID=@OrderID
end

--3)INSERT
create or alter procedure [dbo].[PR_Order_Insert]
	@ProductID INT,
    @UserID INT,
	@Quantity INT,
    @TotalAmount DECIMAL(18, 2),
	@Size VARCHAR(3),
	@Color VARCHAR(50)
as
begin
    insert into [dbo].[Order] (
		[ProductID],
        [UserID],
		[Quantity],
        [TotalAmount],
		[Size],
		[Color]
    )
    values (
		@ProductID,
        @UserID,
		@Quantity,
        @TotalAmount,
		@Size,
		@Color
    )
end

--4)UPDATE
create or alter procedure [dbo].[PR_Order_Update]
    @OrderID INT,
	@ProductID INT,
    @UserID INT,
	@Quantity INT,
    @TotalAmount DECIMAL(18, 2),
	@Size VARCHAR(3),
	@Color VARCHAR(50)
as
begin
    update [dbo].[Order]
    set 
		[ProductID]=@ProductID,
        [UserID] = @UserID,
		[Quantity]=@Quantity,
        [TotalAmount] = @TotalAmount,
		[Size] = @Size,
		[Color] = @Color
    where 
        [OrderID] = @OrderID
end

--5)DELETE
create procedure [dbo].[PR_Order_Delete]
    @OrderID INT
as
begin
    delete from [dbo].[Order]
    where [OrderID] = @OrderID
end


--7)SELECT BY USER_ID
create or alter procedure [dbo].[PR_Order_SelectByUserID]
	@UserID int
as
begin
    select 
        [OrderID],
		[Order].[ProductID],
		[ProductName],
		[ImgUrl],
        [Order].[UserID],
		[UserName],
		[Quantity],
        [TotalAmount],
		[Order].[Size],
		[Color]
    from [dbo].[Order]
	left outer join [Product]
	on [Order].ProductID=[Product].ProductID
	left outer join [User]
	on [Order].UserID=[User].UserID
	where [Order].UserID=@UserID
end



------------------------------User------------------------------
--1)SELECT ALL
ALTER PROCEDURE [dbo].[PR_User_SelectAll]
AS
BEGIN
    SELECT 
        [UserID],
        [UserName],
        [Email],
		[Password],
        [ContactNo]
    FROM [dbo].[User]
END;

--2)GET BY ID
CREATE or ALTER PROCEDURE [dbo].[PR_User_GetByID]
    @UserID INT
AS
BEGIN
    SELECT 
        [UserID],
        [UserName],
        [Email],
		[Password],
        [ContactNo]
    FROM [dbo].[User]
	WHERE [UserID] = @UserID;
END;

--3)INSERT
CREATE or ALTER PROCEDURE [dbo].[PR_User_Insert]
    @UserName NVARCHAR(100),
    @Email NVARCHAR(50),
    @Password NVARCHAR(50),
    @ContactNo NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[User] (
        [UserName],
        [Email],
        [Password],
        [ContactNo]
    )
    VALUES (
        @UserName,
        @Email,
        @Password,
        @ContactNo
    );
END;

--4)UPDATE
CREATE or ALTER PROCEDURE [dbo].[PR_User_Update]
    @UserID INT,
    @UserName NVARCHAR(100),
    @Email NVARCHAR(50),
    @Password NVARCHAR(50),
    @ContactNo NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[User]
    SET 
        [UserName] = @UserName,
        [Email] = @Email,
        [Password] = @Password,
        [ContactNo] = @ContactNo
    WHERE 
        [UserID] = @UserID;
END;

--5)DELETE
CREATE PROCEDURE [dbo].[PR_User_Delete]
    @UserID INT
AS
BEGIN
    DELETE FROM [dbo].[User]
    WHERE [UserID] = @UserID;
END;

--6)DROPDOWN
CREATE PROCEDURE [dbo].[PR_User_Dropdown]
AS
BEGIN
    SELECT 
        [UserID], 
        [UserName]
    FROM [dbo].[User]
    ORDER BY [UserName];
END;


------------------------------Favourite------------------------------
--1)SELECT ALL
CREATE OR ALTER PROCEDURE [dbo].[PR_Favourite_SelectAll]
AS
BEGIN
    SELECT 
        [FavouriteID],
        [Favourite].[ProductID],
        [ProductName],
		[ImgUrl],
		[Favourite].[UserID],
        [UserName]
    FROM [dbo].[Favourite]
	left outer join [Product]
	on [Favourite].ProductID=[Product].ProductID
	left outer join [User]
	on [Favourite].UserID=[User].UserID
END;


--2)SELECT BY USER_ID
CREATE OR ALTER PROCEDURE [dbo].[PR_Favourite_SelectByUserID]
	@UserID int
AS
BEGIN
    SELECT 
        [FavouriteID],
        [Favourite].[ProductID],
        [ProductName],
		[ImgUrl]
    FROM [dbo].[Favourite]
	left outer join [Product]
	on [Favourite].ProductID=[Product].ProductID
	where [Favourite].[UserID]=@UserID
END;


--3)INSERT
CREATE or ALTER PROCEDURE [dbo].[PR_Favourite_Insert]
    @ProductID INT,
    @UserID INT
AS
BEGIN
    INSERT INTO [dbo].[Favourite] (
        [ProductID],
        [UserID]
    )
    VALUES (
        @ProductID,
        @UserID
    );
END;


--4)DELETE
CREATE PROCEDURE [dbo].[PR_Favourite_Delete]
    @FavouriteID INT
AS
BEGIN
    DELETE FROM [dbo].[Favourite]
    WHERE [FavouriteID] = @FavouriteID;
END;



----------------------------------------------DASHBOARD-----------------------------------
CREATE OR ALTER PROCEDURE [dbo].[usp_GetDashboardData]
AS
BEGIN
    -- Enable NOCOUNT for better performance
    SET NOCOUNT ON;
-- SET NOCOUNT ON: Suppresses the message from being returned. This prevents the sending of DONEINPROC messages to the client for each
-- statement in a stored procedure.
-- SET NOCOUNT OFF: Includes the message in the result set. 
    -- Temporary tables for organized data fetching
	CREATE TABLE #Counts (
        Metric NVARCHAR(255),
        Value INT
		);

    CREATE TABLE #RecentOrders (
        OrderID INT,
        UserName NVARCHAR(255),
        ProductName VARCHAR(50),
		TotalAmount DECIMAL(18,2)
    );

    CREATE TABLE #RecentProducts (
        ProductID INT,
        ProductName NVARCHAR(255),
		Price DECIMAL(18,2),
        StockQuantity INT
    );

    CREATE TABLE #TopUsers (
        UserName NVARCHAR(255),
        TotalOrders INT,
        Email NVARCHAR(255)
    );

    CREATE TABLE #TopSellingProducts (
        ProductName NVARCHAR(255),
        TotalSoldQuantity INT
    );

    ---- Step 1: Get Counts
    --
	INSERT INTO #Counts
        SELECT 'TotalUsers', COUNT(*) FROM [User]
    INSERT INTO #Counts
	    SELECT 'TotalProducts', COUNT(*) FROM [Product]
	INSERT INTO #Counts
		SELECT 'TotalOrders',COUNT(*) FROM [Order]
		

    -- Step 2: Get Recent 10 Orders
    INSERT INTO #RecentOrders
    SELECT TOP 10
        O.OrderID,
        U.UserName,
        P.ProductName,
		TotalAmount
    FROM [Order] O
    INNER JOIN [User] U ON O.UserID = U.UserID
	INNER JOIN [Product] P ON O.ProductID = P.ProductID
	ORDER BY OrderID DESC;

    -- Step 3: Get Recent 10 Newly Added Products
    INSERT INTO #RecentProducts --OrderDetail Table
    SELECT TOP 10
        [Product].[ProductID],
        ProductName,
        Price,
        StockQuantity
    FROM [Product]
    ORDER BY ProductID DESC;

    -- Step 4: Get Top 10 Users by Order Count
    INSERT INTO #TopUsers
    SELECT TOP 10
        U.UserName,
        COUNT(O.OrderID) AS TotalOrders,
        U.Email
    FROM [Order] O
    INNER JOIN [User] U ON O.UserID = U.UserID
    GROUP BY U.UserName, U.Email
    ORDER BY COUNT(O.OrderID) DESC;

    -- Step 5: Get Top 10 Selling Products
    INSERT INTO #TopSellingProducts
    SELECT TOP 10
        P.ProductName,
        SUM(O.Quantity) AS TotalSoldQuantity
    FROM [Order] O
    INNER JOIN [Product] P ON O.ProductID = P.ProductID
    GROUP BY P.ProductName
    ORDER BY SUM(O.Quantity) DESC;

    -- Output Results
    -- Output Counts
    SELECT * FROM #Counts;

    -- Output Recent Orders
    SELECT * FROM #RecentOrders;

    -- Output Recent Products
    SELECT * FROM #RecentProducts;

    -- Output Top Customers
    SELECT * FROM #TopUsers;

    -- Output Top Selling Products
    SELECT * FROM #TopSellingProducts;

    -- Cleanup Temporary Tables
    DROP TABLE #RecentOrders;
    DROP TABLE #RecentProducts;
    DROP TABLE #TopUsers;
    DROP TABLE #TopSellingProducts;
END;

