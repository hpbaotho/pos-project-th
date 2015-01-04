USE POS
ALTER TABLE so_menu_dining_type
ADD  isInventoryItem bit null

INSERT INTO [so_menu] ([menu_code] ,[menu_name] ,menu_reference_id,[active] ,[created_by] ,[created_date] ,[updated_by],[updated_date])
VALUES   ('191','ลูกค้า',null,1 ,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
, ('192','เด็ก',(select TOP 1 menu_id FROM so_menu WHERE menu_code='191'),1 ,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())
, ('193','ผู้ใหญ่',(select TOP 1 menu_id FROM so_menu WHERE menu_code='191'),1 ,'SYSTEM' ,GETDATE() ,'SYSTEM' ,GETDATE())

INSERT INTO so_menu_dining_type (menu_id,dining_type_id,isInventoryItem,menu_price,created_by,created_date,updated_by,updated_date)
VALUES 
((SELECT TOP 1  menu_id  FROM so_menu WHERE menu_code='191'),(SELECT TOP 1 dining_type_id FROM db_dining_type WHERE dining_type_code='001'),1,0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
,((SELECT TOP 1  menu_id  FROM so_menu WHERE menu_code='192'),(SELECT TOP 1 dining_type_id FROM db_dining_type WHERE dining_type_code='001'),1,150,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())
,((SELECT TOP 1  menu_id  FROM so_menu WHERE menu_code='193'),(SELECT TOP 1 dining_type_id FROM db_dining_type WHERE dining_type_code='001'),1,300,'SYSTEM',GETDATE(),'SYSTEM',GETDATE())