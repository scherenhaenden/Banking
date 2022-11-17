import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-template-view-login',
  templateUrl: './template-view-login.component.html',
  styleUrls: ['./template-view-login.component.scss']
})
export class TemplateViewLoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.loadThisShit();
  }

  private loadThisShit() {

    const hhh = 'class="form-control form-control-user" type="email" id="exampleInputEmail" aria-describedby="emailHelp" placeholder="Enter Email Address..." name="email"';


    this.getValuePairs(hhh);

  }




  // Create method to parse string of properties into array
  /**
   * readPRopertiesAndValuesfromStrings
   * @param propertiesAndValuesString
   * @returns
   */
  public readPRopertiesAndValuesfromStrings(propertiesAndValuesString: string) {

    // Parse 'class="form-control form-control-user" type="email" id="exampleInputEmail" aria-describedby="emailHelp" placeholder="Enter Email Address..." name="email"' into array

    console.log('propertiesAndValuesString: ', propertiesAndValuesString);

    // Split string into array
    let propertiesAndValuesArray = propertiesAndValuesString.split(' ');

    console.log('propertiesAndValuesArray: ', propertiesAndValuesArray);

    // Create array to hold properties and values
    let propertiesAndValuesArray2: string[] = [];

    // Loop through array
    for (let i = 0; i < propertiesAndValuesArray.length; i++) {

        // Split string into array
        let propertyAndValue = propertiesAndValuesArray[i].split('=');

        // Push property and value into array
        propertiesAndValuesArray2.push(propertyAndValue[0]);
        propertiesAndValuesArray2.push(propertyAndValue[1]);

     }

     console.log('propertiesAndValuesArray2: ', propertiesAndValuesArray2);

  }

  public getValuePairs (val: string):string []{

    var listOfValues: string[] = [];

    const propertyNameAndString = this.getProperty(val);

    const propertyName = propertyNameAndString[0];



    console.log('propertyNameAndString: ', propertyNameAndString);

    console.log('propertyName: ', propertyName);

    const propertyValueAndString = this.getValue(propertyNameAndString[1])

    const propertyValue = propertyValueAndString[0];



    console.log('propertyValueAndString: ', propertyValueAndString);

    console.log('propertyValue: ', propertyValue);


    console.log('val: ', val);





    return listOfValues;

  }


  public getProperty (val: string):[string, string] {

    const fIndex = val.indexOf("=");

    console.log('fIndex: ', fIndex);

    if(fIndex > 1) {
      const result = val.slice(0, fIndex);
      val = val.substring(fIndex);
      console.log('result: ', result);
      return [result, val];
    }
    return ['', val];
  }

  public getValue (val: string):[string, string] {

    let fIndex = val.indexOf('"');

    console.log('fIndex: getValue ', fIndex);
    val = val.substring(fIndex+1);

    fIndex = val.indexOf('"');

    console.log('fIndex: getValue ', fIndex);



    if(fIndex > 1) {
      const result = val.slice(0, fIndex);
      val = val.substring(fIndex);
      console.log('result: getValue ', result);
      return [result, val];
    }
    return ['', val];
  }




}
