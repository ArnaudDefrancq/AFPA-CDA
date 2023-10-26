CREATE TABLE Departement(
   Id_Departement INT AUTO_INCREMENT,
   nomDep VARCHAR(50) ,
   ville VARCHAR(50) ,
   PRIMARY KEY(Id_Departement)
);

CREATE TABLE Grade(
   Id_Garde INT AUTO_INCREMENT,
   salMin INT,
   salMax INT,
   PRIMARY KEY(Id_Garde)
);

CREATE TABLE Employe(
   Id_Employe INT AUTO_INCREMENT,
   nomEmp VARCHAR(50) ,
   fonction VARCHAR(50) ,
   dateEmbauche DATE,
   salaire INT,
   comm INT,
   Id_Employe_1 INT,
   Id_Departement INT NOT NULL,
   PRIMARY KEY(Id_Employe),
   FOREIGN KEY(Id_Employe_1) REFERENCES Employe(Id_Employe),
   FOREIGN KEY(Id_Departement) REFERENCES Departement(Id_Departement)
);

CREATE TABLE Histofonction(
   Id_Histofonction INT AUTO_INCREMENT,
   dateHisto DATE,
   fonction VARCHAR(50) ,
   Id_Employe INT NOT NULL,
   PRIMARY KEY(Id_Histofonction),
   FOREIGN KEY(Id_Employe) REFERENCES Employe(Id_Employe)
);
