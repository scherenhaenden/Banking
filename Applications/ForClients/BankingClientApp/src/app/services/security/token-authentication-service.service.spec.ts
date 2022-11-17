import { TestBed } from '@angular/core/testing';

import { TokenAuthenticationServiceService } from './token-authentication-service.service';

describe('TokenAuthenticationServiceService', () => {
  let service: TokenAuthenticationServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TokenAuthenticationServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
