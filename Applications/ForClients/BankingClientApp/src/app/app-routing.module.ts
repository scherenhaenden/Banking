import { MainViewComponent } from './views/main-view/main-view.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/security/auth-guard.service';
import { AccountsViewComponent } from './views/accounts-view/accounts-view.component';
import { LoginViewComponent } from './views/login-view/login-view.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginViewComponent

  },
  { path: '', component: MainViewComponent, canActivate: [AuthGuardService],
    children: [
      { path: 'accounts', component: AccountsViewComponent },
      // add route for security
      {path: 'security', loadChildren: () => import('./modules/security-management/security-management.module').then(m => m.SecurityManagementModule) },

    ]


  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
