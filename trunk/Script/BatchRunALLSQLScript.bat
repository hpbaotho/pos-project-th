@ECHO OFF
SET Server="Kaew-NB"
SET Database="POS"
SET User="sa"
SET Password="1234"

SET Scripts[1]=0.Tables.sql
SET Scripts[2]=5. AddColumn sc_screen_config.sql
SET Scripts[3]=6. Invent Table.sql
SET Scripts[4]=7. ALTER TABLE Inventory V.1.sql
SET Scripts[5]=8.SO_menu.sql
SET Scripts[6]=9. MigrateData Menu.sql
SET Scripts[7]=10.Order.sql
SET Scripts[8]=11. MiggrateMenu2.sql
SET Scripts[9]=11.Alter Menu.sql
SET Scripts[10]=12 Alter so_menu_dining_type.sql
SET Scripts[11]=13 Alter so_menu_dining_type.sql
SET Scripts[12]=14. New MigrateData Menu.sql
SET Scripts[13]=15. Add new column so_sale_order_detail.sql
SET Scripts[14]=16. Invent Table.sql
SET Scripts[15]=17. Invent Table.sql
SET Scripts[16]=18. Migrate Data Inventory.sql
SET Scripts[17]=19. Invent Table.sql
SET Scripts[18]=20. Invent Table.sql
SET Scripts[19]=21.activity.sql
SET Scripts[20]=22.Employee_role Permission.sql
SET Scripts[21]=23. New Table sc_screen_image.sql
SET Scripts[22]=24. Migrate Table.sql
SET Scripts[23]=25. Invent Table.sql
SET Scripts[24]=26. Migrate Data IN.sql
SET Scripts[25]=27. Add is_payment_process.sql
SET Scripts[26]=28 Add so_sales_order_detail.sql
SET Scripts[27]=29 Alter Table in_bill_of_material_detail.sql
SET Scripts[28]=30. Migrate Portfolio.sql
SET Scripts[29]=31. Alter table IN.sql
SET Scripts[30]=32. Migrate Data IN_Period and Period_Group.sql

SET "count=0"
FOR /F "tokens=2 delims==" %%s in ('set Scripts[') do (
	SET /a "count+=1" 
)

FOR /L %%a in (1,1,%count%) do (
	call echo =============== %%Scripts[%%a]%%
	call SQLCMD -S %Server% -d %Database% -U %User% -P %Password% -i "%CD%\%%Scripts[%%a]%%" -u -r1 -b 
)
echo Complete
PAUSE