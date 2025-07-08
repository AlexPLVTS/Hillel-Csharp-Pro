CREATE DATABASE HOMEWORK;
USE HOMEWORK;

CREATE TABLE StudentGrades (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100),
    City VARCHAR(50),
    Country VARCHAR(50),
    DateOfBirth DATE,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    GroupName VARCHAR(50),
    AvgGradeYear DECIMAL(4,2),
    SubjectMinName VARCHAR(50),
    SubjectMaxName VARCHAR(50)
);

INSERT INTO StudentGrades (
    FullName, City, Country, DateOfBirth, Email, Phone, GroupName, AvgGradeYear, SubjectMinName, SubjectMaxName
) VALUES
('Maria Lopez', 'Madrid', 'Spain', '2000-04-15', 'maria.lopez@example.com', '912345678', 'Group A', 4.1, 'History', 'Mathematics'),
('Wei Chen', 'Beijing', 'China', '1999-09-20', 'wei.chen@example.com', '13800138000', 'Group B', 3.9, 'English', 'Physics'),
('Liam O''Connor', 'Dublin', 'Ireland', '2001-02-12', 'liam.oconnor@example.com', '0871234567', 'Group C', 4.3, 'Biology', 'Chemistry'),
('Aisha Khan', 'Karachi', 'Pakistan', '2000-11-05', 'aisha.khan@example.com', '03001234567', 'Group A', 4.0, 'Mathematics', 'History'),
('Carlos Silva', 'Lisbon', 'Portugal', '1998-07-22', 'carlos.silva@example.com', '910234567', 'Group B', 3.7, 'English', 'Biology'),
('Nina Petrova', 'Sofia', 'Bulgaria', '2002-03-18', 'nina.petrova@example.com', '02-123-4567', 'Group C', 4.2, 'Physics', 'Chemistry'),
('Akira Yamada', 'Tokyo', 'Japan', '1999-10-10', 'akira.yamada@example.com', '090-1234-5678', 'Group A', 4.5, 'Mathematics', 'English'),
('Fatima Al-Hassan', 'Riyadh', 'Saudi Arabia', '2000-06-25', 'fatima.alhassan@example.com', '055-123-4567', 'Group B', 4.0, 'History', 'Biology'),
('Mykhaylo Ivanov', 'Kyiv', 'Ukraine', '1999-12-02', 'mik.ivanov@example.com', '380-123-4567', 'Group C', 3.8, 'Chemistry', 'Mathematics'),
('Sofia Russo', 'Rome', 'Italy', '2001-08-30', 'sofia.russo@example.com', '06-123-4567', 'Group A', 4.4, 'English', 'Physics');

INSERT INTO StudentGrades (
    FullName, City, Country, DateOfBirth, Email, Phone, GroupName, AvgGradeYear, SubjectMinName, SubjectMaxName
) VALUES
('Elena Garcia', 'Barcelona', 'Spain', '2000-09-11', 'elena.garcia@example.com', '655123456', 'Group D', 4.0, 'History', 'Mathematics'),
('Marco Rossi', 'Milan', 'Italy', '1999-11-23', 'marco.rossi@example.com', '02-9876543', 'Group B', 3.9, 'English', 'Physics'),
('Yuki Takahashi', 'Tokyo', 'Japan', '2002-02-14', 'yuki.takahashi@example.com', '090-5678-1234', 'Group A', 4.2, 'Biology', 'Chemistry'),
('Ahmed Said', 'Cairo', 'Egypt', '2001-06-30', 'ahmed.said@example.com', '0123456789', 'Group C', 3.8, 'History', 'Biology'),
('Lara Novak', 'Prague', 'Czech Republic', '1998-10-05', 'lara.novak@example.com', '+420-123456789', 'Group D', 4.3, 'Mathematics', 'English'),
('Sophia M?ller', 'Berlin', 'Germany', '2000-12-12', 'sophia.muller@example.com', '030-123456', 'Group B', 4.1, 'Physics', 'Chemistry'),
('Ivan Popov', 'Sofia', 'Bulgaria', '1999-03-17', 'ivan.popov@example.com', '02-654-3210', 'Group C', 3.7, 'History', 'Mathematics'),
('Hassan Sadek', 'Alexandria', 'Egypt', '2001-09-21', 'hassan.sadek@example.com', '01122334455', 'Group D', 4.0, 'Biology', 'English'),
('Mira Kova?evi?', 'Zagreb', 'Croatia', '2002-07-15', 'mira.kovacevic@example.com', '01-234-5678', 'Group A', 4.2, 'Chemistry', 'Physics'),
('Ravi Patel', 'Mumbai', 'India', '2000-05-09', 'ravi.patel@example.com', '0987654321', 'Group B', 3.9, 'History', 'Biology');