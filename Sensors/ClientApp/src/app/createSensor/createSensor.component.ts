import { Component, OnInit, Injectable, ViewChild } from '@angular/core';
import { SensorsService } from '../../services/sensors.service';
import { Sensor } from '../../models/sensor.model';
import { FormGroup } from '@angular/forms';
import { HomeComponent } from '../home/home.component';
import { inject } from '@angular/core/testing';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-createSensor',
  templateUrl: './createSensor.component.html',
})

export class CreateSensorComponent implements OnInit {
  sensorList: any;
  sensor = new Sensor();
  submitted = false;
  sensorForm: FormGroup;
    
  constructor(
    private sensorsService: SensorsService
    , public toastService: ToastService
    , public home: HomeComponent) { }

  ngOnInit() {
  }

  addSensor() {
    this.sensorsService.addSensor(this.sensor).subscribe((response: any) => {
      this.home.getSensors();
      this.clearSensor();
      this.showSuccess();
    });
  }

  clearSensor() {
    this.sensor = new Sensor();
  }

  showSuccess() {
    this.toastService.show('Operação concluída com sucesso', { classname: 'bg-success text-light', delay: 10000 });
  }

  showDanger(dangerTpl) {
    this.toastService.show('Desculpe, não foi possível completar a operação', { classname: 'bg-danger text-light', delay: 15000 });
  }

}

