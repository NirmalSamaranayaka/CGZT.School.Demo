/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/




BEGIN /**** TeacherStudentMappings ********/
PRINT 'Inserting data for TeacherStudentMapping'
SET IDENTITY_INSERT [cgzt].[Demo_T_TeacherStudentMapping] ON 

INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (1, 1, 1, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (2, 1, 3, N'Syetem', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (3, 1, 4, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (4, 1, 5, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (5, 2, 4, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (6, 2, 5, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_TeacherStudentMapping] ([Id], [Demo_T_TeacherId], [Demo_T_StudentId], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (7, 1, 6, N'System', GETDATE(), NULL, NULL)
SET IDENTITY_INSERT [cgzt].[Demo_T_TeacherStudentMapping] OFF

END
GO