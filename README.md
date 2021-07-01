# School Management System
Project Setup Steps
1.Open ".Sln" file via Visual studio 
Then you can see basic project layors as below. This project used SOLID principle with Adapter design pattern with multi layored architecture. This project is build in very generic way and able to extend very easily
Used Technologies : Asp.net core 5.0 Web API, Entity Framwork Core, Automapper,.net Core Dependency resolver, .net core Logger, Recorces file for Error Messages


![image](https://user-images.githubusercontent.com/86515501/124052551-3c12c000-da51-11eb-83cd-5073f843d1a1.png)


Database Setup(SQL SERVER)
2.---Step 1 Create DB and Create User with Schema and map schema secutity
Create Database [cgzt-school-db-dev]

--Create User Login
CREATE LOGIN [cgztdev] WITH PASSWORD = 'pass#word1'

--User map with Login
CREATE USER [cgztdev] FOR LOGIN [cgztdev]

---Step 2
USE [cgzt-school-db-dev]
CREATE SCHEMA [cgzt]


---Step 3
--user mapp with schema
CREATE USER [cgztdev]
	FOR LOGIN [cgztdev]
	WITH DEFAULT_SCHEMA = [cgzt]
GO

-- Add user to the database owner role
EXEC sp_addrolemember N'db_owner', [cgztdev]
GO


3.Publish Database Table via Database Project

![image](https://user-images.githubusercontent.com/86515501/124050686-9b6ed100-da4d-11eb-8a57-a269fcefec56.png)

right click Database project and Click "Publish" buton

![image](https://user-images.githubusercontent.com/86515501/124050958-2223ae00-da4e-11eb-922c-deef70652ea0.png)

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













