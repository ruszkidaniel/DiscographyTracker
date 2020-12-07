CREATE DATABASE music;
USE music;

CREATE TABLE Albums (
	id varchar(4) primary key,
	artist varchar(255) not null,
	title varchar(255) not null,
	release date
)

CREATE TABLE Tracks (
	id int primary key identity(1,1),
	title varchar(255) not null,
	"length" time,
	"url" varchar(30),
	album varchar(4) foreign key references Albums(id),
)