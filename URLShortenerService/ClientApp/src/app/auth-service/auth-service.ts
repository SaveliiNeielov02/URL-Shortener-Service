import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService{
  /*private role: string = 'Unauthorized';*/
  private roleSubject: string = 'Unauthorized'; // Измените тип на ваш тип роли
  private loginSubject: string = '';

  setRole(role: string) {
    this.roleSubject = role;
  }
  getRole(): string {
    return this.roleSubject;
  }

  setLogin(login: string) {
    this.loginSubject = login;
  }
  getLogin(): string {
    return this.loginSubject;
  }
  isAdmin(): boolean {
    return this.roleSubject == "Admin";
  }
  isOrdinary(): boolean {
    return this.roleSubject == "Ordinary";
  }

}
