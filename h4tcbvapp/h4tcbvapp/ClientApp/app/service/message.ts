import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Message } from '../model/message';

@Injectable()
export class MessageService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private headers: Headers) {}

    public getMessages(student: string): Observable<Message[]> {
        return this.http.get(this.baseUrl + 'api/Messages/GetMessages', {headers: this.headers}).map((response: Response) => {
            console.log(response.json());
            return response.json() as Message[];
        });
    }

    public createMessage(message: Message): Observable<Message> {
        return this.http.post(this.baseUrl + 'api/Message/Post', message).map((response: Response) => {
            message.id = response.json().id;
            return message;
        });
    }

}
