USE [EATFSConverter]
GO

/****** Object:  Table [dbo].[Step]    Script Date: 06.01.2020 17:36:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Step](
	[Id] [uniqueidentifier] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[EAScenarioId] [uniqueidentifier] NOT NULL,
	[SubjectId] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Level] [int] NOT NULL,
	[Result] [nvarchar](max) NOT NULL,
	[Timestamp] [datetime] NULL,
	[PreviousVersionId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Step]  WITH CHECK ADD  CONSTRAINT [FK_Step_EAScenario] FOREIGN KEY([EAScenarioId])
REFERENCES [dbo].[EAScenario] ([Id])
GO

ALTER TABLE [dbo].[Step] CHECK CONSTRAINT [FK_Step_EAScenario]
GO


