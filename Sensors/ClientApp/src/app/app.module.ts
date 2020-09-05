import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SensorsService } from './../services/sensors.service';
import { CreateSensorComponent } from './createSensor/createSensor.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from '../services/toast.service';
import { NgChartjsModule } from 'ng-chartjs';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateSensorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModalModule,
    NgChartjsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [SensorsService, ToastService],
  bootstrap: [AppComponent]
})
export class AppModule { }
