import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AuthenticationService } from '../../service/authentication';
import { User } from '../../model/user';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {

    constructor(private service: AuthenticationService) {}

    public user: User = {userName: "", password: ""} as User;

    public login = () => {
      this.service.loginWithToken(this.user)
          .subscribe( data => console.log(data));
    }
}
