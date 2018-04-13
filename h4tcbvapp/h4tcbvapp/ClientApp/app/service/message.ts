import { Http } from '@angular/http';
import { Message } from '../model/message';

export class MessageService {

    private string baseUrl;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    public async getMessages(student: string): Promise<Message> {
        const response = await this.http.get(this.baseUrl + 'api/messages').toPromise();
        return response.json() as Message[];
    }

}
