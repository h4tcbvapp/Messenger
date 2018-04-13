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
      //create new user
      newUser(): Observable<User[]>  {
            // setting post options
            const body = JSON.stringify(User);
            const header = new Headers();
            header.append("Content-Type","application/json");
            // execute post
            return this.http.post(this.apiUrl + '/api/user', body , { headers: header })
            .map((res:Response) => res.json().console.log(Response))
            .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
            }
            
      // edit existing user details
      editUser(): Observable<User[]>  {
         return this.http.get(this.apiUrl + '/api/user')
         .map((res:Response) => res.json())
         .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
      }

      //delete existing user (deactivate)
      deleteUser(): Observable<User[]>  {
         return this.http.get(this.apiUrl + '/api/user')
         .map((res:Response) => res.json())
         .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
      }
}



  
