use airport;

insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Полякова Анастасия Глебовна', 30, 'жен','Калининградская область, город Подольск, спуск Бухарестская, 69', '756498345', 2);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Исаева Александра Андреевна', 28, 'жен', 'Тульская область, город Талдом, проезд Сталина, 84', '432785630', 2);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Котова Алиса Александровна', 38, 'жен', 'Омская область, город Раменское, пер. Чехова, 39', '627732599', 1);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Бобров Илья Иванович', 45, 'муж', 'Тульская область, город Пушкино, наб. Ладыгина, 21', '436135078', 4);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Широков Иван Дамирович', 27, 'муж', 'Костромская область, город Можайск, пл. Домодедовская, 00', '704784530', 1);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Горячев Владимир Александрович', 30, 'муж', 'Калининградская область, город Подольск, спуск Бухарестская, 69', '756498345', 5);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Лаврова Милана Глебовна', 26, 'жен', 'Брянская область, город Ногинск, бульвар Будапештсткая, 01', '865797092', 3);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Сорокина Амира Тимофеевна', 48, 'жен', 'Новгородская область, город Одинцово, пер. Космонавтов, 27', '960629764', 1);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Комаров Павел Миронович', 31, 'муж', 'Ярославская область, город Москва, шоссе Будапештсткая, 29', '207993216', 5);
insert into Employees(employee_name, age, sex, employee_address, passport_data, position_ID) 
	values ('Громова Зоя Филипповна', 52, 'жен', 'Курганская область, город Москва, наб. Будапештсткая, 12', '170524712', 2);

insert into Positions(position_name, salary) 
	values ('Пилот', 200000);
insert into Positions(position_name, salary) 
	values ('Бортпроводник', 72000);
insert into Positions(position_name, salary) 
	values ('Координатор', 85000);
insert into Positions(position_name, salary) 
	values ('Инженер', 70000);
insert into Positions(position_name, salary) 
	values ('Аналитик', 86000);

insert into Plane_types(plane_type_name)
	values ('Пассажирский');
insert into Plane_types(plane_type_name)
	values ('Пассажирский среднего размера');
insert into Plane_types(plane_type_name)
	values ('Легкий пассажирский');
insert into Plane_types(plane_type_name)
	values ('Пассажирский с турбовинтовым двигателем');
insert into Plane_types(plane_type_name)
	values ('Грузовой');

insert into Planes(plane_type_ID, employee_ID, plane_name)
	values (1, 6, 'Boeing 747-8');
insert into Planes(plane_type_ID, employee_ID, plane_name)
	values (1, 4, 'Boeing 787-10');
insert into Planes(plane_type_ID, employee_ID, plane_name)
	values (2, 6, 'Airbus A350-1000');
insert into Planes(plane_type_ID, employee_ID, plane_name)
	values (3, 4, 'Embraer 175');
insert into Planes(plane_type_ID, employee_ID, plane_name)
	values (5, 6, 'Boeing 747-400 LCF Dreamlifter');

insert into Crews(crewmate1_ID, crewmate2_ID, crewmate3_ID)
	values (3, 1, 2); 
insert into Crews(crewmate1_ID, crewmate2_ID, crewmate3_ID)
	values (5, 10, 2); 
insert into Crews(crewmate1_ID, crewmate2_ID, crewmate3_ID)
	values (8, 1, 10); 
insert into Crews(crewmate1_ID, crewmate2_ID, crewmate3_ID)
	values (3, 10, 2); 
insert into Crews(crewmate1_ID, crewmate2_ID, crewmate3_ID)
	values (5, 1, 2); 

insert into Flights(crew_ID, plane_ID, place_from, place_to, air_time)
	values (1, 1, 'Москва', 'Иркутск', 7);
insert into Flights(crew_ID, plane_ID, place_from, place_to, air_time)
	values (2, 2, 'Санкт-Петербург', 'Екатеринбург', 4);
insert into Flights(crew_ID, plane_ID, place_from, place_to, air_time)
	values (4, 5, 'Москва', 'Петропавловск-Камчатский', 10);
insert into Flights(crew_ID, plane_ID, place_from, place_to, air_time)
	values (3, 3, 'Екатеринбург', 'Якутск', 5);
insert into Flights(crew_ID, plane_ID, place_from, place_to, air_time)
	values (5, 4, 'Новосибирск', 'Краснодар', 7);

insert into Tickets(passenger_name, passport_data, place_from, flight_ID)
	values ('Богданов Александр Александрович', '332366913', 'Москва', 3);
insert into Tickets(passenger_name, passport_data, place_from, flight_ID)
	values ('Мельников Всеволод Артёмович', '524971005', 'Екатеринбург', 4);
insert into Tickets(passenger_name, passport_data, place_from, flight_ID)
	values ('Дмитриева Александра Арсентьевна', '871204869', 'Москва', 1);
insert into Tickets(passenger_name, passport_data, place_from, flight_ID)
	values ('Никольский Иван Дмитриевич', '176200303', 'Санкт-Петербург', 2);
insert into Tickets(passenger_name, passport_data, place_from, flight_ID)
	values ('Островская Дарина Александровна', '213890706', 'Новосибирск', 5);