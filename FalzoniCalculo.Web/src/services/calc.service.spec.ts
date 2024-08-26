import { TestBed } from '@angular/core/testing';
import { CalcService } from './calc.service';
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { defer, of, throwError } from 'rxjs';

describe('CalcService', () => {
  let httpClientSpy: jasmine.SpyObj<HttpClient>
  let service: CalcService;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['post'])

    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CalcService]
    });
    service = new CalcService(httpClientSpy);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('calcCurrency should be succeded', (done: DoneFn) => {    
    const mockParams: any = { date: new Date(2024, 9, 26), value: 100.00 }

    const mockReturn: any = { grossValue: 123.47, liquidValue: 100.97 }

    httpClientSpy.post.and.returnValue(of(mockReturn))

    service.calculateCurrency(mockParams).subscribe({
      next: (value) => {
        expect(value).toEqual(mockReturn)
        done();
      },
      error: (error) => done.fail
    })
  })

  it('calcCurrency should be failed', (done: DoneFn) => {
    const mockParams: any = { date: new Date(2024, 8, 26), value: 100.00 }

    const mockErrorResponse = new HttpErrorResponse({
      error: 'test message of return error',
      status: 400,
      statusText: 'Not Found',
    });

    httpClientSpy.post.and.returnValue(defer(() => Promise.reject(mockErrorResponse)))

    service.calculateCurrency(mockParams).subscribe({
      next: (heroes) => done.fail('expected an error here'),
      error: (error) => {
        expect(error.message).toContain('test message of return error');
        done();
      },
    });
  })
});
