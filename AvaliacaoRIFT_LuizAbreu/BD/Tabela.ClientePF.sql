USE [AvaliacaoRIFT]
GO

/****** Object:  Table [dbo].[ClientePF]    Script Date: 10/10/2024 17:30:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientePF](
	[IdClientePF] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [varchar](14) NULL,
	[Nome] [varchar](255) NOT NULL,
	[Sexo] [varchar](50) NOT NULL,
	[DataNascimento] [varchar](10) NOT NULL,
	[RG] [varchar](20) NOT NULL,
	[Endereco] [varchar](255) NOT NULL,
	[Telefone1] [varchar](14) NOT NULL,
	[Telefone2] [varchar](14) NOT NULL,
	[Email1] [varchar](255) NOT NULL,
	[Email2] [varchar](255) NOT NULL,
	[StatusRegistro] [char](1) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
 CONSTRAINT [PK_ClientePF] PRIMARY KEY CLUSTERED 
(
	[IdClientePF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


