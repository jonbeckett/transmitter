
DROP TABLE IF EXISTS `Positions`;

CREATE TABLE `Positions` (
  `PositionID` int NOT NULL AUTO_INCREMENT,
  `Callsign` varchar(255) NOT NULL,
  `AircraftType` varchar(255) NOT NULL,
  `PilotName` varchar(255) NOT NULL,
  `GroupName` varchar(255) NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `IPAddress` varchar(255) NOT NULL,
  `Latitude` double DEFAULT NULL,
  `Longitude` double DEFAULT NULL,
  `Altitude` double DEFAULT NULL,
  `Heading` double DEFAULT NULL,
  `Airspeed` double DEFAULT NULL,
  `Groundspeed` double DEFAULT NULL,
  `TouchdownVelocity` double DEFAULT NULL,
  `Notes` text DEFAULT NULL,
  `Version` text DEFAULT NULL,
  PRIMARY KEY (`PositionID`)
) 
