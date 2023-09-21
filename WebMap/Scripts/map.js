function initMap() {
    var infoWindow = new google.maps.InfoWindow();
    var center = { lat: locationsData[0].Latitude, lng: locationsData[0].Longitude };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 5,
        center: center
    });

    function createMarker(position, Site_Name) {
        var marker = new google.maps.Marker({
            position: position,
            map: map,
            title: Site_Name
        });
        marker.addListener('click', function () {
            infoWindow.setContent(Site_Name);
            infoWindow.open(map, marker);
        });
    }

    locationsData.forEach(location => {
        if (location.Latitude && location.Longitude) {
            var position = { lat: location.Latitude, lng: location.Longitude };
            createMarker(position, location.Site_Name);
        }
    });
}

