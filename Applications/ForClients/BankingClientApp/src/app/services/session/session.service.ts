import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { TokenAuthenticationServiceService } from '../security/token-authentication-service.service';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor(private tokenAuthenticationServiceService: TokenAuthenticationServiceService,
    private router: Router) { }

  // Create method that checks if user is logged in
  public isLoggedIn(): boolean {
    const isValid = this.tokenAuthenticationServiceService.isTokenValidByToken(this.getToken()!);
    if(!isValid) {
      this.clearUserSession();
    }
    return isValid;
  }

  // Init session into app: Set token into local storage
  public tryInitSession(token: string): boolean {

    // if token is valid set token into local storage
    if(this.tokenAuthenticationServiceService.isTokenValidByToken(token)) {
      this.assignUserTokenInfo(token);
      return true;
    }
    return false;
  }

  // Get token from local storage
  public getToken(): string | undefined {
    return localStorage.getItem('token') as string| undefined;
  }

  // Get user id from token
  public getUserId(): string | undefined {
    const decodeValues = this.tokenAuthenticationServiceService.decode(this.getToken()!);
    if(decodeValues == null || decodeValues == undefined) {
      return undefined
    }
    return decodeValues['id'];
  }


  // Create method that gets user email from local storage
  public getSessionEmail(): string| undefined {
    // Get email from localStorage
    const email = localStorage.getItem('email');
    return email != null ? email : undefined;
  }

  // Create method that logs user out by clearing local storage
  public clearUserSession(): void {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  // Create method that stores user login info into local storage
  public assignSessionInfo(email: string): void {
    localStorage.setItem('email', email);
  }

  // Create method that stores user token info into local storage
  public assignUserTokenInfo(token: string): void {
    localStorage.setItem('token', token);
  }
}
