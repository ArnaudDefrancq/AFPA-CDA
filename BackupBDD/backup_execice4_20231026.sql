-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: execice4
-- ------------------------------------------------------
-- Server version	5.7.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `execice4`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `execice4` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `execice4`;

--
-- Table structure for table `departement`
--

DROP TABLE IF EXISTS `departement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departement` (
  `Id_Departement` int(11) NOT NULL AUTO_INCREMENT,
  `nomDep` varchar(50) DEFAULT NULL,
  `ville` varchar(50) DEFAULT NULL,
  `numDep` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Departement`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departement`
--

LOCK TABLES `departement` WRITE;
/*!40000 ALTER TABLE `departement` DISABLE KEYS */;
INSERT INTO `departement` VALUES (1,'Formation','Aix',10),(2,'Ingénierie','Paris',20),(3,'Industrie','Bordeaux',30),(4,'Direction générale','Paris',40);
/*!40000 ALTER TABLE `departement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employe`
--

DROP TABLE IF EXISTS `employe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employe` (
  `Id_Employe` int(11) NOT NULL AUTO_INCREMENT,
  `nomEmp` varchar(50) DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  `dateEmbauche` date DEFAULT NULL,
  `salaire` int(11) DEFAULT NULL,
  `comm` int(11) DEFAULT NULL,
  `Id_Employe_1` int(11) DEFAULT NULL,
  `Id_Departement` int(11) NOT NULL,
  PRIMARY KEY (`Id_Employe`),
  KEY `Id_Employe_1` (`Id_Employe_1`),
  KEY `Id_Departement` (`Id_Departement`),
  CONSTRAINT `employe_ibfk_1` FOREIGN KEY (`Id_Employe_1`) REFERENCES `employe` (`Id_Employe`),
  CONSTRAINT `employe_ibfk_2` FOREIGN KEY (`Id_Departement`) REFERENCES `departement` (`Id_Departement`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employe`
--

LOCK TABLES `employe` WRITE;
/*!40000 ALTER TABLE `employe` DISABLE KEYS */;
INSERT INTO `employe` VALUES (1,'Costanza','psychologue','1994-10-19',1715,200,8,3),(2,'Mioche','Directeur','1990-03-15',2200,1000,6,2),(3,'Durand','Responsable','1996-04-18',3250,0,2,1),(4,'Xiong','vendeur','1994-12-15',1150,200,5,3),(5,'Manoukian','vendeur','1993-08-15',2530,500,11,3),(6,'Bourdais','directeur','2002-07-12',3550,850,15,4),(7,'Moreno','ouvrier','1999-05-05',1075,50,3,1),(8,'Perou','directeur','1995-07-05',2450,800,2,1),(9,'Bibaut','chef de service','1993-06-07',2200,0,8,2),(10,'Manian','assistant','1996-10-18',1000,250,9,1),(11,'Colin','analyste','1992-07-05',2703,625,2,3),(12,'Coulon','ouvrier','2002-09-18',858,125,8,2),(13,'Roméo','assistant','2001-08-16',1025,1150,8,1),(14,'Solal','secrétaire','1992-02-15',1225,0,3,2),(15,'Bailly','Président','1985-01-05',4275,2000,0,4),(16,'Jazarin','Ouvrier','2001-07-05',875,0,2,1),(17,'Font','Ouvrier','1990-08-04',1200,250,2,1),(18,'Servel','ouvrier','1998-12-02',1025,55,3,3);
/*!40000 ALTER TABLE `employe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grade`
--

DROP TABLE IF EXISTS `grade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grade` (
  `Id_Garde` int(11) NOT NULL AUTO_INCREMENT,
  `salMin` float DEFAULT NULL,
  `salMax` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Garde`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grade`
--

LOCK TABLES `grade` WRITE;
/*!40000 ALTER TABLE `grade` DISABLE KEYS */;
INSERT INTO `grade` VALUES (1,0,1000),(2,1000.01,2000),(3,2000.01,3000),(4,3000.01,4000),(5,4000.01,5000),(6,5000.01,6000);
/*!40000 ALTER TABLE `grade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `histofonction`
--

DROP TABLE IF EXISTS `histofonction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `histofonction` (
  `Id_Histofonction` int(11) NOT NULL AUTO_INCREMENT,
  `dateHisto` date DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  `Id_Employe` int(11) NOT NULL,
  PRIMARY KEY (`Id_Histofonction`),
  KEY `Id_Employe` (`Id_Employe`),
  CONSTRAINT `histofonction_ibfk_1` FOREIGN KEY (`Id_Employe`) REFERENCES `employe` (`Id_Employe`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `histofonction`
--

LOCK TABLES `histofonction` WRITE;
/*!40000 ALTER TABLE `histofonction` DISABLE KEYS */;
INSERT INTO `histofonction` VALUES (3,'1994-10-19','vendeur',1),(4,'1996-12-18','psychologue',1),(5,'1990-03-15','responsable',2),(6,'1994-10-18','directeur',2),(7,'1996-04-18','vendeur',3),(8,'1998-06-18','responsable',3),(9,'1994-12-15','vendeur',4),(10,'1993-08-15','vendeur',5),(11,'2002-07-12','directeur',6),(12,'1999-05-05','ouvrier',7),(13,'1995-07-05','vendeur',8),(14,'1997-04-15','responsable',8),(15,'1999-10-18','directeur',8),(16,'1996-10-18','assistant',10),(17,'1992-07-05','vendeur',11),(18,'1995-07-15','responsable',11),(19,'1999-05-19','analyste',11),(20,'2002-09-18','ouvrier',12),(21,'2001-08-16','ouvrier',13),(22,'2003-07-17','assistant',13),(23,'1992-01-02','secrétaire',14),(24,'1985-01-05','directeur',15),(25,'1995-10-05','président',15),(26,'2001-07-05','ouvrier',16),(27,'1990-08-04','ouvrier',17),(28,'1998-12-02','ouvrier',18);
/*!40000 ALTER TABLE `histofonction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-26 13:36:01
