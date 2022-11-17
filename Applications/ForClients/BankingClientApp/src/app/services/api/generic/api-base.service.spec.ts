import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { ApiBaseService } from './api-base.service';

describe('ApiBaseService', () => {
  let service: ApiBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
      HttpClient]
      ,
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(ApiBaseService);
  });



  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
