import { TestBed } from '@angular/core/testing';

import { PhoneBookManagementService } from './phone-book-management.service';

describe('PhoneBookManagementService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PhoneBookManagementService = TestBed.get(PhoneBookManagementService);
    expect(service).toBeTruthy();
  });
});
