import { Component, ElementRef, EventEmitter, NgZone, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  constructor() { }

  @Output() emitLocationData = new EventEmitter<any>(); 
  myLatLng = { lat: 53.131083, lng: 23.154742 };
  latitude?: 53.131083;
  longitute?: 23.154742;
  googleMap?: google.maps.Map;
  markers?: google.maps.Marker[] = [];
  counter = 0;
  ngOnInit() {

    var mapCanvas = document.getElementById("map");
    var myCenter = new google.maps.LatLng(53.131083, 23.154742);
    var mapOptions = {
      center: myCenter,
      zoom: 15,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.googleMap = new google.maps.Map(mapCanvas!, mapOptions);
    google.maps.event.addListener(this.googleMap, 'click', (event: any) => {
      if (this.counter != 0) {
        this.deleteMarkers();
      }
      this.placeMarker(event);
      this.counter += 1;
      console.log(this.counter);
    });
  }



  async placeMarker(event: any) {
    console.log(event)
    var position = event.latLng;
    var marker = new google.maps.Marker({
      position,
    });
    this.markers?.push(marker);

    this.showMarkers();
    this.latitude = event.latLng.lat();
    this.longitute = event.latLng.lng();
    console.log(event.latLng.lat() + " " + event.latLng.lng());
    this.emitLocationData.emit({ LATIDUTE: this.latitude, LANGITUDE: this.longitute });
  }

  showMarkers(): void {
    this.setMapOnAll(this.googleMap!);
  }

  setMapOnAll(map: google.maps.Map | null) {
    for (let i = 0; i < this.markers!.length; i++) {
      this.markers![i].setMap(map);
    }
  }
  deleteMarkers(): void {
    this.hideMarkers();
    this.markers = [];
  }
  hideMarkers(): void {
    this.setMapOnAll(null);
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

}






