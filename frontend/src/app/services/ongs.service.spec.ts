import { TestBed } from '@angular/core/testing';

import { OngsService } from './ongs.service';

describe('OngsService', () => {
  let service: OngsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OngsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
