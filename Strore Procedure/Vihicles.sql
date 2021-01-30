-- ================================================
-- Template generated from Template Explorer using:

DROP PROCEDURE [DB_PostVihicles_Creation]
 GO


CREATE PROCEDURE [DB_PostVihicles_Creation]
 
     

	                                   @vihiclesID      [uniqueidentifier],
									   @postID          [uniqueidentifier],
									   @makeID          [tinyint],
									   @typeID          [tinyint],
									   @colorID         [tinyint],
									   @fuel            [varchar](50),
									   @transmission    [varchar](50),
									   @listBy          [varchar](50),
									   @mileage         [varchar](50),


									    @registerID    [uniqueidentifier],
										@townID        [tinyint],
										@subcategoryID [tinyint],
										@title         [varchar](50),
										@price         [decimal](18,0),
										@condition     [bit],
										@date          [datetime],
										@description   [varchar](max),
										@isSold        [bit]

  
AS
BEGIN

                               
                              EXECUTE [dbo].[DB_Post_Creation]

							                @postID,
							                @registerID,
										    @townID,
										    @subcategoryID,
										    @title,
										    @price,
										    @condition,
										    @date,
										    @description,
											@isSold

     
								   INSERT INTO [dbo].[Post_Vihicles]
									   ([vihiclesID]
									   ,[postID]
									   ,[makeID]
									   ,[typeID]
									   ,[colorID]
									   ,[fuel]
									   ,[transmission]
									   ,[listBy]
									   ,[mileage])
								 VALUES
									   (@vihiclesID
									   ,@postID
									   ,@makeID
									   ,@typeID
									   ,@colorID
									   ,@fuel
									   ,@transmission
									   ,@listBy
									   ,@mileage)

  


END
GO

--============================================================================================================================

DROP PROCEDURE [DB_PostVihicles_Update]
 GO


CREATE PROCEDURE [DB_PostVihicles_Update]
 
     

	                                   @vihiclesID      [uniqueidentifier],
									   @postID          [uniqueidentifier],
									   @makeID          [tinyint],
									   @typeID          [tinyint],
									   @colorID         [tinyint],
									   @fuel            [varchar](50),
									   @transmission    [varchar](50),
									   @listBy          [varchar](50),
									   @mileage         [varchar](50),


									    @registerID    [uniqueidentifier],
										@townID        [tinyint],
										@subcategoryID [tinyint],
										@title         [varchar](50),
										@price         [decimal](18,0),
										@condition     [bit],
										@date          [datetime],
										@description   [varchar](max),
										@isSold        [bit]

  
AS
BEGIN


                  
                              EXECUTE [dbo].[DB_Post_Update]

							                @postID,
							                @registerID,
										    @townID,
										    @subcategoryID,
										    @title,
										    @price,
										    @condition,
										    @date,
										    @description,
											@isSold
                               
       
	   
										  UPDATE [dbo].[Post_Vihicles]
									   SET 
										  
										   [makeID] = @makeID
										  ,[typeID] = @typeID
										  ,[colorID] = @colorID
										  ,[fuel] =    @fuel
										  ,[transmission] = @transmission
										  ,[listBy] =    @listBy
										  ,[mileage] = @mileage
									 WHERE [postID] = @postID

END
GO


--============================================================================================================================


DROP PROCEDURE [DB_PostVihicles_List]
 GO


CREATE PROCEDURE [DB_PostVihicles_List]
	                              
								       
  
AS
BEGIN


                               SELECT  [Post_Vihicles].[vihiclesID]            AS [Post_Vihicles_vihiclesID]
									  ,[Post_Vihicles].[postID]                AS [Post_Vihicles_postID]
									  ,[Post_Vihicles].[makeID]                AS [Post_Vihicles_makeID]
									  ,[Post_Vihicles].[typeID]                AS [Post_Vihicles_typeID]
									  ,[Post_Vihicles].[colorID]               AS [Post_Vihicles_colorID]
									  ,[Post_Vihicles].[fuel]                  AS [Post_Vihicles_fuel]
									  ,[Post_Vihicles].[transmission]          AS [Post_Vihicles_transmission]
									  ,[Post_Vihicles].[listBy]                AS [Post_Vihicles_listBy]
									  ,[Post_Vihicles].[mileage]               AS [Post_Vihicles_mileage]

									,[Post].[townID]                 AS    [Post_townID]
									,[Post].[subcategoryID]          AS    [Post_subcategoryID]
									,[Post].[title]                  AS    [Post_title]
									,[Post].[price]                  AS    [Post_price]
									,[Post].[condition]              AS    [Post_condition]
									,[Post].[date]                   AS    [Post_date]
									,[Post].[description]            AS    [Post_description]

								  FROM [dbo].[Post_Vihicles]    AS [Post_Vihicles]
								     JOIN [Post] AS [Post]
										  ON [Post].[postID]  = [Post_Vihicles].[postID]
										  WHERE  [Post].[isSold] = 1 
END
GO

--============================================================================================================================


DROP PROCEDURE [DB_PostVihicles_Detail]
 GO


CREATE PROCEDURE [DB_PostVihicles_Detail]
	                              

                             @postID [uniqueidentifier]
AS
BEGIN


                               SELECT  [Post_Vihicles].[vihiclesID]            AS [Post_Vihicles_vihiclesID]
									  ,[Post_Vihicles].[postID]                AS [Post_Vihicles_postID]
									  ,[Post_Vihicles].[makeID]                AS [Post_Vihicles_makeID]
									  ,[Post_Vihicles].[typeID]                AS [Post_Vihicles_typeID]
									  ,[Post_Vihicles].[colorID]               AS [Post_Vihicles_colorID]
									  ,[Post_Vihicles].[fuel]                  AS [Post_Vihicles_fuel]
									  ,[Post_Vihicles].[transmission]          AS [Post_Vihicles_transmission]
									  ,[Post_Vihicles].[listBy]                AS [Post_Vihicles_listBy]
									  ,[Post_Vihicles].[mileage]               AS [Post_Vihicles_mileage]

									,[Post].[townID]                 AS    [Post_townID]
									,[Post].[subcategoryID]          AS    [Post_subcategoryID]
									,[Post].[title]                  AS    [Post_title]
									,[Post].[price]                  AS    [Post_price]
									,[Post].[condition]              AS    [Post_condition]
									,[Post].[date]                   AS    [Post_date]
									,[Post].[description]            AS    [Post_description]

								  FROM [dbo].[Post_Vihicles]    AS [Post_Vihicles]
								     JOIN [Post] AS [Post]
										  ON [Post].[postID]  = [Post_Vihicles].[postID]
								  WHERE [Post].[postID] = @postID
END
GO