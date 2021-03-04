import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SafeAutoComponent } from 'src/pages/safe-auto/safe-auto.component';
import { SafeAutoModule } from 'src/pages/safe-auto/safe-auto.module';

const routes: Routes = [
  { path: '', component: SafeAutoComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SafeAutRoutingModule { }
