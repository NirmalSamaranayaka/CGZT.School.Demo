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


BEGIN /**** Student ********/
PRINT 'Inserting data for Student'

SET IDENTITY_INSERT [cgzt].[Demo_T_Student] ON 

INSERT [cgzt].[Demo_T_Student] ([Id], [Name], [Email], [IsSuspend], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (1, N'studentjon', N'studentjon@gmail.com', 0, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_Student] ([Id], [Name], [Email], [IsSuspend], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (2, N'studentmary', N'studentmary@gmail.com', 0, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_Student] ([Id], [Name], [Email], [IsSuspend], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (3, N'studenthon', N'studenthon@gmail.com', 0, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_Student] ([Id], [Name], [Email], [IsSuspend], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (4, N'commonstudent1', N'commonstudent1@gmail.com', 0, N'Syetem', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_Student] ([Id], [Name], [Email], [IsSuspend], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (5, N'commonstudent2', N'commonstudent2@gmail.com', 0, N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_Student] ([Id], [Name], [Email], [IsSuspend], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (6, N'student_only_under_teacher_ken', N'student_only_under_teacher_ken@gmail.com', 0, N'System', GETDATE(), NULL, NULL)
SET IDENTITY_INSERT [cgzt].[Demo_T_Student] OFF

END
GO

BEGIN /**** Teacher ********/
PRINT 'Inserting data for Teacher'

SET IDENTITY_INSERT [cgzt].[Demo_T_Teacher] ON 

INSERT [cgzt].[Demo_T_Teacher] ([Id], [Name], [Email], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (1, N'Ken', N'teacherken@gmail.com', N'System', GETDATE(), NULL, NULL)
INSERT [cgzt].[Demo_T_Teacher] ([Id], [Name], [Email], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (2, N'Joe', N'teacherjoe@gmail.com', N'System', GETDATE(), NULL, NULL)
SET IDENTITY_INSERT [cgzt].[Demo_T_Teacher] OFF

END
GO
