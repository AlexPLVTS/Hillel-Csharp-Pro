USE BarberShop;

SELECT FullName FROM Barbers
SELECT * FROM Barbers WHERE BarberRank = 'Senior'

SELECT b.*
FROM Barbers b
JOIN ServiceBarbers sb ON b.Id = sb.BarberId
JOIN ServiceList s ON sb.ServiceListId = s.Id
WHERE s.Name = 'Basic Haircut'; --barbers who can make basic haircut

SELECT * FROM Barbers WHERE DATEDIFF(YEAR, HiringDate, GETDATE()) > 10; --barbers with more then 10 exp.

SELECT BarberRank, COUNT(BarberRank) AS Count
FROM Barbers
WHERE BarberRank IN ('Junior', 'Senior')
GROUP BY BarberRank; --returns count of juniors and seniors