import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormBuilder } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { ApiBaseService } from 'src/app/services/api/generic/api-base.service';
import { LoginService } from 'src/app/services/api/login/login.service';
import { TokenAuthenticationServiceService } from 'src/app/services/security/token-authentication-service.service';
import { SessionService } from 'src/app/services/session/session.service';



@NgModule({
  declarations: [],
  providers:  [
    HttpClient,
    ApiBaseService,
    LoginService,



    TokenAuthenticationServiceService,
    SessionService,
    HttpClient,
    FormBuilder,
],
  imports: [
    RouterTestingModule,
    HttpClientModule,
    HttpClientTestingModule
    ]
    ,
    exports: [
      RouterTestingModule,
      HttpClientModule,
      HttpClientTestingModule
    ]


})
export class LoadingTestingModuleModule { }
