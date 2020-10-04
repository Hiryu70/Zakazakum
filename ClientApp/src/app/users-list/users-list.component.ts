import { Component, OnInit } from '@angular/core';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
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
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        user: user,
        usersListComponent: this
      }
    };
    this.modalService.show(UserComponent, config);
  }

  newUser(){
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        user: new UserVm(),
        usersListComponent: this
      }
    };
    this.modalService.show(UserComponent, config);
  }

  refreshList(){
    this.service.user().subscribe(result => {
      this.users = result.users;
    });
  }
}
