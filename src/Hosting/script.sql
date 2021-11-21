-- Customer definition

CREATE TABLE Customer (
	Id	INTEGER,
	FirstName	VARCHAR,
	LastName	VARCHAR,
	CreatedDate	DATETIME,
	LastModifiedDate	DATETIME,
	PRIMARY KEY(Id)
);

-- "Order" definition

CREATE TABLE [Order] (
	Id INTEGER, 
    Number VARCHAR NOT NULL, 
    Description VARCHAR, 
    CreatedDate DATETIME, 
    LastModifiedDate DATETIME, 
    TotalPrice DECIMAL, 
    CustomerId INTEGER NOT NULL,
	CONSTRAINT Order_PK PRIMARY KEY (Id),
    FOREIGN KEY(CustomerId) REFERENCES Customer(Id)

);
-- Product definition

CREATE TABLE Product (
	Id INTEGER,
	Name VARCHAR NOT NULL,
	SKU VARCHAR NOT NULL,
	UnitPrice DECIMAL DEFAULT 0 NOT NULL,
	CreatedDate DATETIME,
	LastModifiedDate DATETIME,
	CONSTRAINT Product_PK PRIMARY KEY (Id)
);

-- OrderLine definition

CREATE TABLE OrderLine (
	Id INTEGER,
	OrderId INTEGER,
	ProductId INTEGER,
	Price DECIMAL,
	CreatedDate DATETIME,
	LastModifiedDate DATETIME,
	CONSTRAINT OrderLine_PK PRIMARY KEY (Id),
    FOREIGN KEY(OrderId) REFERENCES [Order](Id),
    FOREIGN KEY(ProductId) REFERENCES Product(Id)
);

