import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SafeAutoComponent } from './safe-auto.component';
import { SafeAutRoutingModule } from './safe-auto-routing.module';
import { SafeAutoService } from './services/safe-auto.service';
import { HttpClientModule } from '@angular/common/http';
import { PacmanGifComponent } from '../../helpers/pacman-gif/gif/pacman/pacman-gif.component';
import { TableComponent } from '../../helpers/tables/table/table.component';



@NgModule({
  declarations: [
    SafeAutoComponent,
    PacmanGifComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    SafeAutRoutingModule
  ],
  providers: [
    SafeAutoService
  ]
})
export class SafeAutoModule { }
