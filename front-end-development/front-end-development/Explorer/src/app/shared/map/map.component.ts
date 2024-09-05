import { Component, AfterViewInit, Output, EventEmitter } from '@angular/core';
import * as L from 'leaflet';
import { MapService } from './map.service';
import { LatLng } from './latLng.model';
import { AddressTest } from 'src/app/feature-modules/tour-authoring/model/address-test.model';
import { Observable, map } from 'rxjs';
import { Checkpoint } from 'src/app/feature-modules/tour-authoring/model/checkpoint.model';
import { TravelTimeAndMethod } from 'src/app/feature-modules/tour-authoring/model/travel-time-and-method.model';
import { TransferValue } from 'src/app/feature-modules/tour-authoring/model/transfer-value.model';
import { Encounter, EncounterType } from 'src/app/feature-modules/encounters/model/encounters.model';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements AfterViewInit {

  @Output() changeDistance = new EventEmitter();
  @Output() changeTravelMethodAndTime = new EventEmitter();
  @Output() changeValue = new EventEmitter();
  @Output() activatedEncounterId = new EventEmitter<number>();

  private map: any;
  private currentMarker: any = null;
  private routePoints: L.Routing.Waypoint[] = [];
  private routeControl: any = null;
  private markers: L.Marker[] = [];
  private encounterRadiuses: L.Circle[] = [];
  

  distance : number = 0;

  @Output() pinnedPlace = new EventEmitter<AddressTest>();

  constructor(private mapService: MapService) {}
  
  ngAfterViewInit(): void {
    L.Marker.prototype.options.icon = this.generateIcon('blue');
    this.initMap();
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [45.2396, 19.8227],
      zoom: 13,
    });

    const tiles = L.tileLayer(
      'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
      {
        maxZoom: 18,
        minZoom: 3,
        attribution:
          '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
      }
    );
    this.registerOnClick();
    tiles.addTo(this.map);
  }

  setMapCenter(lat: number = 45.2396, lon: number = 19.8227): void {
    this.map.setView([lat, lon]);
  }

  removeMarker(): void {
    if (this.currentMarker) {
      this.map.removeLayer(this.currentMarker);
      this.currentMarker = null;
    }
  }

  registerOnClick(): void {
    this.map.on('click', (e: any) => {
      const redIcon = new L.Icon({
        iconUrl:
          'https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-red.png',
        shadowUrl:
          'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41],
      });
      const lat = e.latlng.lat;
      const lng = e.latlng.lng;
      if (this.currentMarker) {
        this.map.removeLayer(this.currentMarker);
      }
      this.mapService.reverseSearch(lat, lng).subscribe((res) => {
        console.log(res.display_name);
        let addressTest: AddressTest = { lat: lat, lng: lng, address: res.display_name };
        this.pinnedPlace.emit(addressTest);
      });
      console.log(
        'You clicked the map at latitude: ' + lat + ' and longitude: ' + lng
      );
      this.currentMarker = new L.Marker([lat, lng], { icon: redIcon }).addTo(this.map);
    });
  }

  deleteMarkers(): void {
    for (let i = 0; i < this.markers.length; i++) {
      this.map.removeLayer(this.markers[i]);
    }
    this.markers = [];
    this.routePoints = [];
  }

  drawCheckpoints(checkpoints: Checkpoint[]): any[] {
    if (this.currentMarker) {
      this.map.removeLayer(this.currentMarker);
      this.routePoints = [];
    }
   
    for (let i = 0; i < checkpoints.length; i++) {
      this.routePoints.push(
        new L.Routing.Waypoint(L.latLng(checkpoints[i].latitude, checkpoints[i].longitude), 'Checkpoint ' + (i + 1), {allowUTurn: true})
      );
      this.markers.push(
        new L.Marker([checkpoints[i].latitude, checkpoints[i].longitude], { icon: this.generateIcon('blue', i == 0) })
        .bindPopup(`
        <div style="text-align: center; font-size: 1.15em;">
          <h3 style="font-weight: bold;">${checkpoints[i].name}</h3>
          <p style="margin-bottom: 5px;">Reach the checkpoint to unlock the secret.</p>
          <p style="margin-bottom: 5px;"><strong>Checkpoint num:</strong> ${i+1}</p>
        </div>
      `).addTo(this.map)
      );
    }
    return this.markers;
  }

  drawSelectedCheckpoints(checkpoint: Checkpoint[]): void {
    if (this.currentMarker) {
      this.map.removeLayer(this.currentMarker);
      this.routePoints = [];
    }
    const redIcon = new L.Icon({
      iconUrl:
        'https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-red.png',
      shadowUrl:
        'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
      iconSize: [25, 41],
      iconAnchor: [12, 41],
      popupAnchor: [1, -34],
      shadowSize: [41, 41],
    });
    for (let i = 0; i < checkpoint.length; i++) {
      
      this.routePoints.push(
        new L.Routing.Waypoint(L.latLng(checkpoint[i].latitude, checkpoint[i].longitude), 'Checkpoint ' + (i + 1), {allowUTurn: true})
      );
      this.markers.push(
        new L.Marker([checkpoint[i].latitude, checkpoint[i].longitude], { icon: redIcon })
        .bindPopup(`<h3 style="font-weight: bold;">${checkpoint[i].name}</h3>`)
        .addTo(this.map)
      );
    }
  }

  search(): void {
    this.mapService.search('Dusana Danilovica 3, Novi Sad').subscribe({
      next: (result) => {
        //console.log(result);
        L.marker([result[0].lat, result[0].lon])
          .addTo(this.map)
          .bindPopup('Pozdrav iz Strazilovske 19.')
          .openPopup();
      },
      error: () => {},
    });
  }

  reverseSearch(lat: number, lng: number): Observable<string> {
    return this.mapService.reverseSearch(lat, lng).pipe(
      map((res: { display_name: any }) => {
        //console.log(res.display_name);
        return res.display_name;
      })
    );
  }

  changeMarkerColorToGray(marker: any): void {
    const grayIcon = new L.Icon({
      iconUrl: 'https://www.clker.com/cliparts/i/4/d/6/s/P/map-pin-gray-md.png', 
      iconSize: [25, 41],
      iconAnchor: [12, 41],
      popupAnchor: [1, -34],
      shadowSize: [41, 41],
    });
    marker.setIcon(grayIcon);
  }

  bindMarkerPopup(marker: any, popupHtml: string){
    this.changeMarkerColorToGray(marker);
    marker.unbindPopup();
    marker.bindPopup(popupHtml);
  }

  addMarker(lat: number, lng: number): void {
    if (this.currentMarker) {
      this.map.removeLayer(this.currentMarker);
    }
    this.distance = 0;

    if(this.routeControl){
      this.map.removeLayer(this.routeControl);
      this.routeControl = null;
    }
    this.currentMarker = L.marker([lat, lng]).addTo(this.map);
  }
  
  setRoute(): void {
    if (this.routeControl){
      this.map.removeControl(this.routeControl);
      this.routeControl = null;
    }
    this.distance = 0;
    let routesFound = false;
    this.routeControl = L.Routing.control({
      router: L.routing.mapbox(
        'pk.eyJ1Ijoic2xvYmljYSIsImEiOiJjbG8wMm9tbmEwYnhtMmpxdXJzd2R4b2Q1In0.Ezp5HpNKNot63hzulKkRzw',
        { profile: 'mapbox/walking' }
      ),
      plan: L.Routing.plan(
        this.routePoints,
        {
          createMarker: this.shouldCreateMarkers,
        }
      ),
      addWaypoints: false,
      lineOptions: {
        styles: [{ color: '#039dfc', opacity: 1, weight: 4.5, lineCap: 'round' }],
        extendToWaypoints: false,
        missingRouteTolerance: 0.2
      },
    }).addTo(this.map);

    this.routeControl.on('routesfound', (e : any) => {
      var routes = e.routes;
      var summary = routes[0].summary;
      var totalDistance = summary.totalDistance / 1000;
      var totalTime = Math.round(summary.totalTime / 60);
      this.distance = totalDistance;
      
      routesFound = true;
      
      this.chngeValue({distance : totalDistance ,travelMethod : 0, travelTime : totalTime});
    });

    if(!routesFound){
      this.chngeValue({distance : 0 ,travelMethod : 0, travelTime : -1});
    }
  }

  calculateDistance(waypoints: L.Routing.Waypoint[]): void {
    if (waypoints.length < 2) {
      return;
    }
    const routeControl = L.Routing.control({
      router: L.routing.mapbox(
        'pk.eyJ1Ijoic2xvYmljYSIsImEiOiJjbG8wMm9tbmEwYnhtMmpxdXJzd2R4b2Q1In0.Ezp5HpNKNot63hzulKkRzw',
        { profile: 'mapbox/walking' }
      ),
      plan: L.Routing.plan(
        waypoints,
      {
        createMarker: this.shouldCreateMarkers,
      }
      ),
      addWaypoints: false,
    }).addTo(this.map);

    routeControl.on('routesfound', (e : any) => {
      this.map.removeControl(routeControl);
      var routes = e.routes;
      var summary = routes[0].summary;
      var coveredDistance = summary.totalDistance / 1000;
      this.chngeValue({distance : coveredDistance, travelMethod : 0, travelTime : -1});      
    });
  }

  private chngeValue(value : TransferValue){
    this.changeValue.emit(value);
  } 

  private shouldCreateMarkers(i: number, waypoint: L.Routing.Waypoint, n: number): boolean {
    return false;
  }


  removeRoute(): void {
    this.map.removeControl(this.routeControl);
    this.routeControl = null;
  }

  drawEncounters(encounters: Encounter[], popups: Map<number, string>): any[] {
    this.markers.forEach(marker => {
      this.map.removeLayer(marker);
    });
    this.markers = [];

    this.encounterRadiuses.forEach(circle => {
      this.map.removeLayer(circle);
    });
    this.encounterRadiuses = [];
    
    for (let i = 0; i < encounters.length; i++) {
      let popUp = popups.get(encounters[i].id!);
      this.markers.push(
        new L.Marker([encounters[i].coordinates.latitude, encounters[i].coordinates.longitude], { icon: this.generateCorespondingIcon(encounters[i]) })
        .bindPopup(popUp!)
        .addTo(this.map)
      );

      let circle = L.circle([encounters[i].coordinates.latitude, encounters[i].coordinates.longitude], {
        //color: 'black',
        radius: encounters[i].range
      });
      this.encounterRadiuses.push(circle);
  
      // Add the circle to the map
      circle.addTo(this.map);
    }
    return this.markers;
  }

  private generateCorespondingIcon(encounter: Encounter): L.Icon {
    switch (encounter.type) {
      case EncounterType.Social:
        return this.generateIcon('green');
      case EncounterType.HiddenLocation:
        return this.generateIcon('orange');
      case EncounterType.Misc:
        return this.generateIcon('yellow');
    }
  }

  increaseMarkerSize(marker: L.Marker): void {
    marker.setIcon(this.generateIcon('blue', true));
  }

  private generateIcon(color: string, bigger: boolean = false): L.Icon {
    let size: [number, number];
    size = bigger ? [31, 47] : [25, 41];
    return new L.Icon({
      iconUrl: `https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-${color}.png`,
      iconSize: size,
      iconAnchor: [12, 41],
      popupAnchor: [1, -34],
      shadowSize: [41, 41],
    });
  }

  closePopupAt(lat: number, lng: number): void {
    for (let marker of this.markers) {
      if (marker.getLatLng().lat === lat && marker.getLatLng().lng === lng) {
        marker.closePopup();
        break;
      }
    }
  }

  activateEncounter(encounterId: number): void {
    this.activatedEncounterId.emit(encounterId);
  }
}
