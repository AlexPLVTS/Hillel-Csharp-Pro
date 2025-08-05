CREATE DATABASE Functions;
USE Functions;

DECLARE @name NVARCHAR(20);
SET @name='Tom';
PRINT 'Hello ' + @name; --print hello name
--------------
SELECT DATEPART(minute, GETDATE()) AS CurrentMinutes; --current minutes
--------------
SELECT DATEPART(YEAR, GETDATE()) AS CurrentYear; --current year
--------------
IF (DATEPART(YEAR, GETDATE()) % 2 = 0)
	PRINT 'Even'
ELSE
	PRINT 'Odd'
--------------
DECLARE @number INT, @IsPrime INT;
SET @number=7;
SET @IsPrime=1;
IF (@number < 2)
	SET @IsPrime = 0;
ELSE
	BEGIN
		DECLARE @i INT = 2
		WHILE @i <= SQRT(@number)
			BEGIN
				IF @number % @i = 0
				BEGIN
					SET @IsPrime = 0;
					BREAK;
				END
				SET @i = @i + 1;
			END
		END
IF @IsPrime = 0
	PRINT 'NO';
ELSE
	PRINT 'YES'; --check if number is prime
--------------
DECLARE @num1 INT = 10, @num2 INT = 1, @num3 INT = 17, @num4 INT = 14, @num5 INT = 105;
DECLARE @min INT, @max INT;
SELECT @min = MIN(val)
	FROM (VALUES (@num1), (@num2), (@num3), (@num4), (@num5)) AS v(val);
SELECT @max = MAX(val)
    FROM (VALUES (@num1), (@num2), (@num3), (@num4), (@num5)) AS v(val);
PRINT @min + @max; --print sum of min and max values from 5 numbers
--------------

CREATE FUNCTION Functions(
    @start INT,
    @end INT,
    @showEven BIT -- 1 для парних, 0 для непарних
)
RETURNS @Result TABLE (Number INT, Type VARCHAR(10))
AS
BEGIN
    ;WITH Numbers AS (
        SELECT @start AS num
        UNION ALL
        SELECT num + 1 FROM Numbers WHERE num + 1 <= @end
    )
    INSERT INTO @Result
    SELECT 
        num,
        CASE 
            WHEN num % 2 = 0 THEN 'Even'
            ELSE 'Odd'
        END AS Type
    FROM Numbers
    WHERE (@showEven = 1 AND num % 2 = 0)
       OR (@showEven = 0 AND num % 2 <> 0)
    OPTION (MAXRECURSION 0);
    RETURN;
END;
SELECT * FROM Functions(65, 100, 0); --even or odd numbers in range