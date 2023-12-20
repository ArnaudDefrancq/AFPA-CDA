-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: gestioncoursdb
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
-- Current Database: `gestioncoursdb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `gestioncoursdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `gestioncoursdb`;

--
-- Table structure for table `cours`
--

DROP TABLE IF EXISTS `cours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cours` (
  `IdCours` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdCours`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cours`
--

LOCK TABLES `cours` WRITE;
/*!40000 ALTER TABLE `cours` DISABLE KEYS */;
INSERT INTO `cours` VALUES (1,'Mathématiques','Cours de mathématiques avancées'),(2,'Informatique','Introduction à la programmation'),(3,'Français','Littérature française'),(4,'Histoire','Histoire du monde'),(5,'Chimie','Chimie organique'),(6,'Physique','Physique quantique'),(7,'Anglais','Cours d\'anglais avancé'),(8,'Biologie','Biologie cellulaire'),(9,'Art','Histoire de l\'art'),(10,'Musique','Théorie musicale'),(11,'Économie','Principes de l\'économie'),(12,'Psychologie','Introduction à la psychologie'),(13,'Géographie','Géographie humaine'),(14,'Sociologie','Sociologie contemporaine'),(15,'Philosophie','Philosophie politique');
/*!40000 ALTER TABLE `cours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `etudiants`
--

DROP TABLE IF EXISTS `etudiants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `etudiants` (
  `IdEtudiants` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) DEFAULT NULL,
  `Prenom` varchar(50) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdEtudiants`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `etudiants`
--

LOCK TABLES `etudiants` WRITE;
/*!40000 ALTER TABLE `etudiants` DISABLE KEYS */;
INSERT INTO `etudiants` VALUES (1,'Dupont','Jean',20),(2,'Martin','Sophie',22),(3,'Lefevre','Pierre',21),(4,'Moreau','Marie',23),(5,'Dubois','Paul',19),(6,'Thomas','Alice',20),(7,'Garcia','Lucas',22),(8,'Rodriguez','Emma',21),(9,'Lopez','Antoine',23),(10,'Muller','Camille',19),(11,'Schmidt','Nicolas',20),(12,'Weber','Eva',22),(13,'Leroy','Louis',21),(14,'Roux','Chloé',23),(15,'Fischer','Hugo',19);
/*!40000 ALTER TABLE `etudiants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inscriptions`
--

DROP TABLE IF EXISTS `inscriptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inscriptions` (
  `IdInscriptions` int(11) NOT NULL AUTO_INCREMENT,
  `Etudiant` int(11) DEFAULT NULL,
  `Cours` int(11) DEFAULT NULL,
  `DateInscription` datetime DEFAULT NULL,
  PRIMARY KEY (`IdInscriptions`),
  KEY `inscriptions_ibfk_1` (`Etudiant`),
  KEY `inscriptions_ibfk_2` (`Cours`),
  CONSTRAINT `inscriptions_ibfk_1` FOREIGN KEY (`Etudiant`) REFERENCES `etudiants` (`IdEtudiants`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `inscriptions_ibfk_2` FOREIGN KEY (`Cours`) REFERENCES `cours` (`IdCours`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscriptions`
--

LOCK TABLES `inscriptions` WRITE;
/*!40000 ALTER TABLE `inscriptions` DISABLE KEYS */;
INSERT INTO `inscriptions` VALUES (1,1,2,'2023-01-15 08:30:00'),(2,2,4,'2023-02-20 10:15:00'),(3,3,6,'2023-03-05 14:45:00'),(4,4,8,'2023-04-10 09:00:00'),(5,5,10,'2023-05-12 11:30:00'),(6,6,12,'2023-06-18 13:45:00'),(7,7,14,'2023-07-22 16:00:00'),(8,8,1,'2023-08-25 08:45:00'),(9,9,3,'2023-09-30 10:30:00'),(10,10,5,'2023-10-05 12:15:00'),(11,11,7,'2023-11-08 14:00:00'),(12,12,9,'2023-12-12 15:45:00'),(13,13,11,'2024-01-15 08:30:00'),(14,14,13,'2024-02-20 10:15:00'),(15,15,15,'2024-03-25 14:45:00');
/*!40000 ALTER TABLE `inscriptions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-13 15:01:34
