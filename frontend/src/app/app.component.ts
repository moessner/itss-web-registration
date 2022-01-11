import { UserFormComponent } from './user-form/user-form.component';
import { Component } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { User } from './models/user';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

 constructor(public dialog: MatDialog){}

  users = [
    new User('1', 'Fabian', 'Mößner', 'Administrator', 'Blumenstraße 69, 70435 Stuttgart, Germany', 'no image', true),
    new User('2', 'Fabian', 'Mößner', 'Administrator', 'Blumenstraße 69, 70435 Stuttgart, Germany', 'no image', true),
    new User('3', 'Fabian', 'Mößner', 'Administrator', 'Blumenstraße 69, 70435 Stuttgart, Germany', 'no image', true),
    new User('4', 'Fabian', 'Mößner', 'Administrator', 'Blumenstraße 69, 70435 Stuttgart, Germany', 'no image', true),
  ]

  visible_users = this.users;

  ngOnInit(): void {
    this.visible_users = this.users;
  }

  search(query: string): void{
      this.visible_users = this.users.filter((x) =>
        x.firstName.toLowerCase().includes(query.toLowerCase()) ||
        x.lastName.toLowerCase().includes(query.toLowerCase())
        )
  }

  createUser() {
    const dialogRef = this.dialog.open(UserFormComponent);
    dialogRef.componentInstance.user = new User('', '', '', '', '', '', true);
    // todo: create user
  }

  editUser(user: User): void {
    const dialogRef = this.dialog.open(UserFormComponent);
    dialogRef.componentInstance.user = user;
    // todo: edit user
  }

  deleteUser(user: User): void {
    if(confirm(`Are you sure want to delete user '${user.firstName} ${user.lastName}'?`)) {
      // todo: delete user
    }
  }

}
