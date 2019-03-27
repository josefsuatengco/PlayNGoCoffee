import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-coffee-app',
  templateUrl: './coffee-app.component.html'
})
export class CoffeeAppComponent {
  public locations: LocationDataModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _router:Router) {
    http.get<LocationDataModel[]>(baseUrl + 'api/Coffee/Initialize',).subscribe(result => {
      this.locations = result;
    }, error => console.error(error));
  }

  onClick(locationId: number) {
    this._router.navigate(['/Controllers/Coffee', locationId]);
  }
}

interface LocationDataModel {
  id: number;
  locationName: string;
  description: string;
}
