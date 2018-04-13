import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserService } from '../../service/user';
//import { UserService } from '../../services/user';
//import { User } from '../../model/user';
@Component({
    selector: 'createaccount',
    templateUrl: './create.component.html'
})
export class CreateAccountComponent {
    //constructor(private service: UserService) {}

    //public user: User = {};

    createUser() {
      //this.service.createUser(user)
      //    .subscribe( data => console.log(data));
    }
}
