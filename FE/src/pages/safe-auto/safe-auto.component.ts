import { Component, OnInit } from '@angular/core';
import { SafeAutoService } from './services/safe-auto.service';
import { Observable, throwError } from 'rxjs';
import { SafeAuto } from './models/safeAuto.model';
import { InformationSafeAuto, InformationSafeAutoShow } from './models/informationSafeAuto.model';
import * as _ from "lodash";

@Component({
  selector: 'app-safe-auto',
  templateUrl: './safe-auto.component.html',
  styleUrls: ['./safe-auto.component.css']
})
export class SafeAutoComponent implements OnInit {

  file: any;
  fileContent: string = '';
  SafeAuto: SafeAuto = new SafeAuto();
  InformationSafeAuto: InformationSafeAuto;
  InformationSafeAutos: InformationSafeAuto[] = [];
  InformationSafeAutosShow: InformationSafeAutoShow[] = [];
  $safeAutoData: Observable<InformationSafeAuto>;
  errorsAddRowsFile: string[] = [];
  showGif: boolean = false;
  headers = ["NAME","MILES", "AVERAGE"];
  showTab: boolean = false;
  emptyData: boolean = false;

  constructor(
    private _safeAutoService: SafeAutoService
  ) { }

  ngOnInit() {
  }
  public searchFile(): void {
    document.querySelector('input').click()
  }

  public fileChanged(e:any) {
    try{
      this.errorsAddRowsFile = [];
      this.InformationSafeAutosShow = [];
      this.emptyData = false;
      this.showGif = true;
      this.file = null;
      this.file = e.target.files[0];
      let fileReader: FileReader = new FileReader();
      let self = this;
  
      fileReader.onloadend = async () => {
        self.fileContent = fileReader.result + '';
        let content = self.fileContent.split('\n');
        let timer = 0;
        content.forEach(c => {

          let lineSplit = c.split(' ');
        
          //send to Create
          if(lineSplit[0].toUpperCase() == 'DRIVER'){
            this.createModel(lineSplit);
            this.sendModel(true);
          } else if (lineSplit[0].toUpperCase() == 'TRIP') {
            this.OperationModel(lineSplit);
            this.sendModel(false);
          } else if ( (lineSplit[0].match(/\n/g)||[]).length == 0 && lineSplit[0].length <= 1){

          } else {
            this.errorsAddRowsFile.push(c);
          }
          timer++;
          if(content.length == timer){
            try{
              this._safeAutoService.getAllInformation().subscribe(response => {
                if(response.length == 0){
                  this.emptyData = true;
                  this.showGif = false;
                } else {
                  this.InformationSafeAutos = response;
                  this.methodGrouping();
                  this.showGif = false;
                  this.showTab = true;
                  this.emptyData = false;
                }
              
      
            })
          }catch(err){
            console.log(err);
            this.showGif = false;
          }
          }
        })
      }
      fileReader.readAsText(this.file);
    }catch(err){
      console.log(err);
    }
    
  }

  private methodGrouping(): any {
    let groupByName =_.chain(this.InformationSafeAutos)
    .groupBy("name")
    .map((value, key) => ({ name: key, information: value }))
    .value();

    groupByName.forEach((x) => {
      let resultMiles =0;
      let totalMinutos = 0;
      x.information.forEach(y =>{
        resultMiles += y.miles;

        let a =  y.startTrip.split(':');
        let minutos_inicio = parseInt(a[0]) * 60 + parseInt(a[1]);
        let b =  y.endTrip.split(':');
        let minutos_final  = parseInt(b[0]) * 60 + parseInt(b[1]);
        let diferencia = minutos_final - minutos_inicio;
        let minutos = diferencia % 60;
        totalMinutos += minutos;
      })
      
      let r = 60 * resultMiles / totalMinutos;

      let infoSave = new InformationSafeAutoShow();
      infoSave.name = x.name;
      infoSave.totalMiles = resultMiles;
      infoSave.milesPerHour = r;
      this.InformationSafeAutosShow.push(infoSave);
    })

  }

  private createModel(model: string[]): void{
    this.SafeAuto.name = model[1];
  }

  private OperationModel(information: string[]): void{
    this.InformationSafeAuto = new InformationSafeAuto();
    this.InformationSafeAuto.name = information[1];
    this.InformationSafeAuto.startTrip = information[2];
    this.InformationSafeAuto.endTrip = information[3];
    this.InformationSafeAuto.miles = parseFloat(information[4]);
  }

  private async sendModel(isCreate: boolean): Promise<void>{
    if(isCreate){
      try{
        await this._safeAutoService.newDriver(this.SafeAuto).subscribe(response => {
          console.log(response);
        });
      }catch(err){
        console.log(err);
        this.showGif = false;
      }
     
    } else{        //send to Generate reporting
      try{
        await this._safeAutoService.generateReporting(this.InformationSafeAuto).subscribe(response => {
      });
    }catch(err){
      console.log(err);
      this.showGif = false;
    }
    }
  }

}
