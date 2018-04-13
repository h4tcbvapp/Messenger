import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserService } from '../../service/user';
@Component({
    selector: 'createaccount',
    templateUrl: './create.component.html'
})
export class CreateAccountComponent {
    public account = {'name': 'test', 'password': '123'};

//     grabFormValuesForPost(userName: string , password: string) {
//       this.service.newUser({userName: userName, password: password})
//         .subscribe( data => console.log(data));
//     }

// public interface Account {
//     userName: string;
//     password: string;
// }


}