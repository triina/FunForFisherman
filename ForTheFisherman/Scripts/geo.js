if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(success);
} else {
    error("Geolocation is not supported.");
}

function success(position) {
    var lat = position.coords.latitude;
    var long = position.coords.longitude;
    document.getElementById("latitude").innerText = lat;
    document.getElementById("longitude").innerText = long;
}