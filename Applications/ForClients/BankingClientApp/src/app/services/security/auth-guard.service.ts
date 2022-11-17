import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private router: Router
    , private authService: AuthService) { }


  public canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    console.log('AuthGuardService: canActivate()');

    if (this.authService.isAuthorized()) {
      // If the user is logged in, allow them to access the route
      return true;
    }
    // If the user is not logged in, redirect them to the login page
    this.router.navigate(['/login']);
    return false;
  }
}

