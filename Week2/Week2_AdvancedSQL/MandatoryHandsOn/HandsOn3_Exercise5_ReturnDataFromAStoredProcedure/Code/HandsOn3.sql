CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    DECLARE @EmployeeCount INT;
    
    SELECT @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
    
    RETURN @EmployeeCount;
END;
GO

DECLARE @Count INT;
EXEC @Count = sp_GetEmployeeCountByDepartment @DepartmentID = 2;
SELECT @Count AS 'EmployeeCount';