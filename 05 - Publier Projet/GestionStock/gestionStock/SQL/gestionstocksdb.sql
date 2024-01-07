-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: gestionstocksdb
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
-- Current Database: `gestionstocksdb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `gestionstocksdb` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `gestionstocksdb`;

--
-- Table structure for table `articles`
--

DROP TABLE IF EXISTS `articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `articles` (
  `IdArticle` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleArticle` varchar(100) DEFAULT NULL,
  `QuantiteStrockee` int(11) DEFAULT NULL,
  `IdCategorie` int(11) NOT NULL,
  PRIMARY KEY (`IdArticle`),
  KEY `IdCategorie` (`IdCategorie`),
  CONSTRAINT `articles_ibfk_1` FOREIGN KEY (`IdCategorie`) REFERENCES `categories` (`IdCategorie`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articles`
--

LOCK TABLES `articles` WRITE;
/*!40000 ALTER TABLE `articles` DISABLE KEYS */;
INSERT INTO `articles` VALUES (8,'iPhone X',50,1),(9,'Samsung Galaxy S20',30,1),(10,'Dell XPS 13',20,2),(11,'HP Spectre x360',15,2),(12,'Cotton T-shirt',100,3),(13,'Denim Jeans',80,4),(14,'Apples',200,5),(15,'Carrots',150,6);
/*!40000 ALTER TABLE `articles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categories` (
  `IdCategorie` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleCategorie` varchar(100) DEFAULT NULL,
  `IdTypeProduit` int(11) NOT NULL,
  PRIMARY KEY (`IdCategorie`),
  KEY `IdTypeProduit` (`IdTypeProduit`),
  CONSTRAINT `categories_ibfk_1` FOREIGN KEY (`IdTypeProduit`) REFERENCES `typesproduits` (`IdTypeProduit`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Smartphones',1),(2,'Laptops',1),(3,'T-shirts',2),(4,'Jeans',2),(5,'Fruits',3),(6,'Légumes',3);
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typesproduits`
--

DROP TABLE IF EXISTS `typesproduits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `typesproduits` (
  `IdTypeProduit` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleTypeProduit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdTypeProduit`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typesproduits`
--

LOCK TABLES `typesproduits` WRITE;
/*!40000 ALTER TABLE `typesproduits` DISABLE KEYS */;
INSERT INTO `typesproduits` VALUES (1,'Électronique'),(2,'Vêtements'),(3,'Alimentaire');
/*!40000 ALTER TABLE `typesproduits` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-11 16:52:49
