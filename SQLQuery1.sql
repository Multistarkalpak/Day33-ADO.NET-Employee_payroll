create database Employee_Payroll

create table Employeetable(
EmployeeID int Primary Key identity(1,1),
Name varchar(200),
Department varchar(300),
Address varchar(200),
Phone bigint,
BasicPay float,
Gender char(1),
StartDate varchar(200),
TaxablePay float,
NetPay float,
IncomTax Float,
Deductions float);


select * from Employeetable;

insert into Employeetable values('kalpak','HR','1st Cross',9624646441,2000000,'M','2016-04-01',50000,800000,9000,7000),
('Shivraj','Development','2nd Cross',7958255625,3000000,'M','2017-05-01',60000,900000,9500,7900),
('Vishwas','CEO','3rd Cross',7956626426,4000000,'M','2008-04-01',800000,900000,91000,7100);

Alter table EmployeeTable Add EmpId int IDENTITY(1,1) primary key;

Alter table EmployeeTable
Drop COLUMN EmpId;

Drop table EmployeeTable;
