import { Component, Input, OnInit } from '@angular/core';
import { Loader } from '@googlemaps/js-api-loader';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-maps',
  templateUrl: './maps.component.html',
  styleUrls: ['./maps.component.css']
})
export class MapsComponent implements OnInit {
  private map?: google.maps.Map
  @Input() locationList: any[] = [];

  constructor() { }

  ngOnInit(): void {
    let loader = new Loader({
      apiKey: environment.API_KEY
    })
    console.log(this.locationList)
    loader.load().then(() => {
      console.log('loaded gmaps')
      const locationArr = [
        { lat: 51.233334, lng: 6.783333 },
        { lat: 3.233334, lng: 13.783333 },
        { lat: 33.8547, lng: 35.8623 }
      ]

      this.map = new google.maps.Map(document.getElementById("map")!, {
        center: this.locationList[0],
        zoom: 6
      })

      for (let i = 0; i < this.locationList.length; i++) {
        new google.maps.Marker({
          position: this.locationList[i],
          map: this.map,
        });
      }
      // const marker = new google.maps.Marker({
      //   position: location,
      //   map: this.map,
      // });
      // const marker1 = new google.maps.Marker({
      //   position: location2,
      //   map: this.map,
      // });
      // const marker2 = new google.maps.Marker({
      //   position: location3,
      //   map: this.map,
      // });
    })
  }

  
}


