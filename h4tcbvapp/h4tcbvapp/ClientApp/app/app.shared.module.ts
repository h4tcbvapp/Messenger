import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule, Headers } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CreateAccountComponent } from './components/account/create.component';
import { ListMessagesComponent } from './components/messages/list.component';
import { LoginComponent } from './components/login/login.component';
import { MessageService } from './service/message';
import { AuthenticationService } from './service/authentication';
// import { ClassComponent } from './components/class/class.component';
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CreateAccountComponent,
        ListMessagesComponent,
        LoginComponent,
        // ClassComponent
    ],
    providers: [
        { provide: MessageService, useClass: MessageService},
        { provide: AuthenticationService, useClass: AuthenticationService},
        { provide: Headers, useFactory: commonHeaders}
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'create-account', component: CreateAccountComponent },
            // { path: 'class', component: ClassComponent },
            { path: 'list-messages', component: ListMessagesComponent },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

export function commonHeaders(): Headers {
    const header = new Headers();
    header.append("Content-Type","application/json");
    return header;
}