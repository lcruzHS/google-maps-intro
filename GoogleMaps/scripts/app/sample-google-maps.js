var sample = sample || {};
sample.googleMaps = sample.googleMaps || {}; 

sample.googleMaps = function(module, polygons) {

    this.mapOptions = {
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

    /* Used to set the route between two addresses  */
    this.directionsService = new google.maps.DirectionsService();

    /* Used to allow the user get back to the initial position (and zoom level) on the map */
    this.initialCenter = mapOptions.center;
    this.initialZoom = mapOptions.zoom;

    function createMap(options) {
        if (!options || !options.container) return null;
        
        var map = new google.maps.Map(document.getElementById(options.container), mapOptions);

        return map;
    }

    function createGeocoder(map) {
        var geocoder = new google.maps.Geocoder();
       // geocoder.setMap(map);
        return geocoder;
    }

    function createDirectionsService(map) {
        var directionsService = new google.maps.DirectionsService();

        return directionsService;
    }

    function runSamples(options) {
        polygons.addDirectionService(options.map, options.directionsService)
        //polygons.addGeocoderAddress(options.map, options.geocoder);
        polygons.addGoToInitialExtent(options.map, this.initialCenter, this.initialZoom);
        //polygons.addShowCoords(options.map);
        polygons.drawMarkers(options.map);
        polygons.drawPolyline(options.map);
        polygons.drawPolygon(options.map);
        polygons.drawRectangle(options.map);
        polygons.drawCircle(options.map);
    };

    function initialize() {
    }

    module.initialize = initialize.bind(this);
    module.createMap = createMap.bind(this);
    module.createGeocoder = createGeocoder.bind(this);
    module.createDirectionsService = createDirectionsService.bind(this);
    module.runSamples = runSamples.bind(this);

    return module;
}(sample.googleMaps || {}, sample.googleMaps.polygons);
