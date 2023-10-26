-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 06 oct. 2023 à 09:28
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `exercice6`
--
CREATE DATABASE IF NOT EXISTS `exercice6` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `exercice6`;

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

DROP TABLE IF EXISTS `personne`;
CREATE TABLE IF NOT EXISTS `personne` (
  `idPersonne` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) CHARACTER SET latin1 NOT NULL,
  `prenom` varchar(50) CHARACTER SET latin1 NOT NULL,
  `adresse` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `ville` varchar(50) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`idPersonne`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`idPersonne`, `nom`, `prenom`, `adresse`, `ville`) VALUES
(1, 'Jean', 'Marc', 'oui', 'DK'),
(2, 'PO', 'Potin', 'non', 'CDK');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
