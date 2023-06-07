-- ================================================
-- Template generated from Template Explorer using:
-- Create Inline Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
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
CREATE FUNCTION dbo.GetJoinedData()
RETURNS TABLE
AS
RETURN (
    SELECT B.*, BK.NZVK, BK.LOK, BS.DRZ
    FROM [dbo].[Biciklis] B
    JOIN [dbo].[Biciklisticki_Klub] BK ON B.JMBG_T = BK.ID_KLUB
    JOIN [dbo].[Biciklisticki_Savez] BS ON BK.NZV_SVZ = BS.NZV
)

GO
