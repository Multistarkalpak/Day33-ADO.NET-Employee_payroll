create procedure spInsertIntoTwoTables
(
@Name varchar(120),
@Gender varchar(120),
@Address varchar(120),
@EmployeeID int OUTPUT)
as
insert into  Employeetable (Name,Gender,Address)values(@Name,@Gender,@Address);
SET @EmployeeID =SCOPE_IDENTITY();
