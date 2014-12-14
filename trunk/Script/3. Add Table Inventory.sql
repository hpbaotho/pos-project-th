
create table in_material
(
	material_id bigint identity(1,1) not null,
	material_code bigint not null,
	material_name nvarchar(200) not null,
	material_description nvarchar(100) null,
	uom_id_receive bigint not null,
	uom_id_count bigint not null,
	uom_id_use bigint not null,
	active bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_material] primary key clustered 
	(
		material_id asc
	)
)

create table in_bill_of_material_group
(
	bill_of_material_group_id bigint identity(1,1) not null,
	bill_of_material_group_code bigint not null,
	bill_of_material_group_name nvarchar(200) not null,
	bill_of_material_group_description nvarchar(100) null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_bill_of_material_group] primary key clustered 
	(
		bill_of_material_group_id asc
	)
)

create table in_bill_of_material_head
(
	bill_of_material_head_id bigint identity(1,1) not null,
	bill_of_material_group_id bigint not null,
	bill_of_material_head_code bigint not null,
	bill_of_material_head_name nvarchar(200) not null,
	bill_of_material_head_description nvarchar(100) null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_bill_of_material_head] primary key clustered 
	(
		bill_of_material_head_id asc
	)
)

create table in_bill_of_material_detail
(
	bill_of_material_detail_id bigint identity(1,1) not null,
	bill_of_material_head_id bigint not null,
	material_id bigint null,
	bill_of_material_head_id_sub bigint not null,
	amount numeric(11,4) not null,
	lost_factor tinyint not null, 
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_bill_of_material_detail] primary key clustered 
	(
		bill_of_material_detail_id asc
	)
)

alter table in_material
add constraint fk_in_material_db_uom_receive 
foreign key (uom_id_receive) references db_uom (uom_id)

alter table in_material
add constraint fk_in_material_db_uom_count
foreign key (uom_id_count) references db_uom (uom_id)

alter table in_material
add constraint fk_in_material_db_uom_use
foreign key (uom_id_use) references db_uom (uom_id)
		
alter table in_bill_of_material_head
add constraint fk_in_bill_of_material_head_in_bill_of_material_group
foreign key (bill_of_material_group_id) references in_bill_of_material_group (bill_of_material_group_id)
	
alter table in_bill_of_material_detail
add constraint fk_in_bill_of_material_detail_in_bill_of_material_head
foreign key (bill_of_material_head_id) references in_bill_of_material_head (bill_of_material_head_id)

alter table in_bill_of_material_detail
add constraint fk_in_bill_of_material_detail_in_material
foreign key (material_id) references in_material (material_id)
	
alter table in_bill_of_material_detail
add constraint fk_in_bill_of_material_detail_in_bill_of_material_head_sub
foreign key (bill_of_material_head_id_sub) references in_bill_of_material_head (bill_of_material_head_id)

/* transaction */

create table in_receive_material_head
(
	receive_material_head_id bigint identity(1,1) not null,
	supplier_id bigint null,
	warehouse_id_source bigint null,
	other_source nvarchar(1000) null,
	reference_no nvarchar(100) not null,
	transaction_no nvarchar(10) not null,
	transaction_date datetime not null,
	transaction_status bigint not null,
	reason_id bigint not null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_receive_material_head] primary key clustered 
	(
		receive_material_head_id asc
	)
)

create table in_receive_material_detail
(
	receive_material_detail_id bigint identity(1,1) not null,
	receive_material_head_id bigint not null,
	material_id bigint not null,
	warehouse_id_destination bigint not null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_receive_material_detail] primary key clustered 
	(
		receive_material_detail_id asc
	)
)

create table in_send_material_head
(
	send_material_head_id bigint identity(1,1) not null,
	transaction_no nvarchar(10) not null,
	transaction_date datetime not null,
	transaction_status bigint not null,
	reason_id bigint not null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_send_material_head] primary key clustered 
	(
		send_material_head_id asc
	)
)

create table in_send_material_detail
(
	send_material_detail_id bigint identity(1,1) not null,
	send_material_head_id bigint not null,
	warehouse_id_source bigint not null,
	material_id bigint not null,
	warehouse_id_destination bigint not null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	constraint [pk_in_send_material_detail] primary key clustered 
	(
		send_material_detail_id asc
	)
)

alter table in_receive_material_head
add constraint fk_in_receive_material_head_db_supplier
foreign key (supplier_id) references db_supplier (supplier_id)

alter table in_receive_material_head
add constraint fk_in_receive_material_head_db_warehouse
foreign key (warehouse_id_source) references db_warehouse (warehouse_id)

alter table in_receive_material_head
add constraint fk_in_receive_material_head_db_reason
foreign key (reason_id) references db_reason (reason_id)

alter table in_receive_material_detail
add constraint fk_in_receive_material_detail_in_receive_material_head
foreign key (receive_material_head_id) references in_receive_material_head (receive_material_head_id)

alter table in_receive_material_detail
add constraint fk_in_receive_material_detail_in_material
foreign key (material_id) references in_material (material_id)

alter table in_receive_material_detail
add constraint fk_in_receive_material_detail_db_warehouse
foreign key (warehouse_id_destination) references db_warehouse (warehouse_id)

alter table in_send_material_head
add constraint fk_in_send_material_head_db_reason
foreign key (reason_id) references db_reason (reason_id)

alter table in_send_material_detail
add constraint fk_in_send_material_detail_in_send_material_head
foreign key (send_material_head_id) references in_send_material_head (send_material_head_id)

alter table in_send_material_detail
add constraint fk_in_send_material_detail_db_warehouse_source
foreign key (warehouse_id_source) references db_warehouse (warehouse_id)

alter table in_send_material_detail
add constraint fk_in_send_material_detail_db_warehouse_destination
foreign key (warehouse_id_destination) references db_warehouse (warehouse_id)

alter table in_send_material_detail
add constraint fk_in_send_material_detail_in_in_material
foreign key (material_id) references in_material (material_id)