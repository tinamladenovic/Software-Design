import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild  } from '@angular/core';
import { Destination } from '../model/destination.model';
import { TourAuthoringService } from '../tour-authoring.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TextWrapper } from 'src/app/shared/model/text-wrapper.model';
import { AddressTest } from '../model/address-test.model';
import { MapComponent } from 'src/app/shared/map/map.component';
import { Observable } from 'rxjs';
import { ImageService } from 'src/app/shared/image.service';
import { DestinationService } from '../destination.service';

@Component({
  selector: 'xp-destination-form',
  templateUrl: './destination-form.component.html',
  styleUrls: ['./destination-form.component.css']
})
export class DestinationFormComponent implements OnChanges, AfterViewInit{

  @Output() destinationsUpdated = new EventEmitter<null>();
  @Output() closeForm = new EventEmitter<null>();
  @Input() destination: Destination;
  @Input() shouldEdit: boolean = false;
  @ViewChild(MapComponent) mapComponent: MapComponent;
  @ViewChild('fileInput') fileInput: ElementRef;

  destinationForm = new FormGroup({
    longitude: new FormControl(0.0, [Validators.required]),
    latitude: new FormControl(0.0, [Validators.required]),
    name: new FormControl('', [Validators.required]),
    description: new FormControl(''),
    type: new FormControl('', [Validators.required])
  })

  selectedFile: File | null = null;
  imagePreview: string | null = null;

  constructor(
    private service: DestinationService,
    private imageService: ImageService
    ) {}

  ngAfterViewInit(): void {
    if (this.shouldEdit) {
      this.mapComponent.addMarker(
        this.destination.latitude,
        this.destination.longitude
      );
    }
    this.setMapCenter();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.destinationForm.reset();
    if (this.shouldEdit){
      this.imagePreview = this.getFullImageUrl(this.destination.imageURL);
      this.destinationForm.patchValue(this.destination);
      this.mapComponent.addMarker(this.destination.latitude, this.destination.longitude);
    }
    else{
      this.mapComponent.removeMarker();
      this.imagePreview = null;
    }
    this.setMapCenter();
  }

  getFullImageUrl(imageURL?: string): string {
    if(imageURL)
      return this.imageService.getFullImageUrl(imageURL);
    else
      return "Destination Image";
  }

  onFileSelected(event: Event) {
    const target = event.target as HTMLInputElement;
    if (target.files && target.files.length > 0) {
      const file = target.files[0];
      this.selectedFile = file;
    
      if (file) {
        const reader = new FileReader();
        reader.onload = () => {
          this.imagePreview = reader.result as string;
        };
        reader.readAsDataURL(file);
      }
    }
  }

  submitDestination(): void {
    if (this.selectedFile && !this.shouldEdit) {
      this.uploadImage().subscribe({
        next: (response) => {
          this.addDestination(response.text);
          this.destinationForm.reset();
        },
      });
    } else if (this.selectedFile && this.shouldEdit) {
      this.uploadImage().subscribe({
        next: (response) => {
          this.updateDestination(response.text);
        },
      });
    } else if (!this.selectedFile && this.shouldEdit) {
      this.updateDestination();
    } else {
      this.addDestination();
      this.destinationForm.reset();
    }
  }

  addDestination(imageURL?: string): void {
    const destination: Destination = {
      id: 0,
      personId: 0,
      longitude: this.destinationForm.value.longitude || 0,
      latitude: this.destinationForm.value.latitude || 0,
      name: this.destinationForm.value.name || '',
      description: this.destinationForm.value.description || '',
      imageURL: imageURL || '',
      type: this.destinationForm.value.type || '',
    };

    this.service.addDestination(destination).subscribe({
      next: () => {
        this.destinationsUpdated.emit();
        this.mapComponent.removeMarker();
        this.selectedFile = null;
        this.imagePreview = null;
        this.fileInput.nativeElement.value = '';
        this.service.showDestinationCreated();
      }
    });
  }

  updateDestination(imageURL?: string): void{
    const destination: Destination = {
      id: this.destination.id,
      personId: this.destination.personId,
      name: this.destinationForm.value.name || "",
      description: this.destinationForm.value.description || "",
      imageURL: imageURL || this.destination.imageURL,
      longitude: this.destinationForm.value.longitude || 0,
      latitude: this.destinationForm.value.latitude || 0,
      type: this.destinationForm.value.type || '',
    };
    this.service.updateDestination(destination).subscribe({
      next: () => { 
        this.destinationsUpdated.emit();
        this.selectedFile = null;
        this.fileInput.nativeElement.value = '';
        this.service.showDestinationEdited();
      }
    });
  }
  
  uploadImage(): Observable<TextWrapper> {
    if (this.selectedFile instanceof File) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      return this.imageService.uploadImage(formData);
    }
    return new Observable<TextWrapper>();
  }

  createDestination(imageURL: string) {
    const destination: Destination = {
      id: 0,
      personId: 0,
      longitude: this.destinationForm.value.longitude || 0,
      latitude: this.destinationForm.value.latitude || 0,
      name: this.destinationForm.value.name || '',
      description: this.destinationForm.value.description || '',
      imageURL: imageURL,
      type: this.destinationForm.value.type || '',
    };

    this.service.addDestination(destination).subscribe({
      next: () => {
        this.destinationsUpdated.emit();
      }
    });
  }

  setMapCenter(): void {
    if (this.shouldEdit){
      this.mapComponent.setMapCenter(this.destination.latitude, this.destination.longitude);
    }
    else {
      this.mapComponent.setMapCenter();
    }
  }

  emitCloseForm(): void {
    this.closeForm.emit();
  }

  onPinPlaced(event: AddressTest): void {
    this.destinationForm.get('longitude')?.setValue(event.lng);
    this.destinationForm.get('latitude')?.setValue(event.lat);
  }
}
