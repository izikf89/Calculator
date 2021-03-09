import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CalculatorRoutingModule } from './calculator-routing.module';
import { CalculatorComponent } from './calculator.component';
import { FormsModule } from '@angular/forms';
import { ClaculatorHttpService } from 'src/app/services/http/claculator-http/claculator-http.service';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatExpansionModule} from '@angular/material/expansion';


@NgModule({
  declarations: [CalculatorComponent],
  imports: [
    CommonModule,
    CalculatorRoutingModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    MatExpansionModule,
  ],
  providers: [ClaculatorHttpService]
})
export class CalculatorModule { }
