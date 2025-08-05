CREATE DATABASE BarberShop;
USE BarberShop;

CREATE TABLE Barbers (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY NOT NULL,
    FullName VARCHAR (50) NOT NULL,
    Gender VARCHAR(10),
    DateOfBirth DATE NOT NULL,
    HiringDate DATE NOT NULL,
    BarberRank VARCHAR(10),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    CONSTRAINT rank_allowed CHECK (BarberRank IN ('Chief', 'Senior', 'Junior'))
);
INSERT INTO Barbers (FullName, Gender, DateOfBirth, HiringDate, BarberRank, Email, Phone) VALUES
('John Doel', 'Male', '1988-05-10', '2010-06-15', 'Senior', 'john.doel@email.com', '555-1234'),
('Jane Smith', 'Female', '1985-08-20', '2012-09-05', 'Senior', 'jane.smith@email.com', '555-2345'),
('Mike Johnson', 'Male', '1990-01-15', '2015-03-10', 'Junior', 'mike.johnson@email.com', '555-3456'),
('Emily Davis', 'Female', '1989-04-22', '2011-11-20', 'Senior', 'emily.davis@email.com', '555-4567'),
('Robert Brown', 'Male', '1978-12-05', '2008-07-01', 'Senior', 'robert.brown@email.com', '555-5678'),
('Laura Wilson', 'Female', '1988-09-09', '2013-02-12', 'Junior', 'laura.wilson@email.com', '555-6789'),
('David Lee', 'Male', '1992-07-30', '2016-05-20', 'Junior', 'david.lee@email.com', '555-7890'),
('Sophia Clark', 'Female', '1983-02-13', '2014-08-25', 'Senior', 'sophia.clark@email.com', '555-8901'),
('William Martinez', 'Male', '1985-10-10', '2005-12-01', 'Chief', 'william.martinez@email.com', '555-9012'),
('Olivia Rodriguez', 'Female', '1995-11-25', '2018-03-05', 'Junior', 'olivia.rodriguez@email.com', '555-0123'),
('James Walker', 'Male', '1987-03-17', '2012-10-30', 'Senior', 'james.walker@email.com', '555-1324'),
('Isabella Hall', 'Female', '1989-06-08', '2015-09-15', 'Junior', 'isabella.hall@email.com', '555-1435');

CREATE TABLE Clients (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY NOT NULL,
    FullName VARCHAR (50) NOT NULL,
    Email VARCHAR(50),
    Phone VARCHAR(20),
    SchedulledOn DATETIME,
    SchedulledTo UNIQUEIDENTIFIER,
    FOREIGN KEY (SchedulledTo) REFERENCES Barbers(Id)
);
-- Schedule 5 clients for today
INSERT INTO Clients (FullName, Email, Phone, SchedulledOn, SchedulledTo) VALUES
('Alice Johnson', 'alice@example.com', '555-1001', CAST(CAST(GETDATE() AS DATE) AS DATETIME) + '09:15:00', '90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A'),
('Bob Martin', 'bob@example.com', '555-1002', CAST(CAST(GETDATE() AS DATE) AS DATETIME) + '10:45:00', 'AAD44263-5324-4A34-83E2-14A42C6953BB'),
('Charlie Smith', 'charlie@example.com', '555-1003', CAST(CAST(GETDATE() AS DATE) AS DATETIME) + '13:00:00', '42B55FC4-E8AD-461F-935B-1B706715F404'),
('Diana Reed', 'diana@example.com', '555-1004', CAST(CAST(GETDATE() AS DATE) AS DATETIME) + '15:15:00', '0FD73130-D60B-432C-A6BB-32F1CA063B97'),
('Ethan Hill', 'ethan@example.com', '555-1005', CAST(CAST(GETDATE() AS DATE) AS DATETIME) + '16:30:00', 'C4DF25B3-9D2C-4421-82DA-37078E05D65D');
-- Schedule 5 clients for tomorrow
INSERT INTO Clients (FullName, Email, Phone, SchedulledOn, SchedulledTo) VALUES
('Fiona Adams', 'fiona@example.com', '555-1006', CAST(CAST(DATEADD(day,1, GETDATE()) AS DATE) AS DATETIME) + '09:30:00', '7998422C-EC7B-420F-B411-382E74720D7A'),
('George Baker', 'george@example.com', '555-1007', CAST(CAST(DATEADD(day,1, GETDATE()) AS DATE) AS DATETIME) + '11:00:00', '98050509-A6F4-48F9-A14D-6F626E47710A'),
('Hannah Clark', 'hannah@example.com', '555-1008', CAST(CAST(DATEADD(day,1, GETDATE()) AS DATE) AS DATETIME) + '12:15:00', 'F694C97C-5D03-4509-8FEB-991E56593B39'),
('Ian Evans', 'ian@example.com', '555-1009', CAST(CAST(DATEADD(day,1, GETDATE()) AS DATE) AS DATETIME) + '14:00:00', '1C3602C1-7B9A-4DF3-B860-B3BD15DF4CE6'),
('Julia Foster', 'julia@example.com', '555-1010', CAST(CAST(DATEADD(day,1, GETDATE()) AS DATE) AS DATETIME) + '15:45:00', 'A545B901-25C0-4342-AE1D-BCD7BC1E7672');

CREATE TABLE ServiceList (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name VARCHAR (50) NOT NULL,
    Price MONEY,
    Duration TIME
);
INSERT INTO ServiceList (Name, Price, Duration) VALUES
('Basic Haircut', 20.00, '00:30:00'),
('Haircut & Styling', 35.00, '01:00:00'),
('Beard Trim', 15.00, '00:20:00'),
('Shave & Face Massage', 25.00, '00:45:00'),
('Color Highlights', 50.00, '01:30:00'),
('Hair Color', 40.00, '01:00:00'),
('Kids Haircut', 15.00, '00:30:00'),
('Beard Coloring', 30.00, '00:45:00'),
('Hair Wash & Blow-dry', 20.00, '00:45:00');

CREATE TABLE ServiceBarbers (
    ServiceListId INT,
    BarberId UNIQUEIDENTIFIER,
    PRIMARY KEY (ServiceListId, BarberId),
    FOREIGN KEY (ServiceListId) REFERENCES ServiceList(Id),
    FOREIGN KEY (BarberId) REFERENCES Barbers(Id)
);
INSERT INTO ServiceBarbers (ServiceListId, BarberId) VALUES
(1, '90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A'),
(1, 'AAD44263-5324-4A34-83E2-14A42C6953BB'),
(1, '42B55FC4-E8AD-461F-935B-1B706715F404'),
(2, '0FD73130-D60B-432C-A6BB-32F1CA063B97'),
(2, 'C4DF25B3-9D2C-4421-82DA-37078E05D65D'),
(2, '7998422C-EC7B-420F-B411-382E74720D7A'),
(3, '98050509-A6F4-48F9-A14D-6F626E47710A'),
(3, 'F694C97C-5D03-4509-8FEB-991E56593B39'),
(4, '1C3602C1-7B9A-4DF3-B860-B3BD15DF4CE6'),
(5, 'A545B901-25C0-4342-AE1D-BCD7BC1E7672'),
(6, '34D8F36B-BD69-454C-94DB-D8C6F77FDF9D'),
(6, '98050509-A6F4-48F9-A14D-6F626E47710A'),
(7, '3052C790-0469-405A-9187-FC39D284A6EE'),
(8, '90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A'),
(8, 'F694C97C-5D03-4509-8FEB-991E56593B39'),
(9, 'AAD44263-5324-4A34-83E2-14A42C6953BB');

CREATE TABLE VisitsArchive (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ClientId UNIQUEIDENTIFIER DEFAULT NEWID(),
    BarberId UNIQUEIDENTIFIER,
    [Procedure] VARCHAR(50),
    Date DATETIME,
    Rating INT,
    FeedBack VARCHAR(50),
    FOREIGN KEY (BarberId) REFERENCES Barbers(Id),
);

INSERT INTO VisitsArchive (BarberId, [Procedure], Date, Rating, FeedBack) VALUES
('90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A', 'Basic Haircut', '2025-07-05 09:30:00', 5, 'Great service!'),
('42B55FC4-E8AD-461F-935B-1B706715F404', 'Shave & Face Massage', '2025-07-05 11:00:00', 4, 'Very relaxing.'),
('7998422C-EC7B-420F-B411-382E74720D7A', 'Color Highlights', '2025-07-04 16:30:00', 3, 'Color could be better.'),
('98050509-A6F4-48F9-A14D-6F626E47710A', 'Deep Conditioning', '2025-07-04 09:15:00', 4, 'Nice treatment.'),
('F694C97C-5D03-4509-8FEB-991E56593B39', 'Beard Trim', '2025-07-04 10:45:00', 5, 'Perfect!'),
('90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A', 'Hair Wash & Blow-dry', '2025-07-04 15:15:00', 4, 'Good job.'),
('F694C97C-5D03-4509-8FEB-991E56593B39', 'Kids Haircut', '2025-07-05 14:00:00', 5, 'Kids loved it!'),
('90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A', 'Shaving & Grooming', '2025-07-05 12:15:00', 4, 'Nice shave.'),
('90E8FBC3-6D9C-4751-A3C8-0C0E12B32A7A', 'Hair Coloring', '2025-07-05 15:45:00', 3, 'Color faded quickly.'),
('98050509-A6F4-48F9-A14D-6F626E47710A', 'Scalp Treatment', '2025-07-04 13:00:00', 4, 'Good scalp care.');
