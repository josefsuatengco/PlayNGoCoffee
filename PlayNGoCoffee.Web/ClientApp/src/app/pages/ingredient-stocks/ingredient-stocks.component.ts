import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-ingredient-stocks',
  templateUrl: './ingredient-stocks.component.html',
  styleUrls: ['./ingredient-stocks.component.css']
})
export class IngredientStocksComponent implements OnInit {
  public ingredients:any;

  constructor(private activatedRoute:ActivatedRoute, private dataService:DataService) 
  { 
    let locationId = activatedRoute.snapshot.params['id'];
    console.log(locationId);

    this.dataService.getIngredientStocksByLocationId(locationId).subscribe(res => {this.ingredients = res});
  }

  ngOnInit() {
  }

}
