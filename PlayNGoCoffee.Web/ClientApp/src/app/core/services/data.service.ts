import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public recipeIngredients: any;

  constructor(private http: HttpClient) {

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

  public updateStock(locationId: number, updatedStocks: object) {
    let value = JSON.stringify(updatedStocks);
    let url = '/api/RecipeIngredients/'+locationId;
    return this.http.put<void>(url, value, {headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }
}
