import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MaterialModule } from "../material.module";
import { IgxComboModule } from 'igniteui-angular';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([]),
    MatNativeDateModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MaterialModule,
    IgxComboModule
  ],
  exports: [MatDatepickerModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
