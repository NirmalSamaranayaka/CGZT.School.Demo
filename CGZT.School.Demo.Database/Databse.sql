---Step 1
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
