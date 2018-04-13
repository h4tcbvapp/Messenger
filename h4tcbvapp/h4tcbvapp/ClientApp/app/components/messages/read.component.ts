import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { MessageService } from '../../service/message';
import { Message } from '../../model/message';

@Component({
    selector: 'message-read',
    templateUrl: './read.component.html'
})
export class ReadMessagesComponent {

    public message: Message = new Message();
    
    public messages = [{
        "id": "",
        "from": "someone",
        "to": "me",
        "text": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam congue congue elit, eu fermentum urna. Phasellus imperdiet, ante eu vehicula feugiat, est justo venenatis ex, imperdiet tristique lectus quam sed nisi. Quisque magna nulla, mattis eu augue id, lobortis euismod ligula. Vivamus convallis quis ipsum ut dignissim. Fusce nisl nunc, laoreet in est in, porta porttitor dui. Praesent porta dolor vel odio ornare semper. In eu quam convallis, bibendum mauris at, ultrices diam. Vestibulum consequat imperdiet augue, ut mattis est dictum ac.",
        "date" : new Date()
    } as Message];

    public createMessage = () => {
        console.log(this.message);
    }
}