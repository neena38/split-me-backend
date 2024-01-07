CREATE TABLE [dbo].[Profiles]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [NameSet] VARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id]),
)
