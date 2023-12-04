/*
SQLyog Community v9.63 
MySQL - 4.1.12-log : Database - lhkcommrpt
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`lhkcommrpt` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `lhkcommrpt`;

/*Table structure for table `comm_item` */

DROP TABLE IF EXISTS `comm_item`;

CREATE TABLE `comm_item` (
  `FKIDMasterItem` int(10) unsigned NOT NULL default '0',
  `FKIDItemGroup` int(10) unsigned NOT NULL default '0',
  `Active` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`FKIDMasterItem`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `comm_itemgroup` */

DROP TABLE IF EXISTS `comm_itemgroup`;

CREATE TABLE `comm_itemgroup` (
  `IDItemGroup` int(11) unsigned NOT NULL auto_increment,
  `ItemGroupName` varchar(255) NOT NULL default '',
  `Active` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`IDItemGroup`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `comm_outlet` */

DROP TABLE IF EXISTS `comm_outlet`;

CREATE TABLE `comm_outlet` (
  `FKIDBranch` int(11) unsigned NOT NULL default '0',
  `FKIDOutletGroup` int(11) unsigned NOT NULL default '0',
  `Active` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`FKIDBranch`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `comm_outletgroup` */

DROP TABLE IF EXISTS `comm_outletgroup`;

CREATE TABLE `comm_outletgroup` (
  `IDOutletGroup` int(11) unsigned NOT NULL auto_increment,
  `OutletGroupName` varchar(255) NOT NULL default '',
  `Active` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`IDOutletGroup`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `comm_rate` */

DROP TABLE IF EXISTS `comm_rate`;

CREATE TABLE `comm_rate` (
  `IDCommRate` int(11) unsigned NOT NULL auto_increment,
  `Rate` double unsigned NOT NULL default '0',
  `FKIDItemGroup` int(11) unsigned NOT NULL default '0',
  `FKIDOutletGroup` int(11) NOT NULL default '0',
  `MinQty` int(11) unsigned NOT NULL default '1',
  `Active` enum('Y','N') NOT NULL default 'Y',
  PRIMARY KEY  (`IDCommRate`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
