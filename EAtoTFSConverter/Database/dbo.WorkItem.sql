USE [EATFSConverter]
GO

/****** Object:  Table [dbo].[WorkItem]    Script Date: 06.01.2020 17:35:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkItem](
	[Id] [uniqueidentifier] NOT NULL,
	[EAId] [uniqueidentifier] NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
	[WorkItemId] [int] NOT NULL,
	[WorkItemType] [smallint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[WorkItem]  WITH CHECK ADD  CONSTRAINT [FK_WorkItem_EAScenario] FOREIGN KEY([EAId])
REFERENCES [dbo].[EAScenario] ([Id])
GO

ALTER TABLE [dbo].[WorkItem] CHECK CONSTRAINT [FK_WorkItem_EAScenario]
GO

ALTER TABLE [dbo].[WorkItem]  WITH CHECK ADD  CONSTRAINT [FK_WorkItem_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO

ALTER TABLE [dbo].[WorkItem] CHECK CONSTRAINT [FK_WorkItem_Project]
GO


