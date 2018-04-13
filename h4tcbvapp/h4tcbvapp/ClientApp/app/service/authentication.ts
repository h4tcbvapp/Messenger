import { Component, Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { User } from '../model/user';
import { Response, Headers } from '\@angular/http';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch';

@Injectable()
export class AuthenticationService {

      private apiUrl = 'https://h4tcbvapp.azurewebsites.net'

      constructor(private http: Http, private header: Headers){ }
      // list users (Admin functionality)

      getUser(): Observable<User[]>  {
         return this.http.get(this.apiUrl + '/api/user')
         .map((res:Response) => res.json())
         .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
      }


      public loginWithToken(user: User): Observable<boolean> {
            return this.http.post('/api/Token', JSON.stringify(user), { headers: this.header })
                .map((response: Response) => {
                    // login successful if there's a jwt token in the response
                    let token = response.json() && response.json().token;
                    if (token) {
                        // set token property
                        user.token = token;
                        this.header.append("Authorization", token);

                        // store username and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem('currentUser', JSON.stringify(user));

                        // return true to indicate successful login
                        return true;
                    } else {
                        // return false to indicate failed login
                        return false;
                    }
                });
      }
}



  
