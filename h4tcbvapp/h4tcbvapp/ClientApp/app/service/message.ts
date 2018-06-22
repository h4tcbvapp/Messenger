import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Message } from '../model/message';

@Injectable()
export class MessageService {

    public messages: Message[] = [
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

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {}

    public async getMessages(student: string): Promise<Message[]> {
        return Promise.resolve(this.messages);
        // const response = await this.http.get(this.baseUrl + 'api/messages').toPromise();
        // return response.json() as Message[];
    }

    public async createMessage(message: Message): Promise<Message> {
        this.messages.push(message);
        return Promise.resolve(message);
        //const response = await this.http.post(this.baseUrl + 'api/messages', message).toPromise();
        //message.id = response.json() as string;
        //return message;
    }

}
