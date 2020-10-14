window.geoJsFunctions = {
    getLocation: function () {
        if (navigator.geolocation) {
            console.log("geo support");
            navigator.geolocation.getCurrentPosition(this.showPosition);
        } else {
            console.log("Geolocation is not supported by this browser.");
        }
    },
    showPosition: function(position) {
        console.log("Latitude: " +
            position.coords.latitude +
            "<br>Longitude: " +
            position.coords.longitude);
        DotNet.invokeMethodAsync("BlazorApp1", "GetGeo", position.coords.latitude, position.coords.longitude);
    }
};