INSERT INTO [dbo].[db_document_type]([document_type_name],[document_type_description],[active],[created_by],[created_date],[updated_by],[updated_date],[company_branch_id])
VALUES
		('RM','Receive Material',1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),NULL),
		('RO','Receive Order',1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),NULL),
		('IM','Issue Material',1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),NULL),
		('SM','Sold Material',1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),NULL),
		('CS','Cancel Sold',1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),NULL),
		('SC','Stock Count',1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),NULL)
GO

INSERT INTO [dbo].[db_warehouse]([warehouse_code],[warehouse_name],[warehouse_description],[company_branch_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('WH01','Warehouse 1',NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('WH02','Warehouse 2',NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('WH03','Warehouse 3',NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('WH04','Warehouse 4',NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
GO


INSERT INTO [dbo].[db_supplier] ([supplier_code],[supplier_name],[supplier_description],[supplier_address],[supplier_tel],[supplier_contract_person],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('SP01','Supplier 1',NULL,NULL,NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('SP02','Supplier 2',NULL,NULL,NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('SP03','Supplier 3',NULL,NULL,NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('SP04','Supplier 4',NULL,NULL,NULL,NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
GO

DECLARE @document_type_id BIGINT
SELECT TOP 1 @document_type_id = [document_type_id] FROM [dbo].[db_document_type] WHERE [document_type_name] = 'RM'
INSERT INTO [dbo].[db_reason]([reason_name],[reason_description],[module],[document_type_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('Reason 1',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 2',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 3',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())	

INSERT INTO [dbo].[db_document_number_format]([document_type_id],[document_number_format_name],[document_number_format_description],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		(@document_type_id,'{0}{1}{2}{3}[RUNNING]',NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())


SELECT TOP 1 @document_type_id = [document_type_id] FROM [dbo].[db_document_type] WHERE [document_type_name] = 'RO'
INSERT INTO [dbo].[db_reason]([reason_name],[reason_description],[module],[document_type_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('Reason 1',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 2',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 3',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())	

INSERT INTO [dbo].[db_document_number_format]([document_type_id],[document_number_format_name],[document_number_format_description],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		(@document_type_id,'{0}{1}{2}{3}[RUNNING]',NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())


SELECT TOP 1 @document_type_id = [document_type_id] FROM [dbo].[db_document_type] WHERE [document_type_name] = 'IM'
INSERT INTO [dbo].[db_reason]([reason_name],[reason_description],[module],[document_type_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('Reason 1',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 2',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 3',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())	

INSERT INTO [dbo].[db_document_number_format]([document_type_id],[document_number_format_name],[document_number_format_description],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		(@document_type_id,'{0}{1}{2}{3}[RUNNING]',NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())

		
SELECT TOP 1 @document_type_id = [document_type_id] FROM [dbo].[db_document_type] WHERE [document_type_name] = 'SM'
INSERT INTO [dbo].[db_reason]([reason_name],[reason_description],[module],[document_type_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('Reason 1',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 2',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 3',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())	
		
INSERT INTO [dbo].[db_document_number_format]([document_type_id],[document_number_format_name],[document_number_format_description],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		(@document_type_id,'{0}{1}{2}{3}[RUNNING]',NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())


SELECT TOP 1 @document_type_id = [document_type_id] FROM [dbo].[db_document_type] WHERE [document_type_name] = 'CS'
INSERT INTO [dbo].[db_reason]([reason_name],[reason_description],[module],[document_type_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('Reason 1',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 2',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 3',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())	

INSERT INTO [dbo].[db_document_number_format]([document_type_id],[document_number_format_name],[document_number_format_description],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		(@document_type_id,'{0}{1}{2}{3}[RUNNING]',NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())


SELECT TOP 1 @document_type_id = [document_type_id] FROM [dbo].[db_document_type] WHERE [document_type_name] = 'SC'
INSERT INTO [dbo].[db_reason]([reason_name],[reason_description],[module],[document_type_id],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		('Reason 1',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 2',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE()),
		('Reason 3',NULL,NULL,@document_type_id,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())	

INSERT INTO [dbo].[db_document_number_format]([document_type_id],[document_number_format_name],[document_number_format_description],[active],[created_by],[created_date],[updated_by],[updated_date])
VALUES
		(@document_type_id,'{0}{1}{2}{3}[RUNNING]',NULL,1,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())

GO

INSERT INTO [POS].[dbo].[db_uom]
           ([uom_code]
           ,[uom_name])
     VALUES
           ('001','กิโลกรัม')
GO

INSERT INTO [POS].[dbo].[in_material_group]
           ([material_group_code]
           ,[material_group_name])
     VALUES
           ('001','ของสด')
GO

INSERT INTO [POS].[dbo].[in_material]
           ([material_code]
           ,[material_name]
           ,[uom_id_receive]
           ,[uom_id_count]
           ,[uom_id_use]
           ,[material_group_id]
           ,[max_stock]
           ,[min_stock]
           ,[shelf_life]
           ,[material_cost]
           ,[acceptable_variance]
		   ,[active])
     VALUES
           ('001','เนื้อ',1,1,1,1,'100','5','5','130','100',1),
           ('002','หมู',1,1,1,1,'100','5','5','100','80',1),
           ('003','หมึก',1,1,1,1,'50','5','5','150','120',1),
           ('004','กุ้ง',1,1,1,1,'50','5','5','300','280',1),
           ('005','ไก่',1,1,1,1,'100','5','5','80','60',1)
           
GO