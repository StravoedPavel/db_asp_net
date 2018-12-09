USE [EmployeeDB]
GO


INSERT INTO [dbo].[TypeDocument]
           ([Id_TypeDocument]
           ,[TypeName])
     VALUES
           (1,'Паспорт'),
		   (2,'Права'),
		   (3,'Диплом'),
		   (4,'Справка'),
		   (5,'Доп. справки')
GO

INSERT INTO [dbo].[Department]
           ([Id_Department]
           ,[Name]
           ,[Rate])
     VALUES
           (1,'Отдел мира',100),
		   (2,'Отдел правды',200),
		   (3,'Отдел изобилия',300),
		   (4,'Отдел любви',400)
GO

INSERT INTO [dbo].[Position]
           ([Id_Position]
           ,[Name]
           ,[Rate])
     VALUES
           (1,'Военный',100),
		   (2,'Критик',200),
		   (3,'Политик',300),
		   (4,'Пожарник',400),
		   (5,'Врач',500)
GO

INSERT INTO [dbo].[Department_Position]
           ([Id_D_P]
           ,[Id_Department]
           ,[Id_Position])
     VALUES
           (1,1,1),
		   (2,2,2),
		   (3,3,3),
		   (4,4,4),
		   (5,4,5),
		   (6,3,4),
		   (7,2,3),
		   (8,1,2)
GO

INSERT INTO [dbo].[Document]
           ([Id_Document]
           ,[Series]
           ,[DateOfIssue]
           ,[Scan]
           ,[Id_TypeDocument])
     VALUES
           (1,'123asdas','11-11-11',null,1),
		   (2,'321asdsad','12-12-12',null,2),
		   (3,'13444','9-9-9',null,3),
		   (4,'141asdasd','8-8-8',null,4),
		   (5,'asd1441','7-7-7',null,5)
GO

INSERT INTO [dbo].[Employee]
           ([Id_Employee]
           ,[FullName]
           ,[Gender]
           ,[Address]
           ,[Phone]
           ,[MaritalStatus]
           ,[Id_D_P])
     VALUES
           (1,'FullName 1', 'Мужчина','Харьков стрит','+3809333333','одинок',1),
		   (2,'FullName 2', 'Мужчина','Харьков стрит','+3809333333','одинок',2),
		   (3,'FullName 3', 'Мужчина','Харьков стрит','+3809333333','одинок',3),
		   (4,'FullName 4', 'Мужчина','Харьков стрит','+3809333333','одинок',4),
		   (5,'FullName 5', 'Мужчина','Харьков стрит','+3809333333','одинок',5),
		   (6,'FullName 6', 'Мужчина','Харьков стрит','+3809333333','одинок',6),
		   (7,'FullName 7', 'Мужчина','Харьков стрит','+3809333333','одинок',7),
		   (8,'FullName 8', 'Мужчина','Харьков стрит','+3809333333','одинок',8),
		   (9,'FullName 9', 'Мужчина','Харьков стрит','+3809333333','одинок',1)
GO

INSERT INTO [dbo].[Employee_Document]
           ([Id_Employee]
           ,[Id_Document])
     VALUES
           (1,1),
		   (2,2),
		   (3,3),
		   (4,4),
		   (5,5),
		   (6,5),
		   (7,4),
		   (8,3),
		   (9,2)
GO

INSERT INTO [dbo].[EmploymentHistory]
           ([Id_EmploymentHistory]
           ,[EmploymentDate]
           ,[DateOfDismissal]
           ,[Id_Employee]
           ,[Experience])
     VALUES
           (1,'1900-01-01','1900-01-02',1,2),
		   (2,'1900-01-01','1900-01-02',2,12),
		   (3,'1900-01-01','1900-01-02',3,11),
		   (4,'1900-01-01','1900-01-02',4,10),
		   (5,'1900-01-01','1900-01-02',5,4),
		   (6,'1900-01-01','1900-01-02',6,9),
		   (7,'1900-01-01',null,7,1),
		   (8,'1900-01-01',null,8,5),
		   (9,'1900-01-01',null,9,3)
GO