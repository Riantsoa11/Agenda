-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 29 mars 2024 à 07:35
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
  `statut` enum('Amis','Collegue','Famille') CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Reseau` varchar(45) NOT NULL,
  PRIMARY KEY (`idcontact`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Déchargement des données de la table `contact`
--

INSERT INTO `contact` (`idcontact`, `nom`, `prenom`, `age`, `sexe`, `datenaissance`, `Email`, `Phone`, `Ville`, `statut`, `Reseau`) VALUES
(1, 'Andrianasoloharison', 'Tsiory', 20, 'Masculin', '2017-11-27', 'Tsiory.exemple@gmail.com', '06252545028', 'Annecy', 'Collegue', 'Facebook'),
(5, 'Razafinimpanarivo', 'Sylvia', 53, 'Feminin', '1971-01-13', 'Razifinimpanarivo@gmail.com', '0340261245', 'Antananarivo', 'Famille', 'Facebook'),
(6, 'Andrianasoloharison', 'Haingo ', 54, 'Masculin', '1970-01-06', 'HaingoRakou@gmail.com', '0349009379', 'Antananarivo', 'Famille', 'Facebook '),
(7, 'Andrianasoloharison ', 'Salohy', 23, 'Feminin', '2000-04-13', 'SalohyRianala@gmail.com', '0723248901', 'Lyon', 'Amis', 'Instagram '),
(9, 'Rasoafara', 'Lucie', 73, 'Feminin', '1949-02-06', 'LucieRasoafara@gmail.com', '0340486194', 'Antananarivo', 'Famille', 'Twitter');

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Déchargement des données de la table `reseau_sociaux`
--

INSERT INTO `reseau_sociaux` (`idreseau_sociaux`, `Reseau_sociaux`, `Liens`, `Profil`, `contact_idcontact`) VALUES
(1, 'Facebook', 'https://www.facebook.com/tsiory', 'Tsiory Andryah', 1),
(3, 'Facebook', 'https://www.facebook.com/in/Sylvia', 'Razafinimpanarivo Sylvia', 5),
(14, NULL, 'https://instagram.com/Salohy', 'Salohy Rianala', 7),
(15, NULL, 'https/Twitter.com/Luci', 'Luci', 9);

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

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
  `todolist_contact_idcontact` int NOT NULL,
  PRIMARY KEY (`idtask`,`todolist_idtodolist`,`todolist_contact_idcontact`),
  KEY `fk_task_todolist1_idx` (`todolist_idtodolist`,`todolist_contact_idcontact`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Déchargement des données de la table `task`
--

INSERT INTO `task` (`idtask`, `nomtask`, `description`, `todolist_idtodolist`, `todolist_contact_idcontact`) VALUES
(1, 'Voyage', 'Test', 1, 6);

-- --------------------------------------------------------

--
-- Structure de la table `todolist`
--

DROP TABLE IF EXISTS `todolist`;
CREATE TABLE IF NOT EXISTS `todolist` (
  `idtodolist` int NOT NULL AUTO_INCREMENT,
  `date` date DEFAULT NULL,
  `descriptionl` varchar(45) DEFAULT NULL,
  `contact_idcontact` int NOT NULL,
  PRIMARY KEY (`idtodolist`,`contact_idcontact`),
  KEY `fk_todolist_contact1_idx` (`contact_idcontact`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Déchargement des données de la table `todolist`
--

INSERT INTO `todolist` (`idtodolist`, `date`, `descriptionl`, `contact_idcontact`) VALUES
(1, '2024-03-29', 'Faire les valises', 6),
(4, '2024-03-29', 'Faire les courses', 6);

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
  ADD CONSTRAINT `fk_task_todolist1` FOREIGN KEY (`todolist_idtodolist`,`todolist_contact_idcontact`) REFERENCES `todolist` (`idtodolist`, `contact_idcontact`);

--
-- Contraintes pour la table `todolist`
--
ALTER TABLE `todolist`
  ADD CONSTRAINT `fk_todolist_contact1` FOREIGN KEY (`contact_idcontact`) REFERENCES `contact` (`idcontact`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
