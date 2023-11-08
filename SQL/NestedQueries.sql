USE Test

SELECT * FROM Orders
SELECT * FROM OrderPositions
GO


SELECT 
    o.Date, 
    (SELECT c.[Last Name] + ' ' + c.[Last Name] FROM Customers c WHERE c.Id = o.CustomerId) AS [Customer Name],
	(SELECT m.[First Name] + ' ' + m.[Last Name] FROM Managers m WHERE m.Id = o.ManagerId) AS [Manager Name],
	op.PositionNumber AS [Position],
    (SELECT p.Name FROM Products p WHERE p.Id = op.ProductId) AS [Product Name],
	op.Qty AS [Quontity]
FROM Orders o
JOIN OrderPositions op ON o.Id = op.OrderId;
GO



--switch var
SELECT
	m.[First Name] AS [Manager Name],
	SUM(CASE WHEN o.Date BETWEEN '2023-10-01' AND '2023-10-31' THEN op.Qty ELSE 0 END) AS [October Sales],
	SUM(CASE WHEN o.Date BETWEEN '2023-11-01' AND '2023-11-30' THEN op.Qty ELSE 0 END) AS [November Sales],
	SUM(CASE WHEN o.Date BETWEEN '2023-11-01' AND '2023-11-30' THEN op.Qty ELSE 0 END) - SUM(CASE WHEN o.Date BETWEEN '2023-10-01' AND '2023-10-31' THEN op.Qty ELSE 0 END) AS [Difference]
FROM Managers AS m
LEFT JOIN Orders AS o ON (m.Id = o.ManagerId)
LEFT JOIN OrderPositions AS op ON (o.Id = op.OrderId)
GROUP BY m.[First Name]
GO

SELECT
	m.[First Name] + ' ' + m.[Last Name] AS [Name],
	(SELECT ISNULL(SUM(op.Qty), 0) FROM OrderPositions op WHERE op.OrderId = o.Id AND o.Date BETWEEN '2023-10-01' AND '2023-10-31') AS [October Sales],
	(SELECT ISNULL(SUM(op.Qty), 0) FROM OrderPositions op WHERE op.OrderId = o.Id AND o.Date BETWEEN '2023-11-01' AND '2023-11-30') AS [November Sales],
	(SELECT ISNULL(SUM(op.Qty), 0) FROM OrderPositions op WHERE op.OrderId = o.Id AND o.Date BETWEEN '2023-11-01' AND '2023-11-30') - (SELECT ISNULL(SUM(op.Qty), 0) FROM OrderPositions op WHERE op.OrderId = o.Id AND o.Date BETWEEN '2023-10-01' AND '2023-10-31') AS [Difference]
FROM  Managers m
LEFT JOIN Orders o ON (o.ManagerId = m.Id)
GO