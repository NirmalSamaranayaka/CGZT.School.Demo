# School Management System
1. Project Setup Step steps

*Open "CGZT.School.Demo.sln" file using Visual studio 

Then you can see basic project layors as below. 

![image](https://user-images.githubusercontent.com/86515501/124052551-3c12c000-da51-11eb-83cd-5073f843d1a1.png)

This project used SOLID principle with Adapter design pattern with multi layored architecture. This project is build in very generic way and able to extend very easily

Used Technologies : Asp.net core 5.0 Web API, Entity Framwork Core, Automapper,.net Core Dependency resolver, .net core Logger, Swagger for API testing, Recorces file for Error Messages, SQL server

------------------------------------------------------------------------------------------------------------------------------------------
2. Database Setup(SQL SERVER)

Go to "CGZT.School.Demo.Database" project and open "DatabaseCreationwithUserMapping.sql" script and follow given steps as below

![image](https://user-images.githubusercontent.com/86515501/124054014-cf4cf500-da53-11eb-85ac-395753509616.png)

*Step 1 Create DB and Create User with Schema and map schema secutity
Create Database [cgzt-school-db-dev]

*Create User Login
CREATE LOGIN [cgztdev] WITH PASSWORD = 'pass#word1'

*User map with Login
CREATE USER [cgztdev] FOR LOGIN [cgztdev]

*Step 2
USE [cgzt-school-db-dev]
CREATE SCHEMA [cgzt]


*Step 3
--user mapp with schema
CREATE USER [cgztdev]
	FOR LOGIN [cgztdev]
	WITH DEFAULT_SCHEMA = [cgzt]
GO

*Add user to the database owner role
EXEC sp_addrolemember N'db_owner', [cgztdev]
GO




3. Publish Database Table via Database Project

Below you can see database project and please follow given instructions to deploy detabase to sql server
![Untitled](https://user-images.githubusercontent.com/86515501/124054459-a24d1200-da54-11eb-8edb-553f2c882f82.png)

right click Database project and Click "Publish" buton

![124050958-2223ae00-da4e-11eb-922c-deef70652ea0](https://user-images.githubusercontent.com/86515501/124053758-636a8c80-da53-11eb-8a2d-34ab3d44ca1c.png)

After Click "Publish" will come popup as below
![image](https://user-images.githubusercontent.com/86515501/124051018-39629b80-da4e-11eb-8b2f-e4aad97ca303.png)

Ten please setup give your server, Database, user name and password and then check cnnection okay or not using"Test Connacron" as below
![image](https://user-images.githubusercontent.com/86515501/124051316-d7eefc80-da4e-11eb-9e15-5944c2b3ab1d.png)

After configure server you will be able to see below window and then press "Publish"button and 
![image](https://user-images.githubusercontent.com/86515501/124051415-11276c80-da4f-11eb-9c6e-61890eedc332.png

After publish you are able to see table details in SQL management Studio(SSMS)

![image](https://user-images.githubusercontent.com/86515501/124051557-48961900-da4f-11eb-99d4-3dba10a1b9a0.png)

Then goto "CGZT.School.Demo.WebAPI" project and open "appsettings.Development.json" file and setup your server and database details as below

![Capturew](https://user-images.githubusercontent.com/86515501/124051978-176a1880-da50-11eb-9a88-03bec594c272.PNG)


Adter setup Database you can chack main project "CGZT.School.Demo.WebAPI" and Run project. Then you will be able to see all api details and you can test this API using Swagger/ Postman

![image](https://user-images.githubusercontent.com/86515501/124052179-80519080-da50-11eb-82ca-8787609117a4.png)













