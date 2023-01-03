USE EmployeesDb

GO
CREATE TABLE dbo.Departments
(
	Id INT IDENTITY PRimary key,
	Name VARCHAR(70) NOT NULL,
	Floor INT NOT NULL
)

GO
CREATE TABLE dbo.ProgrammingLanguages
(
	Id INT IDENTITY PRimary key,
	Name VARCHAR(70) NOT NULL
)

GO
CREATE TABLE dbo.Employees
(
	Id INT IDENTITY PRimary key,
	Name VARCHAR(70) NOT NULL,
	Surname VARCHAR(70) NOT NULL,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES dbo.Departments(Id),
	ProgrammingLanguageId INT FOREIGN KEY REFERENCES dbo.ProgrammingLanguages(id)
)

GO
CREATE VIEW dbo.EmployeeView AS

SELECT e.*, d.Name 'DepartmentName', pl.Name 'ProgrammingLanguageName' FROM dbo.Employees e (NOLOCK)
	JOIN 
		dbo.Departments d (NOLOCK)
		ON e.DepartmentID = d.id
	JOIN
		dbo.ProgrammingLanguages pl (NOLOCK)
		ON pl.id = e.ProgrammingLanguageId

GO
CREATE OR ALTER PROC dbo.AddEmployee
	@Name VARCHAR(70),
	@Surname VARCHAR(70),
	@Age INT,
	@DepartmentId INT,
	@ProgrammingLanguageId INT
AS
BEGIN
	INSERT INTO dbo.Employees
	(
		Name,
		Surname,
		Age,
		DepartmentId,
		ProgrammingLanguageId
	)
	VALUES
	(
		@Name,
		@Surname,
		@Age,	
		@DepartmentId,
		@ProgrammingLanguageId
	)
END

GO
CREATE OR ALTER PROC dbo.UpdateEmployee
	@Id INT,
	@Name VARCHAR(70),
	@Surname VARCHAR(70),
	@Age INT,
	@DepartmentId INT,
	@ProgrammingLanguageId INT
AS
BEGIN
	UPDATE dbo.Employees
	SET
		Name = @Name,
		Surname = @Surname,
		Age = @Age,
		DepartmentId = @DepartmentId,
		ProgrammingLanguageId = @ProgrammingLanguageId
	WHERE 
		id = @Id 
END
	
GO
CREATE OR ALTER PROC dbo.GetProgrammingLanguages
AS
BEGIN
	SELECT * FROM dbo.ProgrammingLanguages  (NOLOCK)
END

GO
CREATE OR ALTER PROC dbo.GetDepartments  
AS
BEGIN
	SELECT * FROM dbo.Departments (NOLOCK)
END

GO
CREATE OR ALTER PROC dbo.GetEmployeeViews
AS
Begin
	SELECT * FROM dbo.EmployeeView
END

GO
CREATE OR ALTER PROC dbo.GetEmployeeViewById
	@EmployeeId INT
AS
BEGIN 
	SELECT TOP 1 * FROM dbo.EmployeeView e
	WHERE e.id = @EmployeeId
END 

GO
CREATE OR ALTER PROC dbo.DeleteEmployee
	@EmployeeId INT
AS
BEGIN 
	DELETE FROM dbo.Employees 
	WHERE id = @EmployeeId
END 


GO
INSERT INTO
dbo.ProgrammingLanguages
VALUES
(
	'Php'
),
(
	'C++'
),
(
	'GO'
)

GO
INSERT INTO 
dbo.Departments
VALUES
(
	'Development',
	2
),
(
	'Security',
	1
),
(
	'Support',
	3
)

	GO
	INSERT INTO 
	dbo.Employees
	VALUES
	(
		'TestName',
		'TestSurname',
		45,
		1,
		2
	),
	(
		'John',
		'Doe',
		36,
		2,
		1
	)
