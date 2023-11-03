SELECT * FROM Orders
SELECT * FROM OrderPositions
GO


SELECT
	o.Date AS [Date],
	c.[First Name] + ' ' + c.[Last Name] AS [Customer Name],
	m.[First Name] + ' ' + m.[Last Name] AS [Manager Name],
	op.PositionNumber AS [Position],
	p.Name AS [Product],
	op.Qty AS [Quontity]
FROM Orders AS o
JOIN OrderPositions AS op ON (o.Id = op.OrderId)
JOIN Customers AS c ON (o.CustomerId = c.Id)
JOIN Managers AS m ON (o.ManagerId = m.Id)
JOIN Products AS p ON (op.ProductId = p.Id)
GO



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