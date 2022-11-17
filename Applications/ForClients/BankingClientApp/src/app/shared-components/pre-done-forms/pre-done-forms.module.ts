import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericFormInputComponent } from './generic-form-input/generic-form-input.component';



@NgModule({
  declarations: [
    GenericFormInputComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[GenericFormInputComponent]
})
export class PreDoneFormsModule { }
