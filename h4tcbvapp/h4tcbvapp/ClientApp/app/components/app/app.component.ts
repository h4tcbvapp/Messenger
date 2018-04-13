import { Component, ViewEncapsulation } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Component({
   selector: 'app',
   templateUrl: './app.component.html',
   //styleUrls: ['./app.component.css'],
   encapsulation: ViewEncapsulation.None
})

export class AppComponent {}
