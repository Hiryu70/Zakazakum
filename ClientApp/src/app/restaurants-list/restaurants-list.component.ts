import { Component, OnInit } from '@angular/core';
import { Service, RestaurantVm } from '../api/api.client.generated';

@Component({
  selector: 'app-restaurants-list',
  templateUrl: './restaurants-list.component.html',
  styleUrls: []
})
export class RestaurantsListComponent implements OnInit {
  public restaurants: RestaurantVm[];

  constructor(private service: Service) { }

  ngOnInit() {
    this.refreshList();
  }

  refreshList(){
    this.service.restaurant().subscribe(result => {
      this.restaurants = result.restaurants;
    });
  }
}
