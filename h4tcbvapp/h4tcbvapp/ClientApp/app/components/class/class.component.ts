import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AuthenticationService } from '../../service/authentication';
import { User } from '../../model/user';
// import { TeacherComponent } 
// import { StudentComponent } 

@Component({
    selector: 'class',
    templateUrl: './class.component.html'
})
export class ClassComponent {

    constructor(private service: ClassService) {}

    public user: User = {"username": "", "password": "", token: ""};

    public addClass = () => {
      this.service.addClassToEducator(this.user)
          .subscribe( data => console.log(data));
    }
}
