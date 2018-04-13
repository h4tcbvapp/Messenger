import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { MessageService } from '../../service/message';
import { Message } from '../../model/message';

@Component({
    selector: 'message-read',
    templateUrl: './read.component.html'
})
export class ReadMessagesComponent {

    public message: Message = {id: "", from: "", to: "", text: "", date: new Date()} as Message;
    
    public messages = [{
        "from": "someone",
        "to": "me",
        "message": "hello1",
        "date" : new Date()
    }];

    public createMessage = () => {
        console.log(this.message);
    }
}