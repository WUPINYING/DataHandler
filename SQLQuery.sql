SELECT * FROM Customers

SELECT * FROM Employees

SELECT * FROM Orders

SELECT * FROM Customers AS C
JOIN Orders AS O ON O.CustomerID=C.CustomerID
JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
JOIN [Order Details] AS OD ON OD.OrderID=O.OrderID

SELECT C.[CustomerID],C.[Country],
	   O.OrderDate,
	   OD.UnitPrice,
	   E.[Title],E.LastName 
FROM Customers AS C
JOIN Orders AS O ON O.CustomerID=C.CustomerID
JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
JOIN [Order Details] AS OD ON OD.OrderID=O.OrderID
WHERE C.CustomerID='VINET';

SELECT C.CustomerID,
       AVG(OD.UnitPrice) AS AverageUnitPrice
FROM Customers AS C
JOIN Orders AS O ON O.CustomerID = C.CustomerID
JOIN [Order Details] AS OD ON OD.OrderID = O.OrderID
GROUP BY C.CustomerID
HAVING AVG(OD.UnitPrice) > 40