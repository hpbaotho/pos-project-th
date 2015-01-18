
DELETE so_table
Go

INSERT INTO [POS].[dbo].[so_table]
           ([table_code]
           ,[table_name]
           ,[IsAvailable]
           ,[active]
           ,[created_by]
           ,[created_date]
           ,[updated_by]
           ,[updated_date])
     VALUES
         ('TB01' ,'TB01' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB02' ,'TB02' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB03' ,'TB03' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB04' ,'TB04' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB05' ,'TB05' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB06' ,'TB06' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB07' ,'TB07' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB08' ,'TB08' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB09' ,'TB09' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
		,('TB10' ,'TB10' ,1 ,1,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())

GO


