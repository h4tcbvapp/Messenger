export class User {
 
    id: string;
    userName: string;
    password: string;
   
    constructor(id: string, userName: string, password: string, email: string){
      this.id = id;
      this.userName = userName;
      this.password = password;
    }
   
  }