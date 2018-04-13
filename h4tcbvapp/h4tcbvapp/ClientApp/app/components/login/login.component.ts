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

    public loggedIn: boolean = false;

    public displayLoginMessage: boolean = false;

    public user: User = new User();

    public login = () => {
      try {
          this.service.loginWithToken(this.user).subscribe( loggedIn => {
                this.loggedIn = loggedIn
          });
      }
      finally {
          this.displayLoginMessage = true;
      }

    }
}
