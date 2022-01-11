import { Component, EventEmitter, Output } from "@angular/core";
import { FormControl, Validators } from "@angular/forms";
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { WebcamImage, WebcamInitError } from "ngx-webcam";
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent {

  @Output() getPicture = new EventEmitter<WebcamImage>();
  private webcamTrigger: Subject<void> = new Subject<void>();

  webcamImage: WebcamImage | undefined;
  user: any;
  roles: string[];
  webcamMode: boolean = false;

  constructor(public dialogRef: MatDialogRef<UserFormComponent>){
    this.roles = ['Administrator', 'Visitor']
  }

  handleImage(webcamImage: WebcamImage) {
    this.getPicture.emit(webcamImage);
    this.webcamMode = false;
    this.webcamImage = webcamImage;
  }

  captureImage(): void {
    this.webcamTrigger.next();
  }

  createOrUpdateUser(): void {
    console.log("create user");
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

  get webcamTriggerObservable(): Observable<void> {
    return this.webcamTrigger.asObservable();
  }
}
