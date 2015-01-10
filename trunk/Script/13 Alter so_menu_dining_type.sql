USE POS
Go
ALTER TABLE so_menu_dining_type
ADD  ref_menu_dining_type_id bigint null

ALTER TABLE so_menu_dining_type
ADD  menu_effective_date datetime null

ALTER TABLE so_menu_dining_type
DROP COLUMN isInventoryItem

ALTER TABLE so_menu
ADD  isInventoryItem bit null


ALTER TABLE so_menu_dining_type  WITH CHECK ADD  CONSTRAINT [fk_so_menu_dining_type_so_menu_dining_type] FOREIGN KEY([ref_menu_dining_type_id])
REFERENCES so_menu_dining_type ([menu_dining_type_id])
GO

--DROP TABLE so_menu_combo
CREATE TABLE [dbo].[so_menu_combo](
	[so_menu_combo_id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_id] [bigint] NOT NULL,
	[detail_menu_id] [bigint] NOT NULL,
	[isFreeChoice] bit NULL,
	[maxFreeQTY] int NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_so_menu_combo] PRIMARY KEY CLUSTERED 
(
	[so_menu_combo_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE so_menu_combo  WITH CHECK ADD  CONSTRAINT [fk_menu_id_so_menu] FOREIGN KEY([menu_id])
REFERENCES so_menu ([menu_id])
GO


ALTER TABLE so_menu_combo  WITH CHECK ADD  CONSTRAINT [fk_detail_menu_id_so_menu] FOREIGN KEY([detail_menu_id])
REFERENCES so_menu ([menu_id])
GO


CREATE TABLE [dbo].[so_menu_group](
	[menu_group_id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_group_code] nvarchar(20) NOT NULL,
	[menu_group_name] nvarchar(500) NOT NULL,
	[menu_group_description] nvarchar(MAX)  NULL,
	[priorityValue] int null,
	[active] bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_so_menu_group] PRIMARY KEY CLUSTERED 
(
	[menu_group_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[so_menu_category](
	[menu_category_id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_category_code] nvarchar(20) NOT NULL,
	[menu_category_name] nvarchar(500) NOT NULL,
	[menu_group_description] nvarchar(MAX)  NULL,
	[priorityValue] int null,
	[active] bit null,
	[isCombo] bit null,
	[isCondiment] bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_so_menu_category] PRIMARY KEY CLUSTERED 
(
	[menu_category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE so_menu
ADD menu_group_id bigint null,
menu_category_id bigint null,
priorityValue int null


ALTER TABLE so_menu  WITH CHECK ADD  CONSTRAINT [fk_menu_group_so_menu_group] FOREIGN KEY([menu_group_id])
REFERENCES so_menu_group ([menu_group_id])
GO

ALTER TABLE so_menu  WITH CHECK ADD  CONSTRAINT [fk_menu_category_so_menu_category] FOREIGN KEY([menu_category_id])
REFERENCES so_menu_category ([menu_category_id])
GO