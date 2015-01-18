USE [POS]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_sc_activity_log_sc_activity_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[sc_activity_log]'))
ALTER TABLE [dbo].[sc_activity_log] DROP CONSTRAINT [fk_sc_activity_log_sc_activity_type]
GO

USE [POS]
GO

/****** Object:  Table [dbo].[sc_activity_log]    Script Date: 01/12/2015 10:33:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sc_activity_log]') AND type in (N'U'))
DROP TABLE [dbo].[sc_activity_log]
GO


/****** Object:  Table [dbo].[sc_activity_type]    Script Date: 01/12/2015 10:34:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sc_activity_type]') AND type in (N'U'))
DROP TABLE [dbo].[sc_activity_type]
GO


CREATE TABLE [dbo].[sc_activity_type](
	[activity_type_code] [nvarchar] (20) NOT NULL,
	[activity_type_name] [nvarchar](max) NULL,
	[activity_type_description] [nvarchar](max) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_activity_type] PRIMARY KEY CLUSTERED 
(
	[activity_type_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[sc_activity_log](
	[activity_log_id] [bigint] IDENTITY(1,1) NOT NULL,
	[activity_type_code] [nvarchar](20) NOT NULL,
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

ALTER TABLE [dbo].[sc_activity_log]  WITH CHECK ADD  CONSTRAINT [fk_sc_activity_log_sc_activity_type] FOREIGN KEY([activity_type_code])
REFERENCES [dbo].[sc_activity_type] ([activity_type_code])
GO

ALTER TABLE [dbo].[sc_activity_log] CHECK CONSTRAINT [fk_sc_activity_log_sc_activity_type]
GO


INSERT INTO sc_activity_type (activity_type_code, activity_type_name, activity_type_description, active, created_by, created_date, updated_by, updated_date)
VALUES('1001', 'Log-in', 'Log in successful', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1002', 'Log-in Fail', 'Log in Fail', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1003', 'Add User Role', 'Add User Role', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1004', 'Remove User Role', 'Remove User Role', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1005', 'Open Bill', 'Open Bill', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1006', 'Close Bill', 'Close Bill', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1007', 'Cancel Bill', 'Cancel Bill', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1008', 'Adjust Stock', 'Adjust Stock', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1009', 'Re-new Time', 'Re-new Time', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())
, ('1010', 'Re-print Bill', 'Re-print Bill', 1, 'SYSTEM', GETDATE(), 'SYSTEM', GETDATE())