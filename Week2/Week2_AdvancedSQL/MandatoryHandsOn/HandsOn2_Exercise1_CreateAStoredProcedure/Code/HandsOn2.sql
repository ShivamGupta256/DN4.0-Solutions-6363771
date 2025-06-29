CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

INSERT INTO Departments VALUES (1, 'HR'), (2, 'IT'), (3, 'Finance');
INSERT INTO Employees VALUES 
    (1, 'John', 'Doe', 1, 50000, '2020-01-15'),
    (2, 'Jane', 'Smith', 2, 60000, '2019-03-22'),
    (3, 'Mike', 'Johnson', 2, 55000, '2021-05-10');
GO

CREATE OR ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.Salary,
        e.JoinDate,
        d.DepartmentName
    FROM 
        Employees e
    JOIN 
        Departments d ON e.DepartmentID = d.DepartmentID
    WHERE 
        e.DepartmentID = @DepartmentID;
END;
GO

EXEC sp_GetEmployeesByDepartment @DepartmentID = 1;
GO