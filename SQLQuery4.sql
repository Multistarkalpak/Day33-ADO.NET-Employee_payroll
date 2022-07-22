create procedure spDeleteEmployee
@Name varchar(120)
as
Delete Employeetable where Name=@Name;

exec spDeleteEmployee 'Kalpak';
