import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', data: { title: 'Home' }, loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule) },
  { path: 'calculator', data: { title: 'Calculator' }, loadChildren: () => import('./pages/calculator/calculator.module').then(m => m.CalculatorModule) },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
