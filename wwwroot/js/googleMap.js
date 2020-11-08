




$.get("@Url.Action('GetAllLocation', 'Branches')", function (data, status) {

    var marker = [];
    var info = [];
    var infoWindow = [];

    for (var i = 0; i < data.length; i++) {

        marker[i] = new google.maps.Marker({
            position: { lat: data[i].Latitude, lng: data[i].Longitude },
            map: map
        });

        //info[i] = '<div id="content">' +
        //    '<div id="siteNotice">' +
        //    '</div>' +
        //    '<h1 id="firstHeading" class="firstHeading">' + data[i].Address + '</h1>' 

        //infoWindow[i] = new google.maps.InfoWindow({
        //    content: info[i]
        //});

        //var mdl = marker[i];
        //google.maps.event.addListener(marker, 'mouseover', (function (mdl, i) {
        //    return function () {
        //        infowindow.open(map, marker);
        //    }
        //})(marker, i));
        //google.maps.event.addListener(marker, 'mouseout', (function (mdl, i) {
        //    return function () {
        //        infowindow.close();
        //    }
        //})(marker, i));

    }

})