CREATE TRIGGER Prevent_Chief_DELETE
ON Barbers
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM deleted WHERE BarberRank = 'Chief')
    BEGIN
        RAISERROR('Add a new Chief before deleting the current one.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    DELETE FROM Barbers WHERE Id IN (SELECT Id FROM deleted);
END; --cant delete chief until added new chief
ENABLE TRIGGER Prevent_Chief_DELETE ON Barbers

CREATE TRIGGER Barbers_AgeLimit
ON Barbers
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE DATEDIFF(year, DateOfBirth, GETDATE()) < 21)
    BEGIN
        RAISERROR('Cannot add a barber younger than 21.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END; --cant add barbers < 21 yo.
ENABLE TRIGGER Barbers_AgeLimit ON Barbers

