USE AdventureWorks2022

CREATE UNIQUE NONCLUSTERED INDEX
idx_Document_Title
ON [Production].[Document] (Title);
GO


CREATE PROCEDURE GetOrdersByDate
    @OrderDate DATE
AS
BEGIN
    SELECT 
		p.Name AS [Product],
		od.OrderQty
    FROM [Sales].[SalesOrderDetail] od
	JOIN [Production].[Product] p ON (od.ProductID = p.ProductID)
    WHERE od.ModifiedDate = @OrderDate;
END;
GO

EXEC GetOrdersByDate '2011-05-31'

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO [Sales].[SalesOrderDetail]
	(  [SalesOrderID]
      ,[OrderQty]
      ,[ProductID]
      ,[SpecialOfferID]
      ,[UnitPrice])
    VALUES (43659, 4, 758, 1, 874.794);

    EXEC GetOrdersByDate '2011-05-31';

    DELETE FROM [Sales].[SalesOrderDetail]
    WHERE SalesOrderDetailID = 2;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
GO

CREATE TRIGGER UpdateInventory
ON [Production].[Product]
AFTER INSERT
AS
BEGIN
    UPDATE [Production].[ProductInventory]
    SET Quantity = Quantity + 1
    FROM Inserted i
    WHERE [Production].[ProductInventory].ProductID = i.ProductID;
END;
GO