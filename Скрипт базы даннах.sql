CREATE DATABASE IT_SolutionDataBase;

USE IT_SolutionDataBase;

CREATE TABLE Neispravnosti(
	ID_Neispravnosti INT PRIMARY KEY,
	Type_neispravnosti VARCHAR(100) NOT NULL,
	Problem VARCHAR(100) NOT NULL
);

INSERT INTO Neispravnosti(ID_Neispravnosti,Type_neispravnosti, Problem) VALUES
	(1, '��������','�������'),
	(2, '��������','�������'),
	(3, '�������','�������'),
	(4, '�������','�������');


CREATE TABLE Oborudovanie(
	ID_Oborudovanie INT PRIMARY KEY,
	Name_Oborudovanie VARCHAR(100) NOT NULL,
	NeispravnostiID INT NOT NULL,
	FOREIGN KEY (NeispravnostiID) REFERENCES Neispravnosti(ID_Neispravnosti)
);

INSERT INTO Oborudovanie(ID_Oborudovanie,Name_Oborudovanie, NeispravnostiID) VALUES
	(1, '����', 1),
	(2, '����', 2),
	(3, '�����', 3),
	(4, '�����', 4);


CREATE TABLE Client(
	ID_Client INT PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	MidlleName VARCHAR(100)  NULL,
	Login VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL
);

INSERT INTO Client(ID_Client,FirstName, LastName,Login, Password) VALUES
	(1, '������', '����', 'Oleg45', '123'),
	(2, '������', '����', 'Vikt45', '563'),
	(3, '��������', '�����', 'Denis12', '123'),
	(4, '�����', '����', 'Egor18', '123');


CREATE TABLE Status(
	ID_Status INT PRIMARY KEY,
	Name_Status VARCHAR(100) NOT NULL
);

INSERT INTO Status(ID_Status,Name_Status) VALUES
	(1, '� ��������'),
	(2, '� ������'),
	(3, '���������');

DROP TABLE Orders

CREATE TABLE Orders(
	ID_Order INT PRIMARY KEY,
	Name_Order VARCHAR(100) NOT NULL,
	Date_of_issue DATE NOT NULL,
	OborudovanieID INT NOT NULL,
	ClientID INT NOT NULL,
	StatusID INT NOT NULL,
	FOREIGN KEY (OborudovanieID) REFERENCES Oborudovanie(ID_Oborudovanie),
	FOREIGN KEY (ClientID) REFERENCES Client(ID_Client),
	FOREIGN KEY (StatusID) REFERENCES Status(ID_Status)
);

INSERT INTO Orders(ID_Order,Name_Order, Date_of_issue, OborudovanieID, ClientID, StatusID) VALUES
	(1, '67233','2023-03-20', 1, 1, 1),
	(2, '23233','2023-03-20', 2, 2, 2),
	(3, '23909','2023-03-20', 3, 3, 3),
	(4, '23909','2023-03-20', 4, 4, 3);

