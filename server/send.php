<?php
ini_set('display_errors', 1);  
ini_set('display_startup_errors', 1);  
error_reporting(E_ALL);  

include "config.php";


// get the data from the request (which may not be populated)
$callsign           = isset($_GET["Callsign"])          ? $_GET["Callsign"]          : "";
$aircraft_type      = isset($_GET["AircraftType"])      ? $_GET["AircraftType"]      : "";
$pilot_name         = isset($_GET["PilotName"])         ? $_GET["PilotName"]         : "";
$group_name         = isset($_GET["GroupName"])         ? $_GET["GroupName"]         : "";
$latitude           = isset($_GET["Latitude"])          ? $_GET["Latitude"]          : "0";
$longitude          = isset($_GET["Longitude"])         ? $_GET["Longitude"]         : "0";
$altitude           = isset($_GET["Altitude"])          ? $_GET["Altitude"]          : "0";
$heading            = isset($_GET["Heading"])           ? $_GET["Heading"]           : "0";
$airspeed           = isset($_GET["Airspeed"])          ? $_GET["Airspeed"]          : "0";
$groundspeed        = isset($_GET["Groundspeed"])       ? $_GET["Groundspeed"]       : "0";
$touchdown_velocity = isset($_GET["TouchdownVelocity"]) ? $_GET["TouchdownVelocity"] : "0";
$notes              = isset($_GET["Notes"])             ? $_GET["Notes"]             : "";
$version            = isset($_GET["Version"])           ? $_GET["Version"]           : "1.0.0.n";

// default groundspeed to airspeed if it is not supplied
if ($groundspeed == "0") $groundspeed = $airspeed;

// check we have everything we need to update the database
if(	empty($callsign) || empty($aircraft_type) || empty($pilot_name)	|| empty($group_name) )
{
	
	print "Insufficient data received";
	
	print empty($callsign) ? "Callsign" : "";
	print empty($aircraft_type) ? "AircraftType" : "";
	print empty($pilot_name) ? "PilotName" : "";
	print empty($group_name) ? "GroupName" : "";
	

} else {

	// connect to the database
	$con = mysqli_connect($database_server, $database_username, $database_password, $database_name);

	// find the first record with the same group, and callsign
	$sql = "SELECT PositionID,Modified FROM Positions"
		." WHERE GroupName LIKE '".mysqli_real_escape_string($con,$_GET["GroupName"])."'"
		." AND Callsign LIKE '".mysqli_real_escape_string($con,$_GET["Callsign"])."'"
		." ORDER BY PositionID DESC";

	$result = mysqli_query($con, $sql);

	// if we have a record matching, update it
	if ( mysqli_num_rows($result) > 0) {
		
		// A row exists
		
		// get the first matching row
		$row = $result->fetch_array(MYSQLI_ASSOC);
		$position_id = $row["PositionID"];
		$modified_timestamp = strtotime($row["Modified"]);
		
		// check the row was not updated less than a second ago
		$now = new DateTime();
		$now_timestamp = $now->getTimestamp();
		if (($now_timestamp-$modified_timestamp) > 1){

			// prepare database instruction
			$sql = "UPDATE Positions SET"
				." Callsign='".mysqli_real_escape_string($con, $callsign)."',"
				." AircraftType='".mysqli_real_escape_string($con, $aircraft_type)."',"
				." PilotName='".mysqli_real_escape_string($con, $pilot_name)."',"
				." GroupName='".mysqli_real_escape_string($con, $group_name)."',"
				." Latitude='".mysqli_real_escape_string($con, $latitude)."',"
				." Longitude='".mysqli_real_escape_string($con, $longitude)."',"
				." Altitude='".mysqli_real_escape_string($con, $altitude)."',"
				." Heading='".mysqli_real_escape_string($con, $heading)."',"
				." Airspeed='".mysqli_real_escape_string($con, $airspeed)."',"
				." Groundspeed='".mysqli_real_escape_string($con, $groundspeed)."',"
				." TouchdownVelocity='".mysqli_real_escape_string($con, $touchdown_velocity)."',"
				." Notes='".mysqli_real_escape_string($con, $notes)."',"
				." Version='".mysqli_real_escape_string($con, $version)."',"
				." IPAddress='".$_SERVER['REMOTE_ADDR']."',"
				." Modified=NOW()"
				." WHERE PositionID=".$position_id;
			
			// execute database instruction
			$result = mysqli_query($con, $sql);

			// return the ID of the updated record
			print $position_id;
			
		} else {
			
			// rate limited
			print "-1";
			
		}
		
	} else {
		
		// A row does not exist
		
		// prepare database instruction
		$sql = "INSERT INTO Positions ("
			."Callsign,AircraftType,PilotName,GroupName,Created,Modified,IPAddress,Latitude,Longitude,Altitude,Heading,Airspeed,Groundspeed,TouchdownVelocity,Notes,Version"
			.") VALUES ("
			."'".mysqli_real_escape_string($con, $callsign)."',"
			."'".mysqli_real_escape_string($con, $aircraft_type)."',"
			."'".mysqli_real_escape_string($con, $pilot_name)."',"
			."'".mysqli_real_escape_string($con, $group_name)."',"
			."NOW(),"
			."NOW(),"
			."'".$_SERVER['REMOTE_ADDR']."',"
			.mysqli_real_escape_string($con, $latitude).","
			.mysqli_real_escape_string($con, $longitude).","
			.mysqli_real_escape_string($con, $altitude).","
			.mysqli_real_escape_string($con, $heading).","
			.mysqli_real_escape_string($con, $airspeed).","
			.mysqli_real_escape_string($con, $groundspeed).","
			.mysqli_real_escape_string($con, $touchdown_velocity).","
			."'".mysqli_real_escape_string($con, $notes)."',"
			."'".mysqli_real_escape_string($con, $version)."'"
			.")";
		
		// execute database instruction
		$result = mysqli_query($con, $sql);
		
		// return the ID of the new record
		print mysqli_insert_id($con);
	}

	// close the database connection
	mysqli_close($con);
	
		
}

?>