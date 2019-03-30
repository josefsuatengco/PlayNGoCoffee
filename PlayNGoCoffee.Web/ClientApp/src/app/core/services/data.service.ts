import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public retPutData: any;

  constructor(private http: HttpClient, private router: Router) {

  }

  public getLocation() {
    return this.http.get('api/Location');
  }

  public getIngredientStocksByLocationId(locationId: number) {
    return this.http.get('api/Location/' + locationId.toString());
  }

  public getAllRecipesDataModel() {
    return this.http.get('api/Recipe');
  }

  public getRecipeIngredientsDataModelById(recipeId: number) {
    return this.http.get('api/RecipeIngredients/' + recipeId.toString());
  }

  public getAllRecipeIngredientsDataModel() {
    return this.http.get('api/RecipeIngredients');
  }

  public getOrderHistories() {
    return this.http.get('api/OrderHistory');
  }

  public getHistoryChartData() {
    return this.http.get('api/HistoryChartData');
  }

  public updateStock(locationId: number, updatedStocks: object, recipeId: number) {
    let value = JSON.stringify(updatedStocks);
    let url = '/api/RecipeIngredients/' + recipeId.toString();
    return this.http.put(url, value,{headers: new HttpHeaders({ 'Content-Type': 'application/json' })})
      .subscribe(response => {
        alert("Coffee Made!");
        location.reload(true);
      });
  }
}
