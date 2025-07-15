SELECT * FROM [Hospital].dbo.Wards; --get info from Wards

SELECT LastName, PhoneNumber FROM [Hospital].dbo.Doctors; --Doctors LastNames and Numbers

SELECT DISTINCT Floor FROM [Hospital].dbo.Wards; --distinct floors

SELECT DiseaseName AS 'Name of Disease', Severity AS 'Severity of Disease' FROM [Hospital].dbo.Diseases; --show with tags

SELECT StartTime AS 'Start of procedure' FROM [Hospital].dbo.Examinations; --tags1

SELECT Id AS 'Unique identification code' FROM [Hospital].dbo.Doctors; --tags2

SELECT Salary AS 'Doctors annual salary' FROM [Hospital].dbo.Doctors; --tags3

SELECT DepartmentName FROM [Hospital].dbo.Departments 
WHERE Building = 5 AND Financing < 30000; --departments from building 5 with financing less then 30000

SELECT DepartmentName FROM [Hospital].dbo.Departments 
WHERE Building = 3 AND Financing BETWEEN 120000 AND 190000; --departments from building 3 with financing 120000-190000

SELECT WardName FROM [Hospital].dbo.Wards WHERE Building IN(4,5) AND Floor = 1; --wards from buildings 4 and 5 on 1st floor

SELECT DepartmentName, Building, Financing FROM [Hospital].dbo.Departments
WHERE (Building = 3 OR Building = 5) AND (Financing < 110000 OR Financing > 150000); --departmens from building 3 or 5 with financing less then 110000 or more then 150000

SELECT DISTINCT ExaminationName FROM [Hospital].dbo.Examinations 
WHERE (DayOfWeek BETWEEN 1 AND 3) AND (StartTime >= '12:00' AND EndTime <= '15:00'); --examinations three first days of week from 12 to 15

SELECT DepartmentName, Building FROM [Hospital].dbo.Departments WHERE Building IN(1,3,8,10); --departments from buildings 1,3,8,10

SELECT DiseaseName FROM [Hospital].dbo.Diseases WHERE (Severity <> 1 AND Severity <> 2); --diseases except severity 1 and 2

SELECT DepartmentName FROM [Hospital].dbo.Departments WHERE (Building <> 1 AND Building <> 3);

SELECT LastName FROM [Hospital].dbo.Doctors WHERE LastName LIKE 'M%'; --doctors lastnames starting with 'M'
