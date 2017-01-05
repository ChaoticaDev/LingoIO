-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Jan 05, 2017 at 06:26 AM
-- Server version: 5.6.33-cll-lve
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `IOSpeech`
--

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE IF NOT EXISTS `courses` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) NOT NULL DEFAULT '',
  `Description` text NOT NULL,
  `Icon` varchar(45) NOT NULL DEFAULT '',
  `created_on` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`ID`, `Title`, `Description`, `Icon`, `created_on`) VALUES
(1, 'Family', 'Family members', 'Pregnant-96', '2016-12-21 18:28:24');

-- --------------------------------------------------------

--
-- Table structure for table `english_words`
--

CREATE TABLE IF NOT EXISTS `english_words` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) NOT NULL DEFAULT '',
  `Spanish` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `english_words`
--

INSERT INTO `english_words` (`ID`, `Title`, `Spanish`) VALUES
(1, 'The', 'El'),
(2, 'Family', 'Familia');

-- --------------------------------------------------------

--
-- Table structure for table `lessons`
--

CREATE TABLE IF NOT EXISTS `lessons` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CID` int(10) unsigned NOT NULL DEFAULT '0',
  `Title` varchar(45) NOT NULL DEFAULT '',
  `Description` varchar(45) DEFAULT NULL,
  `Icon` varchar(45) DEFAULT NULL,
  `created_on` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `lessons`
--

INSERT INTO `lessons` (`ID`, `CID`, `Title`, `Description`, `Icon`, `created_on`) VALUES
(1, 1, 'Getting to know the family', ' ', 'Family Man Woman-96', '2016-12-21 18:30:21');

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE IF NOT EXISTS `questions` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `LID` int(10) unsigned NOT NULL DEFAULT '0',
  `Title` varchar(255) NOT NULL DEFAULT '',
  `Icon` varchar(45) DEFAULT NULL,
  `created_on` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LTO` int(10) unsigned NOT NULL DEFAULT '2',
  `LFROM` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`ID`, `LID`, `Title`, `Icon`, `created_on`, `LTO`, `LFROM`) VALUES
(1, 1, 'La familia', NULL, '2016-12-21 18:39:50', 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `question_words`
--

CREATE TABLE IF NOT EXISTS `question_words` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `QID` int(10) unsigned NOT NULL DEFAULT '0',
  `Language` int(10) unsigned NOT NULL DEFAULT '0',
  `WID` varchar(255) NOT NULL DEFAULT '0',
  `created_on` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `question_words`
--

INSERT INTO `question_words` (`ID`, `QID`, `Language`, `WID`, `created_on`) VALUES
(1, 1, 1, '1,2', '2016-12-21 18:46:03');

-- --------------------------------------------------------

--
-- Table structure for table `spanish_words`
--

CREATE TABLE IF NOT EXISTS `spanish_words` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) NOT NULL DEFAULT '',
  `English` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `spanish_words`
--

INSERT INTO `spanish_words` (`ID`, `Title`, `English`) VALUES
(1, 'La', 'The'),
(2, 'El', 'The'),
(3, 'Familia', 'Family');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
