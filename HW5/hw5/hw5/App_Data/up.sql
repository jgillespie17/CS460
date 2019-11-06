CREATE TABLE [dbo].[Homework]
(
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Urgency] INT NOT NULL,
	[DueDate] DATETIME NOT NULL,
	[Department] NVARCHAR(32) NOT NULL,
	[Course] INT NOT NULL,
	[Title] NVARCHAR(64) NOT NULL,
	[Notes] NVARCHAR(512) NOT NULL,
	CONSTRAINT [Pk_dbo.Homeworks] Primary key clustered ([ID] ASC)
	);

INSERT INTO [dbo].[Homework] (Urgency, DueDate, DEPARTMENT, COURSE, TITLE, NOTES) Values
	('1', '1945-07-16 05:29:00', 'HIS', '450', 'MANHATTAN', 'CLASSIFIED'),
	('2', '1944-06-06 06:30:00', 'HIS', '450', 'OVERLORD', 'CLASSIFIED'),
	('3', '1945-11-01 05:30:00', 'HIS', '450', 'OLYMPIC', 'CLASSIFIED'),
	('4', '1942-11-8 12:50:00', 'HIS', '450', 'TORCH', 'CLASSIFIED'),
	('5', '1945-04-10 20:20:20', 'HIS', '450', 'PAPERCLIP', 'CLASSIFIED'); 
