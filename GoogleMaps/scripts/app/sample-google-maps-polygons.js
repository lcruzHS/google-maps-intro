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

    module.drawMarkers = drawMarkers.bind(this);    
    module.drawPolyline = drawPolyline.bind(this);    
    module.drawPolygon = drawPolygon.bind(this);
    module.drawRectangle = drawRectangle.bind(this);    
    module.drawCircle = drawCircle.bind(this);

    return module;

}(sample.googleMaps.polygons || {});