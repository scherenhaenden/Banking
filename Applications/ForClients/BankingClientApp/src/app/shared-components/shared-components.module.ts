import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PreDoneFormsModule } from './pre-done-forms/pre-done-forms.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PreDoneFormsModule
  ],
  exports:[PreDoneFormsModule]
})
export class SharedComponentsModule { }
