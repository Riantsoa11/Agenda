-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : jeu. 11 avr. 2024 à 13:11
-- Version du serveur : 8.2.0
-- Version de PHP : 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `agenda_andrianasoloharison`
--

-- --------------------------------------------------------

--
-- Structure de la table `contact`
--

DROP TABLE IF EXISTS `contact`;
CREATE TABLE IF NOT EXISTS `contact` (
  `idcontact` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `prenom` varchar(45) NOT NULL,
  `age` int NOT NULL,
  `sexe` enum('Masculin','Feminin') NOT NULL,
  `datenaissance` date NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Phone` varchar(45) NOT NULL,
  `Ville` varchar(45) NOT NULL,
  `statut` enum('Amis','Collegue','Famille') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Reseau` varchar(45) NOT NULL,
  PRIMARY KEY (`idcontact`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `contact`
--

INSERT INTO `contact` (`idcontact`, `nom`, `prenom`, `age`, `sexe`, `datenaissance`, `Email`, `Phone`, `Ville`, `statut`, `Reseau`) VALUES
(12, 'Andrianasoloharison', 'Tsiory ', 20, 'Masculin', '2003-08-11', 'tsiory.andrianasoloharison@gmail.com', '0625254028', 'Annecy', 'Famille', 'Facebook'),
(13, 'Dupont', 'Jean', 30, 'Masculin', '1994-02-20', 'jeandupont@example.com', '1234567890', 'Paris', 'Collegue', 'LinkedIn'),
(14, 'Durand', 'Marie', 25, 'Feminin', '1999-10-15', 'mariedurand@example.com', '9876543210', 'Lyon', 'Amis', 'Facebook'),
(15, 'Martin', 'Pierre', 35, 'Masculin', '1989-03-10', 'pierremartin@example.com', '4567890123', 'Marseille', 'Famille', 'Twitter'),
(17, 'Choi', 'Soojin', 31, 'Feminin', '1991-04-08', 'soojinchoi@example.com', '4567890123', 'Seoul', 'Famille', 'Facebook');

-- --------------------------------------------------------

--
-- Structure de la table `profilsreseau`
--

DROP TABLE IF EXISTS `profilsreseau`;
CREATE TABLE IF NOT EXISTS `profilsreseau` (
  `idprofilsreseau` int NOT NULL AUTO_INCREMENT,
  `datecreation` date DEFAULT NULL,
  `namereseau` varchar(45) DEFAULT NULL,
  `reseau_sociaux_idreseau_sociaux` int NOT NULL,
  PRIMARY KEY (`idprofilsreseau`),
  KEY `fk_profilsreseau_reseau_sociaux1_idx` (`reseau_sociaux_idreseau_sociaux`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `reseau_sociaux`
--

DROP TABLE IF EXISTS `reseau_sociaux`;
CREATE TABLE IF NOT EXISTS `reseau_sociaux` (
  `idreseau_sociaux` int NOT NULL AUTO_INCREMENT,
  `Reseau_sociaux` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Liens` varchar(45) DEFAULT NULL,
  `Profil` varchar(45) DEFAULT NULL,
  `contact_idcontact` int NOT NULL,
  PRIMARY KEY (`idreseau_sociaux`),
  KEY `fk_reseau_sociaux_contact1_idx` (`contact_idcontact`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `reseau_sociaux`
--

INSERT INTO `reseau_sociaux` (`idreseau_sociaux`, `Reseau_sociaux`, `Liens`, `Profil`, `contact_idcontact`) VALUES
(18, NULL, 'https://www.facebook.com/Tsiory Andryah/', 'Tsiory', 12);

-- --------------------------------------------------------

--
-- Structure de la table `status`
--

DROP TABLE IF EXISTS `status`;
CREATE TABLE IF NOT EXISTS `status` (
  `idStatus` int NOT NULL AUTO_INCREMENT,
  `Status` varchar(45) NOT NULL,
  `contact_idcontact` int NOT NULL,
  `contact_idcontact1` int NOT NULL,
  PRIMARY KEY (`idStatus`,`contact_idcontact`,`contact_idcontact1`),
  KEY `fk_Status_contact_idx` (`contact_idcontact1`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `task`
--

DROP TABLE IF EXISTS `task`;
CREATE TABLE IF NOT EXISTS `task` (
  `idtask` int NOT NULL AUTO_INCREMENT,
  `nomtask` varchar(45) NOT NULL,
  `description` varchar(45) NOT NULL,
  `todolist_idtodolist` int NOT NULL,
  PRIMARY KEY (`idtask`),
  KEY `fk_task_todolist1_idx` (`todolist_idtodolist`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `todolist`
--

DROP TABLE IF EXISTS `todolist`;
CREATE TABLE IF NOT EXISTS `todolist` (
  `idtodolist` int NOT NULL AUTO_INCREMENT,
  `date` date DEFAULT NULL,
  `descriptionl` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idtodolist`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `profilsreseau`
--
ALTER TABLE `profilsreseau`
  ADD CONSTRAINT `fk_profilsreseau_reseau_sociaux1` FOREIGN KEY (`reseau_sociaux_idreseau_sociaux`) REFERENCES `reseau_sociaux` (`idreseau_sociaux`);

--
-- Contraintes pour la table `reseau_sociaux`
--
ALTER TABLE `reseau_sociaux`
  ADD CONSTRAINT `fk_reseau_sociaux_contact1` FOREIGN KEY (`contact_idcontact`) REFERENCES `contact` (`idcontact`);

--
-- Contraintes pour la table `status`
--
ALTER TABLE `status`
  ADD CONSTRAINT `fk_Status_contact` FOREIGN KEY (`contact_idcontact1`) REFERENCES `contact` (`idcontact`);

--
-- Contraintes pour la table `task`
--
ALTER TABLE `task`
  ADD CONSTRAINT `fk_task_todolist1` FOREIGN KEY (`todolist_idtodolist`) REFERENCES `todolist` (`idtodolist`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
