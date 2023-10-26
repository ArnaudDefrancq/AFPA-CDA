DROP DATABASE IF EXISTS ZeroFaute;
CREATE DATABASE ZeroFaute DEFAULT CHARACTER SET utf8;
USE ZeroFaute;

-- CREATE TABLE

-- Table modele
DROP TABLE If EXISTS modele;
CREATE TABLE modele(
   Id_modele INT AUTO_INCREMENT PRIMARY KEY,
   codeProduit VARCHAR(50) ,
   nom VARCHAR(50) ,
   dateMiseMarche DATE
)ENGINE=InnoDB;


-- Table faute
DROP TABLE If EXISTS faute;
CREATE TABLE faute(
   Id_faute INT AUTO_INCREMENT PRIMARY KEY,
   titre VARCHAR(50) ,
   commentaire VARCHAR(50) ,
   codeFaute VARCHAR(50) 
)ENGINE=InnoDB;

-- Table categorie
DROP TABLE If EXISTS categorie;
CREATE TABLE categorie(
   Id_categorie INT AUTO_INCREMENT PRIMARY KEY,
   nom VARCHAR(50) ,
   description VARCHAR(50) ,
   Id_categorie_1 INT NOT NULL
)ENGINE=InnoDB;

-- Table produit
DROP TABLE If EXISTS produit;
CREATE TABLE produit(
   Id_produit INT AUTO_INCREMENT PRIMARY KEY,
   numSerie INT,
   numProd INT,
   dateProd DATE,
   Id_modele INT NOT NULL
)ENGINE=InnoDB;

-- Table asso posseder
DROP TABLE If EXISTS posseder;
CREATE TABLE posseder(
   Id_posseder INT AUTO_INCREMENT PRIMARY KEY,
   Id_produit INT NOT NULL,
   Id_faute INT NOT NULL,
   dateDetection DATE,
   dateReparation DATE
)ENGINE=InnoDB;

-- Table classifier
DROP TABLE If EXISTS classifier;
CREATE TABLE classifier(
   Id_classifier INT AUTO_INCREMENT PRIMARY KEY,
   Id_faute INT NOT NULL,
   Id_categorie INT NOT NULL
)ENGINE=InnoDB;


-- Ajout des contraintes

ALTER TABLE produit ADD CONSTRAINT Id_modele FOREIGN KEY(Id_modele) REFERENCES modele(Id_modele);

ALTER TABLE posseder
    ADD CONSTRAINT Id_produit FOREIGN KEY(Id_produit) REFERENCES produit(Id_produit),
    ADD CONSTRAINT Id_faute FOREIGN KEY(Id_faute) REFERENCES faute(Id_faute);

ALTER TABLE classifier
    ADD CONSTRAINT Id_faute FOREIGN KEY(Id_faute) REFERENCES faute(Id_faute),
    ADD CONSTRAINT Id_categorie FOREIGN KEY(Id_categorie) REFERENCES categorie(Id_categorie);

ALTER TABLE categorie ADD CONSTRAINT Id_categorie_1 FOREIGN KEY(Id_categorie) REFERENCES categorie(Id_categorie);