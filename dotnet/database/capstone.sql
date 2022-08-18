USE master
GO

-- Drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

-- Create Tables

CREATE TABLE potholes (
	pothole_id int IDENTITY(1000,1) NOT NULL,
	severity int check (severity between 0 and 3) DEFAULT 0,
	latitude varchar(25),
	longitude varchar(25),
	address varchar(150),
	city varchar(75),
	CONSTRAINT PK_potholes PRIMARY KEY (pothole_id)
)

CREATE TABLE reports (
	report_id int IDENTITY(2000,1) NOT NULL,
	pothole_id int NOT NULL,
	report_date date,
	is_Reviewed BIT,
	report_notes varchar(300),
	CONSTRAINT PK_reports PRIMARY KEY (report_id),
	CONSTRAINT [FK_reports_potholes] FOREIGN KEY (pothole_id) REFERENCES [potholes] (pothole_id),
)

CREATE TABLE inspections (
	inspection_id int IDENTITY(3000,1) NOT NULL,
	pothole_id int NOT NULL,
	inspection_date date,
	is_Inspected BIT,
	inspection_notes varchar(300),
	CONSTRAINT PK_inspections PRIMARY KEY (inspection_id),
	CONSTRAINT [FK_inspections_potholes] FOREIGN KEY (pothole_id) REFERENCES [potholes] (pothole_id),
)

CREATE TABLE repairs (
	repair_id int IDENTITY(4000,1) NOT NULL,
	pothole_id int NOT NULL,
	repair_date date,
	is_Repaired BIT,
	repair_notes varchar(300),
	CONSTRAINT PK_repairs PRIMARY KEY (repair_id),
	CONSTRAINT [FK_repairs_potholes] FOREIGN KEY (pothole_id) REFERENCES [potholes] (pothole_id),
)

CREATE TABLE users (
	user_id int IDENTITY(5000,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

-- Populate default data for testing: user and admin with password of 'password'
-- These values should not be kept when going to Production
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('jimothy','yZTP3HjGnpELdELpsS2YsM1e0z0=', 'R+IFi2NICls=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('testuser','lGCwMrq2x7PPlCdI4FHSULskiJ4=','/93YdmNM1lU=','user');

INSERT INTO potholes (latitude, longitude, address, city) VALUES ('39.998159','-83.042176','1256-1280 Kinnear Rd', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes) VALUES (1000, '8/9/2022', 0, 'No notes at this time');

INSERT INTO potholes (latitude, longitude, address, city) VALUES ('39.975428','-83.003223','High & Russell', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes) VALUES (1001, '8/9/2022', 0, 'This one is a doozy, folks');

INSERT INTO potholes (latitude, longitude, address, city) VALUES ('40.146961','-82.911106','7165-7151 Hilmar Dr', 'Westerville');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes) VALUES (1002, '8/11/2022', 0, 'woohoo');


select * from potholes
select * from reports
select * from inspections
select * from repairs
select * from users


GO
