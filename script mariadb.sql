CREATE DATABASE `department_employees_db`;

ALTER TABLE departments_employees
	DROP FOREIGN KEY rel_dep;
ALTER TABLE departments_employees
	DROP FOREIGN KEY rel_employee;
ALTER TABLE departments
	DROP FOREIGN KEY ent_department;
DROP TABLE IF EXISTS departments;
DROP TABLE IF EXISTS departments_employees;
DROP TABLE IF EXISTS employees;
DROP TABLE IF EXISTS enterprises;
CREATE TABLE departments  ( 
	id            	int(15) AUTO_INCREMENT NOT NULL,
	id_enterprises	int(15) NOT NULL,
	name          	varchar(250) NOT NULL,
	phone         	varchar(25) NOT NULL,
	description   	varchar(250) NOT NULL,
	status        	tinyint(15) NOT NULL DEFAULT true,
	created_by    	varchar(50) NOT NULL,
	created_date  	datetime NOT NULL,
	modified_by   	varchar(50) NULL,
	modified_date 	datetime NULL,
	PRIMARY KEY(id)
);
CREATE TABLE departments_employees  ( 
	id           	int(15) AUTO_INCREMENT NOT NULL,
	id_department	int(15) NOT NULL,
	id_employee  	int(15) NOT NULL,
	status       	tinyint(15) NOT NULL DEFAULT true,
	created_by   	varchar(50) NOT NULL,
	created_date 	datetime NOT NULL,
	modified_by  	varchar(50) NULL,
	modified_date	datetime NULL,
	PRIMARY KEY(id)
);
CREATE TABLE employees  ( 
	id           	int(15) AUTO_INCREMENT NOT NULL,
	name         	varchar(250) NOT NULL,
	surname      	varchar(250) NOT NULL,
	age          	int(15) NOT NULL,
	email        	varchar(100) NOT NULL,
	position     	varchar(100) NOT NULL,
	status       	tinyint(15) NOT NULL DEFAULT true,
	created_by   	varchar(50) NOT NULL,
	created_date 	datetime NOT NULL,
	modified_by  	varchar(50) NULL,
	modified_date	datetime NULL,
	PRIMARY KEY(id)
);
CREATE TABLE enterprises  ( 
	id           	int(15) AUTO_INCREMENT NOT NULL,
	name         	varchar(250) NOT NULL,
	phone        	varchar(25) NOT NULL,
	address      	varchar(250) NOT NULL,
	status       	tinyint(15) NOT NULL DEFAULT true,
	created_by   	varchar(50) NOT NULL,
	created_date 	datetime NOT NULL,
	modified_by  	varchar(50) NULL,
	modified_date	datetime NULL,
	PRIMARY KEY(id)
);
ALTER TABLE departments_employees
	ADD CONSTRAINT rel_dep
	FOREIGN KEY(id_department)
	REFERENCES departments(id)
	ON DELETE CASCADE 
	ON UPDATE CASCADE ;
ALTER TABLE departments_employees
	ADD CONSTRAINT rel_employee
	FOREIGN KEY(id_employee)
	REFERENCES employees(id)
	ON DELETE CASCADE 
	ON UPDATE CASCADE ;
ALTER TABLE departments
	ADD CONSTRAINT ent_department
	FOREIGN KEY(id_enterprises)
	REFERENCES enterprises(id);
