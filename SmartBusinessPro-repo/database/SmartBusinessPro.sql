CREATE DATABASE SmartBusinessPro;
GO
USE SmartBusinessPro;
GO

CREATE TABLE Categorias (
    CategoriaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre      NVARCHAR(100) NOT NULL
);

CREATE TABLE Productos (
    ProductoId  INT IDENTITY(1,1) PRIMARY KEY,
    Nombre      NVARCHAR(150) NOT NULL,
    Precio      DECIMAL(10,2) NOT NULL,
    Existencia  INT NOT NULL,
    CategoriaId INT NOT NULL,
    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId)
);
GO

INSERT INTO Categorias (Nombre) VALUES
(N'Electrónica'), (N'Papelería'), (N'Hogar');

INSERT INTO Productos (Nombre, Precio, Existencia, CategoriaId) VALUES
(N'Mouse inalámbrico', 12.50, 40, 1),
(N'Teclado USB', 18.99, 25, 1),
(N'Cuaderno profesional', 2.75, 120, 2),
(N'Resma de papel carta', 5.40, 60, 2),
(N'Lámpara de escritorio', 15.00, 18, 3);
GO
