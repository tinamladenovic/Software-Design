import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { MapComponent } from 'src/app/shared/map/map.component';
import { Checkpoint } from '../../tour-authoring/model/checkpoint.model';
import { LatLng } from 'leaflet';
import { TouristCheckpointService } from '../tourist-checkpoint.service';
import { TourAuthoringService } from '../../tour-authoring/tour-authoring.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TourDataService } from '../../tour-authoring/tourData.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Tour } from '../../tour-authoring/model/tour.model';
import { MarketplaceService } from '../../marketplace/marketplace.service';
import { UserService } from '../../marketplace/owner-club-options/owner-club-options.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'xp-tour-creation',
  templateUrl: './tour-creation.component.html',
  styleUrls: ['./tour-creation.component.css'],
})
export class TourCreationComponent {
  @ViewChild(MapComponent) mapComponent: MapComponent;

  addedCheckpoints: Checkpoint[];
  clickedLatLng: LatLng; // export interface LatLng { lat: number,lng: number }
  clickedAddress: string;
  selectedCheckpoint: Checkpoint | null;
  tourId: number;
  showed: boolean = false;
  distance: number;
  selectedCheckpoints: Checkpoint[] = [];
  createOn: boolean = false;
  tours: Tour[] = [];
  private user: User;

  constructor(
    private touristCheckpointService: TouristCheckpointService,
    private tourService: TourAuthoringService,
    private route: ActivatedRoute,
    private router: Router,
    private tourDataService: TourDataService,
    private marketplaceService: MarketplaceService,
    private userService: AuthService
  ) {
    this.tourId = tourDataService.getTourId();
  }

  ngOnInit(): void {
    this.clickedAddress = '';

    this.getCheckpoints(this.tourId);
    this.userService.user$.subscribe((user) => {
      this.user = user;
    });

    this.tourForm
      .get('name')
      ?.valueChanges.subscribe(() => this.updateIsFormFull());
    this.tourForm
      .get('description')
      ?.valueChanges.subscribe(() => this.updateIsFormFull());
  }

  drawCheckpoints(): void {
    this.mapComponent.drawCheckpoints(this.addedCheckpoints);
    this.mapComponent.drawSelectedCheckpoints(this.selectedCheckpoints);
    // this.mapComponent.setRoute();
  }

  showFullRoute(): void {
    if (this.showed) {
      this.mapComponent.removeRoute();
      this.showed = false;
    } else {
      this.mapComponent.setRoute();
      this.showed = true;
    }
  }

  onSelectedCheckpoint(checkpoint: Checkpoint): void {
    this.addedCheckpoints = this.addedCheckpoints.filter(
      (c) => c.id != checkpoint.id
    );
    this.selectedCheckpoints = [...this.selectedCheckpoints, checkpoint];
    this.drawCheckpoints();
    if (this.selectedCheckpoints.length > 1) {
      this.showed = true;
      this.getSugegstedTours();
    }
  }

  addToCart(tour: Tour) {
    console.log(tour);
    this.tourDataService.setTourId(tour.id);
    this.marketplaceService
      .addToCart(
        {
          tourId: tour.id,
          tourName: tour.name,
          price: tour.price,
          quantity: 1,
        },
        this.user.id
      )
      .subscribe();
    this.router.navigate(['/shopping-cart']);
  }

  getSugegstedTours(): void {
    this.tourService
      .getSuggestedTours(this.selectedCheckpoints)
      .subscribe((pagedResults) => {
        this.tours = pagedResults.results;
      });
  }

  onDeselectedCheckpoint(checkpoint: Checkpoint): void {
    this.selectedCheckpoints = this.selectedCheckpoints.filter(
      (c) => c.id != checkpoint.id
    );
    this.addedCheckpoints = [...this.addedCheckpoints, checkpoint];
    if (this.selectedCheckpoints.length < 2) {
      this.showed = false;
    }
    this.drawCheckpoints();
  }

  getCheckpoints(id: number): void {
    this.touristCheckpointService.getCheckpoints().subscribe((pagedResults) => {
      this.addedCheckpoints = pagedResults.results;
      this.drawCheckpoints();
    });
  }

  goBack(): void {
    this.router.navigate(['/author/tour-checkpoints']);
  }

  onCreateTour() {
    this.createOn = true;
  }

  @Output() equimpentUpdated = new EventEmitter<null>();

  tour: Tour;

  isFormFull: boolean = false;

  tourForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    difficult: new FormControl(0),
    tags: new FormControl([]),
  });

  updateIsFormFull() {
    const name = this.tourForm.get('name')?.value;
    const description = this.tourForm.get('description')?.value;
    this.isFormFull = !!(name && description);
  }

  tourId1: number;

  allTags: string[] = ['tag1', 'tag2', 'tag3'];
  submitForm(): void {
    let randomIndex: number = Math.floor(Math.random() * 9900) + 100;

    let tour: Tour;
    tour = {
      id: randomIndex,
      authorId: this.user?.id,
      name: this.tourForm.value.name || '',
      description: this.tourForm.value.description || '',
      tags: this.tourForm.value.tags?.join(',') || '',
      difficult: Number(this.tourForm.value.difficult) || 0,
      status: 0,
      price: 0,
      distance: 0,
      travelTimeAndMethod: [],
      checkpoints: [],
      publishTime: new Date(),
      archiveTime: new Date(),
      tourEquipment: [],
    };
    console.log(tour);

    this.tourService.addTour(tour).subscribe((result) => {
      console.log(result.id);
      this.tourId1 = result.id;
      this.getTour();
    });
    this.createOn = false;
  }
  getTour(): void {
    this.tourService.getTourById(this.tourId1).subscribe((result) => {
      this.tour = result;
      this.addCheckpoints();
    });
  }

  addCheckpoints(): void {
    this.touristCheckpointService.addCheckpoints(
      this.tourId,
      this.selectedCheckpoints
    );
    this.router.navigate(['/tourist/tours']);
  }
}
