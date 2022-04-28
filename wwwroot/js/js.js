mapboxgl.accessToken = "pk.eyJ1Ijoic3RlcGhlbnNvbi1oZXJpdGFnZSIsImEiOiJjanZ4ejlxazMwYWRlNDhrOHJxN2hlZGl5In0.GvwpDRkNHQKPfS8S2SA4Dg";
let map;

let hydrants = [];

let getHydrants = async() => {

    let hydrantsFetchResult = await fetch('https://localhost:7132/hydrant', {
        mode: 'no-cors'
    });
    let hydrantsText = await hydrantsFetchResult.text();
    let hydrantsDOM = (new window.DOMParser()).parseFromString(hydrantsText, "text/xml");


    let hydrantsListEl = hydrantsDOM.querySelectorAll('BORNE_FONTAINE')



    let i = 0;

    hydrantsListEl.forEach((el) => {
        i++;

        if (i % 10 == 0) {
            //POINT (-75.805517 45.420381)

            let locString = el.childNodes[19].innerHTML;
            locString = locString.substring(7, locString.length - 1).split(' ');
            lng = locString[0];
            lat = locString[1];
            //console.log({ "lat": lat, "lng": lng });
            hydrants.push(new mapboxgl.Marker().setLngLat([lng, lat]).addTo(map));
        }
    });





};


let mapInit = function() {
    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/stephenson-heritage/cl2aikyg4000n15nuwwy5u72c',
        center: [-75.765, 45.456],
        zoom: 13.5
    });
}

mapInit();
getHydrants();