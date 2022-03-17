var z = 10;
var s = 60000;

function urlify(text) {
    var urlRegex = /(((https?:\/\/)|(www\.))[^\s]+)/g;
    return text.replace(urlRegex, function(url,b,c) {
        var url2 = (c == 'www.') ?  'http://' +url : url;
        return '<a href="' +url2+ '" target="_blank">' + url + '</a>';
    }) 
}

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function fetch_aircraft(set_bounds){
  $.ajax({
    url:who_json_url,
    dataType:"json",
    success:function(locations){
    render_aircraft(locations);
  },
    error:function(xhr, status, error){
      var errorMessage = xhr.status + ': ' + xhr.statusText
      console.log('Error - ' + errorMessage);
    }
  });
}

function render_aircraft(locations){

    $("#aircraft_count").text(locations.length);

    var infowindow = new google.maps.InfoWindow();

    bounds = new google.maps.LatLngBounds();

    markers = new Array();

    $("#aircraft_table tr").slice(1).remove();

    // loop through the locations of aircraft, making google map markers
    for (i = 0; i < locations.length; i++) {

      // create a new marker
      var marker = new google.maps.Marker({
	map: map,
        position: new google.maps.LatLng(locations[i]["latitude"], locations[i]["longitude"]),
	icon: {  
	    path: "M21 16v-2l-8-5V3.5c0-.83-.67-1.5-1.5-1.5S10 2.67 10 3.5V9l-8 5v2l8-2.5V19l-2 1.5V22l3.5-1 3.5 1v-1.5L13 19v-5.5l8 2.5z",
	    fillColor: '#f00',
	    fillOpacity: 1,
	    anchor: new google.maps.Point(12, 12),
	    strokeWeight: 1,
	    scale: 1.25,
	    rotation: parseInt(locations[i]["heading"])
	}
      });

      markers.push(marker);

      

      // show a label when a marker is clicked
      google.maps.event.addListener(marker, 'click', (function(marker, i) {

        return function() {

          // construct the info panel
          document.getElementById("info").innerHTML = "<h1>" + locations[i]["callsign"] + "</h1>"
		+ "<p style='font-size:1.3em;'>" + locations[i]["pilot_name"] + ", " + locations[i]["group_name"] + "</p>"
		+ "<table class='info'>"
		+ "<tr><th>Aircraft Type</td><td>" + locations[i]["aircraft_type"] + "</td>"
		+ "<tr><th>Location</td><td>" + $("<div/>").html(locations[i]["latitude_formatted"]).text() + " " + $("<div/>").html(locations[i]["longitude_formatted"]).text() + "</td>"
		+ "<tr><th>Heading</td><td>" + locations[i]["heading"].toFixed(0) + "&#176;</td>"
		+ "<tr><th>Altitude</td><td>" + locations[i]["altitude"].toFixed(0) + " ft</td>"
		+ "<tr><th>IAS</td><td>" + locations[i]["airspeed"].toFixed(0) + " knots</td>"
		+ "<tr><th>GS</td><td>" + locations[i]["groundspeed"].toFixed(0) + " knots</td>"
		+ "<tr><th>LLR</td><td>" +  locations[i]["touchdown_velocity"].toFixed(0) + " ft/min</td>"
		+ "</table>"
		+ ((locations[i]["notes"] != "") ? "<p style='margin:10px 0px 10px 0px;padding:10px 0px 10px 0px;border-top:1px dotted #ccc;'>" + urlify(locations[i]["notes"]) + "</p>" : "")
		+ "<div style='text-align:right;padding:2px;'><small><a href='#' onClick='map.setCenter({lat:" + locations[i]["latitude"] + ",lng:" + locations[i]["longitude"] + "});map.setZoom(" + z + ");'>Zoom to Aircraft</a></small></div>";

          infowindow.setContent(document.getElementById("info").innerHTML);
          infowindow.open(map, marker);

        }

      })(marker, i));

      // add the marker position to the bounds object
      bounds.extend(marker.getPosition());

      // how long since last update ?
      var seconds = parseInt(locations[i]["seconds_since_last_update"]);

      var row_style = (seconds>5) ? "offline" : "online";

      $("#aircraft_table").append("<tr class='" + row_style + "'>"
	+ "<td class='l'><span style='font-size:18px !important;' title='" + ((locations[i]["airspeed"] > 20)?"Flying":"On the ground") + " - click to view on map'><a class='callsign' location_index='" + i + "' href='#' >" + ((locations[i]["airspeed"] > 20)?"&#128747;":"&#127760;") + "</a></span></td>"
	+ "<td class='l'><strong><a class='callsign' location_index='" + i + "' href='#' title='Click to view on map'>" + locations[i]["callsign"] + ((locations[i]["notes"] != "" ) ? " *" : "" ) + ((locations[i]["notes"].includes("#invite")) ? "&nbsp;<span style='font-size:18px !important;' title='Invitation - fly with me!'>&#128075;</span>": "" ) + "</a></strong></td>"
	+ "<td class='l'>" + locations[i]["pilot_name"] + "</td>"
	+ "<td class='l'>" + locations[i]["aircraft_type"] + "</td>"
	+ "<td class='r'>" + locations[i]["touchdown_velocity"].toFixed(0) + "</td>"
	+ "<td class='c'>" + ((seconds>5) ? "Offline" : locations[i]["time_online"]) + "</td>"
	+ "</tr>\r\n");

      $(".callsign").click(function(){
          // map.setCenter({lat:" + locations[i]["latitude"] + ",lng:" + locations[i]["longitude"] + "});
          // map.setZoom(10);
	  google.maps.event.trigger( markers[$(this).attr("location_index")], 'click' );
      });

      if (getParameterByName("z") != null) {
        z = parseInt(getParameterByName("z"));
      }

      if (getParameterByName("callsign") == locations[i]["callsign"]) {
        map.setCenter({
          lat: locations[i]["latitude"],
          lng: locations[i]["longitude"]
        });
        map.setZoom(z);
      }
      
     



    } // loop 

    // if a callsign is not passed in, zoom the map to it - else fit all the aircraft
    if (getParameterByName("callsign") == null) {
      // fit the map to the markers being shown
      if (set_bounds) {
        map.fitBounds(bounds);
        set_bounds = false;
      }
    }
}

function timer(){
  if (document.getElementById("reload").checked){
    // clear existing markers
    for(var i=0; i < markers.length; i++){
      markers[i].setMap(null);			
    }
    markers = [];
    fetch_aircraft(false);
  }
}

function comparer(index) {
  return function(a, b) {
    var valA = getCellValue(a, index), valB = getCellValue(b, index)
    return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.toString().localeCompare(valB)
  }
}

var bounds = null;
var set_bounds = true;
var markers = [];

var map = new google.maps.Map(document.getElementById('map'), {
  mapTypeId: google.maps.MapTypeId.TERRAIN
});

var filter_group_name = getParameterByName("group");
var who_json_url = (filter_group_name != null) ? "https://virtualflight.online/who_json.php?group=" + filter_group_name : "https://virtualflight.online/who_json.php" ;


if (getParameterByName("s") != null) {
  s = parseInt(getParameterByName("s")) * 1000;
  if (s<5000) s = 5000;
}

$('th').click(function(){
  var table = $(this).parents('table').eq(0)
  var rows = table.find('tr:gt(0)').toArray().sort(comparer($(this).index()))
  this.asc = !this.asc
  if (!this.asc){rows = rows.reverse()}
  for (var i = 0; i < rows.length; i++){table.append(rows[i])}
})

function getCellValue(row, index){ return $(row).children('td').eq(index).text() }

// wait for jQuery
$(document).ready(function(){
  console.log("Ready!");
  fetch_aircraft(true);
  window.setInterval(timer, s);
});


