 CREATE TABLE #Adjectives (
     Value NVARCHAR(256)
 );
 CREATE TABLE #Colors(
     Value NVARCHAR(16)
 );
 CREATE TABLE #PetNames(
     Value NVARCHAR(16)
 );

 INSERT INTO #Adjectives ([Value]) VALUES('Big');
 INSERT INTO #Adjectives ([Value]) VALUES('Small');
 INSERT INTO #Adjectives ([Value]) VALUES('Brave');
 INSERT INTO #Adjectives ([Value]) VALUES('Cowardly');
 INSERT INTO #Adjectives ([Value]) VALUES('Smart');
 INSERT INTO #Adjectives ([Value]) VALUES('Snoopy');
 INSERT INTO #Adjectives ([Value]) VALUES('Sneeky');
 INSERT INTO #Adjectives ([Value]) VALUES('Funny');
 INSERT INTO #Adjectives ([Value]) VALUES('Shy');
 INSERT INTO #Adjectives ([Value]) VALUES('Agressor');

 INSERT INTO #PetNames ([Value]) VALUES('Rex');
 INSERT INTO #PetNames ([Value]) VALUES('Luthar');
 INSERT INTO #PetNames ([Value]) VALUES('Jack');
 INSERT INTO #PetNames ([Value]) VALUES('Snoopy');
 INSERT INTO #PetNames ([Value]) VALUES('Scooby');
 INSERT INTO #PetNames ([Value]) VALUES('Lion');
 INSERT INTO #PetNames ([Value]) VALUES('Limbo');
 INSERT INTO #PetNames ([Value]) VALUES('Simba');
 INSERT INTO #PetNames ([Value]) VALUES('Kirk');
 INSERT INTO #PetNames ([Value]) VALUES('Ca');

 INSERT INTO #Colors ([Value]) VALUES ('Red');
 INSERT INTO #Colors ([Value]) VALUES ('Green');
 INSERT INTO #Colors ([Value]) VALUES ('Purple');
 INSERT INTO #Colors ([Value]) VALUES ('Yellow');
 INSERT INTO #Colors ([Value]) VALUES ('Blue');
 INSERT INTO #Colors ([Value]) VALUES ('Cyan');
 INSERT INTO #Colors ([Value]) VALUES ('Black');
 INSERT INTO #Colors ([Value]) VALUES ('White');
 INSERT INTO #Colors ([Value]) VALUES ('Grey');
 INSERT INTO #Colors ([Value]) VALUES ('LightGrey');

DECLARE @Counter INT;
DECLARE @Year INT;
DECLARE @YearString NVARCHAR(16);
DECLARE @Month INT;
DECLARE @MonthString NVARCHAR(16);
DECLARE @Day INT;
DECLARE @DayString NVARCHAR(16);
SET @Counter = 0;

WHILE @Counter < 100
BEGIN
    SET @Year = 2002 + RAND() * 20;
    SET @YearString = CAST(@Year AS NVARCHAR(16));
    SET @Month = 1 + RAND() * 11;
    SET @MonthString = CAST(@Month AS NVARCHAR(16));
    SET @Day = RAND() * 27;
    SET @DayString = CAST(@Day AS NVARCHAR(16));
    INSERT INTO Pets (Name, Type, Weight, DateOfBirth) VALUES(
        CONCAT((SELECT TOP(1) Value from #Adjectives ORDER BY NEWID()),' ',(SELECT TOP(1) Value from #Colors ORDER BY NEWID()),' ',(SELECT TOP(1) Value from #PetNames ORDER BY NEWID())),
        (SELECT TOP(1) ID FROM PetTypes ORDER BY NEWID()), 20 + (RAND() * 30), CONCAT(@YearString, '-', @MonthString, '-', @DayString))
    SET @Counter = @Counter + 1
END