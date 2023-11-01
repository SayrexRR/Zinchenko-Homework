INSERT INTO Departments
(
	[Name]
)
VALUES
('Software Development'),
('Quality Assurance (QA)'),
('Product Management'),
('User Experience (UX) and User Interface (UI) Design'),
('DevOps'),
('Research and Development (R&D)'),
('Sales and Marketing'),
('Customer Support'),
('Human Resources (HR)'),
('Finance and Accounting'),
('Legal and Compliance'),
('Security'),
('Data Analytics'),
('IT Infrastructure'),
('Project Management')
GO

INSERT INTO EmploeeDepartment
(
	[EmployeeId],
	[DepartmentId]
)
VALUES
(2, 3),
(1, 2),
(1, 5),
(3, 1),
(3, 6),
(3, 9),
(4, 1),
(4, 9),
(4, 12),
(4, 15),
(5, 5),
(5, 15),
(6, 2),
(6, 11)
GO

SELECT
	e.FirstName AS [Name],
	COUNT(ed.DepartmentId) AS [Department Qty]
FROM Employees AS e
JOIN EmploeeDepartment AS ed ON (e.Id = ed.EmployeeId)
GROUP BY e.FirstName
GO


SELECT
	d.Name AS [Department],
	COUNT(ed.EmployeeId) AS [Emploee Qty]
FROM Departments AS d
RIGHT JOIN EmploeeDepartment AS ed ON (d.Id = ed.DepartmentId)
GROUP BY d.Name
GO


SELECT
	d.Name AS [Department],
	ISNULL(e.LastName + ' ' + e.FirstName, 'Empty') AS [Employee Name]
FROM Departments AS d
LEFT JOIN EmploeeDepartment AS ed ON (d.Id = ed.DepartmentId)
LEFT JOIN Employees AS e ON (e.Id = ed.EmployeeId)
ORDER BY [Employee Name]
GO
