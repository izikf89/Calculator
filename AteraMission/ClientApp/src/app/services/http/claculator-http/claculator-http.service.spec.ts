import { TestBed } from '@angular/core/testing';

import { ClaculatorHttpService } from './claculator-http.service';

describe('ClaculatorHttpService', () => {
  let service: ClaculatorHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClaculatorHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
