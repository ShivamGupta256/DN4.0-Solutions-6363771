CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Headphones', 'Electronics', 150.00),
(4, 'Desk Chair', 'Furniture', 250.00),
(5, 'Coffee Table', 'Furniture', 180.00),
(6, 'Monitor', 'Electronics', 300.00),
(7, 'Bookshelf', 'Furniture', 120.00);

WITH RankedProducts AS (
    SELECT 
        Category,
        ProductName,
        Price,
        ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNumRank,
        RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS Rank,
        DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRank
    FROM 
        Products
)

SELECT 
    Category,
    ProductName,
    Price,
    RowNumRank,
    Rank,
    DenseRank
FROM 
    RankedProducts
WHERE 
    RowNumRank <= 3
ORDER BY 
    Category, Price DESC;