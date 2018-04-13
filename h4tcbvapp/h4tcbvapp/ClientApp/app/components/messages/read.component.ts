import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { MessageService } from '../../service/message';
import { Message } from '../../model/message';

@Component({
    selector: 'message-read',
    templateUrl: './read.component.html'
})
export class CreateMessagesComponent {
    public message = {
        "from": "someone",
        "to": "me",
        "message": "hello1",
        "date" : new Date()
    };

    public createMessage = () => {
        console.log(this.message);
    }
}