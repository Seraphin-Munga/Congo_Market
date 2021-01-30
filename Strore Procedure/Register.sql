

DROP PROCEDURE [DB_Register_Creation]
  GO

CREATE PROCEDURE [DB_Register_Creation]


                                   @registerID         [uniqueidentifier],
								   @firstName          [varchar](50),
								   @lastName           [varchar](50),
								   @email              [varchar](50),
								   @password           [varchar](500),
								   @telephone          [varchar](14)

AS
BEGIN


										 INSERT INTO [dbo].[Register]
											   ([registerID]
											   ,[firstName]
											   ,[lastName]
											   ,[email]
											   ,[password]
											   ,[telephone])
										 VALUES
											   (@registerID
											   ,@firstName
											   ,@lastName
											   ,@email
											   ,@password
											   ,@telephone)

END
GO


----==========================================================================================================================================


DROP PROCEDURE [DB_Register_Login]
  GO

CREATE PROCEDURE [DB_Register_Login]


								   @email              [varchar](50),
								   @password           [varchar](500)
								 

AS
BEGIN


										 SELECT    [Register].[registerID]            AS        [Register_registerID]
												  ,[Register].[firstName]             AS        [Register_firstName]
												  ,[Register].[lastName]              AS        [Register_lastName]
												  ,[Register].[email]                 AS        [Register_email]
												  ,[Register].[password]              AS        [Register_password]  
												  ,[Register].[telephone]             AS        [Register_telephone]

										  FROM [dbo].[Register]
										        
												WHERE  [Register].[email] = @email  AND [Register].[password] =  @password 

END
GO

----==========================================================================================================================================

DROP PROCEDURE [DB_Register_Detail]
  GO

CREATE PROCEDURE [DB_Register_Detail]


								   @registerID              [uniqueidentifier]
								         
								 

AS
BEGIN


										 SELECT    [Register].[registerID]            AS        [Register_registerID]
												  ,[Register].[firstName]             AS        [Register_firstName]
												  ,[Register].[lastName]              AS        [Register_lastName]
												  ,[Register].[email]                 AS        [Register_email]
												  ,[Register].[password]              AS        [Register_password]  
												  ,[Register].[telephone]             AS        [Register_telephone]

										  FROM [dbo].[Register]
										        
												WHERE  [Register].[registerID] =  @registerID
END
GO

----==========================================================================================================================================


DROP PROCEDURE [DB_Register_Update]
  GO

CREATE PROCEDURE [DB_Register_Update]


								   @registerID         [uniqueidentifier],
								   @firstName          [varchar](50),
								   @lastName           [varchar](50),
								   @telephone          [varchar](14)
AS
BEGIN


										UPDATE [dbo].[Register]
										   SET 
											   [firstName] =  @firstName
											  ,[lastName] =   @lastName
											  ,[telephone] =  @telephone
										 WHERE [registerID] = @registerID


END
GO