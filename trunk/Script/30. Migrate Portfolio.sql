INSERT INTO [dbo].[in_portfolio_head]([portfolio_head_code],[portfolio_head_name],[portfolio_head_desc],[created_by],[created_date],[updated_by],[updated_date],[active])
VALUES ('001','Portfolio 1', NULL,NULL,NULL,NULL,NULL,1)

INSERT INTO [dbo].[in_portfolio_head]([portfolio_head_code],[portfolio_head_name],[portfolio_head_desc],[created_by],[created_date],[updated_by],[updated_date],[active])
VALUES ('002','Portfolio 2', NULL,NULL,NULL,NULL,NULL,1)

INSERT INTO [dbo].[in_portfolio_head]([portfolio_head_code],[portfolio_head_name],[portfolio_head_desc],[created_by],[created_date],[updated_by],[updated_date],[active])
VALUES ('003','Portfolio 3', NULL,NULL,NULL,NULL,NULL,1)

DECLARE @PortfolioHeadID001 AS BIGINT,@PortfolioHeadID002 AS BIGINT,@PortfolioHeadID003 AS BIGINT
SELECT TOP 1 @PortfolioHeadID001 = portfolio_head_id FROM in_portfolio_head WHERE portfolio_head_code = '001'
SELECT TOP 1 @PortfolioHeadID002 = portfolio_head_id FROM in_portfolio_head WHERE portfolio_head_code = '002'
SELECT TOP 1 @PortfolioHeadID003 = portfolio_head_id FROM in_portfolio_head WHERE portfolio_head_code = '003'

INSERT INTO [dbo].[in_portfolio_detail] ([portfolio_head_id],[material_id],[warehouse_id],[created_by],[created_date],[updated_by],[updated_date])
SELECT @PortfolioHeadID001,material_id,NULL,NULL,NULL,NULL,NULL FROM in_material WHERE material_code IN ('01-0001','01-0002','01-0003','01-0004','01-0005','01-0006','01-0007','01-0008','01-0009','01-0010')

INSERT INTO [dbo].[in_portfolio_detail] ([portfolio_head_id],[material_id],[warehouse_id],[created_by],[created_date],[updated_by],[updated_date])
SELECT @PortfolioHeadID002,material_id,NULL,NULL,NULL,NULL,NULL FROM in_material WHERE material_code IN ('01-0011','01-0012','01-0013','01-0014','01-0015','01-0016','01-0017','01-0018','01-0019','01-0020')

INSERT INTO [dbo].[in_portfolio_detail] ([portfolio_head_id],[material_id],[warehouse_id],[created_by],[created_date],[updated_by],[updated_date])
SELECT @PortfolioHeadID003,material_id,NULL,NULL,NULL,NULL,NULL FROM in_material WHERE material_code IN ('01-0021','01-0022','01-0023','01-0024','01-0025','01-0026','01-0027','01-0028','01-0029','01-0030')