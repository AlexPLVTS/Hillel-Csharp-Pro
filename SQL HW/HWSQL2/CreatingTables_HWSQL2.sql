USE Hospital;

CREATE TABLE Departments 
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Building INT CHECK (Building > 0 AND Building < 6) NOT NULL,
	Financing DECIMAL(9, 3) DEFAULT 0 CHECK (Financing >= 0),
	DepartmentName VARCHAR(100) CHECK (DepartmentName <> '') NOT NULL UNIQUE,
)

INSERT INTO Departments (Building, Financing, DepartmentName)
VALUES
(1, 150000.75, 'Cardiology'),
(2, 250000.00, 'Neurology'),
(3, 50000.00, 'Pediatrics'),
(4, 100000.50, 'Radiology'),
(5, 75000.00, 'Oncology'),
(2, 200000.00, 'Emergency Medicine'),
(3, 180000.25, 'Orthopedics'),
(1, 135000.85, 'Laboratory Services'),
(4, 95000.00, 'Anesthesiology'),
(5, 120000.00, 'Dermatology');

CREATE TABLE Diseases 
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DiseaseName VARCHAR(100) CHECK (DiseaseName <> '') NOT NULL UNIQUE,
	Severity INT DEFAULT 1 CHECK (Severity >= 1)
)

INSERT INTO Diseases (DiseaseName, Severity)
VALUES
('Common Cold', 1),
('Flu', 2),
('Diabetes', 3),
('Hypertension', 2),
('Asthma', 2),
('COVID-19', 3),
('Migraine', 1),
('Pneumonia', 3),
('Cancer', 4),
('Tuberculosis', 3);

CREATE TABLE Doctors
(
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY NOT NULL,
	FirstName VARCHAR(MAX) CHECK (FirstName <> '') NOT NULL,
	LastName  VARCHAR(MAX) CHECK (LastName <> '') NOT NULL,
	PhoneNumber CHAR(10),
	Salary DECIMAL(6, 3) CHECK (Salary > 0) NOT NULL
)

INSERT INTO Doctors (FirstName, LastName, PhoneNumber, Salary)
VALUES
('Aurelia', 'Vandermeer', '5553456701', 142.500),
('Dorian', 'Blackwood', '5554567802', 155.300),
('Xavier', 'Montgomery', '5555678903', 138.750),
('Selena', 'Gardner', '5556789014', 128.600),
('Finnian', 'O’Connor', '5557890125', 132.900),
('Lyra', 'Sanchez', '5558901236', 124.450),
('Lucian', 'Devereux', '5559012347', 160.000),
('Isolde', 'Thorne', '5550123458', 147.250),
('Ezekiel', 'Starling', '5551234569', 135.600),
('Amara', 'Silvers', '5552345670', 150.900),
('Caspian', 'Kingsley', '5553456781', 142.300),
('Selena', 'Moonstone', '5554567892', 148.500);

CREATE TABLE Examinations
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DayOfWeek INT CHECK (DayOfWeek > 0 AND DayOfWeek < 8) NOT NULL,
	StartTime TIME(0) CHECK (StartTime >= '08:00' AND StartTime <= '18:00') NOT NULL,
	EndTime TIME(0) NOT NULL,
	CONSTRAINT chk_EndTime_after_StartTime CHECK (EndTime > StartTime),
	ExaminationName NVARCHAR(100) CHECK (ExaminationName <> '') UNIQUE NOT NULL 
)

INSERT INTO Examinations (DayOfWeek, StartTime, EndTime, ExaminationName)
VALUES
(1, '09:00', '10:00', N'Blood Test'),
(2, '10:30', '11:30', N'X-Ray'),
(3, '08:15', '09:00', N'MRI Scan'),
(4, '13:00', '14:00', N'Ultrasound'),
(5, '15:30', '16:30', N'ECG'),
(6, '11:00', '12:00', N'Physiotherapy'),
(7, '16:00', '17:00', N'Blood Pressure Check'),
(1, '14:00', '15:00', N'Vision Test'),
(2, '09:30', '10:15', N'Dental Checkup'),
(3, '12:30', '13:30', N'Allergy Test');

CREATE TABLE Wards
(
	Id INT IDENTITY(100,1) PRIMARY KEY NOT NULL,
	Building INT CHECK (Building > 0 AND Building < 6) NOT NULL,
	Floor INT CHECK (Floor > 0) NOT NULL,
	WardName NVARCHAR(100) CHECK (WardName <> '') UNIQUE NOT NULL 
)

INSERT INTO Wards (Building, Floor, WardName)
VALUES
-- Building 1 wards
(1, 1, N'Cardiology Ward A'),
(1, 2, N'Laboratory Ward'),
(1, 3, N'Recovery Ward 1'),
(1, 4, N'Cardiology ICU'),
(1, 5, N'Pediatric Ward A'),
-- Building 2 wards
(2, 1, N'Neurology Ward'),
(2, 2, N'Emergency Dept Ward'),
(2, 3, N'Neurology ICU'),
(2, 4, N'Emergency Observation'),
(2, 5, N'Neuro Surgery Ward'),
-- Building 3 wards
(3, 1, N'Pediatrics Ward'),
(3, 2, N'Orthopedics Ward'),
(3, 3, N'Pediatric ICU'),
(3, 4, N'Orthopedics Surgery'),
(3, 5, N'Pediatrics Observation'),
-- Building 4 wards
(4, 1, N'Radiology Department'),
(4, 2, N'Anesthesiology Ward'),
(4, 3, N'Surgical Recovery'),
(4, 4, N'Radiology ICU'),
(4, 5, N'Surgical ICU'),
-- Building 5 wards
(5, 1, N'Oncology Ward'),
(5, 2, N'Dermatology Ward'),
(5, 3, N'Oncology ICU'),
(5, 4, N'Dermatology Observation'),
(5, 5, N'Cancer Care Ward');