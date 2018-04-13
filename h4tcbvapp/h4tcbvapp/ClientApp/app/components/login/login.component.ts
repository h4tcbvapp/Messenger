import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { Http } from '@angular/http';
import { AuthenticationService } from '../../service/authentication';
import { User } from '../../model/user';
import 'rxjs/add/operator/finally';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    encapsulation: ViewEncapsulation.None
})
export class LoginComponent {

    constructor(private service: AuthenticationService) {}

    public loggedIn: boolean = false;

    public displayLoginMessage: boolean = false;

    public user: User = new User();

    public login = () => {
      this.service.loginWithToken(this.user).subscribe( 
          loggedIn => this.loggedIn = loggedIn,
          error => {},
          () => this.displayLoginMessage = true
      );
    }
}
