import { UserFormComponent } from './user-form/user-form.component';
import { Component } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { User } from './api/models/user';
import { UserService } from './api/user-service';
import { environment } from 'src/environments/environment';
import { DomSanitizer } from '@angular/platform-browser';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  users: User[] = [];
  visible_users: User[] = [];
  imageToShow: any;

 constructor(public dialog: MatDialog, private userService: UserService, 
  public readonly sanitizer: DomSanitizer){ }

  ngOnInit() {
    this.updateUsers();
  }

  search(query: string) {
      this.visible_users = this.users.filter((x) =>
        x.firstName.toLowerCase().includes(query.toLowerCase()) ||
        x.lastName.toLowerCase().includes(query.toLowerCase())
        )
  }

  openCreateUserDialog() {
    const dialogRef = this.dialog.open(UserFormComponent);
    dialogRef.componentInstance.user = new User('', '', '', '', '', true);
    dialogRef.afterClosed().subscribe(() => {
      this.updateUsers();
    })
  }

  openEditUserDialog(user: User) {
    const dialogRef = this.dialog.open(UserFormComponent);
    dialogRef.componentInstance.user = user;
    dialogRef.afterClosed().subscribe(() => {
      this.updateUsers();
    })
  }

  deleteUser(user: User) {
    if(confirm(`Are you sure want to delete user '${user.firstName} ${user.lastName}'?`)) {
      this.userService.deleteUser(user.id).subscribe(r => {
        this.updateUsers();
      })
    }
  }

  updateUsers() {

    this.userService.getUsers().subscribe(r => {
      this.users = r;
      this.visible_users = this.users;
    });
  }

}
