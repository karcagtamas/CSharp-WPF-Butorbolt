CREATE DATABASE `13a_butorbolt`
  CHARACTER SET utf8
  COLLATE utf8_hungarian_ci;

USE `13a_butorbolt`;

CREATE TABLE Alapanyag(
  id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  megnevezes varchar(50) NOT NULL UNIQUE
);

INSERT INTO Alapanyag (megnevezes)
  VALUES 
  ('Fa'),
  ('Bútorlap'),
  ('Fém'),
  ('Műanyag');

CREATE TABLE Butor(
  id int(11) AUTO_INCREMENT NOT NULL PRIMARY KEY,
  megnevezes varchar(100) NOT NULL,
  alapanyag int(11) NOT NULL,
  ar numeric(12, 2),
  szallitas datetime,
  szin varchar(20),
  CONSTRAINT fk_butor_alapanyag_alapanyag FOREIGN KEY (alapanyag)
  REFERENCES Alapanyag(id),
  UNIQUE (alapanyag, megnevezes)  
);

SELECT Butor.id, Butor.megnevezes, Butor.alapanyag, Alapanyag.megnevezes AS alapanyagnev, Butor.ar, Butor.szallitas, Butor.szin FROM Butor
  JOIN Alapanyag ON Butor.alapanyag = Alapanyag.id
  WHERE 1=1;

INSERT INTO Butor(id, megnevezes, alapanyag, ar, szallitas, szin)
  VALUES (0, '', 0, 0, NOW(), '');

UPDATE Butor 
  SET 
  megnevezes = ?, 
  alapanyag = ?, 
  ar = ?, 
  szallitas = ?, 
  szin = ?
  WHERE id = ?;

DELETE FROM Butor
  WHERE id = ?;