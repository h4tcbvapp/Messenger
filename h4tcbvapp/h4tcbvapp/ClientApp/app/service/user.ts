import { Component, Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { User } from '../user/user.component';
import { Response, Headers } from '\@angular/http';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch';

@Injectable()
export class UserService {

      private apiUrl = 'https://h4tcbvapp.azurewebsites.net'
      constructor(private http: Http){ }
      // list users (Admin functionality)
      getUser(): Observable<User[]>  {
         return this.http.get(this.apiUrl + '/api/user')
         .map((res:Response) => res.json())
         .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
      }

      
      public async postUser(userName: string, password: string): Promise<Message[]> {
          const body = JSON.stringify(User);
          const header = new Headers();
          header.append("Content-Type","application/json");
          return this.messages;
          const response = await this.http.get(this.baseUrl + 'api/messages').toPromise();
          return this.http.post(this.apiUrl + '/api/user', body , { headers: header })
                return response.json() as Message[];
            }

      // edit existing user details
      // editUser(): Observable<User[]>  {
      //    return this.http.put(this.apiUrl + '/api/user')
      //    .map((res:Response) => res.json())
      //    .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
      // }

      //delete existing user (deactivate)
      // deleteUser(): Observable<User[]>  {
      //    return this.http.delete(this.apiUrl + '/api/user')
      //    .map((res:Response) => res.json())
      //    .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
      // }
}



  
