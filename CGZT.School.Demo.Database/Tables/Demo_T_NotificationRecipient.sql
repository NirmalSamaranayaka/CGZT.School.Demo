CREATE TABLE [cgzt].[Demo_T_NotificationRecipient]
(
	[Id] int IDENTITY(1,1) NOT NULL,
	[Demo_T_NotificationId] int NOT NULL,
	[Demo_T_StudentId] int NOT NULL,
	[IsNotificationSent] Bit Not NULL DEFAULT 'false',
	[CreatedBy] nvarchar(100) NOT NULL,
	[CreatedAt] datetime2 NOT NULL DEFAULT getdate(),
	[UpdatedBy] nvarchar(100) NULL,
	[UpdatedAt] datetime2 NULL,
	CONSTRAINT PK_Demo_T_NotificationRecipient PRIMARY KEY (Id),
	CONSTRAINT FK_NotificationRecipientNotificationId FOREIGN KEY  (Demo_T_NotificationId) REFERENCES [cgzt].Demo_T_Notification(Id),
    CONSTRAINT FK_NotificationRecipientStudentId FOREIGN KEY  (Demo_T_StudentId) REFERENCES [cgzt].Demo_T_Student(Id),
    CONSTRAINT UC_NotificationRecipient UNIQUE  (Demo_T_NotificationId, Demo_T_StudentId)
)
