CREATE PROCEDURE Hello_World
AS
BEGIN
	PRINT 'Hello WORLD!'
END;
EXEC Hello_World
-------------
CREATE PROCEDURE CurrentTime
AS
BEGIN
	SELECT CONVERT(VARCHAR(8), GETDATE(), 108);
END;
EXEC CurrentTime
-------------
CREATE PROCEDURE CurrentDate
AS
BEGIN
	SELECT CAST(GETDATE() AS DATE);
END;
EXEC CurrentDate
-------------
CREATE PROCEDURE SumNumbers
    @num1 INT,
    @num2 INT
AS
BEGIN
    SELECT @num1 + @num2 AS Sum;
END;
EXEC SumNumbers @num1 = 5, @num2 = 10;
-------------
CREATE PROCEDURE Average
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    SELECT (@num1 + @num2 + @num3) / 3;
END;
EXEC Average @num1 = 5, @num2 = 10, @num3 = 23;
-------------
CREATE PROCEDURE MaxValue
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    DECLARE @max INT
    SELECT @max = MAX(val)
        FROM (VALUES (@num1), (@num2), (@num3)) AS v(val);
    SELECT @max AS MaxValue
END;
EXEC MaxValue @num1 = 4, @num2 = 5, @num3 = 45;
-------------
CREATE PROCEDURE MinValue
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    DECLARE @min INT
    SELECT @min = MIN(val)
        FROM (VALUES (@num1), (@num2), (@num3)) AS v(val);
    SELECT @min AS MinValue
END;
EXEC MinValue @num1 = 4, @num2 = 5, @num3 = 45;
-------------
CREATE PROCEDURE NumSymbol
    @num INT,
    @sym NVARCHAR(1)
AS
    BEGIN
        DECLARE @line NVARCHAR(1000) = ' ';
        DECLARE @i INT = 0;
        WHILE @i < @num
            BEGIN
                SET @line = @line + @sym
                SET @i = @i + 1;
            END
                PRINT @line;
        END
EXEC NumSymbol @num = 5, @sym = '*';
-------------
CREATE PROCEDURE Factorial
    @num INT
AS
    BEGIN
        DECLARE @f INT = 1;
        DECLARE @i INT = 1;
        WHILE @i <= @num
            BEGIN
                SET @f = @f * @i
                SET @i = @i + 1;
            END
                PRINT @f;
        END;
EXEC Factorial @num = 10;
-------------
CREATE PROCEDURE PowerOf
    @num1 INT,
    @num2 INT
AS
    BEGIN
        DECLARE @i INT = 0;
        DECLARE @power INT = 1;
        WHILE @i < @num2
            BEGIN
                SET @power = @power * @num1;
                SET @i = @i + 1;
            END
                PRINT @power;
        END;
EXEC PowerOf @num1 = 3, @num2 = 10;