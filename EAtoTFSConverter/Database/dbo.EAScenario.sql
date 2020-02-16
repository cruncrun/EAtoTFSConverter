USE [EATFSConverter]
GO

/****** Object:  Table [dbo].[EAScenario]    Script Date: 06.01.2020 17:36:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EAScenario](
	[Id] [uniqueidentifier] NOT NULL,
	[XmiId] [nvarchar](64) NOT NULL,
	[SubjectId] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Timestamp] [datetime] NULL,
	[PreviousVersionId] [uniqueidentifier] NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EAScenario]  WITH CHECK ADD  CONSTRAINT [FK_EAScenario_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO

ALTER TABLE [dbo].[EAScenario] CHECK CONSTRAINT [FK_EAScenario_Project]
GO

