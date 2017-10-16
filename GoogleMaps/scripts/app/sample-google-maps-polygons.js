var sample = sample || {};
sample.googleMaps = sample.googleMaps || {};

sample.googleMaps.polygons = function (module) {

    function drawMarkers (map) {
        //var image = 'https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/Flag_of_Wales_2.svg/255px-Flag_of_Wales_2.svg.png';
        var centerMarker = new google.maps.Marker({
            map: map,
            //icon: image,
            position: new google.maps.LatLng(52.427548, -3.515625),
            title: "The Offa's Dyke Center, Knighton, Powys"
        });

        var pubMarker = new google.maps.Marker({
            map: map,
            //icon: image,
            position: new google.maps.LatLng(52.489548, -3.515905),
            title: 'The Knighton Hotel'
        });

        var contentString =
            '<div id="content">' +
            ' <div id="siteNotice">' +
            ' </div>' +
            ' <h3 id="firstHeading" class="firstHeading">' +
            '  The Offa\'s Dyke Center, Knighton, Powys' +
            ' </h3>' +
            ' <p> This is a little bit of information about' +
            '     the place we are marking on the map </p>';

        var infoWindow = new google.maps.InfoWindow({ content: contentString });

        google.maps.event.addListener(centerMarker, 'click',
            function () {
                infoWindow.open(map, centerMarker);
            });


    };
    function drawPolyline (map) {
        var pathCoordinates = [
            new google.maps.LatLng(52.427548, -3.15625),
            new google.maps.LatLng(52.520048, -3.615625),
            new google.maps.LatLng(52.627548, -3.795625),
            new google.maps.LatLng(52.729994, -3.815625),
            new google.maps.LatLng(52.827548, -3.915625)
        ];
        var pathToCenter = new google.maps.Polyline({
            path: pathCoordinates,
            geodesic: false,
            strokeColor: '#0000FF',
            strokeOpacity: 1.0,
            storkeWeight: 1
        });
        pathToCenter.setMap(map);
    };
    function drawPolygon (map) {
        var natureCoords = [
            new google.maps.LatLng(52.427548, -3.15625),
            new google.maps.LatLng(52.520048, -3.615625),
            new google.maps.LatLng(52.627548, -3.795625),
            new google.maps.LatLng(52.729994, -3.815625),
            new google.maps.LatLng(52.827548, -3.915625),
        ];
        var polygon = new google.maps.Polygon({
            path: natureCoords,
            strokeColor: '#FFFFFF',
            strokeOpacity: 0.8,
            storkeWeight: 1,
            fillColor: '#00ff00',
            fillOpacity: 0.6,
            editable: true
        });
        polygon.setMap(map);
    };
    function drawRectangle (map) {
        var bounds = new google.maps.LatLngBounds(
            new google.maps.LatLng(52.827548, -3.915625),
            new google.maps.LatLng(52.427548, -3.15625)
        );
        var rectangle = new google.maps.Rectangle({
            bounds: bounds,
            strokeColor: '#ff0000',
            strokeOpacity: 0.8,
            strokeWeight: 1,
            fillColor: '#00aa00',
            fillOpacity: 0.6,
            draggable: true
        });
        rectangle.setMap(map);
    };
    function drawCircle (map) {
        var circle = new google.maps.Circle({
            map: map,
            center: new google.maps.LatLng(52.489548, -3.515905),
            strokeColor: '#ff0000',
            strokeOpacity: 0.8,
            strokeWeight: 1,
            fillColor: '#00cc00',
            fillOpacity: 0.6
        });
        circle.setRadius(5000); //In meters.
        //circle.setMap(map);
    };
    function geocodeFindAddress(map, address, geocoder) {        
        geocoder.geocode(
            { address: address },
            function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });
                    map.setZoom(17);
                    map.panTo(marker.position);
                } else {
                    alert('Geocode failed with the following error: ' + status);
                }
            });
    }
    function calRoute(map, directionsService, startAddress) {
        var directionsDisplay =
            new google.maps.DirectionsRenderer();
        directionsDisplay.setMap(map);
        directionsDisplay.setPanel(document.getElementById('directionsPanel'));

        var end = new google.maps.LatLng(41.030790, -74.131191);

        var request = {
            origin: startAddress,
            destination: end,
            travelMode: google.maps.TravelMode.DRIVING
        };

        directionsService.route(request,
            function (results, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(results);
                } else {
                    alert('Could not calculate directions. Try again, or buy a map! ;p');
                }
            });
    }


    /*
     * Settup event handlers
     */
    function addGoToInitialExtent(map, initialCenter, initialZoom) {
        google.maps.event.addListener(map, 'rightclick',
            function () {
                map.setCenter(initialCenter);
                map.setZoom(initialZoom);
            });
    }
    function addShowCoords(map) {
        google.maps.event.addListener(map, 'center_changed',
            function () {
                var newCenter = map.getCenter();
                var zoom = map.getZoom();
                document.getElementById('coordsDiv').innerHTML = 'Center: ' + newCenter.toString() + '<br>Zoom: ' + zoom;
            }
        );
    }
    function addGeocoderAddress(map, geocoder) {
        var btnFindAddress = document.getElementById("btnFindAddress");
        google.maps.event.addDomListener(btnFindAddress, 'click',
            function () {
                var address = document.getElementById("address").value;
                geocodeFindAddress(map, address, geocoder);
            });
    }
    function addDirectionService(map, directionsService) {
        var btnFindAddress = document.getElementById("btnFindRoute");
        google.maps.event.addDomListener(btnFindAddress, 'click',
            function () {
                var startAddress = document.getElementById("start").value;
                calRoute(map, directionsService, startAddress)
            });
    }

    /*
     * Register public functions
     */
    module.drawMarkers = drawMarkers.bind(this);    
    module.drawPolyline = drawPolyline.bind(this);    
    module.drawPolygon = drawPolygon.bind(this);
    module.drawRectangle = drawRectangle.bind(this);    
    module.drawCircle = drawCircle.bind(this);
    module.addGoToInitialExtent = addGoToInitialExtent.bind(this);
    module.addShowCoords = addShowCoords.bind(this);
    module.addGeocoderAddress = addGeocoderAddress.bind(this);
    module.addDirectionService = addDirectionService.bind(this);

    /*
     * Returns module object
     */
    return module;

}(sample.googleMaps.polygons || {});