import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SafeAutoModule } from 'src/pages/safe-auto/safe-auto.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SafeAutoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
