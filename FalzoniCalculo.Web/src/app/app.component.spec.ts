import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { CalcService } from '../services/calc.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

describe('AppComponent', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [AppComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'FalzoniCalculo.Web'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Falzoni Cálculo');
  });

  it('submitForm should be succeded', () => {    
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;

    app.ngOnInit()

    app.calcForm.get("date")?.setValue("2024-28-01")
    app.calcForm.get("value")?.setValue(100)

    expect(() => app.submitForm()).not.toThrow()
  })

  it('submitForm should be failed with bad value', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;

    app.ngOnInit()

    app.calcForm.get("date")?.setValue("2024-01-02")
    app.calcForm.get("value")?.setValue(0)

    expect(() => app.submitForm()).toThrowError("Valor não pode ser menor ou igual a zero")
  })
});
