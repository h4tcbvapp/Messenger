import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Message } from '../../model/message';

@Component({
    selector: 'messages-list',
    templateUrl: './list.component.html'
})
export class ListMessagesComponent {
    public messages: Message[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.messages = [
            {
                "from": "someone",
                "to": "me",
                "message": "hello1",
                "date" : new Date()
            },
            {
                "from": "someone2",
                "to": "me",
                "message": "hello2",
                "date" : new Date()
            }
        ];
    }
}