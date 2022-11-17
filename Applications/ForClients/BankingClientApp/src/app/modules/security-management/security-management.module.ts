import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesViewComponent } from './views/roles-view/roles-view.component';
import { SecurityManagementRoutingModule } from './security-management-routing.module';
import { SecurityTokensViewComponent } from './views/security-tokens-view/security-tokens-view.component';



@NgModule({
  declarations: [
    RolesViewComponent,
    SecurityTokensViewComponent
  ],
  imports: [
    CommonModule,
    SecurityManagementRoutingModule
  ],
  exports: [
    RolesViewComponent,
    SecurityTokensViewComponent
  ]
})
export class SecurityManagementModule { }
