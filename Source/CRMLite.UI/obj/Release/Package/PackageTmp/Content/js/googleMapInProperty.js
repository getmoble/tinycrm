var lat = 0;
var log = 0;
if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition);
} else {
    alert("Geolocation is not supported by this browser.");
}

function showPosition(position) {
    //map
    var myLatlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    var myOptions = {
        center: myLatlng,
        zoom: 6,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
    google.maps.event.addListenerOnce(map, 'idle', function () {
        google.maps.event.trigger(map, 'resize');
    });
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: "lat: " + position.coords.latitude + " long: " + position.coords.longitude,
        draggable: true
    });
    google.maps.event.addListener(marker, 'dragend', function (marker) {
        var latLng = marker.latLng;
        $("#hdlogitude").val(latLng.lng());
        $("#hdlatitude").val(latLng.lat());
    });
}