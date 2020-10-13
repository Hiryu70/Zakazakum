import { Component, OnInit } from '@angular/core';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Service, RestaurantVm } from '../api/api.client.generated';
import { RestaurantComponent } from '../restaurant/restaurant.component';

@Component({
  selector: 'app-restaurants-list',
  templateUrl: './restaurants-list.component.html',
  styleUrls: []
})
export class RestaurantsListComponent implements OnInit {
  public restaurants: RestaurantVm[];

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshList();
  }

  refreshList(){
    this.service.restaurant().subscribe(result => {
      this.restaurants = result.restaurants;
    });
  }

  public editRestaurant(restaurant: RestaurantVm) {
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        restaurant: restaurant,
        restaurantsListComponent: this
      }
    };
    this.modalService.show(RestaurantComponent, config);
  }

  newRestaurant(){
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        restaurant: new RestaurantVm(),
        restaurantsListComponent: this
      }
    };
    this.modalService.show(RestaurantComponent, config);
  }
}
