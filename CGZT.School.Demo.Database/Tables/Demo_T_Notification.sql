CREATE TABLE [cgzt].[Demo_T_Notification]
(
	[Id] int IDENTITY(1,1) NOT NULL,
	[Demo_T_TeacherId] int NOT NULL,
	[Notification] nvarchar(100) NOT NULL,
	[CreatedBy] nvarchar(100) NOT NULL,
	[CreatedAt] datetime2 NOT NULL DEFAULT getdate(),
	[UpdatedBy] nvarchar(100) NULL,
	[UpdatedAt] datetime2 NULL,
	CONSTRAINT PK_Demo_T_Notification PRIMARY KEY (Id),
	CONSTRAINT FK_Demo_T_NotificationTeacherId FOREIGN KEY  (Demo_T_TeacherId) REFERENCES [cgzt].Demo_T_Teacher(Id),
)
