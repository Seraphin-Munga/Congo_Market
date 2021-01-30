


DROP PROCEDURE [DB_PostPoperty_Creation]
   GO 


CREATE PROCEDURE [DB_PostPoperty_Creation]

                                        @propertyPostID             [uniqueidentifier],
									    @postID                     [uniqueidentifier],
									    @propertyType               [tinyint],
									    @surfaceSize                [varchar](50),
									    @bethroom                   [tinyint],
									    @bathroom                   [tinyint],
									    @listBy                     [varchar](50),
									    @petAllow                   [bit],
									    @numberOfParking            [tinyint],



										    @registerID    [uniqueidentifier],
										    @townID        [tinyint],
										    @subcategoryID [tinyint],
										    @title         [varchar](50),
										    @price         [decimal](18,0),
										    @condition     [bit],
											@isSold        [bit],
										    @date          [datetime],
										    @description   [varchar](max)


 
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



								   INSERT INTO [dbo].[Post_Property]
									   ([propertyPostID]
									   ,[postID]
									   ,[propertyType]
									   ,[surfaceSize]
									   ,[bethroom]
									   ,[bathroom]
									   ,[listBy]
									   ,[petAllow]
									   ,[numberOfParking])
								 VALUES
									   (@propertyPostID
									   ,@postID
									   ,@propertyType
									   ,@surfaceSize
									   ,@bethroom
									   ,@bathroom
									   ,@listBy
									   ,@petAllow
									   ,@numberOfParking)

END
GO



---==============================================================================================================================================


DROP PROCEDURE [DB_PostPoperty_Update]
   GO 


CREATE PROCEDURE [DB_PostPoperty_Update]

									    @postID                     [uniqueidentifier],
									    @propertyType               [tinyint],
									    @surfaceSize                [varchar](50),
									    @bethroom                   [tinyint],
									    @bathroom                   [tinyint],
									    @listBy                     [varchar](50),
									    @petAllow                   [bit],
									    @numberOfParking            [tinyint],



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



										UPDATE [dbo].[Post_Property]
											SET 
												
												 [propertyType] = @propertyType
												,[surfaceSize] =  @surfaceSize
												,[bethroom] =     @bethroom
												,[bathroom] =     @bathroom
												,[listBy] =       @listBy
												,[petAllow] =     @petAllow 
												,[numberOfParking] = @numberOfParking

											WHERE [postID] = @postID

END
GO


---==============================================================================================================================================


DROP PROCEDURE [DB_PostPoperty_List]
   GO 


CREATE PROCEDURE [DB_PostPoperty_List]

									  


 
AS
BEGIN

                  
				            SELECT [Post_Property].[propertyPostID]           AS [Post_Property_propertyPostID]
								  ,[Post_Property].[postID]                   AS [Post_Property_postID]
								  ,[Post_Property].[propertyType]             AS [Post_Property_propertyType]
								  ,[Post_Property].[surfaceSize]              AS [Post_Property_surfaceSize]
								  ,[Post_Property].[bethroom]                 AS [Post_Property_bethroom]
								  ,[Post_Property].[bathroom]                 AS [Post_Property_bathroom]
								  ,[Post_Property].[listBy]                   AS [Post_Property_listBy]
								  ,[Post_Property].[petAllow]                 AS [Post_Property_petAllow]
								  ,[Post_Property].[numberOfParking]          AS [Post_Property_numberOfParking]

								,[Post].[townID]                 AS    [Post_townID]
								,[Post].[subcategoryID]          AS    [Post_subcategoryID]
								,[Post].[title]                  AS    [Post_title]
								,[Post].[price]                  AS    [Post_price]
								,[Post].[condition]              AS    [Post_condition]
								,[Post].[date]                   AS    [Post_date]
								,[Post].[description]            AS    [Post_description]
								  
							  FROM [dbo].[Post_Property]   AS [Post_Property]
							            JOIN [Post] AS [Post]
										  ON [Post].[postID]  = [Post_Property].[postID]

										  WHERE  [Post].[isSold] = 1 

                        

END
GO


---==============================================================================================================================================



DROP PROCEDURE [DB_PostPoperty_Detail]
   GO 


CREATE PROCEDURE [DB_PostPoperty_Detail]

									  
                                   @postID [uniqueidentifier]

 
AS
BEGIN

                  
				            SELECT [Post_Property].[propertyPostID]           AS [Post_Property_propertyPostID]
								  ,[Post_Property].[postID]                   AS [Post_Property_postID]
								  ,[Post_Property].[propertyType]             AS [Post_Property_propertyType]
								  ,[Post_Property].[surfaceSize]              AS [Post_Property_surfaceSize]
								  ,[Post_Property].[bethroom]                 AS [Post_Property_bethroom]
								  ,[Post_Property].[bathroom]                 AS [Post_Property_bathroom]
								  ,[Post_Property].[listBy]                   AS [Post_Property_listBy]
								  ,[Post_Property].[petAllow]                 AS [Post_Property_petAllow]
								  ,[Post_Property].[numberOfParking]          AS [Post_Property_numberOfParking]

								,[Post].[townID]                 AS    [Post_townID]
								,[Post].[subcategoryID]          AS    [Post_subcategoryID]
								,[Post].[title]                  AS    [Post_title]
								,[Post].[price]                  AS    [Post_price]
								,[Post].[condition]              AS    [Post_condition]
								,[Post].[date]                   AS    [Post_date]
								,[Post].[description]            AS    [Post_description]
								  
							  FROM [dbo].[Post_Property]   AS [Post_Property]
							            JOIN [Post] AS [Post]
										  ON [Post].[postID]  = [Post_Property].[postID]

                        WHERE [Post].[postID] = @postID

END
GO


---==============================================================================================================================================


