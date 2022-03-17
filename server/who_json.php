<?php

$html = "";

include "config.php";

function DECtoDMS($dec)
{

  // Converts decimal longitude / latitude to DMS
  // ( Degrees / minutes / seconds ) 

  // This is the piece of code which may appear to 
  // be inefficient, but to avoid issues with floating
  // point math we extract the integer part and the float
  // part by using a string function.

  if ($dec<>0){

    $vars = explode(".",$dec);
    $deg = $vars[0];
    $tempma = "0.".$vars[1];

    $tempma = $tempma * 3600;
    $min = floor($tempma / 60);
    $sec = $tempma - ($min*60);

    return array("deg"=>$deg,"min"=>$min,"sec"=>$sec);
  } else {
    return array("deg"=>0,"min"=>0,"sec"=>0);
  }
}    

ini_set('display_errors', 1);  
ini_set('display_startup_errors', 1);  
error_reporting(E_ALL);  


$con = mysqli_connect($database_server, $database_username, $database_password, $database_name);
if (isset($_GET["group"])) {
	$sql = "SELECT * FROM Positions WHERE GroupName='".mysqli_real_escape_string($con,$_GET["group"])."' ORDER BY Created ASC;";
} else {
	$sql = "SELECT * FROM Positions ORDER BY Created ASC;";
}
$result = mysqli_query($con, $sql);


$js_data = "";
$i =0;

$json = "[\r\n";

// if we have records
if ( mysqli_num_rows($result) > 0) {
	
	// loop through the records
	while ($row = $result->fetch_array(MYSQLI_ASSOC)) {

		// prepare aircraft information
		$callsign = preg_replace('/[^A-Za-z0-9. -]/', '', strip_tags($row["Callsign"]));
		$pilot_name = preg_replace('/[^A-Za-z0-9. -]/', '', strip_tags($row["PilotName"]));
		$group_name = preg_replace('/[^A-Za-z0-9. -]/', '', strip_tags($row["GroupName"]));
		$aircraft_type = preg_replace('/[^A-Za-z0-9. -]/', '', strip_tags($row["AircraftType"]));
		$version = preg_replace('/[^A-Za-z0-9. -]/', '', strip_tags($row["Version"]));
		$notes = preg_replace('/[^A-Za-z0-9. -\/\:]/', '', strip_tags($row["Notes"]));
		$longitude = $row["Longitude"];
		$latitude = $row["Latitude"];
		$altitude = $row["Altitude"];
		$heading = $row["Heading"];
		$airspeed = $row["Airspeed"];
		$groundspeed = $row["Groundspeed"];
		$touchdown_velocity = $row["TouchdownVelocity"] * 60;

		$altitude_formatted = number_format($row["Altitude"],0,".",",");
		$heading_formatted = number_format($row["Heading"],0,".","");
		$airspeed_formatted = number_format($row["Airspeed"],0,".",",");
		$groundspeed_formatted = number_format($row["Groundspeed"],0,".",",");
		$touchdown_velocity_formatted = number_format($row["TouchdownVelocity"] * 60,0,".",",");

		// calculate longitude and latitude formatted for display
		$lat = DECtoDMS($row["Latitude"]);
		$lon = DECtoDMS($row["Longitude"]);
		$latitude_formatted = htmlspecialchars(abs($lat["deg"])."&deg; ".$lat["min"]."' ".number_format($lat["sec"],2,".","")."\" ".(($row["Latitude"] > 0) ? "N" : "S" ));
		$longitude_formatted = htmlspecialchars(abs($lon["deg"])."&deg; ".$lon["min"]."' ".number_format($lon["sec"],2,".","")."\" ".(($row["Longitude"] > 0) ? "E" : "W" ));

		$created = new DateTime($row["Created"]);
		$modified = new DateTime($row["Modified"]);

		// calculate seconds since last update		
		$time_online = $modified->diff($created)->format("%H:%I:%S");
		$now = new DateTime();
		$seconds_since_last_update = $now->diff($modified)->format("%s");
		
		// output aircraft data as json
		
		$json .= "{\r\n"
			."  \"callsign\":\"".$callsign."\",\r\n"
			."  \"pilot_name\":\"".$pilot_name."\",\r\n"
			."  \"group_name\":\"".$group_name."\",\r\n"
			."  \"aircraft_type\":\"".$aircraft_type."\",\r\n"
			."  \"version\":\"".$version."\",\r\n"
			."  \"notes\":\"".$notes."\",\r\n"
			."  \"longitude\":".$longitude.",\r\n"
			."  \"latitude\":".$latitude.",\r\n"
			."  \"altitude\":".$altitude.",\r\n"
			."  \"heading\":".$heading.",\r\n"
			."  \"airspeed\":".$airspeed.",\r\n"
			."  \"groundspeed\":".$groundspeed.",\r\n"
			."  \"touchdown_velocity\":".$touchdown_velocity.",\r\n"
			."  \"altitude_formatted\":\"".$altitude_formatted."\",\r\n"
			."  \"heading_formatted\":\"".$heading_formatted."\",\r\n"
			."  \"airspeed_formatted\":\"".$airspeed_formatted."\",\r\n"
			."  \"groundspeed_formatted\":\"".$groundspeed_formatted."\",\r\n"
			."  \"touchdown_velocity_formatted\":\"".$touchdown_velocity_formatted."\",\r\n"
			."  \"latitude_formatted\":\"".$latitude_formatted."\",\r\n"
			."  \"longitude_formatted\":\"".$longitude_formatted."\",\r\n"
			."  \"time_online\":\"".$time_online."\",\r\n"
			."  \"seconds_since_last_update\":\"".$seconds_since_last_update."\"\r\n"
			."},";
	}
		
}

$json = rtrim($json,",");
$json .= "]";

// close the connection
mysqli_close($con);

print($json);

?>
