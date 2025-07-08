SELECT * FROM [HOMEWORK].dbo.StudentGrades; --view complete table
SELECT FullName FROM [HOMEWORK].dbo.StudentGrades; --view fullnames
SELECT AvgGradeYear FROM [HOMEWORK].dbo.StudentGrades; --show average grades
SELECT FullName, AvgGradeYear FROM [HOMEWORK].dbo.StudentGrades WHERE AvgGradeYear > 4.0; --show students with AGY more then 4
SELECT DISTINCT Country FROM [HOMEWORK].dbo.StudentGrades; --view unique countries
SELECT DISTINCT City FROM [HOMEWORK].dbo.StudentGrades; --view unique cities
SELECT DISTINCT GroupName FROM [HOMEWORK].dbo.StudentGrades; --show unique groups