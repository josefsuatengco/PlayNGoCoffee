import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/core/services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {
  public orderHistories: any;

  constructor(private dataService: DataService, private router: Router) {
    this.dataService.getOrderHistories().subscribe(res => { this.orderHistories = res });
  }

  ngOnInit() {
  }

}
