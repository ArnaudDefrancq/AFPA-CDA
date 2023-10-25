-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: utilisateur
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
-- Current Database: `utilisateur`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `utilisateur` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `utilisateur`;

--
-- Table structure for table `personne`
--

DROP TABLE IF EXISTS `personne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personne` (
  `idPersonne` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `dateInscription` date NOT NULL,
  PRIMARY KEY (`idPersonne`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personne`
--

LOCK TABLES `personne` WRITE;
/*!40000 ALTER TABLE `personne` DISABLE KEYS */;
INSERT INTO `personne` VALUES (1,'Rebekah','Cleveland','nec@aol.com','07 65 41 61 31','2023-06-27'),(2,'Jillian','Hahn','id@google.couk','04 61 94 13 05','2023-11-09'),(3,'Blake','Schultz','erat.eget@outlook.couk','03 32 76 25 25','2023-09-13'),(4,'Gareth','Medina','eu.elit@aol.edu','04 73 34 82 48','2023-01-05'),(5,'Ebony','Raymond','dictum.cursus.nunc@outlook.couk','05 94 85 98 44','2023-01-19'),(6,'Noelani','Burris','diam.nunc@outlook.com','05 84 16 25 84','2023-02-20'),(7,'Harlan','Ford','molestie.sed@aol.edu','02 53 41 10 81','2023-09-17'),(8,'Cade','Chavez','pharetra.nam@yahoo.net','08 65 26 80 45','2023-05-06'),(9,'Aimee','Reed','nec.mollis@aol.org','04 25 65 18 01','2023-10-09'),(10,'Sasha','Sears','cras@google.net','02 95 24 87 41','2023-06-30'),(11,'Henry','Curtis','odio@outlook.net','03 18 54 83 83','2023-06-04'),(12,'Basil','Luna','quis@outlook.org','07 37 45 14 52','2023-10-16'),(13,'Colton','Moran','convallis.convallis@hotmail.net','07 70 42 14 80','2023-12-09'),(14,'Hillary','Crosby','ipsum.donec@icloud.edu','02 11 40 86 61','2023-05-17'),(15,'Dacey','Randall','erat.eget@google.org','07 22 78 43 66','2023-01-11'),(16,'Jerry','Giles','dolor.fusce@protonmail.edu','02 88 73 96 92','2023-04-21'),(17,'Minerva','Reed','blandit@google.org','01 18 76 72 61','2023-02-22'),(18,'Raphael','Meadows','pretium@google.edu','04 55 93 74 54','2023-05-22'),(19,'Thomas','Camacho','aliquet.lobortis@aol.edu','07 80 04 47 22','2023-07-18'),(20,'Ingrid','Schneider','in.consequat@yahoo.net','03 85 46 65 91','2023-03-18');
/*!40000 ALTER TABLE `personne` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-25 15:26:30
