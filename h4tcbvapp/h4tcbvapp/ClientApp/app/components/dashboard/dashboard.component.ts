import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http'; 
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html'
})


// return Object.create(null, {
//     "all": {
//         value: function () {
//             return firebase.auth().currentUser.getToken(true)
//                 .then(idToken => {
//                     return $http({
//                         method: "POST",
//                         url: `https://h4tcbvapp.azurewebsites.net/home/api/`
//                     }).then(response => {
//                         const data = response.data
//                         this.cache = Object.keys(data).map(key => {
//                             data[key].id = key
//                             return data[key]
//                         })
//                         return this.cache
//                     })
//                 })
//         }
//     }})  

export class DashboardComponent { }
