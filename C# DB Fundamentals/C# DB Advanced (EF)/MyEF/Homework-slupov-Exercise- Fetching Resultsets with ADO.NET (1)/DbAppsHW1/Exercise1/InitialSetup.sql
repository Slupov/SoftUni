USE MinionsDB

CREATE TABLE Towns
(
	Id int PRIMARY KEY NOT NULL IDENTITY,
	Name varchar(30) NOT NULL,
	CountryName varchar(30) NOT NULL
)

CREATE TABLE Villains
(
	Id int PRIMARY KEY NOT NULL IDENTITY,
	Name varchar(50) NOT NULL,
	EvilnessFactor varchar(10) NOT NULL
)
CREATE TABLE Minions
(
	Id int PRIMARY KEY NOT NULL IDENTITY,
	Name varchar(50) NOT NULL,
	Age int NOT NULL,
	TownId int NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE MinionsVillains
(
	VillainId int FOREIGN KEY REFERENCES Villains(Id),
	MinionId int FOREIGN KEY REFERENCES Minions(Id),

	CONSTRAINT PK_VillainId_MinionId PRIMARY KEY (VillainId,MinionId)
)

INSERT INTO Towns (Name,CountryName) VALUES 
('Sofia','Bulgaria'), ('Berlin','Germany'), ('London','UK'), ('New York','USA'), ('Madrid','Spain')

INSERT INTO Villains VALUES
('Gru','super evil'), ('Tinko','bad'), ('Viktor','evil'), ('Gosho','good'), ('Donald Trump','super evil')

INSERT INTO Minions (Name,Age,TownId) VALUES
('Bob',15,3), ('Pencho',25,1), ('Mincho',21,5), ('Juan',28,4), ('Felix',34,2)

INSERT INTO MinionsVillains (MinionId,VillainId) VALUES
(1,2), (2,3), (3,4), (4,5), (5,1)