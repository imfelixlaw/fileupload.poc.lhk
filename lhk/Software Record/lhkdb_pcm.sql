/*
SQLyog Community v9.63 
MySQL - 4.1.12-log : Database - lhkdb_pcmanagement
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`lhkdb_pcmanagement` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `lhkdb_pcmanagement`;

/*Table structure for table `list_pc` */

DROP TABLE IF EXISTS `list_pc`;

CREATE TABLE `list_pc` (
  `IDPC` mediumint(9) unsigned NOT NULL auto_increment,
  `DisplayName` varchar(100) NOT NULL default '',
  `Desc` text,
  `PCName` varchar(100) default NULL,
  `AdminUsername` varchar(100) default NULL,
  `AdminPassword` varchar(100) default NULL,
  `Status` enum('Y','N','D') NOT NULL default 'Y',
  PRIMARY KEY  (`IDPC`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `list_productkey` */

DROP TABLE IF EXISTS `list_productkey`;

CREATE TABLE `list_productkey` (
  `IDProductKey` int(11) unsigned NOT NULL auto_increment,
  `FKIDSoftware` varchar(100) NOT NULL default '',
  `ProductKey` varchar(255) NOT NULL default '',
  `Status` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`IDProductKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `list_software` */

DROP TABLE IF EXISTS `list_software`;

CREATE TABLE `list_software` (
  `IDSoftware` mediumint(9) unsigned NOT NULL auto_increment,
  `SoftwareName` varchar(100) NOT NULL default '',
  `Desc` text,
  `ProductKey` enum('Y','N') NOT NULL default 'Y',
  `Status` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`IDSoftware`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `pc_software` */

DROP TABLE IF EXISTS `pc_software`;

CREATE TABLE `pc_software` (
  `IDPCSoftware` int(11) unsigned NOT NULL auto_increment,
  `FKIDPC` mediumint(9) unsigned NOT NULL default '0',
  `FKIDSoftware` mediumint(9) unsigned NOT NULL default '0',
  `FKIDProductKey` int(11) unsigned default NULL,
  `Status` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`IDPCSoftware`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
