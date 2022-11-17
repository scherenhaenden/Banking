import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-generic-form-input',
  templateUrl: './generic-form-input.component.html',
  styleUrls: ['./generic-form-input.component.scss']
})
export class GenericFormInputComponent implements OnInit {

  @ViewChild('el')
  span!: ElementRef;

  @Input() public InputPropertiesModel!: string[];

  constructor() { }

  ngOnInit(): void {
    this.setPropertiesOnElement();
  }

  private setPropertiesOnElement(): void {

    // Check if element is null or undefined
    if (this.span?.nativeElement == null || this.span?.nativeElement == undefined) { return; }

    // Check if InputPropertiesModel is null or undefined
    if (this.InputPropertiesModel == null || this.InputPropertiesModel == undefined) { return; }

    // Set Elements of array into element
    for (let i = 0; i < this.InputPropertiesModel.length; i++) {
      this.span.nativeElement.setAttribute(this.InputPropertiesModel[i], this.InputPropertiesModel[i]);
    }




    //this.span.nativeElement.setAttribute('keyProperty', this.InputPropertiesModel.keyProperty);
    //this.span.nativeElement.setAttribute('keyValue', this.InputPropertiesModel.keyValue);

      //this.span.nativeElement.setAttribute('type', this.InputPropertiesModel.type);
      //this.span.nativeElement.setAttribute('name', this.InputPropertiesModel.name);
      //this.span.nativeElement.setAttribute('label', this.InputPropertiesModel.label);
      //this.span.nativeElement.setAttribute('placeholder', this.InputPropertiesModel.placeholder);
      //this.span.nativeElement.setAttribute('value', this.InputPropertiesModel.value);
      //this.span.nativeElement.setAttribute('required', this.InputPropertiesModel.required

  }



}
