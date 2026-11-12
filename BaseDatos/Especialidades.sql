USE ClinicaTurnos;
GO

IF OBJECT_ID(N'dbo.Especialidades', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Especialidades
    (
        Id int IDENTITY(1,1) PRIMARY KEY,
        Nombre nvarchar(80) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Especialidades WHERE Nombre = N'Cardiología')
    INSERT INTO dbo.Especialidades (Nombre) VALUES (N'Cardiología');

IF NOT EXISTS (SELECT 1 FROM dbo.Especialidades WHERE Nombre = N'Dermatología')
    INSERT INTO dbo.Especialidades (Nombre) VALUES (N'Dermatología');

IF NOT EXISTS (SELECT 1 FROM dbo.Especialidades WHERE Nombre = N'Pediatría')
    INSERT INTO dbo.Especialidades (Nombre) VALUES (N'Pediatría');
GO
