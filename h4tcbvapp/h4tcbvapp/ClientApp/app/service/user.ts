import { Component, Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { User } from '../model/user';
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
      
    //   public async createUser(userName: string, password: string): Promise<User[]> {
    //       const body = JSON.stringify(User);
    //       const header = new Headers();
    //       header.append(
    //               "Content-Type",
    //               "application/json",
    //               );
    //       const response = await this.http.post(this.apiUrl + '/api/user', body , { headers: header });
    //             return response.json() as User[];
    //         }


    public loginWithToken(username: string, password: string): Observable<boolean> {
            return this.http.post('/api/Token', JSON.stringify({ username: username, password: password }))
                .map((response: Response) => {
                    // login successful if there's a jwt token in the response
                    let token = response.json() && response.json().token;
                    if (token) {
                        // set token property
                        token = token;
    
                        // store username and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token }));
    
                        // return true to indicate successful login
                        return true;
                    } else {
                        // return false to indicate failed login
                        return false;
                    }
                });
        }


















      // // edit existing user details
      // public async editUser(userName: string, password: string): Promise<User[]>  {
      //       const body = JSON.stringify(User);
      //       const header = new Headers();
      //       header.append("Content-Type","application/json");
      //       const response = await this.http.post(this.apiUrl + '/api/user', body , { headers: header }).toPromise();
      //             return response.json() as User[];
      // }

      // // delete existing user (deactivate)
      // public async deleteUser(userName: string, password: string): Promise<User[]>  {
      //       const options = JSON.stringify(User);
      //       const header = new Headers();
      //       header.append("Content-Type","application/json");
      //       const response = await this.http.delete(this.apiUrl + '/api/user', options , { headers: header }).toPromise();
      //             return response.json() as User[];
      // }
}



  
