import { Component, EventEmitter, Output } from "@angular/core";
import { FormControl, Validators } from "@angular/forms";
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { WebcamImage, WebcamInitError } from "ngx-webcam";
import { Observable, Subject } from 'rxjs';
import { User } from "../api/models/user";
import { UserService } from "../api/user-service";

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent {

  @Output() getPicture = new EventEmitter<WebcamImage>();
  private webcamTrigger: Subject<void> = new Subject<void>();

  webcamImage!: WebcamImage;
  user!: User;
  webcamMode: boolean = false;

  constructor(public dialogRef: MatDialogRef<UserFormComponent>, private userService: UserService){}

  handleImage(webcamImage: WebcamImage) {
    this.getPicture.emit(webcamImage);
    this.webcamMode = false;
    this.webcamImage = webcamImage;
  }

  captureImage(): void {
    this.webcamTrigger.next();
  }

  createOrUpdateUser(): void {
    
    this.userService.getUsers().subscribe(users => {

      const user = users.find(x => x.id == this.user.id);

      if(user) {
        this.userService.putUser(this.user).subscribe(user => {
          if(!this.webcamImage){
            return;
          }
          this.userService.postImage(user, this.convertWebcamImageToFile(this.webcamImage)).subscribe(r => {
          });
        });
      }
      else {
        this.userService.postUser(this.user).subscribe(user => {
          if(!this.webcamImage){
            return;
          }
          this.userService.postImage(user, this.convertWebcamImageToFile(this.webcamImage)).subscribe(r => {
          });
        });
      }
    })


    this.dialogRef.close();
  }

  convertWebcamImageToFile(webcamImage: WebcamImage): File {

    const arr = webcamImage.imageAsDataUrl.split(",");

    const bstr = atob(arr[1]);
    let n = bstr.length;
    const u8arr = new Uint8Array(n);
    while (n--) {
      u8arr[n] = bstr.charCodeAt(n);
    }
    const file: File = new File([u8arr], 'image', { type: 'png' })
    return file;
  }

  abort(): void {
    if(confirm('Are you sure want to abort?')){
      this.dialogRef.close();
    }
  }

  webcamInitFailure(error: WebcamInitError): void {
    alert("Camera module: " + error.message);
    this.webcamMode = false;
  }

  ngOnDestroy(): void {
    this.webcamTrigger.complete();
  }

  get webcamTriggerObservable(): Observable<void> {
    return this.webcamTrigger.asObservable();
  }
}
