USE [AvaliacaoRIFT]
GO

/****** Object:  Table [dbo].[ClientePJ]    Script Date: 10/10/2024 17:31:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientePJ](
	[IdClientePJ] [int] IDENTITY(1,1) NOT NULL,
	[CNPJ] [varchar](20) NOT NULL,
	[RazaoSocial] [varchar](255) NOT NULL,
	[NomeFantasia] [varchar](255) NOT NULL,
	[Endereco] [varchar](255) NOT NULL,
	[Telefone1] [varchar](14) NOT NULL,
	[Telefone2] [varchar](14) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[StatusRegistro] [char](1) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
 CONSTRAINT [PK_ClientePJ] PRIMARY KEY CLUSTERED 
(
	[IdClientePJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


