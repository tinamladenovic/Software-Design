import { Component, AfterViewInit } from "@angular/core";
//import { TourAuthoringService } from "../tour-authoring.service";
import { AuthService } from "src/app/infrastructure/auth/auth.service";
import { User } from "src/app/infrastructure/auth/model/user.model";

import * as L from "leaflet";

@Component({
    selector: 'xp-create-checkpoint',
    templateUrl: './create-checkpoint.component.html',
    styleUrls: ['./create-checkpoint.component.css']
    })

  export class CreateCheckpointComponent implements AfterViewInit {

    private map : any;

    private initMap(): void {
      this.map = L.map("map", {
        center: [39.8282, -98.5795],
        zoom: 3
      });
    }
  
    constructor() {

    }

    ngAfterViewInit() : void {
      this.initMap();
    }

}