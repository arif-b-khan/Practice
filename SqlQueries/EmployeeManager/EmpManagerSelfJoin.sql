create table Employee(
empid int identity(1,1) primary key,
name nvarchar(30) not null,
mgrid int
)
select @@IDENTITY
select IDENT_CURRENT('employee')
select * from Employee

insert into Employee(name, mgrid) values('Arif', null)
insert into Employee(name, mgrid) values('Afreen', IDENT_CURRENT('Employee') - 1)
insert into Employee(name, mgrid) values('Tarik', IDENT_CURRENT('Employee') - 1)
insert into Employee(name, mgrid) values('Asif', IDENT_CURRENT('Employee') - 1)
insert into Employee(name, mgrid) values('Rahat', 1)

select e1.empid, e1.name 'EmployeeName', e2.name as 'ManagerName'
from Employee as e1 left outer join Employee as e2
on e1.mgrid = e2.empid

