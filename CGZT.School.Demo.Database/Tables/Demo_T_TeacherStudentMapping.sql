CREATE TABLE [cgzt].[Demo_T_TeacherStudentMapping]
(
	[Id] int IDENTITY(1,1) NOT NULL,
	[Demo_T_TeacherId] int NOT NULL,
	[Demo_T_StudentId] int NOT NULL,
	[CreatedBy] nvarchar(100) NOT NULL,
	[CreatedAt] datetime2 NOT NULL DEFAULT getdate(),
	[UpdatedBy] nvarchar(100) NULL,
	[UpdatedAt] datetime2 NULL,
	CONSTRAINT PK_Demo_T_TeacherStudentMapping PRIMARY KEY (Id),
	CONSTRAINT FK_TeacherStudentMappingTeacherId FOREIGN KEY  (Demo_T_TeacherId) REFERENCES [cgzt].Demo_T_Teacher(Id),
    CONSTRAINT FK_TeacherStudentMappingStudentId FOREIGN KEY  (Demo_T_StudentId) REFERENCES [cgzt].Demo_T_Student(Id),
    CONSTRAINT UC_TeacherStudentMapping UNIQUE  (Demo_T_TeacherId, Demo_T_StudentId)
)
