USE master
GO
IF EXISTS(SELECT 1 FROM sys.databases WHERE name = 'Loja')
	DROP DATABASE Loja
GO
CREATE DATABASE Loja
GO

USE Loja
GO

CREATE TABLE Usuario
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NomeUsuario VARCHAR(150),
	Senha VARCHAR(100),
	Ativo BIT
)
GO

CREATE PROCEDURE SP_InserirUsuario
	@Id INT OUTPUT,
	@NomeUsuario VARCHAR(150),
	@Senha VARCHAR(100),
	@Ativo BIT
AS
	INSERT INTO Usuario(Ativo, NomeUsuario, Senha)
	VALUES(@Ativo, @NomeUsuario, @Senha)
	SET @Id = (SELECT @@IDENTITY)
	--SELECT @@IDENTITY
GO

CREATE PROC SP_BuscarUsuario
	@Filtro VARCHAR(250) = ''
AS
	SELECT Id, Ativo, NomeUsuario, Senha FROM Usuario WHERE NomeUsuario LIKE '%' + @Filtro + '%'
GO

CREATE PROC SP_AlterarUsuario
	@Id INT, 
	@Ativo BIT, 
	@NomeUsuario VARCHAR(50), 
	@Senha VARCHAR(50)
AS
	UPDATE Usuario SET
		Ativo = @Ativo,
		NomeUsuario = @NomeUsuario,
		Senha = @Senha
	WHERE Id = @Id
GO
	
CREATE PROC SP_ExcluirUsuario
	@Id INT
AS
	DELETE FROM Usuario WHERE Id = @Id
GO


/*
EXEC SP_InserirUsuario 0, 'Teste', '123', 1
EXEC SP_InserirUsuario 0, 'Erisvaldo', '123456', 1

SELECT*FROM Usuario
*/
