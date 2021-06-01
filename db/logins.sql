drop table Logins;

create table Logins (
	_login VARCHAR(100),
	_password VARCHAR(50),
	position VARCHAR(50)
);

insert into Logins (_login, _password, position)
select employee_name, passport_data, position_name
from Employees inner join Positions on position_ID = ID_position;

--select * from Logins;
--select * from Positions;