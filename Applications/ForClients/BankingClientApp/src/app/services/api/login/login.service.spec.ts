import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { LoadingTestingModuleModule } from 'src/app/views/login-view/loading-testing-module/loading-testing-module.module';
import { TokenAuthenticationServiceService } from '../../security/token-authentication-service.service';
import { SessionService } from '../../session/session.service';
import { ApiBaseService } from '../generic/api-base.service';

import { LoginService } from './login.service';

describe('LoginService', () => {
  let service: LoginService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers:  [
        HttpClient,
        ApiBaseService,
        LoginService,
    ],
    imports: [
      LoadingTestingModuleModule]
    });
    service = TestBed.inject(LoginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
