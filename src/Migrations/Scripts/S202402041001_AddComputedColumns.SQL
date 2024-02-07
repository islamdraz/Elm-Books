USE [$DatabaseName$]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Add the BookTitle computed column
ALTER TABLE [dbo].[Book]
ADD BookTitle AS (JSON_VALUE(BookInfo, '$.BookTitle'));
GO
ALTER TABLE [Book]
ALTER COLUMN BookTitle ADD PERSISTED;
GO
-- Create the index
CREATE INDEX IX_Book_BookTitle
ON [Book](BookTitle);
GO

-- Add the Author computed column
ALTER TABLE [dbo].[Book]
ADD Author AS (JSON_VALUE(BookInfo, '$.Author')) ;
GO

ALTER TABLE [Book]
ALTER COLUMN Author ADD PERSISTED;
GO
-- Create the index
CREATE INDEX IX_Book_Author
ON [Book] (Author);
GO

-- Add the BookDescription computed column
ALTER TABLE [dbo].[Book]
ADD BookDescription AS (JSON_VALUE(BookInfo, '$.BookDescription'));
GO

ALTER TABLE [Book]
ALTER COLUMN BookDescription ADD PERSISTED;
GO
-- Create the index
CREATE INDEX IX_Book_BookDescription
ON [Book] (BookDescription);
GO
-- Add the PublishDate computed column
ALTER TABLE [dbo].[Book]
ADD PublishDate AS (JSON_VALUE(BookInfo, '$.PublishDate'));
GO
ALTER TABLE [Book]
ALTER COLUMN PublishDate ADD PERSISTED;
GO

-- Create the index
CREATE INDEX IX_Book_PublishDate
ON [Book] (PublishDate);
GO


