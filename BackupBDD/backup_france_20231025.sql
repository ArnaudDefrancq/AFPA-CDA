-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: france
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
-- Current Database: `france`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `france` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `france`;

--
-- Table structure for table `departement`
--

DROP TABLE IF EXISTS `departement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departement` (
  `Id_departement` int(11) NOT NULL AUTO_INCREMENT,
  `numDepartement` varchar(50) DEFAULT NULL,
  `nomDepartement` varchar(50) DEFAULT NULL,
  `Id_region` int(11) NOT NULL,
  PRIMARY KEY (`Id_departement`),
  KEY `Id_region` (`Id_region`),
  CONSTRAINT `departement_ibfk_1` FOREIGN KEY (`Id_region`) REFERENCES `region` (`Id_region`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departement`
--

LOCK TABLES `departement` WRITE;
/*!40000 ALTER TABLE `departement` DISABLE KEYS */;
INSERT INTO `departement` VALUES (1,'1','Ain',1),(2,'2','Aisne',7),(3,'3','Allier',1),(4,'4','Alpes-de-Haute-Provence',13),(5,'5','Hautes-Alpes',13),(6,'6','Alpes-Maritimes',13),(7,'7','Ardèche',1),(8,'8','Ardennes',6),(9,'9','Ariège',11),(10,'10','Aube',6),(11,'11','Aude',11),(12,'12','Aveyron',11),(13,'13','Bouches-du-Rhône',13),(14,'14','Calvados',9),(15,'15','Cantal',1),(16,'16','Charente',10),(17,'17','Charente-Maritime',10),(18,'18','Cher',4),(19,'19','Correze',10),(20,'21','Côte-d\'Or',2),(21,'22','Côtes-d\'Armor',3),(22,'23','Creuse',10),(23,'24','Dordogne',10),(24,'25','Doubs',2),(25,'26','Drôme',1),(26,'27','Eure',9),(27,'28','Eure-et-Loir',4),(28,'29','Finistère',3),(29,'2A','Corse-du-Sud',5),(30,'2B','Haute-Corse ',5),(31,'30','Gard',11),(32,'31','Haute-Garonne',11),(33,'32','Gers',11),(34,'33','Gironde',10),(35,'34','Hérault',11),(36,'35','Ille-et-Vilaine',3),(37,'36','Indre',4),(38,'37','Indre-et-Loire',4),(39,'38','Isère',1),(40,'39','Jura',2),(41,'40','Landes',10),(42,'41','Loir-et-Cher',4),(43,'42','Loire',1),(44,'43','Haute-Loire',1),(45,'44','Loire-Atlantique',12),(46,'45','Loiret',4),(47,'46','Lot',11),(48,'47','Lot-et-Garonne',10),(49,'48','Lozère',11),(50,'49','Maine-et-Loire',12),(51,'50','Manche',9),(52,'51','Marne',6),(53,'52','Haute-Marne',6),(54,'53','Mayenne',12),(55,'54','Meurthe-et-Moselle',6),(56,'55','Meuse',6),(57,'56','Morbihan',3),(58,'57','Moselle',6),(59,'58','Nièvre',2),(60,'59','Nord',7),(61,'60','Oise',7),(62,'61','Orne',9),(63,'62','Pas-de-Calais',7),(64,'63','Puy-de-Dôme',1),(65,'64','Pyrénées-Atlantiques',10),(66,'65','Hautes-Pyrénées',11),(67,'66','Pyrénées-Orientales',11),(68,'67','Bas-Rhin',6),(69,'68','Haut-Rhin',6),(70,'69','Rhône',1),(71,'70','Haute-Saône',2),(72,'71','Saône-et-Loire',2),(73,'72','Sarthe',12),(74,'73','Savoie',1),(75,'74','Haute-Savoie',1),(76,'75','Paris',8),(77,'76','Seine-Maritime',9),(78,'77','Seine-et-Marne',8),(79,'78','Yvelines',8),(80,'79','Deux-Sèvres',10),(81,'80','Somme',7),(82,'81','Tarn',11),(83,'82','Tarn-et-Garonne',11),(84,'83','Var',13),(85,'84','Vaucluse',13),(86,'85','Vendée',12),(87,'86','Vienne',10),(88,'87','Haute-Vienne',10),(89,'88','Vosges',6),(90,'89','Yonne',2),(91,'90','Territoire de Belfort',2),(92,'91','Essonne',8),(93,'92','Hauts-de-Seine',8),(94,'93','Seine-Saint-Denis',8),(95,'94','Val-de-Marne',8),(96,'95','Val-d\'Oise',8),(97,'971','Guadeloupe',14),(98,'972','Martinique',14),(99,'973','Guyane',14),(100,'974','La Réunion',14),(101,'975','Saint-Pierre-et-Miquelon',14),(102,'977','Saint-Barthélemy',14),(103,'978','Saint-Martin',14),(104,'984','Terres australes et antarctiques françaises',14),(105,'986','Wallis-et-Futuna',14),(106,'987','Polynésie française',14),(107,'988','Nouvelle-Calédonie',14),(108,'989','Clipperton',14);
/*!40000 ALTER TABLE `departement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `region`
--

DROP TABLE IF EXISTS `region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `region` (
  `Id_region` int(11) NOT NULL AUTO_INCREMENT,
  `nomRegion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id_region`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `region`
--

LOCK TABLES `region` WRITE;
/*!40000 ALTER TABLE `region` DISABLE KEYS */;
INSERT INTO `region` VALUES (1,'Auvergne-Rhône-Alpes'),(2,'Bourgogne-Franche-Comté'),(3,'Bretagne'),(4,'Centre-Val de Loire'),(5,'Corse'),(6,'Grand-Est'),(7,'Hauts-de-France'),(8,'Ile-de-France'),(9,'Normandie'),(10,'Nouvelle-Aquitaine'),(11,'Occitanie'),(12,'Pays de la Loire'),(13,'Provence-Alpes-Côte d\'Azur'),(14,'DOM-TOM');
/*!40000 ALTER TABLE `region` ENABLE KEYS */;
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
