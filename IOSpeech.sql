-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Jan 09, 2017 at 07:57 AM
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
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Language` int(11) NOT NULL DEFAULT '1',
  `auth` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`ID`, `Username`, `Password`, `Language`, `auth`) VALUES
(1, 'demo', 'demo', 1, 'MCLTYDAHAFVRUUDTDLOTSMQUDQRBLLGFJAWQWEPRNONKFHODRWIKGUSZLQQILZVOZPIUXNXZWWFEYGOVBNJODWZOHXEFOGFOSZLP');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `english_words`
--

INSERT INTO `english_words` (`ID`, `Title`, `Spanish`) VALUES
(1, 'The', 'El'),
(2, 'Family', 'Familia'),
(3, 'Mother', 'Madre'),
(4, 'Father', 'Padre'),
(5, 'The', 'La'),
(6, 'Brother', 'Hermano'),
(7, 'Sister', 'Hermana');

-- --------------------------------------------------------

--
-- Table structure for table `learned_courses`
--

CREATE TABLE IF NOT EXISTS `learned_courses` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UID` int(11) NOT NULL,
  `CID` int(11) NOT NULL,
  `Strength` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `learned_words`
--

CREATE TABLE IF NOT EXISTS `learned_words` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UID` int(11) NOT NULL,
  `WID` int(11) NOT NULL,
  `Efficiency` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`ID`, `LID`, `Title`, `Icon`, `created_on`, `LTO`, `LFROM`) VALUES
(1, 1, 'La Familia', NULL, '2016-12-21 18:39:50', 2, 1),
(2, 1, 'La Madre', NULL, '2017-01-08 04:48:26', 2, 1),
(3, 1, 'El Padre', NULL, '2017-01-08 05:10:27', 2, 1),
(4, 1, 'El Hermano', NULL, '2017-01-08 05:11:55', 2, 1),
(5, 1, 'La Hermana', NULL, '2017-01-08 05:12:03', 2, 1);

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `question_words`
--

INSERT INTO `question_words` (`ID`, `QID`, `Language`, `WID`, `created_on`) VALUES
(1, 1, 1, '1,2', '2016-12-21 18:46:03'),
(2, 2, 1, '5,3', '2017-01-08 04:49:35'),
(3, 3, 1, '5,4', '2017-01-08 05:09:57'),
(4, 4, 1, '1,6', '2017-01-08 05:15:01'),
(6, 5, 1, '1,7', '2017-01-08 05:49:18');

-- --------------------------------------------------------

--
-- Table structure for table `spanish_words`
--

CREATE TABLE IF NOT EXISTS `spanish_words` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) NOT NULL DEFAULT '',
  `English` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `spanish_words`
--

INSERT INTO `spanish_words` (`ID`, `Title`, `English`) VALUES
(1, 'La', 'The'),
(2, 'El', 'The'),
(3, 'Familia', 'Family'),
(4, 'Hermano', 'Brother'),
(5, 'Madre', 'Mother'),
(6, 'Padre', 'Father'),
(7, 'Hermana', 'Sister');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
