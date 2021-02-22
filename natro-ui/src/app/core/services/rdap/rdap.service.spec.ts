import { TestBed } from '@angular/core/testing';

import { RdapService } from './rdap.service';

describe('RdapService', () => {
  let service: RdapService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RdapService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
