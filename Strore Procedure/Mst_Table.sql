

DROP PROCEDURE [DB__Mst_Color_List]
  GO

CREATE PROCEDURE [DB__Mst_Color_List]
  

   
AS
BEGIN

						SELECT [Color].[colorID]          AS  [Color_colorID]
						  ,    [Color].[colorName]        AS  [Color_colorName]
					  FROM [dbo].[Color]

  

END
GO


---==============================================================================================================


DROP PROCEDURE [DB__Mst_Category_List]
  GO

CREATE PROCEDURE [DB__Mst_Category_List]
  

   
AS
BEGIN

						SELECT [Category].[categoryID]              AS [Category_categoryID]
							  ,[Category].[categoryName]            AS [Category_categoryName]
						  FROM [dbo].[Category]

 

END
GO


---==============================================================================================================


DROP PROCEDURE [DB__Mst_Province_List]
  GO

CREATE PROCEDURE [DB__Mst_Province_List]
  

   
AS
BEGIN

					   SELECT    [Province].[provinceID]               AS   [Province_provinceID]
							  ,  [Province].[provinceName]             AS   [Province_provinceName]
						  FROM [dbo].[Province]  


 

END
GO



---==============================================================================================================

DROP PROCEDURE [DB__Mst_Subcategory_List]
  GO

CREATE PROCEDURE [DB__Mst_Subcategory_List]
  
                                 @categoryID  [tinyint]        
   
AS
BEGIN

					  
									SELECT [Subcategory].[subcategoryID]      AS    [Subcategory_subcategoryID]
										  ,[Subcategory].[categoryID]         AS    [Subcategory_categoryID]
										  ,[Subcategory].[subcategoryName]    AS    [Subcategory_subcategoryName]
										  ,[Category].[categoryName]            AS [Category_categoryName]

									  FROM [dbo].[Subcategory]   AS [Subcategory]
									          JOIN [Category] AS [Category]
											    ON [Category].[categoryID] = [Subcategory].[categoryID]

									           WHERE [Subcategory].[categoryID] = @categoryID

 

END
GO


---==============================================================================================================


DROP PROCEDURE [DB__Mst_Town_List]
  GO

CREATE PROCEDURE [DB__Mst_Town_List]
  
                                 @provinceID  [tinyint]        
   
AS
BEGIN

					     SELECT    [Town].[townID]                       AS              [Town_townID]
								  ,[Town].[provinceID]                   AS              [Town_provinceID]
								  ,[Town].[townName]                     AS              [Town_townName]
								  ,[Province].[provinceName]             AS              [Province_provinceName]

							  FROM [dbo].[Town]  AS  [Town]
							        JOIN [Province]  AS [Province]
									   ON [Province].[provinceID] = [Town].[provinceID]

									WHERE [Town].[provinceID] = @provinceID
 

END
GO
---==============================================================================================================

DROP PROCEDURE [DB__Mst_Make_List]
  GO

CREATE PROCEDURE [DB__Mst_Make_List]
  
                            
   
AS
BEGIN

					  SELECT   [Vihicles_Make].[makeID]             AS [Vihicles_Make_makeID]
							  ,[Vihicles_Make].[makeName]           AS [Vihicles_Make_makeName]
						  FROM [dbo].[Vihicles_Make]
 

END
GO

---==============================================================================================================

DROP PROCEDURE [DB__Mst_TypeVihicle_List]
  GO

CREATE PROCEDURE [DB__Mst_TypeVihicle_List]
  
                            
   
AS
BEGIN

					 SELECT    [Vihicles_Type].[typeID]               AS [Vihicles_Type_typeID]
							  ,[Vihicles_Type].[typeName]             AS [Vihicles_Type_typeName]
						  FROM [dbo].[Vihicles_Type]
 

END
GO

---==============================================================================================================

DROP PROCEDURE [DB__Mst_PropertyType_List]
  GO

CREATE PROCEDURE [DB__Mst_PropertyType_List]
  
                            
   
AS
BEGIN

				SELECT     [Property_Type].[proppertyType]    AS [Property_Type_proppertyType]
						  ,[Property_Type].[propertyName]     AS [Property_Type_propertyName]
					  FROM [dbo].[Property_Type]

END
GO