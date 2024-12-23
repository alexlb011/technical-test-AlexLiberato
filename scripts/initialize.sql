PRINT 'Iniciando criação do banco de dados';
CREATE DATABASE ERP;
GO
    USE ERP;
GO
    CREATE TABLE tblCliente (
        Codigo INT PRIMARY KEY IDENTITY(1, 1),
        Nome NVARCHAR(150) NOT NULL,
        DataNascimento DATE NOT NULL,
        Sexo BIT NOT NULL,
        LimiteCompra DECIMAL(10, 2) NOT NULL
    );
GO
    PRINT 'Banco de dados e tabela criados com sucesso';