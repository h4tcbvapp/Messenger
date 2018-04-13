import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CreateAccountComponent } from './components/account/create.component';
import { ListMessagesComponent } from './components/messages/list.component';
import { LoginComponent } from './components/login/login.component';
import { MessageService } from './service/message';
import { AuthenticationService } from './service/authentication';
import { Headers } from '\@angular/http';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CreateAccountComponent,
        ListMessagesComponent,
        LoginComponent
    ],
    providers: [
        { provide: MessageService, useClass: MessageService},
        { provide: AuthenticationService, useClass: AuthenticationService}
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'create-account', component: CreateAccountComponent },
            { path: 'list-messages', component: ListMessagesComponent },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
