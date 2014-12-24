CREATE TABLE [dbo].[in_tran_head](
	[tran_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[document_type_id] [bigint] NOT NULL,
	[transaction_no] [nvarchar](10) NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[transaction_status] [bigint] NOT NULL,
	[reference_no] [nvarchar](100) NOT NULL,
	[reason_id] [bigint] NOT NULL,
	
	[supplier_id] [bigint] NULL,
	[warehouse_id] [bigint] NULL,
	[other_source] [nvarchar](1000) NULL,
	
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_tran_head] PRIMARY KEY CLUSTERED 
(
	[tran_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_db_reason] FOREIGN KEY([reason_id])
REFERENCES [dbo].[db_reason] ([reason_id])
GO

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_db_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[db_supplier] ([supplier_id])
GO

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_db_document_type] FOREIGN KEY([document_type_id])
REFERENCES [dbo].[db_document_type] ([document_type_id])
GO

CREATE TABLE [dbo].[in_tran_detail](
	[in_tran_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[tran_head_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[warehouse_id_dest] [bigint] NOT NULL,
	[quantity] [numeric] (11,4) NULL,
	
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_tran_detail] PRIMARY KEY CLUSTERED 
(
	[in_tran_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[in_tran_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_detail_db_warehouse] FOREIGN KEY([warehouse_id_dest])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_tran_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_detail_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO

ALTER TABLE [dbo].[in_tran_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_detail_in_tran_head] FOREIGN KEY([tran_head_id])
REFERENCES [dbo].[in_tran_head] ([tran_head_id])
GO