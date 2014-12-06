USE [POS]
GO
/****** Object:  Table [dbo].[db_company]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_branch]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[ap_vat_type]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_service_type]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_employee_group]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[sc_export_activity]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[sc_activity_type]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[sc_screen_config]    Script Date: 12/06/2014 12:20:39 ******/
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
 CONSTRAINT [PK_sc_screen_config] PRIMARY KEY CLUSTERED 
(
	[control_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_role]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[sc_function_group]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_system_configuration_group]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_system_configuration]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[sc_function]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[sc_activity_log]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_employee]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  Table [dbo].[db_company_branch]    Script Date: 12/06/2014 12:20:39 ******/
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
/****** Object:  ForeignKey [fk_db_company_branch_branch]    Script Date: 12/06/2014 12:20:39 ******/
ALTER TABLE [dbo].[db_company_branch]  WITH CHECK ADD  CONSTRAINT [fk_db_company_branch_branch] FOREIGN KEY([branch_id])
REFERENCES [dbo].[db_branch] ([branch_id])
GO
ALTER TABLE [dbo].[db_company_branch] CHECK CONSTRAINT [fk_db_company_branch_branch]
GO
/****** Object:  ForeignKey [fk_db_company_branch_company]    Script Date: 12/06/2014 12:20:39 ******/
ALTER TABLE [dbo].[db_company_branch]  WITH CHECK ADD  CONSTRAINT [fk_db_company_branch_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[db_company] ([company_id])
GO
ALTER TABLE [dbo].[db_company_branch] CHECK CONSTRAINT [fk_db_company_branch_company]
GO
/****** Object:  ForeignKey [fk_db_employee_employee_group]    Script Date: 12/06/2014 12:20:39 ******/
ALTER TABLE [dbo].[db_employee]  WITH CHECK ADD  CONSTRAINT [fk_db_employee_employee_group] FOREIGN KEY([employee_group_id])
REFERENCES [dbo].[db_employee_group] ([employee_group_id])
GO
ALTER TABLE [dbo].[db_employee] CHECK CONSTRAINT [fk_db_employee_employee_group]
GO
/****** Object:  ForeignKey [fk_db_system_configuration_configuration_group]    Script Date: 12/06/2014 12:20:39 ******/
ALTER TABLE [dbo].[db_system_configuration]  WITH CHECK ADD  CONSTRAINT [fk_db_system_configuration_configuration_group] FOREIGN KEY([system_configuration_group_code])
REFERENCES [dbo].[db_system_configuration_group] ([system_configuration_group_code])
GO
ALTER TABLE [dbo].[db_system_configuration] CHECK CONSTRAINT [fk_db_system_configuration_configuration_group]
GO
/****** Object:  ForeignKey [fk_sc_activity_log_sc_activity_type]    Script Date: 12/06/2014 12:20:39 ******/
ALTER TABLE [dbo].[sc_activity_log]  WITH CHECK ADD  CONSTRAINT [fk_sc_activity_log_sc_activity_type] FOREIGN KEY([activity_type_id])
REFERENCES [dbo].[sc_activity_type] ([activity_type_id])
GO
ALTER TABLE [dbo].[sc_activity_log] CHECK CONSTRAINT [fk_sc_activity_log_sc_activity_type]
GO
/****** Object:  ForeignKey [fk_sc_function_function_group]    Script Date: 12/06/2014 12:20:39 ******/
ALTER TABLE [dbo].[sc_function]  WITH CHECK ADD  CONSTRAINT [fk_sc_function_function_group] FOREIGN KEY([function_group_code])
REFERENCES [dbo].[sc_function_group] ([function_group_code])
GO
ALTER TABLE [dbo].[sc_function] CHECK CONSTRAINT [fk_sc_function_function_group]
GO
