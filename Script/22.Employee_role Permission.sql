CREATE TABLE [dbo].[sc_employee_role](
	[employee_role_id] [bigint] IDENTITY(1,1) NOT NULL,
	[role_id] [bigint] NULL,
	[employee_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_employee_role] PRIMARY KEY CLUSTERED 
(
	[employee_role_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[sc_employee_role]  WITH CHECK ADD  CONSTRAINT [fk_sc_employee_role_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].db_employee ([employee_id])
GO

ALTER TABLE [dbo].[sc_employee_role] CHECK CONSTRAINT [fk_sc_employee_role_employee]
GO

ALTER TABLE [dbo].[sc_employee_role]  WITH CHECK ADD  CONSTRAINT [fk_sc_employee_role_role] FOREIGN KEY([role_id])
REFERENCES [dbo].sc_role ([role_id])
GO

ALTER TABLE [dbo].[sc_employee_role] CHECK CONSTRAINT [fk_sc_employee_role_role]
GO

CREATE TABLE [dbo].[sc_function_permission](
	[function_permission_id] [bigint] IDENTITY(1,1) NOT NULL,
	[role_id] [bigint] NULL,
	[function_code] nvarchar(50) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_function_permission] PRIMARY KEY CLUSTERED 
(
	[function_permission_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[sc_function_permission]  WITH CHECK ADD  CONSTRAINT [fk_sc_function_permission_function] FOREIGN KEY([function_code])
REFERENCES [dbo].sc_function ([function_code])
GO

ALTER TABLE [dbo].[sc_function_permission] CHECK CONSTRAINT [fk_sc_function_permission_function]
GO

ALTER TABLE [dbo].[sc_function_permission]  WITH CHECK ADD  CONSTRAINT [fk_sc_function_permission_role] FOREIGN KEY([role_id])
REFERENCES [dbo].sc_role ([role_id])
GO

ALTER TABLE [dbo].[sc_function_permission] CHECK CONSTRAINT [fk_sc_function_permission_role]
GO

