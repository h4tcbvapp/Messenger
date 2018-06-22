import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Message } from '../../model/message';

@Component({
    selector: 'messages-create',
    templateUrl: './create.component.html'
})
export class CreateMessagesComponent {
    public message = {
            "from": "someone",
            "to": "me",
            "message": "hello1",
            "date" : new Date()
    };

    public createMessage = () => {
        //console.log(message);
    }
}