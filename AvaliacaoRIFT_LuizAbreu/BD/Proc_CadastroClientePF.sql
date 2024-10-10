USE [AvaliacaoRIFT]
GO

/****** Object:  StoredProcedure [dbo].[Proc_CadastroClientePF]    Script Date: 10/10/2024 17:33:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Proc_CadastroClientePF]
(
	 @IdClientePF		INT
	,@CPF				VARCHAR(14)
	,@Nome				VARCHAR(255)
	,@Sexo				VARCHAR(50)
	,@DataNascimento	VARCHAR(10)
	,@RG				VARCHAR(20)
	,@Endereco			VARCHAR(255)
	,@Telefone1			VARCHAR(14)
	,@Telefone2			VARCHAR(14)
	,@Email1			VARCHAR(255)
	,@Email2			VARCHAR(255)
)
AS
BEGIN
	DECLARE
		@retorno VARCHAR(2)

	IF (@IdClientePF = 0)
	BEGIN
		IF EXISTS (SELECT * FROM ClientePF WHERE CPF = @CPF)
		BEGIN
			SET @retorno = 'E1'
		END
		ELSE
		BEGIN
			INSERT INTO ClientePF (
				 CPF
				,Nome
				,Sexo
				,DataNascimento
				,RG
				,Endereco
				,Telefone1
				,Telefone2
				,Email1
				,Email2
				,StatusRegistro
				,DataRegistro
				,DataAlteracao
			) VALUES (
				@CPF
				,@Nome
				,@Sexo
				,@DataNascimento
				,@RG
				,@Endereco
				,@Telefone1
				,@Telefone2
				,@Email1
				,@Email2
				,'A'
				,GETDATE()
				,GETDATE()
			)
			
			SET @retorno = 'A'
		END
	END
	ELSE IF NOT EXISTS (SELECT * FROM ClientePF WHERE IdClientePF = @IdClientePF)
	BEGIN
			SET @retorno = 'E2'
	END
	ELSE
	BEGIN
		UPDATE ClientePF
		SET
			 Nome				= @Nome
			,Sexo				= @Sexo
			,DataNascimento		= @DataNascimento
			,RG					= @RG
			,Endereco			= @Endereco
			,Telefone1			= @Telefone1
			,Telefone2			= @Telefone2
			,Email1				= @Email1
			,Email2				= @Email2
			,DataAlteracao		= GETDATE()
		WHERE
			IdClientePF = @IdClientePF
			
		SET @retorno = 'A'
	END

	SELECT @retorno retorno
END
GO


