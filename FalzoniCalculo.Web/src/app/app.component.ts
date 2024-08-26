import { formatDate } from '@angular/common';
import { Component, OnInit, isDevMode } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser'
import { CalcService } from '../services/calc.service';
import { CurrencyEntry } from '../models/currency-entry.model';
import { CurrencyReturn } from '../models/currency-return.model';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Falzoni Cálculo'
  calcForm!: FormGroup
  liquidValue?: number = 0
  grossValue?: number = 0

  constructor(
    private titleService: Title,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder,
    private calcService: CalcService
    ) {
    this.titleService.setTitle(this.title)
  }

  ngOnInit() {
    this.buildForm()
  }

  submitForm() {
      try {
        const obj = Object.assign(new CurrencyEntry(), this.calcForm.value)

        if (obj.date === undefined) {
          throw new Error("A data deve ser preenchida")
        }

        if (obj.value <= 0) {
          throw new Error("Valor não pode ser menor ou igual a zero")
        }

        this.spinner.show()

        setTimeout(() => {
            this.calcService.calculateCurrency(obj).subscribe({
            next: (value) => {
              let result = Object.assign(value, new CurrencyReturn)
              this.grossValue = result.GrossValue
              this.liquidValue = result.LiquidValue
              this.spinner.hide()
            },
            error: (error) => {
              this.actionForError(error.message)
            }
          })
        }, 3000)
      } catch (e: any) {
          this.actionForError(e.message)
          throw e
      }
  }

  // private METHODS
  private buildForm() {
    this.calcForm = this.fb.group({
      date: new FormControl(formatDate(new Date(), 'yyyy-MM-dd', 'en')),
      value: new FormControl([0])
    })
  }

  private actionForError(message: string) {
    this.spinner.hide()

    Swal.fire({
      title: 'Deu ruim!',
      text: message,
      icon: 'error',
      confirmButtonText: 'Ok'
    })
  }
}
