-- Query #1 --
SELECT dbo.Employees.employee_name AS Имя, dbo.Positions.position_name AS Должность
FROM dbo.Employees INNER JOIN dbo.Positions ON dbo.Employees.position_ID = dbo.Positions.ID_position
WHERE dbo.Positions.position_name = 'Пилот';

-- Query #2 --
SELECT dbo.Planes.plane_name AS Самолет, dbo.Plane_types.plane_type_name AS Тип, dbo.Employees.employee_name AS Механик
FROM dbo.Planes INNER JOIN
     dbo.Plane_types ON dbo.Planes.plane_type_ID = dbo.Plane_types.ID_type INNER JOIN
     dbo.Employees ON dbo.Planes.employee_ID = dbo.Employees.ID_employee
WHERE dbo.Plane_types.plane_type_name = 'Пассажирский';

-- Query #3 --
SELECT dbo.Tickets.passenger_name AS [Имя пассажира], dbo.Flights.place_from AS Откуда, dbo.Flights.place_to AS Куда
FROM dbo.Tickets INNER JOIN dbo.Flights ON dbo.Tickets.flight_ID = dbo.Flights.ID_flight
WHERE dbo.Flights.place_from = 'Москва';