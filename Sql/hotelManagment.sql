IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'room')
	CREATE TABLE dbo.room (
		room_id INT IDENTITY(1,1) NOT NULL,

		room_number INT NOT NULL,
		room_type NVARCHAR(50) NOT NULL,
		price_per_night MONEY NOT NULL,
		availability BIT NOT NULL,

		CONSTRAINT PK_room_room_id PRIMARY KEY (room_id)
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'customer')
	CREATE TABLE dbo.customer (
		customer_id INT IDENTITY(1,1) NOT NULL,

		first_name NVARCHAR(50) NOT NULL,
		last_name NVARCHAR(50) NOT NULL,
		email NVARCHAR(50) NOT NULL,
		phone_number NVARCHAR(20) NOT NULL,

		CONSTRAINT PK_customer_customer_id PRIMARY KEY (customer_id)
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'booking')
	CREATE TABLE dbo.booking (
		booking_id INT IDENTITY(1,1) NOT NULL,

		customer_id INT NOT NULL,
		room_id INT NOT NULL,
		check_in_date DATE NOT NULL,
		check_out_date DATE NOT NULL,

		CONSTRAINT PK_booking_booking_id PRIMARY KEY (booking_id),

		CONSTRAINT FK_booking_customer_id FOREIGN KEY (customer_id) REFERENCES HotelManagement.dbo.customer (customer_id),
		CONSTRAINT FK_booking_room_id FOREIGN KEY (room_id) REFERENCES HotelManagement.dbo.room (room_id)
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'facility')
	CREATE TABLE dbo.facility (
		facility_id INT IDENTITY(1,1) NOT NULL,

		facility_name NVARCHAR(50) NOT NULL,

		CONSTRAINT PK_facility_facility_id PRIMARY KEY (facility_id)
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'room_to_facility')
	CREATE TABLE dbo.room_to_facility (
		facility_id INT NOT NULL,
		room_id INT NOT NULL,

		CONSTRAINT FK_room_to_facility_facility_id FOREIGN KEY (facility_id) REFERENCES HotelManagement.dbo.facility (facility_id),
		CONSTRAINT FK_room_to_facility_room_id FOREIGN KEY (room_id) REFERENCES HotelManagement.dbo.room (room_id)
	);

INSERT INTO dbo.room (room_number, room_type, price_per_night, availability) 
VALUES 
    (1, 'single', 1000, 1),
	(2, 'double', 2000, 0),
	(3, 'triple', 3000, 0),
	(4, 'single', 1000, 0),
	(5, 'double', 2000, 1),
	(6, 'single', 1000, 1);

INSERT INTO dbo.customer (first_name, last_name, email, phone_number) 
VALUES 
    ('Margaret', 'Hale', 'margaret_hale@gmail.com', '+79575854598'),
	('John', 'Thornton', 'john1845@gmail.com', '+79954849734'),
	('Nicholas', 'Higgins', 'higginsNic@gmail.com', '+79462686843'),
	('Neal', 'Stephenson', 'nealSteph@gmail.com', '+79072453452'),
	('Rafael', 'Sabatini', 'rafael_sabatini@gmail.com', '+79389279473'),
	('Andy', 'Weir', 'martian@gmail.com', '+79385927569');

INSERT INTO dbo.booking (customer_id, room_id, check_in_date, check_out_date) 
VALUES 
    (1, 2, '2024-08-01', '2024-08-10'),
    (6, 3, '2024-09-12', '2024-09-21'),
    (4, 4, '2024-08-03', '2024-08-13'),
    (1, 6, '2024-10-23', '2024-10-30'),
    (2, 5, '2024-09-02', '2024-09-22'),
    (3, 1, '2024-10-05', '2024-10-10'),
    (5, 4, '2024-08-21', '2024-08-24');

INSERT INTO dbo.facility(facility_name) 
VALUES 
    ('air-conditioning'),
	('cable TV'),
	('hairdryer'),
	('in-room internet'),
	('refrigerator'),
	('bathrobes'),
	('slippers'),
	('minibar');

INSERT INTO dbo.room_to_facility(facility_id, room_id) 
VALUES 
    (1, 1),
	(1, 3),
	(1, 5),
	(2, 1),
	(2, 2),
	(2, 4),
	(3, 2),
	(3, 3),
	(4, 1),
	(4, 6),
	(5, 4),
	(5, 5),
	(6, 3),
	(6, 4),
	(7, 1),
	(7, 6),
	(8, 3);

--Ќайдите все доступные номера дл€ бронировани€ сегодн€.
SELECT * FROM dbo.room 
WHERE availability = 1;

--Ќайдите всех клиентов, чьи фамилии начинаютс€ с буквы "S".
SELECT * FROM dbo.customer
WHERE last_name LIKE 'S%';

--Ќайдите все бронировани€ дл€ определенного клиента (по имени или электронному адресу).
SELECT * FROM booking
WHERE customer_id IN (
	SELECT customer_id FROM dbo.customer
	WHERE first_name = 'Margaret' AND last_name = 'Hale');

--Ќайдите все бронировани€ дл€ определенного номера.
SELECT * FROM booking
WHERE room_id IN (
	SELECT room_id FROM dbo.room
	WHERE room_number = 4);

--Ќайдите все номера, которые не забронированы на определенную дату.
SELECT * FROM room
WHERE room_id NOT IN (
	SELECT room_id FROM dbo.booking
	WHERE check_in_date < '2024-08-08' AND check_out_date > '2024-08-08');
