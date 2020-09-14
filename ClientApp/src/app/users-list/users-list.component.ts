import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Service, UserVm } from '../api/api.client.generated';
import { UserComponent } from '../user/user.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: []
})
export class UsersListComponent implements OnInit {
  public users: UserVm[];

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshList();
  }

  public editUser(user: UserVm) {
    const initialState = {
      user: user,
      usersListComponent: this
    };
    this.modalService.show(UserComponent, { initialState });
  }

  newUser(){
    const initialState = {
      user: new UserVm(),
      usersListComponent: this
    };
    this.modalService.show(UserComponent, { initialState });
  }

  refreshList(){
    this.service.user().subscribe(result => {
      this.users = result.users;
    });
  }
}
