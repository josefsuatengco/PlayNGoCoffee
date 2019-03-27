import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  constructor(private http:HttpClient) { 

  }

  public getLocation(){
    return this.http.get('api/Location');
    //http://localhost:52521/
  }

  public getIngredientStocksByLocationId(locationId: number){
    return this.http.get('api/Location/' + locationId.toString());
  }
}
