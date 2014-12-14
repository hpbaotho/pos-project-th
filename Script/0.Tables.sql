USE [POS]
GO
/****** Object:  Table [dbo].[sc_export_activity]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_export_activity](
	[export_activity_id] [bigint] IDENTITY(1,1) NOT NULL,
	[export_status] [nvarchar](300) NULL,
	[exported_by] [nvarchar](50) NULL,
	[exported_date] [datetime] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_export_activity] PRIMARY KEY CLUSTERED 
(
	[export_activity_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_dining_type]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_dining_type](
	[dining_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[dining_type_code] [nvarchar](20) NULL,
	[dining_type_name] [nvarchar](1000) NULL,
	[dining_type_description] [nvarchar](1000) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_dining_type] PRIMARY KEY CLUSTERED 
(
	[dining_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_screen_config]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_screen_config](
	[control_id] [bigint] IDENTITY(1,1) NOT NULL,
	[control_code] [nvarchar](20) NULL,
	[control_type] [nvarchar](500) NULL,
	[background_color] [int] NULL,
	[background_image_path] [nvarchar](max) NULL,
	[fore_color] [int] NULL,
	[font] [nvarchar](500) NULL,
	[position_top] [int] NULL,
	[position_left] [int] NULL,
	[control_width] [int] NULL,
	[control_height] [int] NULL,
	[control_parent_id] [bigint] NULL,
	[percent_width] [decimal](18, 0) NULL,
	[percent_height] [decimal](18, 0) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[border_style] [int] NULL,
	[display_text] [nvarchar](5) NULL,
 CONSTRAINT [PK_sc_screen_config] PRIMARY KEY CLUSTERED 
(
	[control_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_role]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_role](
	[role_id] [bigint] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NOT NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_function_group]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_function_group](
	[function_group_code] [nvarchar](50) NOT NULL,
	[function_group_name] [nvarchar](300) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_function_group] PRIMARY KEY CLUSTERED 
(
	[function_group_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_command_script]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_command_script](
	[command_script_id] [bigint] IDENTITY(1,1) NOT NULL,
	[command_script_code] [nvarchar](20) NULL,
	[command_script] [nvarchar](max) NULL,
	[stored_procedure_name] [nvarchar](max) NULL,
	[command_script_description] [nvarchar](max) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_command_script] PRIMARY KEY CLUSTERED 
(
	[command_script_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_activity_type]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_activity_type](
	[activity_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[activity_type_name] [nvarchar](max) NULL,
	[activity_type_description] [nvarchar](max) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_activity_type] PRIMARY KEY CLUSTERED 
(
	[activity_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_period]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_period](
	[period_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_code] [nvarchar](20) NULL,
	[period_name] [nvarchar](300) NULL,
	[period_description] [nvarchar](max) NULL,
	[open_period_by] [nvarchar](100) NULL,
	[open_period_date] [datetime] NULL,
	[close_period_by] [nvarchar](100) NULL,
	[close_period_date] [datetime] NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_period] PRIMARY KEY CLUSTERED 
(
	[period_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_employee_group]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_employee_group](
	[employee_group_id] [bigint] IDENTITY(1,1) NOT NULL,
	[employee_group_name] [nvarchar](300) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_employee_group] PRIMARY KEY CLUSTERED 
(
	[employee_group_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_company]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_company](
	[company_id] [bigint] IDENTITY(1,1) NOT NULL,
	[company_code] [nvarchar](20) NULL,
	[company_name] [nvarchar](500) NULL,
	[company_address_line1] [nvarchar](max) NULL,
	[company_address_line2] [nvarchar](max) NULL,
	[company_address_line3] [nvarchar](max) NULL,
	[company_address_line4] [nvarchar](max) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_company] PRIMARY KEY CLUSTERED 
(
	[company_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_branch]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_branch](
	[branch_id] [bigint] IDENTITY(1,1) NOT NULL,
	[branch_code] [nvarchar](20) NULL,
	[branch_name] [nvarchar](500) NULL,
	[branch_address_line1] [nvarchar](max) NULL,
	[branch_address_line2] [nvarchar](max) NULL,
	[branch_address_line3] [nvarchar](max) NULL,
	[branch_address_line4] [nvarchar](max) NULL,
	[branch_telephone] [nvarchar](100) NULL,
	[branch_email] [nvarchar](100) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_branch] PRIMARY KEY CLUSTERED 
(
	[branch_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ap_vat_type]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ap_vat_type](
	[vat_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[vat_type_name] [nvarchar](300) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_ap_vat_type] PRIMARY KEY CLUSTERED 
(
	[vat_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ap_payment_type]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ap_payment_type](
	[payment_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[payment_type_name] [nvarchar](300) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_ap_payment_type] PRIMARY KEY CLUSTERED 
(
	[payment_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ap_payment_type] ON
INSERT [dbo].[ap_payment_type] ([payment_type_id], [payment_type_name], [active], [created_by], [created_date], [updated_by], [updated_date]) VALUES (1, N'Cash', 1, N'SYSTEM', CAST(0x0000A3F900000000 AS DateTime), N'SYSTEM', CAST(0x0000A3F900000000 AS DateTime))
INSERT [dbo].[ap_payment_type] ([payment_type_id], [payment_type_name], [active], [created_by], [created_date], [updated_by], [updated_date]) VALUES (2, N'Credit Card', 1, N'SYSTEM', CAST(0x0000A3F900000000 AS DateTime), N'SYSTEM', CAST(0x0000A3F900000000 AS DateTime))
INSERT [dbo].[ap_payment_type] ([payment_type_id], [payment_type_name], [active], [created_by], [created_date], [updated_by], [updated_date]) VALUES (3, N'Voucher', 1, N'SYSTEM', CAST(0x0000A3F900000000 AS DateTime), N'SYSTEM', CAST(0x0000A3F900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[ap_payment_type] OFF
/****** Object:  Table [dbo].[in_bill_of_material_group]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_bill_of_material_group](
	[bill_of_material_group_id] [bigint] IDENTITY(1,1) NOT NULL,
	[bill_of_material_group_code] [bigint] NOT NULL,
	[bill_of_material_group_name] [nvarchar](200) NOT NULL,
	[bill_of_material_group_description] [nvarchar](100) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_bill_of_material_group] PRIMARY KEY CLUSTERED 
(
	[bill_of_material_group_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_supplier]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_supplier](
	[supplier_id] [bigint] IDENTITY(1,1) NOT NULL,
	[supplier_code] [nvarchar](20) NULL,
	[supplier_name] [nvarchar](1000) NULL,
	[supplier_description] [nvarchar](1000) NULL,
	[supplier_address] [nvarchar](max) NULL,
	[supplier_tel] [nvarchar](100) NULL,
	[supplier_contract_person] [nvarchar](500) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_supplier] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_service_type]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_service_type](
	[service_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[service_type_name] [nvarchar](300) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_service_type] PRIMARY KEY CLUSTERED 
(
	[service_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_uom]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_uom](
	[uom_id] [bigint] IDENTITY(1,1) NOT NULL,
	[uom_code] [nvarchar](20) NULL,
	[uom_name] [nvarchar](1000) NULL,
	[uom_description] [nvarchar](1000) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_uom] PRIMARY KEY CLUSTERED 
(
	[uom_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_system_configuration_group]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_system_configuration_group](
	[system_configuration_group_code] [nvarchar](20) NOT NULL,
	[system_configuration_group_name] [nvarchar](max) NULL,
	[system_configuration_group_description] [nvarchar](max) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_system_configuration_group] PRIMARY KEY CLUSTERED 
(
	[system_configuration_group_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_system_configuration]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_system_configuration](
	[system_configuration_code] [nvarchar](20) NOT NULL,
	[system_configuration_group_code] [nvarchar](20) NOT NULL,
	[system_configuration_name] [nvarchar](max) NOT NULL,
	[system_configuration_description] [nvarchar](max) NOT NULL,
	[system_configuration_value] [nvarchar](max) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](max) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_system_configuration] PRIMARY KEY CLUSTERED 
(
	[system_configuration_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_material]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_material](
	[material_id] [bigint] IDENTITY(1,1) NOT NULL,
	[material_code] [bigint] NOT NULL,
	[material_name] [nvarchar](200) NOT NULL,
	[material_description] [nvarchar](100) NULL,
	[uom_id_receive] [bigint] NOT NULL,
	[uom_id_count] [bigint] NOT NULL,
	[uom_id_use] [bigint] NOT NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_material] PRIMARY KEY CLUSTERED 
(
	[material_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_bill_of_material_head]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_bill_of_material_head](
	[bill_of_material_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[bill_of_material_group_id] [bigint] NOT NULL,
	[bill_of_material_head_code] [bigint] NOT NULL,
	[bill_of_material_head_name] [nvarchar](200) NOT NULL,
	[bill_of_material_head_description] [nvarchar](100) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_bill_of_material_head] PRIMARY KEY CLUSTERED 
(
	[bill_of_material_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_company_branch]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_company_branch](
	[company_branch_id] [bigint] IDENTITY(1,1) NOT NULL,
	[company_id] [bigint] NULL,
	[branch_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_company_branch] PRIMARY KEY CLUSTERED 
(
	[company_branch_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_employee]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_employee](
	[employee_id] [bigint] IDENTITY(1,1) NOT NULL,
	[employee_group_id] [bigint] NOT NULL,
	[employee_no] [nvarchar](50) NULL,
	[first_name] [nvarchar](300) NULL,
	[mid_name] [nvarchar](300) NULL,
	[last_name] [nvarchar](300) NULL,
	[user_name] [nvarchar](300) NULL,
	[user_password] [nvarchar](300) NULL,
	[miss_login] [int] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_activity_log]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_activity_log](
	[activity_log_id] [bigint] IDENTITY(1,1) NOT NULL,
	[activity_type_id] [bigint] NOT NULL,
	[log_by] [nvarchar](50) NULL,
	[log_description] [nvarchar](max) NULL,
	[log_date] [datetime] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_activity_log] PRIMARY KEY CLUSTERED 
(
	[activity_log_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_function]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_function](
	[function_code] [nvarchar](50) NOT NULL,
	[function_group_code] [nvarchar](50) NOT NULL,
	[function_name] [nvarchar](max) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_function] PRIMARY KEY CLUSTERED 
(
	[function_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_command_script_param]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_command_script_param](
	[command_script_param_id] [bigint] IDENTITY(1,1) NOT NULL,
	[command_script_id] [bigint] NULL,
	[command_script_param_code] [nvarchar](100) NULL,
	[command_script_param_value] [nvarchar](max) NULL,
	[command_script_param_description] [nvarchar](max) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_command_script_param] PRIMARY KEY CLUSTERED 
(
	[command_script_param_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_uom_ratio]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_uom_ratio](
	[uom_ratio_id] [bigint] IDENTITY(1,1) NOT NULL,
	[uom_id_from] [bigint] NULL,
	[uom_id_to] [bigint] NULL,
	[uom_ratio_description] [nvarchar](1000) NULL,
	[uom_ratio] [decimal](18, 0) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_uom_ratio] PRIMARY KEY CLUSTERED 
(
	[uom_ratio_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_user_permission]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[db_device]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_device](
	[device_id] [bigint] IDENTITY(1,1) NOT NULL,
	[device_name] [nvarchar](1000) NULL,
	[device_description] [nvarchar](1000) NULL,
	[device_ip] [nvarchar](1000) NOT NULL,
	[company_branch_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_device] PRIMARY KEY CLUSTERED 
(
	[device_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_document_type]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_document_type](
	[document_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[document_type_name] [nvarchar](300) NULL,
	[document_type_description] [nvarchar](500) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[company_branch_id] [bigint] NULL,
 CONSTRAINT [PK_db_document_type] PRIMARY KEY CLUSTERED 
(
	[document_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_bill_of_material_detail]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_bill_of_material_detail](
	[bill_of_material_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[bill_of_material_head_id] [bigint] NOT NULL,
	[material_id] [bigint] NULL,
	[bill_of_material_head_id_sub] [bigint] NOT NULL,
	[amount] [numeric](11, 4) NOT NULL,
	[lost_factor] [tinyint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_bill_of_material_detail] PRIMARY KEY CLUSTERED 
(
	[bill_of_material_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_warehouse]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_warehouse](
	[warehouse_id] [bigint] IDENTITY(1,1) NOT NULL,
	[warehouse_code] [nvarchar](20) NULL,
	[warehouse_name] [nvarchar](1000) NULL,
	[warehouse_description] [nvarchar](1000) NULL,
	[company_branch_id] [bigint] NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_warehouse] PRIMARY KEY CLUSTERED 
(
	[warehouse_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_reason]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_reason](
	[reason_id] [bigint] IDENTITY(1,1) NOT NULL,
	[reason_name] [nvarchar](500) NULL,
	[reason_description] [nvarchar](max) NULL,
	[module] [nvarchar](500) NULL,
	[document_type_id] [bigint] NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_reason] PRIMARY KEY CLUSTERED 
(
	[reason_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_document_number_format]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_document_number_format](
	[document_number_format_id] [bigint] IDENTITY(1,1) NOT NULL,
	[document_type_id] [bigint] NULL,
	[document_number_format_name] [nvarchar](500) NULL,
	[document_number_format_description] [nvarchar](max) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_document_number_format] PRIMARY KEY CLUSTERED 
(
	[document_number_format_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[db_document_last_running_number]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_document_last_running_number](
	[document_last_running_number_id] [bigint] IDENTITY(1,1) NOT NULL,
	[document_type_id] [bigint] NULL,
	[document_number_value] [nvarchar](100) NOT NULL,
	[document_last_running_number] [int] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_document_last_running_number] PRIMARY KEY CLUSTERED 
(
	[document_last_running_number_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_send_material_head]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_send_material_head](
	[send_material_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[transaction_no] [nvarchar](10) NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[transaction_status] [bigint] NOT NULL,
	[reason_id] [bigint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_send_material_head] PRIMARY KEY CLUSTERED 
(
	[send_material_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_receive_material_head]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_receive_material_head](
	[receive_material_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[supplier_id] [bigint] NULL,
	[warehouse_id_source] [bigint] NULL,
	[other_source] [nvarchar](1000) NULL,
	[reference_no] [nvarchar](100) NOT NULL,
	[transaction_no] [nvarchar](10) NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[transaction_status] [bigint] NOT NULL,
	[reason_id] [bigint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_receive_material_head] PRIMARY KEY CLUSTERED 
(
	[receive_material_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_receive_material_detail]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_receive_material_detail](
	[receive_material_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_material_head_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[warehouse_id_destination] [bigint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_receive_material_detail] PRIMARY KEY CLUSTERED 
(
	[receive_material_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[in_send_material_detail]    Script Date: 12/14/2014 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[in_send_material_detail](
	[send_material_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[send_material_head_id] [bigint] NOT NULL,
	[warehouse_id_source] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[warehouse_id_destination] [bigint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_send_material_detail] PRIMARY KEY CLUSTERED 
(
	[send_material_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [fk_db_company_branch_branch]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_company_branch]  WITH CHECK ADD  CONSTRAINT [fk_db_company_branch_branch] FOREIGN KEY([branch_id])
REFERENCES [dbo].[db_branch] ([branch_id])
GO
ALTER TABLE [dbo].[db_company_branch] CHECK CONSTRAINT [fk_db_company_branch_branch]
GO
/****** Object:  ForeignKey [fk_db_company_branch_company]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_company_branch]  WITH CHECK ADD  CONSTRAINT [fk_db_company_branch_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[db_company] ([company_id])
GO
ALTER TABLE [dbo].[db_company_branch] CHECK CONSTRAINT [fk_db_company_branch_company]
GO
/****** Object:  ForeignKey [fk_db_device_company_branch]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_device]  WITH CHECK ADD  CONSTRAINT [fk_db_device_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].[db_company_branch] ([company_branch_id])
GO
ALTER TABLE [dbo].[db_device] CHECK CONSTRAINT [fk_db_device_company_branch]
GO
/****** Object:  ForeignKey [fk_db_document_last_running_number_document_type]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_document_last_running_number]  WITH CHECK ADD  CONSTRAINT [fk_db_document_last_running_number_document_type] FOREIGN KEY([document_type_id])
REFERENCES [dbo].[db_document_type] ([document_type_id])
GO
ALTER TABLE [dbo].[db_document_last_running_number] CHECK CONSTRAINT [fk_db_document_last_running_number_document_type]
GO
/****** Object:  ForeignKey [fk_db_document_number_format_document_type]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_document_number_format]  WITH CHECK ADD  CONSTRAINT [fk_db_document_number_format_document_type] FOREIGN KEY([document_type_id])
REFERENCES [dbo].[db_document_type] ([document_type_id])
GO
ALTER TABLE [dbo].[db_document_number_format] CHECK CONSTRAINT [fk_db_document_number_format_document_type]
GO
/****** Object:  ForeignKey [fk_db_document_type_company_branch]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_document_type]  WITH CHECK ADD  CONSTRAINT [fk_db_document_type_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].[db_company_branch] ([company_branch_id])
GO
ALTER TABLE [dbo].[db_document_type] CHECK CONSTRAINT [fk_db_document_type_company_branch]
GO
/****** Object:  ForeignKey [fk_db_employee_employee_group]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_employee]  WITH CHECK ADD  CONSTRAINT [fk_db_employee_employee_group] FOREIGN KEY([employee_group_id])
REFERENCES [dbo].[db_employee_group] ([employee_group_id])
GO
ALTER TABLE [dbo].[db_employee] CHECK CONSTRAINT [fk_db_employee_employee_group]
GO
/****** Object:  ForeignKey [fk_db_reason_document_type]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_reason]  WITH CHECK ADD  CONSTRAINT [fk_db_reason_document_type] FOREIGN KEY([document_type_id])
REFERENCES [dbo].[db_document_type] ([document_type_id])
GO
ALTER TABLE [dbo].[db_reason] CHECK CONSTRAINT [fk_db_reason_document_type]
GO
/****** Object:  ForeignKey [fk_db_system_configuration_configuration_group]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_system_configuration]  WITH CHECK ADD  CONSTRAINT [fk_db_system_configuration_configuration_group] FOREIGN KEY([system_configuration_group_code])
REFERENCES [dbo].[db_system_configuration_group] ([system_configuration_group_code])
GO
ALTER TABLE [dbo].[db_system_configuration] CHECK CONSTRAINT [fk_db_system_configuration_configuration_group]
GO
/****** Object:  ForeignKey [fk_db_uom_ratio_uom_from]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_uom_ratio]  WITH CHECK ADD  CONSTRAINT [fk_db_uom_ratio_uom_from] FOREIGN KEY([uom_id_from])
REFERENCES [dbo].[db_uom] ([uom_id])
GO
ALTER TABLE [dbo].[db_uom_ratio] CHECK CONSTRAINT [fk_db_uom_ratio_uom_from]
GO
/****** Object:  ForeignKey [fk_db_uom_ratio_uom_to]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_uom_ratio]  WITH CHECK ADD  CONSTRAINT [fk_db_uom_ratio_uom_to] FOREIGN KEY([uom_id_to])
REFERENCES [dbo].[db_uom] ([uom_id])
GO
ALTER TABLE [dbo].[db_uom_ratio] CHECK CONSTRAINT [fk_db_uom_ratio_uom_to]
GO
/****** Object:  ForeignKey [fk_db_warehouse_company_branch]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[db_warehouse]  WITH CHECK ADD  CONSTRAINT [fk_db_warehouse_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].[db_company_branch] ([company_branch_id])
GO
ALTER TABLE [dbo].[db_warehouse] CHECK CONSTRAINT [fk_db_warehouse_company_branch]
GO
/****** Object:  ForeignKey [fk_in_bill_of_material_detail_in_bill_of_material_head]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_bill_of_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_bill_of_material_detail_in_bill_of_material_head] FOREIGN KEY([bill_of_material_head_id])
REFERENCES [dbo].[in_bill_of_material_head] ([bill_of_material_head_id])
GO
ALTER TABLE [dbo].[in_bill_of_material_detail] CHECK CONSTRAINT [fk_in_bill_of_material_detail_in_bill_of_material_head]
GO
/****** Object:  ForeignKey [fk_in_bill_of_material_detail_in_bill_of_material_head_sub]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_bill_of_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_bill_of_material_detail_in_bill_of_material_head_sub] FOREIGN KEY([bill_of_material_head_id_sub])
REFERENCES [dbo].[in_bill_of_material_head] ([bill_of_material_head_id])
GO
ALTER TABLE [dbo].[in_bill_of_material_detail] CHECK CONSTRAINT [fk_in_bill_of_material_detail_in_bill_of_material_head_sub]
GO
/****** Object:  ForeignKey [fk_in_bill_of_material_detail_in_material]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_bill_of_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_bill_of_material_detail_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO
ALTER TABLE [dbo].[in_bill_of_material_detail] CHECK CONSTRAINT [fk_in_bill_of_material_detail_in_material]
GO
/****** Object:  ForeignKey [fk_in_bill_of_material_head_in_bill_of_material_group]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_bill_of_material_head]  WITH CHECK ADD  CONSTRAINT [fk_in_bill_of_material_head_in_bill_of_material_group] FOREIGN KEY([bill_of_material_group_id])
REFERENCES [dbo].[in_bill_of_material_group] ([bill_of_material_group_id])
GO
ALTER TABLE [dbo].[in_bill_of_material_head] CHECK CONSTRAINT [fk_in_bill_of_material_head_in_bill_of_material_group]
GO
/****** Object:  ForeignKey [fk_in_material_db_uom_count]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_material]  WITH CHECK ADD  CONSTRAINT [fk_in_material_db_uom_count] FOREIGN KEY([uom_id_count])
REFERENCES [dbo].[db_uom] ([uom_id])
GO
ALTER TABLE [dbo].[in_material] CHECK CONSTRAINT [fk_in_material_db_uom_count]
GO
/****** Object:  ForeignKey [fk_in_material_db_uom_receive]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_material]  WITH CHECK ADD  CONSTRAINT [fk_in_material_db_uom_receive] FOREIGN KEY([uom_id_receive])
REFERENCES [dbo].[db_uom] ([uom_id])
GO
ALTER TABLE [dbo].[in_material] CHECK CONSTRAINT [fk_in_material_db_uom_receive]
GO
/****** Object:  ForeignKey [fk_in_material_db_uom_use]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_material]  WITH CHECK ADD  CONSTRAINT [fk_in_material_db_uom_use] FOREIGN KEY([uom_id_use])
REFERENCES [dbo].[db_uom] ([uom_id])
GO
ALTER TABLE [dbo].[in_material] CHECK CONSTRAINT [fk_in_material_db_uom_use]
GO
/****** Object:  ForeignKey [fk_in_receive_material_detail_db_warehouse]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_receive_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_receive_material_detail_db_warehouse] FOREIGN KEY([warehouse_id_destination])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO
ALTER TABLE [dbo].[in_receive_material_detail] CHECK CONSTRAINT [fk_in_receive_material_detail_db_warehouse]
GO
/****** Object:  ForeignKey [fk_in_receive_material_detail_in_material]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_receive_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_receive_material_detail_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO
ALTER TABLE [dbo].[in_receive_material_detail] CHECK CONSTRAINT [fk_in_receive_material_detail_in_material]
GO
/****** Object:  ForeignKey [fk_in_receive_material_detail_in_receive_material_head]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_receive_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_receive_material_detail_in_receive_material_head] FOREIGN KEY([receive_material_head_id])
REFERENCES [dbo].[in_receive_material_head] ([receive_material_head_id])
GO
ALTER TABLE [dbo].[in_receive_material_detail] CHECK CONSTRAINT [fk_in_receive_material_detail_in_receive_material_head]
GO
/****** Object:  ForeignKey [fk_in_receive_material_head_db_reason]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_receive_material_head]  WITH CHECK ADD  CONSTRAINT [fk_in_receive_material_head_db_reason] FOREIGN KEY([reason_id])
REFERENCES [dbo].[db_reason] ([reason_id])
GO
ALTER TABLE [dbo].[in_receive_material_head] CHECK CONSTRAINT [fk_in_receive_material_head_db_reason]
GO
/****** Object:  ForeignKey [fk_in_receive_material_head_db_supplier]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_receive_material_head]  WITH CHECK ADD  CONSTRAINT [fk_in_receive_material_head_db_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[db_supplier] ([supplier_id])
GO
ALTER TABLE [dbo].[in_receive_material_head] CHECK CONSTRAINT [fk_in_receive_material_head_db_supplier]
GO
/****** Object:  ForeignKey [fk_in_receive_material_head_db_warehouse]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_receive_material_head]  WITH CHECK ADD  CONSTRAINT [fk_in_receive_material_head_db_warehouse] FOREIGN KEY([warehouse_id_source])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO
ALTER TABLE [dbo].[in_receive_material_head] CHECK CONSTRAINT [fk_in_receive_material_head_db_warehouse]
GO
/****** Object:  ForeignKey [fk_in_send_material_detail_db_warehouse_destination]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_send_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_send_material_detail_db_warehouse_destination] FOREIGN KEY([warehouse_id_destination])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO
ALTER TABLE [dbo].[in_send_material_detail] CHECK CONSTRAINT [fk_in_send_material_detail_db_warehouse_destination]
GO
/****** Object:  ForeignKey [fk_in_send_material_detail_db_warehouse_source]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_send_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_send_material_detail_db_warehouse_source] FOREIGN KEY([warehouse_id_source])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO
ALTER TABLE [dbo].[in_send_material_detail] CHECK CONSTRAINT [fk_in_send_material_detail_db_warehouse_source]
GO
/****** Object:  ForeignKey [fk_in_send_material_detail_in_in_material]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_send_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_send_material_detail_in_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO
ALTER TABLE [dbo].[in_send_material_detail] CHECK CONSTRAINT [fk_in_send_material_detail_in_in_material]
GO
/****** Object:  ForeignKey [fk_in_send_material_detail_in_send_material_head]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_send_material_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_send_material_detail_in_send_material_head] FOREIGN KEY([send_material_head_id])
REFERENCES [dbo].[in_send_material_head] ([send_material_head_id])
GO
ALTER TABLE [dbo].[in_send_material_detail] CHECK CONSTRAINT [fk_in_send_material_detail_in_send_material_head]
GO
/****** Object:  ForeignKey [fk_in_send_material_head_db_reason]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[in_send_material_head]  WITH CHECK ADD  CONSTRAINT [fk_in_send_material_head_db_reason] FOREIGN KEY([reason_id])
REFERENCES [dbo].[db_reason] ([reason_id])
GO
ALTER TABLE [dbo].[in_send_material_head] CHECK CONSTRAINT [fk_in_send_material_head_db_reason]
GO
/****** Object:  ForeignKey [fk_sc_activity_log_sc_activity_type]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[sc_activity_log]  WITH CHECK ADD  CONSTRAINT [fk_sc_activity_log_sc_activity_type] FOREIGN KEY([activity_type_id])
REFERENCES [dbo].[sc_activity_type] ([activity_type_id])
GO
ALTER TABLE [dbo].[sc_activity_log] CHECK CONSTRAINT [fk_sc_activity_log_sc_activity_type]
GO
/****** Object:  ForeignKey [fk_sc_command_script_param_command_script]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[sc_command_script_param]  WITH CHECK ADD  CONSTRAINT [fk_sc_command_script_param_command_script] FOREIGN KEY([command_script_id])
REFERENCES [dbo].[sc_command_script] ([command_script_id])
GO
ALTER TABLE [dbo].[sc_command_script_param] CHECK CONSTRAINT [fk_sc_command_script_param_command_script]
GO
/****** Object:  ForeignKey [fk_sc_function_function_group]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[sc_function]  WITH CHECK ADD  CONSTRAINT [fk_sc_function_function_group] FOREIGN KEY([function_group_code])
REFERENCES [dbo].[sc_function_group] ([function_group_code])
GO
ALTER TABLE [dbo].[sc_function] CHECK CONSTRAINT [fk_sc_function_function_group]
GO
/****** Object:  ForeignKey [fk_sc_user_permission_company_branch]    Script Date: 12/14/2014 22:53:50 ******/
ALTER TABLE [dbo].[sc_user_permission]  WITH CHECK ADD  CONSTRAINT [fk_sc_user_permission_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].[db_company_branch] ([company_branch_id])
GO
ALTER TABLE [dbo].[sc_user_permission] CHECK CONSTRAINT [fk_sc_user_permission_company_branch]
GO
