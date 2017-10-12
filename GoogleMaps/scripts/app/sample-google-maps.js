var sample = sample || {};
sample.googleMaps = sample.googleMaps || {}; 

sample.googleMaps = function(module, polygons) {

    var mapOptions = {
        center: new google.maps.LatLng(52.427548, -3.515625),
        zoom: 8,
        /* UI Controls settings */
        disableDefaultUI: true,
        zoomControl: true,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.LARGE,
            positon: google.maps.ControlPosition.BOTTOM_LEFT
        },
        panControl: true, /* Allows moving around the map and also (when zooming) enough doubles as the rotate control */
        mapTypeControl: true,
        mapTypeControlOptions: {
            mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                            google.maps.MapTypeId.HYBRID],
            style: google.maps.MapTypeControlStyle.DROPDOWN_MENU
        },
        scaleControl: true,
        streetViewControl: true, /* Allows dragging the yellow man into the map and activate a stree view */
        rotateControl: true,
        overViewMapControl: true,
        overViewMapControlOptions: {
            opened: true
        },
        navigationControl: true
    };
    var map = new google.maps.Map(document.getElementById("mapDiv"), mapOptions);

    module.CreateMap = function (options) {
        if (!options || !options.container) return null;
        
        var map = new google.maps.Map(document.getElementById(options.container), mapOptions);

        return map;
    };

    module.runSamples = function (map) {
        polygons.drawMarkers(map);
        polygons.drawPolyline(map);
        polygons.drawPolygon(map);
        polygons.drawRectangle(map);
        polygons.drawCircle(map);
    };

    return module;
}(sample.googleMaps || {}, sample.googleMaps.polygons);
