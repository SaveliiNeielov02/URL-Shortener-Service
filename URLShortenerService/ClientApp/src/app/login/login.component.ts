import { Component, Inject } from '@angular/core';
import { AuthService } from '../auth-service/auth-service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public login: string = '';
  public password: string = '';

  constructor(public authService: AuthService, public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {

  }

  onSubmit() {
    const loginUrl = `${this.baseUrl}urlservice/Authorize/${this.login}/${this.password}`;
    this.http.get(loginUrl).subscribe(result => {
        const parsedResult = result as { roleName: string };
        alert(`Welcome,${parsedResult.roleName}`);
        this.authService.setRole(parsedResult.roleName);
        this.authService.setLogin(this.login);
    },
      error => {
        error = error as { message: string };
        alert(error.message)
      }
    );
  }
}
