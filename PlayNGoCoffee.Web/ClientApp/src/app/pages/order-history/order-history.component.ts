import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/core/services/data.service';
import { Router } from '@angular/router';
import * as CanvasJS from 'src/app/scripts/canvasjs.min';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {
  public orderHistories: any;
  public chartData: any;

  constructor(private dataService: DataService, private router: Router) {
    this.dataService.getOrderHistories().subscribe(res => {this.orderHistories = res;});

    this.dataService.getHistoryChartData().subscribe(res => {
      this.chartData = res;
      this.loadChart();
    });
  }

  public loadChart() {
    let dataPoints = [];
    this.chartData.forEach(function (data) {
      dataPoints.push({y:data.quantity, name:data.name});
    });

    let chart = new CanvasJS.Chart("chartContainer", {
      theme: "light2",
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: "Coffee Distribution"
      },
      data: [{
        type: "pie",
        showInLegend: true,
        toolTipContent: "<b>{name}</b>: {y} (#percent%)",
        indexLabel: "{name} - {y}",
        dataPoints: dataPoints
      }]
    });

    chart.render();
  }

  ngOnInit() {
    
  }

}
