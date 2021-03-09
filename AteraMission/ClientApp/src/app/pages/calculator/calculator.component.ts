import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ClaculatorHttpService } from 'src/app/services/http/claculator-http/claculator-http.service';


@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  exp: string = '';
  btnNumberList: number[] = [...Array(10).keys()].reverse();
  operatorsList: string[] = ['+', '-', '/', '*']
  history =[];

  constructor(
    private claculatorHttp: ClaculatorHttpService,
    private _snackBar: MatSnackBar,
  ) { }

  ngOnInit(): void {
  }

  add(digit: string) {
    this.exp += digit
  }

  remove() {
    this.exp.substring(0, this.exp.length - 1)
  }

  clear() {
    this.exp = '';
  }

  calc() {    
     this.claculatorHttp.calc(this.exp).subscribe(res => {
      this.history.push(this.exp +' = ' + res);
      this.exp = res;      
    }, (err:HttpErrorResponse)  => this.showError(err));
  }

  showError(err: HttpErrorResponse) {
    console.log(err);
    this._snackBar.open(err.error, "error", {
      duration: 2000,
    });
  }
}
