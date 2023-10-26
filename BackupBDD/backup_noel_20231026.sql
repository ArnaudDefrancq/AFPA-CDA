-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: noel
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
-- Current Database: `noel`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `noel` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `noel`;

--
-- Table structure for table `cadeau`
--

DROP TABLE IF EXISTS `cadeau`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cadeau` (
  `idCadeau` int(11) NOT NULL AUTO_INCREMENT,
  `libelleCadeau` varchar(50) DEFAULT NULL,
  `idTraineauCadeau` int(11) NOT NULL,
  `idEnfant` int(11) NOT NULL,
  PRIMARY KEY (`idCadeau`),
  KEY `idTraineauCadeau` (`idTraineauCadeau`),
  KEY `idEnfant` (`idEnfant`),
  CONSTRAINT `idEnfant` FOREIGN KEY (`idEnfant`) REFERENCES `enfant` (`idEnfant`),
  CONSTRAINT `idTraineauCadeau` FOREIGN KEY (`idTraineauCadeau`) REFERENCES `traineau` (`idTraineau`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cadeau`
--

LOCK TABLES `cadeau` WRITE;
/*!40000 ALTER TABLE `cadeau` DISABLE KEYS */;
/*!40000 ALTER TABLE `cadeau` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enfant`
--

DROP TABLE IF EXISTS `enfant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enfant` (
  `idEnfant` int(11) NOT NULL AUTO_INCREMENT,
  `nomEnfant` varchar(50) DEFAULT NULL,
  `prenomEnfant` varchar(50) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `sexeEnfant` varchar(50) DEFAULT NULL,
  `voeu` varchar(50) DEFAULT NULL,
  `sagesse` int(11) DEFAULT NULL,
  PRIMARY KEY (`idEnfant`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enfant`
--

LOCK TABLES `enfant` WRITE;
/*!40000 ALTER TABLE `enfant` DISABLE KEYS */;
/*!40000 ALTER TABLE `enfant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historesponsable`
--

DROP TABLE IF EXISTS `historesponsable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `historesponsable` (
  `idHistoResponsable` int(11) NOT NULL AUTO_INCREMENT,
  `idLutinResp` int(11) DEFAULT NULL,
  `idTraineauResp` int(11) DEFAULT NULL,
  PRIMARY KEY (`idHistoResponsable`),
  KEY `idLutinResp` (`idLutinResp`),
  KEY `idTraineauResp` (`idTraineauResp`),
  CONSTRAINT `idLutinResp` FOREIGN KEY (`idLutinResp`) REFERENCES `lutin` (`idLutin`),
  CONSTRAINT `idTraineauResp` FOREIGN KEY (`idTraineauResp`) REFERENCES `traineau` (`idTraineau`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historesponsable`
--

LOCK TABLES `historesponsable` WRITE;
/*!40000 ALTER TABLE `historesponsable` DISABLE KEYS */;
/*!40000 ALTER TABLE `historesponsable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lutin`
--

DROP TABLE IF EXISTS `lutin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lutin` (
  `idLutin` int(11) NOT NULL AUTO_INCREMENT,
  `nomLutin` varchar(50) DEFAULT NULL,
  `prenomLutin` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idLutin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lutin`
--

LOCK TABLES `lutin` WRITE;
/*!40000 ALTER TABLE `lutin` DISABLE KEYS */;
/*!40000 ALTER TABLE `lutin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `renne`
--

DROP TABLE IF EXISTS `renne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `renne` (
  `idRenne` int(11) NOT NULL AUTO_INCREMENT,
  `nomRenne` varchar(50) DEFAULT NULL,
  `sexeRenne` varchar(50) DEFAULT NULL,
  `dateNaissanceRenne` date DEFAULT NULL,
  PRIMARY KEY (`idRenne`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `renne`
--

LOCK TABLES `renne` WRITE;
/*!40000 ALTER TABLE `renne` DISABLE KEYS */;
/*!40000 ALTER TABLE `renne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `revision`
--

DROP TABLE IF EXISTS `revision`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `revision` (
  `idRevision` int(11) NOT NULL AUTO_INCREMENT,
  `dateRevision` date DEFAULT NULL,
  `idTraineau` int(11) NOT NULL,
  PRIMARY KEY (`idRevision`),
  KEY `idTraineau` (`idTraineau`),
  CONSTRAINT `idTraineau` FOREIGN KEY (`idTraineau`) REFERENCES `traineau` (`idTraineau`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `revision`
--

LOCK TABLES `revision` WRITE;
/*!40000 ALTER TABLE `revision` DISABLE KEYS */;
/*!40000 ALTER TABLE `revision` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tournee`
--

DROP TABLE IF EXISTS `tournee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tournee` (
  `idTournee` int(11) NOT NULL AUTO_INCREMENT,
  `idConducteur` int(11) DEFAULT NULL,
  `idTraineauTournee` int(11) DEFAULT NULL,
  `idRenneTournee` int(11) DEFAULT NULL,
  `dateDebutTournee` time DEFAULT NULL,
  PRIMARY KEY (`idTournee`),
  KEY `idConducteur` (`idConducteur`),
  KEY `idTraineauTournee` (`idTraineauTournee`),
  KEY `idRenneTournee` (`idRenneTournee`),
  CONSTRAINT `idConducteur` FOREIGN KEY (`idConducteur`) REFERENCES `lutin` (`idLutin`),
  CONSTRAINT `idRenneTournee` FOREIGN KEY (`idRenneTournee`) REFERENCES `renne` (`idRenne`),
  CONSTRAINT `idTraineauTournee` FOREIGN KEY (`idTraineauTournee`) REFERENCES `traineau` (`idTraineau`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tournee`
--

LOCK TABLES `tournee` WRITE;
/*!40000 ALTER TABLE `tournee` DISABLE KEYS */;
/*!40000 ALTER TABLE `tournee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `traineau`
--

DROP TABLE IF EXISTS `traineau`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `traineau` (
  `idTraineau` int(11) NOT NULL AUTO_INCREMENT,
  `taille` int(11) DEFAULT NULL,
  `dateServiceTraineau` date DEFAULT NULL,
  `dateRespTraineau` date DEFAULT NULL,
  `idResp` int(11) NOT NULL,
  PRIMARY KEY (`idTraineau`),
  KEY `idResp` (`idResp`),
  CONSTRAINT `idResp` FOREIGN KEY (`idResp`) REFERENCES `lutin` (`idLutin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traineau`
--

LOCK TABLES `traineau` WRITE;
/*!40000 ALTER TABLE `traineau` DISABLE KEYS */;
/*!40000 ALTER TABLE `traineau` ENABLE KEYS */;
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
