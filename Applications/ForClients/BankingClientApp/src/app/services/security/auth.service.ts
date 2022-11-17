import { Injectable } from '@angular/core';
import { SessionService } from '../session/session.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private sessionService: SessionService) { }

  public isAuthorized(): boolean {

    // Check if user is logged in
    const isLogged = this.sessionService.isLoggedIn();

    if(!isLogged) {
      return false;
    }
    console.log('AuthService: isAuthorized()');



    return true;
  }
}
