USE [$DatabaseName$]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [ElmTestDb]
GO
/****** Object:  StoredProcedure [dbo].[p_SearchBooks]    Script Date: 2/5/2024 1:37:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Author			IDRAZ
Description		Search in BookInfo Json object by value
Date			04/02/2024
Prototype		Exec SearchBooks @SearchValue = 'abc'
*/
ALTER PROC [dbo].[p_SearchBooks](@SearchValue NVARCHAR(50) = Null, @Offset int = 0, @PageSize Int = 20)
AS
BEGIN
	
	DECLARE @_searchValue NVARCHAR(50) = @SearchValue;
	if(@Offset is null )
	BEGIN
		Set @Offset = 0
	END

	if(@PageSize is null or @PageSize = 0)
	BEGIN
		Set @PageSize = 20
	END

	SELECT BookId, BookInfo, LastModified 
		FROM Book  
		WHERE 
			@SearchValue is null 
				Or (
				BookTitle like @SearchValue +'%'
				OR 
				BookDescription like   @SearchValue +'%'
				OR 
				Author like  @SearchValue +'%'
				OR 
				PublishDate = @SearchValue
			)
		ORDER BY BookId 
		OFFSET @Offset ROWS
		FETCH NEXT @PageSize ROWS ONLY

END



