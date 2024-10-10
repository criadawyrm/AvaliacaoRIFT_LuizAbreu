USE [AvaliacaoRIFT]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Login]    Script Date: 10/10/2024 17:33:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Proc_Login] (
	 @Usuario	VARCHAR(30)
	,@Senha		VARCHAR(30)
)
AS
BEGIN
	DECLARE
		 @StatusRegistro	VARCHAR(1)
		,@SenhaBD			VARCHAR(30)
	
	SELECT TOP 1
		 @StatusRegistro	= StatusRegistro
		,@SenhaBD			= Senha
	FROM
		Usuario
	WHERE
		Usuario = @Usuario

	IF ISNULL(@StatusRegistro,'') = ''
	BEGIN
		SET @StatusRegistro = ''		
	END
	ELSE IF ISNULL(@SenhaBD,'') <> @Senha
	BEGIN
		SET @StatusRegistro = 'E'
	END

	SELECT @StatusRegistro StatusRegistro
END
GO


