import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'createaccount',
    templateUrl: './create.account.component.html'
})
export class CreateAccountComponent {
    public account = {'name': 'test', 'password': '123'};

    public createUser = () => console.log(this.account);
}

interface Account {
    name: string;
    password: string;
}
