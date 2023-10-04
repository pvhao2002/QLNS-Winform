CREATE DATABASE QLNS;
GO
USE QLNS;
GO
CREATE TABLE account
(
	username NVARCHAR(255) PRIMARY KEY,
	password NVARCHAR(255) NOT NULL
);
INSERT INTO account(username, password) VALUES (N'admin', '123456');
INSERT INTO account(username, password) VALUES (N'admin5', '123456');
INSERT INTO account(username, password) VALUES (N'admin2', '123456');
INSERT INTO account(username, password) VALUES (N'admin3', '123456');
INSERT INTO account(username, password) VALUES (N'admin4', '123456');
GO
CREATE TABLE department
(
	id INT PRIMARY KEY IDENTITY,
	department_name NVARCHAR(255) NOT NULL,
	manager_id INT,
	description NVARCHAR(200),
	is_deleted BIT DEFAULT 0
);

GO
CREATE TABLE employee
(
	id INT PRIMARY KEY IDENTITY,
	full_name NVARCHAR(255),
	address NVARCHAR(255),
	birthday DATETIME DEFAULT '01-01-1990',
	gender NVARCHAR(10),
	phone NVARCHAR(12),
	department_id INT,
	position NVARCHAR(255),
	is_deleted BIT DEFAULT 0,
	CONSTRAINT fk_employee_department FOREIGN KEY(department_id) REFERENCES department(id)
);
GO
CREATE TABLE contract
(
	id INT PRIMARY KEY IDENTITY,
	employee_id INT,
	contract_type NVARCHAR(255),
	start_date DATETIME NOT NULL,
	end_date DATETIME,
	salary DECIMAL(10,2),
	other_item NVARCHAR(255),
	CONSTRAINT fk_contract_employee FOREIGN KEY(employee_id) REFERENCES employee(id)
);
GO
CREATE TABLE rewards_discipline
(
	id INT PRIMARY KEY IDENTITY,
	employee_id INT,
	type NVARCHAR(255) NOT NULL,
	create_at DATE NOT NULL,
	description NVARCHAR(255),
	CONSTRAINT fk_rewards_discipline_employee FOREIGN KEY(employee_id) REFERENCES employee(id)
);
GO
ALTER TABLE department
ADD FOREIGN KEY (manager_id) REFERENCES employee(id);
