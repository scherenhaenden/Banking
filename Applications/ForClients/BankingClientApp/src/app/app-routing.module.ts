import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/security/auth-guard.service';
import { AccountsViewComponent } from './views/accounts-view/accounts-view.component';
import { LoginViewComponent } from './views/login-view/login-view.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginViewComponent  },
  { path: 'accounts', component: AccountsViewComponent, canActivate: [AuthGuardService] },
  // add route that needs authentication

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
