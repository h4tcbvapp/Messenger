import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AuthenticationService } from '../../service/authentication';
import { User } from '../../model/user';
import { Class } from '../../model/class';

// import { TeacherComponent } 
// import { StudentComponent } 

@Component({
    selector: 'class',
    templateUrl: './class.component.html'
})
export class ClassComponent {

    constructor() {
        // private service: ClassService
    }

    public class: Class = {"name": "", "grade": "", "teacher": "", "student": ""};

    public addClass = () => {
    //   this.service.addClassToEducator(this.user)
    //       .subscribe( data => console.log(data));
    }
}
