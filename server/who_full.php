<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Virtual Flight Online Transmitter - Who is Online?</title>
  <link rel="shortcut icon" type="image/jpg" href="virtualflightonline.jpg"/>

  <script src="https://maps.google.com/maps/api/js?key=API_KEY" type="text/javascript"></script>
  <script src="https://code.jquery.com/jquery-3.6.0.min.js" crossorigin="anonymous"></script>

  <link href="style.css" rel="stylesheet" />

</head>
<body>


<div id="map"></div>

<section style="display:none;">

<table border="0" cellspacing="1" cellpadding="5" width="100%" class="table table-sm table-striped" id="aircraft_table">
<thead>
<tr>
<th class='l icon' scope="col"><a title=''>&nbsp;</a></th>
<th class='l' scope="col"><a title='Callsign (click to sort)'>CALLSIGN</a></th>
<th class='l' scope="col"><a title='Pilot Name (click to sort)'>NAME</a></th>
<th class='l' scope="col"><a title='Aircraft Type (click to sort)'>AIRCRAFT TYPE</a></th>
<th class='r' scope="col"><a title='Last Landing Rate (click to sort)'>LLR (ft/min)</a></th>
<th class='c' scope="col"><a title='Online Status (click to sort)'>ONLINE</a></th>
</tr>
</thead>
<tbody>
</tbody>
</table>

<p><span id="aircraft_count"></span> aircraft online.</p>

</section>

<footer style="display:none;">
<p><input type="checkbox" id="reload" checked />&nbsp;<em><small>If ticked, the aircraft positions update automatically every 60 seconds.</small></em></p>
</footer>

<div style="display:none;" id="info"></div>

<script src="who.js?t=9" type="text/javascript"></script>

<script type="text/javascript">

$("BODY").css("margin","0");
$("BODY").css("padding","0");

function resize_map(){
  $("#map").css("width",$(window).width());
  $("#map").css("height",$(window).height());
}

$(document).ready(function(){

  $(window).resize(function(){
    resize_map();
  });
  
  resize_map();

});
</script>


</body>
</html>