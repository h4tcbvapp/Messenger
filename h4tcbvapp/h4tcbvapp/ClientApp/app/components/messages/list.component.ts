import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { MessageService } from '../../service/message';
import { Message } from '../../model/message';

@Component({
    selector: 'messages-list',
    templateUrl: './list.component.html'
})
export class ListMessagesComponent {
    public messages: Message[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private messageService: MessageService) {
        this.messages = this.messageService.listMessages();
    }
}