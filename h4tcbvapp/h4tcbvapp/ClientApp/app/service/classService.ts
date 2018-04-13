// import {Component, Inject, Injectable} from '@angular/core';
// import {Http} from '@angular/http';
// import {Observable} from 'rxjs/Observable';
// import { Class } from '../model/class';
// import {Response, Headers} from '\@angular/http';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/catch';

// @Injectable()
// export class ClassService {
//   private apiUrl = 'https://h4tcbvapp.azurewebsites.net';
//   constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private headers: Headers) {}

//   // list class (Admin functionality)
//   //   public getClass(): Observable<Class[]>
//   //      return this.http.get(this.apiUrl + '/api/Authentication')
//   //      .map((res:Response) => res.json())
//   //      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
//   //   }

//   public addClassForEducator(
//     className: string,
//     password: string
//   ): Observable<boolean> {
//     return this.http
//       .post(this.baseUrl + 'api/Class/Post', class)
//       .map((response: Response) => {
//         class.name = response.json().name;
//         return class;
//       });
//   }
// }
