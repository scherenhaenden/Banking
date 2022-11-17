import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RolesViewComponent } from './views/roles-view/roles-view.component';

const routes: Routes = [
  //{ path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '', component: RolesViewComponent  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityManagementRoutingModule { }
