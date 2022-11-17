import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/api/login/login.service';
import { SessionService } from 'src/app/services/session/session.service';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss']
})
export class LoginViewComponent implements OnInit {

  // Variable to set if user is loging in as customer or employee
  public isCustomer: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    private sessionService: SessionService,
    private router: Router) { }

  public checkoutForm = this.formBuilder.group({
    email: '',
    password: '',
    employeeid: ''
  });


  ngOnInit(): void {
    this.goToDashboard();
  }

  // Check if user is logged in and if logged in than sent to accounts
  public goToDashboard(): void {
    // Check if user is logged in
    const isLogged = this.sessionService.isLoggedIn();

    if(isLogged) {
      // Redirect to dashboard
      //window.location.href = '/accounts';
      // go to accounts using route
      this.router.navigate(['/accounts']);

    }
  }

  // Create method that checks if user is logged in
  public isLoggedIn(): boolean {

   this.sessionService.isLoggedIn()

    return false;
  }

  // Create method that checks if value is in local storage
  public isValueInLocalStorage(value: string): boolean {
    // Get value from local storage
    const email = localStorage.getItem('email');
    if(email != null && email != undefined) {
      return true;
    }
    return false;
  }

  public async onSubmit(): Promise<void> {

    // Store in local storage for now (until we have a database)
    const email = this.checkoutForm.get('email')?.value;
    const password = this.checkoutForm.get('password')?.value;
    const employeId = this.checkoutForm.get('employeeid')?.value;
    console.log('employee id: ' + employeId);

    if(this.isCustomer) {
      // Call login customer
      if(email != null && email != undefined && password != null && password != undefined) {
        await this.loginService.loginCustomer(email, password);
        this.goToDashboard();
      }
      return;
    }

    // Call login employee
    if(employeId != null && employeId != undefined && password != null && password != undefined) {
      await this.loginService.loginEmployee(employeId, password);
      this.goToDashboard();
      return;
    }
  }

  // Set login as employee or customer
  public changeLoginEmployeeOrCustomer(): void {
    this.isCustomer = !this.isCustomer;
  }


}
