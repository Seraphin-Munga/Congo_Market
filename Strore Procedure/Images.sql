


DROP PROCEDURE [DB_Image_Creation]
     GO


CREATE PROCEDURE [DB_Image_Creation]

                            @imageID   [uniqueidentifier],
						    @postID    [uniqueidentifier],
						    @ImageLinks [varchar](50)

AS
BEGIN

                   INSERT INTO [dbo].[Image]
						   ([imageID]
						   ,[postID]
						   ,[ImageLinks])
					 VALUES
						   (@imageID
						   ,@postID
						   ,@ImageLinks)

END
GO


----====================================================================================================


DROP PROCEDURE [DB_Image_Update]
     GO


CREATE PROCEDURE [DB_Image_Update]

                            @imageID   [uniqueidentifier],
						    @postID    [uniqueidentifier],
						    @ImageLinks [varchar](50)

AS
BEGIN

                 UPDATE [dbo].[Image]
					   SET 
						   [postID] =  @postID
						  ,[ImageLinks] =  @ImageLinks
					 WHERE [imageID] = @imageID

END
GO


----====================================================================================================


DROP PROCEDURE [DB_Image_List]
     GO


CREATE PROCEDURE [DB_Image_List]

                       

AS
BEGIN

                   SELECT [Image].[imageID]                   AS [Image_imageID]
						  ,[Image].[postID]                   AS [Image_postID]
						  ,[Image].[ImageLinks]               AS [Image_ImageLinks]
					  FROM [dbo].[Image]

END
GO


----====================================================================================================


DROP PROCEDURE [DB_Image_Detail]
     GO


CREATE PROCEDURE [DB_Image_Detail]

                        @postID [uniqueidentifier]   

AS
BEGIN

                   SELECT [Image].[imageID]                   AS [Image_imageID]
						  ,[Image].[postID]                   AS [Image_postID]
						  ,[Image].[ImageLinks]               AS [Image_ImageLinks]
					  FROM [dbo].[Image]
					   
					  WHERE [Image].[postID] = @postID

END
GO

