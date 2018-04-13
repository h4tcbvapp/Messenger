import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Message } from '../../model/message';

@Component({
    selector: 'messages-create',
    templateUrl: './create.component.html'
})
export class CreateMessagesComponent {
    public message = {};

    public createMessage = () => {
        console.log(message);
    }
}