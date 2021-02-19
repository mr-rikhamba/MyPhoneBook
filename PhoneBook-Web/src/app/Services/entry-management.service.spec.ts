import { TestBed } from '@angular/core/testing';

import { EntryManagementService } from './entry-management.service';

describe('EntryManagementService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EntryManagementService = TestBed.get(EntryManagementService);
    expect(service).toBeTruthy();
  });
});
