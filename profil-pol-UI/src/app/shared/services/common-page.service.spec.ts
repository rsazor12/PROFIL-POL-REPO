import { TestBed, inject } from '@angular/core/testing';

import { CommonPageService } from './common-page.service';

describe('CommonPageService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CommonPageService]
    });
  });

  it('should be created', inject([CommonPageService], (service: CommonPageService) => {
    expect(service).toBeTruthy();
  }));
});
