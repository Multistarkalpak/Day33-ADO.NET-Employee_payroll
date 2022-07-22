create procedure spUpdateEmployee
@BasicPay float,
@Name varchar(120)
as
Update Employeetable set BasicPay= @BasicPay where Name=@Name;

exec spUpdateEmployee 30000,'kalpak'
