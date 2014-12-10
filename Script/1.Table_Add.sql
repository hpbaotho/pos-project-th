CREATE TABLE [dbo].[sc_user_permission](
	[user_permission_id] [bigint] IDENTITY(1,1) NOT NULL,
	[company_branch_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_user_permission] PRIMARY KEY CLUSTERED 
(
	[user_permission_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[sc_user_permission]  WITH CHECK ADD  CONSTRAINT [fk_sc_user_permission_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].db_company_branch ([company_branch_id])
GO

ALTER TABLE [dbo].[sc_user_permission] CHECK CONSTRAINT [fk_sc_user_permission_company_branch]
GO
