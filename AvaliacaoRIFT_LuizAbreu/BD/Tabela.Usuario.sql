USE [AvaliacaoRIFT]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 10/10/2024 17:31:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Usuario] [varchar](30) NOT NULL,
	[Senha] [varchar](30) NOT NULL,
	[StatusRegistro] [char](1) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [Usuario] VALUES ('Operador','Senha1','A')

