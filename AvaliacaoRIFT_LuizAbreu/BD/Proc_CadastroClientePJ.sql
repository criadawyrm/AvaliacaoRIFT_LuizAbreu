USE [AvaliacaoRIFT]
GO

/****** Object:  StoredProcedure [dbo].[Proc_CadastroClientePJ]    Script Date: 10/10/2024 17:33:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Proc_CadastroClientePJ]
(
	 @IdClientePJ		INT
	,@CNPJ				VARCHAR(20)
	,@RazaoSocial		VARCHAR(255)
	,@NomeFantasia		VARCHAR(255)
	,@Endereco			VARCHAR(255)
	,@Telefone1			VARCHAR(14)
	,@Telefone2			VARCHAR(14)
	,@Email				VARCHAR(255)
)
AS
BEGIN
	DECLARE
		@retorno VARCHAR(2)

	IF (@IdClientePJ = 0)
	BEGIN
		IF EXISTS (SELECT * FROM ClientePJ WHERE CNPJ = @CNPJ)
		BEGIN
			SET @retorno = 'E1'
		END
		ELSE
		BEGIN
			INSERT INTO ClientePJ (
				 CNPJ
				,RazaoSocial
				,NomeFantasia
				,Endereco
				,Telefone1
				,Telefone2
				,Email
				,StatusRegistro
				,DataRegistro
				,DataAlteracao
			) VALUES (
				@CNPJ
				,@RazaoSocial
				,@NomeFantasia
				,@Endereco
				,@Telefone1
				,@Telefone2
				,@Email
				,'A'
				,GETDATE()
				,GETDATE()
			)
			
			SET @retorno = 'A'
		END
	END
	ELSE IF NOT EXISTS (SELECT * FROM ClientePJ WHERE IdClientePJ = @IdClientePJ)
	BEGIN
			SET @retorno = 'E2'
	END
	ELSE
	BEGIN
		UPDATE ClientePJ
		SET
			 RazaoSocial		= @RazaoSocial
			,NomeFantasia		= @NomeFantasia
			,Endereco			= @Endereco
			,Telefone1			= @Telefone1
			,Telefone2			= @Telefone2
			,Email				= @Email
			,DataAlteracao		= GETDATE()
		WHERE
			IdClientePJ = @IdClientePJ
			
		SET @retorno = 'A'
	END

	SELECT @retorno retorno
END
GO


