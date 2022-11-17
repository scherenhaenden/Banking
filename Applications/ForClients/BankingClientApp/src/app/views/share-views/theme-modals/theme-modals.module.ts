import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlertSimpleMessagesComponent } from './alert-simple-messages/alert-simple-messages.component';



@NgModule({
  declarations: [
    AlertSimpleMessagesComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    AlertSimpleMessagesComponent
  ]
})
export class ThemeModalsModule { }
