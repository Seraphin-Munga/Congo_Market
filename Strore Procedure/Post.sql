

DROP PROCEDURE [DB_Post_Creation]
   GO

CREATE PROCEDURE [DB_Post_Creation]
   


                                            @postID        [uniqueidentifier],
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

									INSERT INTO [dbo].[Post]
										   ([postID]
										   ,[registerID]
										   ,[townID]
										   ,[subcategoryID]
										   ,[title]
										   ,[price]
										   ,[condition]
										   ,[date]
										   ,[description]
										   ,[isSold])
									 VALUES
										   (@postID
										   ,@registerID
										   ,@townID
										   ,@subcategoryID
										   ,@title
										   ,@price
										   ,@condition
										   ,@date
										   ,@description
										   ,@isSold)

END
GO

--================================================================================================================

DROP PROCEDURE [DB_Post_Update]
   GO

CREATE PROCEDURE [DB_Post_Update]
   


                                            @postID        [uniqueidentifier],
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


								UPDATE [dbo].[Post]
							   SET 
								    
								   [townID] =          @townID
								  ,[subcategoryID] =   @subcategoryID
								  ,[title] =           @title
								  ,[price] =           @price
								  ,[condition] =       @condition
								  ,[isSold]    =       @isSold
								  ,[date] =            @date
								  ,[description] =     @description
							 WHERE [postID] = @postID


END
GO


--================================================================================================================

DROP PROCEDURE [DB_Post_Detail]
   GO

CREATE PROCEDURE [DB_Post_Detail]
   


                                            @postID        [uniqueidentifier]
										 

 
AS
BEGIN


            
													SELECT [Post].[postID]                 AS    [Post_postID]
														  ,[Post].[registerID]             AS    [Post_registerID]
														  ,[Post].[townID]                 AS    [Post_townID]
														  ,[Post].[subcategoryID]          AS    [Post_subcategoryID]
														  ,[Post].[title]                  AS    [Post_title]
														  ,[Post].[price]                  AS    [Post_price]
														  ,[Post].[condition]              AS    [Post_condition]
														  ,[Post].[date]                   AS    [Post_date]
														  ,[Post].[description]            AS    [Post_description]

													  FROM [dbo].[Post]

													    WHERE [Post].[postID] =  @postID  

END
GO


--================================================================================================================


DROP PROCEDURE [DB_Post_List]
   GO

CREATE PROCEDURE [DB_Post_List]
   


                                         
										 

 
AS
BEGIN


            
													SELECT [Post].[postID]                 AS    [Post_postID]
														  ,[Post].[registerID]             AS    [Post_registerID]
														  ,[Post].[townID]                 AS    [Post_townID]
														  ,[Post].[subcategoryID]          AS    [Post_subcategoryID]
														  ,[Post].[title]                  AS    [Post_title]
														  ,[Post].[price]                  AS    [Post_price]
														  ,[Post].[condition]              AS    [Post_condition]
														  ,[Post].[date]                   AS    [Post_date]
														  ,[Post].[description]            AS    [Post_description]

													  FROM [dbo].[Post]

													  WHERE [Post].[isSold] = 1

													  

END
GO