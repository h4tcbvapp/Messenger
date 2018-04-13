import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'messages-list',
    templateUrl: './list.component.html'
})
export class ListMessagesComponent {
    public messages: Messages[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        //http.get(baseUrl + 'api/messages').subscribe(result => {
        //    this.messages = result.json() as Messages[];
        //}, error => console.error(error));
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

interface Messages {
    from: string;
    to: string;
    message: string;
    date: Date;
}