import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-coffee-app',
  templateUrl: './coffee-app.component.html'
})
export class CoffeeAppComponent {
  public locations: LocationDataModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<LocationDataModel[]>(baseUrl + 'api/Coffee/GetLocations').subscribe(result => {
      this.locations = result;
    }, error => console.error(error));
  }
}

interface LocationDataModel {
  id: number;
  locationName: string;
  description: string;
}
