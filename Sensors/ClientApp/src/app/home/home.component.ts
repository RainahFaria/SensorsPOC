import { Component, OnInit } from '@angular/core';
import { SensorsService } from '../../services/sensors.service';
import { Sensor } from '../../models/sensor.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
  sensorList: Sensor[];
  regionList = [];

  lineChartDataObject = {
    label: '',
    fill: false,
    lineTension: 0.3,
    backgroundColor: 'rgba(25, 42, 86, 0.6)',
    borderColor: 'rgba(25, 42, 86,1)',
    borderCapStyle: 'butt',
    borderDash: [],
    borderDashOffset: 0.0,
    borderJoinStyle: 'miter',
    pointBorderColor: 'rgba(25, 42, 86,1)',
    pointBackgroundColor: '#fff',
    pointBorderWidth: 1,
    pointHoverRadius: 5,
    pointHoverBackgroundColor: 'rgba(25, 42, 86,1)',
    pointHoverBorderColor: 'rgba(25, 42, 86,1)',
    pointHoverBorderWidth: 2,
    pointRadius: 3,
    pointHitRadius: 10,
    data: [],
  };
  lineChartData: Array<any> = [];
  lineChartLabels: Array<any> = [];
  lineChartOptions: any = {
    responsive: true,
    annotation: {
      annotations: [
        {
          drawTime: 'afterDraw',
          type: 'line',
          mode: 'horizontal',
          scaleID: 'y-axis-0',
          value: 70,
          borderColor: '#000000',
          borderWidth: 2,
          label: {
            backgroundColor: 'red',
            content: 'global plugin',
            enabled: true,
            position: 'center',
          }
        }
      ]
    }
  };
  lineChartLegend = true;
  lineChartType = 'line';
  inlinePlugin: any;
  textPlugin: any;

  constructor(
    private sensorsService: SensorsService
    , private modalService: NgbModal) { }

  ngOnInit() {
    this.getSensors();

    this.textPlugin = [{
      id: 'textPlugin',
      beforeDraw(chart: any): any {
        const width = chart.chart.width;
        const height = chart.chart.height;
        const ctx = chart.chart.ctx;
        ctx.restore();
        const fontSize = (height / 160).toFixed(2);
        ctx.font = `${fontSize}em sans-serif`;
        ctx.textBaseline = 'middle';
        ctx.save();
      }
    }];

    this.inlinePlugin = this.textPlugin;
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  close() {
    this.modalService.dismissAll();
  }

  fillChartSeries(list) {

    list.forEach(item => {
      const exists = this.lineChartLabels.indexOf(item.tag);

      if (exists === -1) {
        const events = list.filter(e => e.tag === item.tag);

        if (events.length > 0) {
          const serie = events.map(e => e.value);

          this.lineChartData.push({ ...this.lineChartDataObject, data: serie, label: item.tag });
          this.lineChartLabels.push(item.tag);
        }

        const region = {
          name: item.tag,
          value: item.value
        }

        this.regionList.push(region);
      }

    });
  }

  getSensors() {
    this.sensorsService.getAllSensors().subscribe((response: Sensor[]) => {
      this.sensorList = response;
      this.fillChartSeries(this.sensorList);
      this.close();
    });
  }

}

