import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserService } from '../services/userFactory.component';
@Component({
    selector: 'create-account',
    templateUrl: './create.component.html'
})
export class CreateAccountComponent {
    public account = {'name': 'test', 'password': '123'};

    
        UserService.newUser()

interface Account {
    name: string;
    password: string;
}
