import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { WebcamImage } from "ngx-webcam";
import { environment } from "src/environments/environment";
import { User } from "./models/user";

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private readonly client: HttpClient) {}
 
  postUser(user: User) {
    return this.client.post<User>(environment.apiUrl + 'User', user);
  }

  postImage(user: User, image: File) {
    const formData: FormData = new FormData();
    formData.append('image', image)
    return this.client.post(environment.apiUrl + 'User/Image/' + user.id, formData);
  }

  getBase64Image(user: User) {
    console.log(environment.apiUrl + 'User/Image/'  + user.id)
    return this.client.get(environment.apiUrl + 'User/Image/'  + user.id);
  }

  putUser(user: User) {
    return this.client.put<User>(environment.apiUrl + 'User', user);
  }

  getUsers() {
    return this.client.get<User[]>(environment.apiUrl + 'User');
  }

  deleteUser(userId: string) {
    return this.client.delete(environment.apiUrl + 'User/' + userId);
  }
}