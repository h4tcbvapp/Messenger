import { Component, Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
// import { Class } from '../model/class';
import { Response, Headers } from '\@angular/http';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch';

@Injectable()
export class ClassService {

      private apiUrl = 'https://h4tcbvapp.azurewebsites.net'
      constructor(private http: Http){ }
}
      // list classs (Admin functionality)
    //   public getClass(): Observable<Class[]>
    //      return this.http.get(this.apiUrl + '/api/Authentication')
    //      .map((res:Response) => res.json())
    //      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    //   }

    // public loginWithToken(className: string, password: string): Observable<boolean> {
    //         return this.http.post('/api/Token', JSON.stringify({ classname: classname, password: password }))
    //             .map((response: Response) => {
    //                 // login successful if there's a jwt token in the response
    //                 let token = response.json() && response.json().token;
    //                 if (token) {
    //                     // set token property
    //                     token = token;
    
    //                     // store classname and jwt token in local storage to keep class logged in between page refreshes
    //                     localStorage.setItem('currentClass', JSON.stringify({ classname: classname, token: token }));
    
    //                     // return true to indicate successful login
    //                     return true;
    //                 } else {
    //                     // return false to indicate failed login
    //                     return false;
    //                 }
    //             });
    //     }




  
