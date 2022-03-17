<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Virtual Flight Online Transmitter - Who is Online?</title>
  <link rel="shortcut icon" type="image/jpg" href="virtualflightonline.jpg"/>

  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous" />
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj" crossorigin="anonymous"></script>
  <script src="https://maps.google.com/maps/api/js?key=API_KEY" type="text/javascript"></script>
  <script src="https://code.jquery.com/jquery-3.6.0.min.js" crossorigin="anonymous"></script>

  <link href="style.css" rel="stylesheet" />


</head>
<body>


<div class="container">

  <header class="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
    <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
      <img src="/virtualflightonline.jpg" width="48" height="48" alt="Virtual Flight Online" class="bi me-2" />
      <span class="fs-4">VirtualFlight.Online</span>
    </a>

    <ul class="nav nav-pills">
      <li class="nav-item"><a href="/" class="nav-link" aria-current="page">Home</a></li>
      <li class="nav-item"><a href="https://virtualflightonline.substack.com" class="nav-link">Newsletter</a></li>
      <li class="nav-item"><a href="https://bit.ly/virtualflightonlinediscord" class="nav-link">Discord</a></li>
      <li class="nav-item"><a href="https://www.facebook.com/groups/virtualflight.online" class="nav-link">Facebook</a></li>
      <li class="nav-item"><a href="/transmitter" class="nav-link">Transmitter</a></li>
      <li class="nav-item"><a href="/who" class="nav-link">Who is Online?</a></li>
    </ul>
  </header>

</div>

<div class="container">


<header>
<h1 class="display-1 mb-3">Who is Online?</h1>
</header>

<section>
<div id="map"></div>
<div><small><a href="#" onClick="map.fitBounds(bounds);">Zoom Out</a></small></div>
</section>

<br />

<div class="alert alert-info">Have you signed up for the <strong><a href="https://virtualflightonline.substack.com">VirtualFlight.Online Newsletter</a></strong> yet?</div>

<div class="row">
<div class="col-md-8">

<section>

<div id="info"></div>

</section>

<br />

<section>

<p><a class="btn btn-primary" role="button" href="https://www.virtualflight.online/transmitter">Download Transmitter</a></p>

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

<h4>Tips</h4>
<ul>
<li>Click on callsigns or aircraft to show more information about them.</li>
<li>The icon next to each callsign indicates if the aircraft is in the air or not.</li>
<li>Callsigns with * have notes - click on them!</li>
<li>Write #invite in your notes to invite others to fly with you (a waving hand icon will appear next to your callsign)</li>
<li>Click on column headings in the table of aircraft to sort it</li>
<li>Visit the <strong><a href="https://bit.ly/virtualflightonlinediscord" target="_blank">Discord Server</a></strong> to talk to each other!</li>
<li>You can centre the map on an aircraft by adding the parameter "callsign" to the URL (e.g. who?callsign=xyz)</li>
<li>You can change the zoom level by adding the parameter "z" to the URL (e.g. who?callsign=xyz&z=15)</li>
<li>You can change the refresh rate of the map in seconds by adding the parameter "s" to the URL (e.g. who?callsign=xyz&z=15&s=10) - the minimum is 5 - if you go lower it will ignore it</li>
<li>You can change to a full browser-window view by changing the URL to who_full instead of just who</li>
<li>Note that the parameters above are all case sensitive - as is the callsign parameter value.</li>
</ul>

</section>

</div> <!-- .col-md-8 -->

<div class="col-md-auto">&nbsp;</div>

<div class="col-md-3">
<br />
<iframe src="https://discord.com/widget?id=750398586851688499&theme=light" width="350" height="800" allowtransparency="true" frameborder="0" sandbox="allow-popups allow-popups-to-escape-sandbox allow-same-origin allow-scripts"></iframe>
</div>

</div> <!-- .row -->


<footer>
<p><input type="checkbox" id="reload" checked />&nbsp;<em><small>If ticked, the aircraft positions update automatically every 60 seconds.</small></em></p>
</footer>


</div> <!-- .container -->

<div style="display:none;" id="info"></div>
<script src="who.js?t=9" type="text/javascript"></script>

</body>
</html>