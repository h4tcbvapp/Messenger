import { Component, Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class ProductService {
   constructor(http: Http, @Inject('BASE_URL') baseUrl: string){ }
   
   getUser() {
      return this.http.get(this.baseUrl + `api/users`)
            .subscribe(result.json() as Users[])
            .map((response: Response) => Users[].response.json())
            .do(data => console.log(JSON.stringify(data)));
   }
}