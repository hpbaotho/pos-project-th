ALTER TABLE [dbo].[in_material]
DROP COLUMN [material_pic_path]

ALTER TABLE [dbo].[in_material]
ADD [material_pic] [image] NULL

ALTER TABLE [dbo].[in_tran_head]
ALTER COLUMN [transaction_no] NVARCHAR(20)