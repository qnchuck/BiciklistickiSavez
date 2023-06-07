-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetBicyclesPerSavez
   AS
BEGIN 
	CREATE TABLE #ResultData
    (
        naziv_saveza VARCHAR(100),
        total_bicycles INT
    );
    DECLARE @naziv_saveza VARCHAR(100);
    DECLARE @total_bicycles INT;

    -- Declare the cursor
    DECLARE cursor_name CURSOR FOR
    SELECT t.NZV_SVZ, COUNT(b.ID_B) AS total_bicycles
    FROM dbo.Takmicari t
    JOIN Biciklis b ON t.jmbg = b.jmbg_t
    GROUP BY t.NZV_SVZ;

    -- Open the cursor
    OPEN cursor_name;

    -- Fetch the data into variables and insert into the result table variable
    FETCH NEXT FROM cursor_name INTO @naziv_saveza, @total_bicycles;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO #ResultData (naziv_saveza, total_bicycles)
        VALUES (@naziv_saveza, @total_bicycles);

        FETCH NEXT FROM cursor_name INTO @naziv_saveza, @total_bicycles;
    END;

    -- Close and deallocate the cursor
    CLOSE cursor_name;
    DEALLOCATE cursor_name;

    -- Select the result set from the table variable
    SELECT * FROM #ResultData;
END;

GO
