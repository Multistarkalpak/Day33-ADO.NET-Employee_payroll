ALTER procedure spAddEmployee

@Name Nvarchar,
@Department nvarchar,
@Address nvarchar,
@Phone int,
@BasicPay float,
@Gender char,
@StartDate varchar,
@TaxablePay float,
@NetPay float,
@IncomeTax float,
@Deductions float
as

insert into Employeetable(Name,Department,Address,Phone,
BasicPay,Gender ,StartDate,TaxablePay,NetPay,IncomTax,Deductions) values(@Name,@Department,@Address,@Phone,
@BasicPay,@Gender ,@StartDate,@TaxablePay,@NetPay,@IncomeTax,@Deductions);


exec spAddEmployee 'Gurpreet','hr','2nd cross',5347676,78765,'M','2000-09-08',6547,756,746,923;