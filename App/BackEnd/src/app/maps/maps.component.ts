import { Component, OnInit } from '@angular/core';
import { Loader } from '@googlemaps/js-api-loader';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-maps',
  templateUrl: './maps.component.html',
  styleUrls: ['./maps.component.css']
})
export class MapsComponent implements OnInit {
  private map?: google.maps.Map

  constructor() { }

  ngOnInit(): void {
    let loader = new Loader({
      apiKey: environment.API_KEY
    })

    loader.load().then(() => {
      console.log('loaded gmaps')

      const location = { lat: 51.233334, lng: 6.783333 }
      const location2 = { lat: 3.233334, lng: 13.783333 }

      this.map = new google.maps.Map(document.getElementById("map")!, {
        center: location,
        zoom: 6
      })

      const marker = new google.maps.Marker({
        position: location,
        map: this.map,
      });
      const marker1 = new google.maps.Marker({
        position: location2,
        map: this.map,
      });
    })
  }


}
