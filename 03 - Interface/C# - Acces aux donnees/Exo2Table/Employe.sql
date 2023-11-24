CREATE DATABASE IF NOT EXISTS Entreprise;
USE Entreprise;

CREATE TABLE VoitureFonction(
   IdVoitureFonction INT AUTO_INCREMENT,
   Marque VARCHAR(50)  NOT NULL,
   Kilometre INT NOT NULL,
   Model VARCHAR(50)  NOT NULL,
   PRIMARY KEY(Id_VoitureFonction)
);

CREATE TABLE Employe(
   Id_Employe INT AUTO_INCREMENT,
   Nom VARCHAR(50)  NOT NULL,
   Prenom VARCHAR(50)  NOT NULL,
   Age INT NOT NULL,
   IdVoitureFonction INT,
   PRIMARY KEY(Id_Employe),
--    FOREIGN KEY(Id_VoitureFonction) REFERENCES VoitureFonction(Id_VoitureFonction)
);

ALTER TABLE Employe ADD CONSTRAINT IdVoitureFonction FOREIGN KEY(IdVoitureFonction) REFERENCES VoitureFonction(IdVoitureFonction);