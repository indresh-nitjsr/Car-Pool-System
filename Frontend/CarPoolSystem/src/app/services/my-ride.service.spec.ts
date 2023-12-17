import { TestBed } from '@angular/core/testing';

import { MyRideService } from './my-ride.service';

describe('MyRideService', () => {
  let service: MyRideService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyRideService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
