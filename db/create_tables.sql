use airport;

alter table Employees drop constraint FK_position;
alter table Planes drop constraint FK_plane_type, FK_employee;
alter table Crews drop constraint FK_crewmate1, FK_crewmate2, FK_crewmate3;
alter table Flights drop constraint FK_crew, FK_plane;
alter table Tickets drop constraint FK_flight;

drop table Employees;
drop table Positions;
drop table Planes;
drop table Plane_types;
drop table Crews;
drop table Flights;
drop table Tickets;

create table Employees (
	ID_employee INT PRIMARY KEY IDENTITY,
	employee_name VARCHAR(100),
	age INT,
	sex VARCHAR(10),
	employee_address VARCHAR(MAX),
	passport_data VARCHAR(50),
	position_ID INT
);

create table Positions (
	ID_position INT PRIMARY KEY IDENTITY,
	position_name VARCHAR(70),
	salary MONEY,
	responsibilities VARCHAR(40),
	requirements VARCHAR(40)
);

create table Planes (
	ID_plane INT PRIMARY KEY IDENTITY,
	plane_type_ID INT,
	employee_ID INT,
	plane_name VARCHAR(80),
	seats_capacity INT, 
	load_capacity INT,
	specifications VARCHAR(50),
	release_date DATE,
	hours_flown FLOAT,
	last_repair DATE,
);

create table Plane_types (
	ID_type INT PRIMARY KEY IDENTITY,
	plane_type_name VARCHAR(80),
	purpose VARCHAR(10),
	restrictions VARCHAR(30)
);

create table Crews (
	ID_crew INT PRIMARY KEY IDENTITY,
	hours_flown TIME,
	crewmate1_ID INT,
	crewmate2_ID INT,
	crewmate3_ID INT
);

create table Flights (
	ID_flight INT PRIMARY KEY IDENTITY,
	crew_ID INT,
	plane_ID INT,
	flight_date DATE,
	flight_time TIME,
	place_from VARCHAR(MAX),
	place_to VARCHAR(MAX),
	air_time FLOAT
);

create table Tickets (
	passenger_name VARCHAR(100),
	passport_data VARCHAR(50),
	place_from VARCHAR(40),
	flight_ID INT,
	price MONEY
);

alter table Employees
	add constraint FK_position foreign key (position_ID)
		references Positions(ID_position);

alter table Planes
	add constraint FK_plane_type foreign key (plane_type_ID)
		references Plane_types(ID_type),
	constraint FK_employee foreign key (employee_ID)
		references Employees(ID_employee);

alter table Crews
	add constraint FK_crewmate1 foreign key (crewmate1_ID)
		references Employees(ID_employee),
	constraint FK_crewmate2 foreign key (crewmate2_ID)
		references Employees(ID_employee),
	constraint FK_crewmate3 foreign key (crewmate3_ID)
		references Employees(ID_employee);

alter table Flights
	add constraint FK_crew foreign key (crew_ID)
		references Crews(ID_crew),
	constraint FK_plane foreign key (plane_ID)
		references Planes(ID_plane);

alter table Tickets
	add constraint FK_flight foreign key (flight_ID)
		references Flights(ID_flight);