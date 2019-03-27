import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/core/services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private dataService: DataService, private router:Router) {
    this.dataService.getLocation().subscribe(res => { this.locations = res });
  }

  public onClick(id:number){
    this.router.navigate(['location/' + id]);
  }

  public locations: any;

  ngOnInit() {
  }

}
