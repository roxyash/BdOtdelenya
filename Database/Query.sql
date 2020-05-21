USE Karataev;

SELECT 
       [Number_Students]
     , [First_Name_Students]
     , [Mid_Name_Students]
     , [Last_Name_Students]
     , [Address_Students]
     , [Course_Students]
     , [Birthday_Students]
FROM Students;


DECLARE @search nvarchar(50);
SET @search = N'М';
SELECT [Number_Students]
     , [First_Name_Students]
     , [Mid_Name_Students]
     , [Last_Name_Students]
     , [Address_Students]
     , [Course_Students]
     , [Birthday_Students]
FROM Students
WHERE First_Name_Students LIKE CONCAT(@search, '%')
    OR Mid_Name_Students LIKE CONCAT(@search, '%')
    OR Last_Name_Students LIKE CONCAT(@search, '%');