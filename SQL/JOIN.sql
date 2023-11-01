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
JOIN Departments AS d ON (d.Id = ed.DepartmentId)
GROUP BY e.FirstName
GO


SELECT
	d.Name AS [Department],
	COUNT(ed.EmployeeId) AS [Emploee Qty]
FROM Employees AS e
RIGHT JOIN EmploeeDepartment AS ed ON (e.Id = ed.EmployeeId)
RIGHT JOIN Departments AS d ON (d.Id = ed.DepartmentId)
GROUP BY d.Name
GO


SELECT
	d.Name AS [Department],
	e.FirstName + ' ' + e.LastName AS [Emploee]
FROM Departments AS d
LEFT JOIN EmploeeDepartment AS ed ON (d.Id = ed.DepartmentId)
LEFT JOIN Employees AS e ON (e.Id = ed.EmployeeId)
ORDER BY d.Id
GO
