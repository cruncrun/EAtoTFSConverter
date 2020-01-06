USE [EATFSConverter]
GO

/****** Object:  Table [dbo].[UseCase]    Script Date: 06.01.2020 17:35:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UseCase](
	[Id] [uniqueidentifier] NOT NULL,
	[EAScenarioId] [uniqueidentifier] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[SubjectId] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Timestamp] [datetime] NULL,
	[PreviousVersionId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UseCase]  WITH CHECK ADD  CONSTRAINT [FK_UseCase_EAScenario] FOREIGN KEY([EAScenarioId])
REFERENCES [dbo].[EAScenario] ([Id])
GO

ALTER TABLE [dbo].[UseCase] CHECK CONSTRAINT [FK_UseCase_EAScenario]
GO

