import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Destination } from '../model/destination.model';
import { TourAuthoringService } from '../tour-authoring.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { ImageService } from 'src/app/shared/image.service';
import { DestinationService } from '../destination.service';

@Component({
  selector: 'xp-destination',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.css']
})
export class DestinationComponent implements OnInit{
  destinations: Destination[] = [];
  selectedDestination: Destination;
  shouldRenderDestinationForm: boolean = false;
  shouldEdit: boolean = false;

  constructor(
    private service: DestinationService,
    private changeDetector: ChangeDetectorRef,
    private imageService: ImageService
    ) {}

  ngOnInit(): void {
    this.getDestinations();
  }

  getDestinations(): void {
    this.service.getDestinations().subscribe({
      next: (result: PagedResults<Destination>) => {
        this.destinations = result.results
      }
    })
  }

  getFullImageUrl(imageURL?: string): string {
    return this.imageService.getFullImageUrl(imageURL || 'noImage.jpg');
  }

  deleteDestination(id: number): void {
    this.service.deleteDestination(id).subscribe({
      next: () => {
        this.getDestinations();
        this.service.showDestinationDeleted();
      },
    })
  }

  onEditClicked(destination: Destination): void {
    this.selectedDestination = destination;
    this.shouldRenderDestinationForm = true;
    this.shouldEdit = true;

    this.changeDetector.detectChanges();
  }

  onAddClicked(): void {
    this.shouldEdit = false;
    this.shouldRenderDestinationForm = true;

    this.changeDetector.detectChanges();
  }

  closeForm(): void {
    this.shouldRenderDestinationForm = false;
  }
}
