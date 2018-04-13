import {Component, Inject} from '@angular/core';
import {Http} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {MessageService} from '../../service/message';
import {Message} from '../../model/message';

@Component({
  selector: 'messages-list',
  templateUrl: './list.component.html',
})
export class ListMessagesComponent {
  public student: string;

  public messages: Message[];

  constructor(
    http: Http,
    @Inject('BASE_URL') baseUrl: string,
    private messageService: MessageService
  ) {
    this.messageService
      .getMessages(this.student)
      .subscribe(messages => (this.messages = messages));
  }
}
