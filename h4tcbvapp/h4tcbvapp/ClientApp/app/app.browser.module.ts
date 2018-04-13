import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { MessageService } from './service/message';
import { AuthenticationService } from './service/authentication';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        HttpModule,
        BrowserModule,
        AppModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        // { provide: 'BASE_U', useFactory: getBaseUrl },  //JWT HEADERS
        { provide: MessageService, useClass: MessageService},
        { provide: AuthenticationService, useClass: AuthenticationService}
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
