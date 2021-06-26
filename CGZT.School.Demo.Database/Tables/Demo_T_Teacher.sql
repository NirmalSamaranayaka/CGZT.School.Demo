CREATE TABLE [cgzt].[Demo_T_Teacher]
(
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	[Email] nvarchar(200) NOT NULL UNIQUE,
	[IsSuspend] Bit Not NULL DEFAULT 'false',
	[CreatedBy] nvarchar(100) NOT NULL,
	[CreatedAt] datetime2 NOT NULL DEFAULT getdate(),
	[UpdatedBy] nvarchar(100) NULL,
	[UpdatedAt] datetime2 NULL,
	CONSTRAINT PK_Demo_T_Teacher PRIMARY KEY (Id)
)
