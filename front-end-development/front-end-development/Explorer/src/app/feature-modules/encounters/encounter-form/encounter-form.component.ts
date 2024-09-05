import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild, } from '@angular/core';
import { Encounter } from '../model/encounters.model';
import { EncounterService } from '../encounter.service';
import { MapComponent } from 'src/app/shared/map/map.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddressTest } from '../../tour-authoring/model/address-test.model';
import { TextWrapper } from 'src/app/shared/model/text-wrapper.model';
import { Coordinate } from '../../tour-execution/model/coordinate';
import { Observable } from 'rxjs';
import { Checkpoint } from '../../tour-authoring/model/checkpoint.model';
import { ImageService } from 'src/app/shared/image.service';
import { EncounterDrawService } from '../encounter-draw.service';

@Component({
  selector: 'xp-encounter-form',
  templateUrl: './encounter-form.component.html',
  styleUrls: ['./encounter-form.component.css'],
})
export class EncounterFormComponent implements OnChanges, AfterViewInit {
  @Output() encountersUpdated = new EventEmitter<null>();
  @Output() closeForm = new EventEmitter<null>();
  @Input() shouldEdit: boolean = false;
  @Input() encounter: Encounter;
  @Input() typeValue: number;
  @Input() checkpoint: Checkpoint | null;
  @ViewChild(MapComponent) mapComponent: MapComponent;
  @ViewChild('fileInput') fileInput: ElementRef;
  selectedFile: File | null = null;

  encounterForm = new FormGroup({
    longitude: new FormControl(0.0, [Validators.required]),
    latitude: new FormControl(0.0, [Validators.required]),
    status: new FormControl(0.0, [Validators.required]),
    name: new FormControl('', [Validators.required]),
    xp: new FormControl(0.0, [Validators.required]),
    description: new FormControl(''),
    type: new FormControl(0.0, [Validators.required]),
    range: new FormControl(0.0, [Validators.required]),
    miscEncounterTask: new FormControl('', [Validators.required]),
    socialEncounterRequiredPeople: new FormControl(0.0, [Validators.required]),
    isRequired: new FormControl(false, [Validators.required]),
  });

  constructor(
    private service: EncounterService,
    private imageService: ImageService,
    private drawService: EncounterDrawService
  ) { }

  ngAfterViewInit(): void {
    if (this.shouldEdit) {
      this.mapComponent.addMarker(
        this.encounter.coordinates.latitude,
        this.encounter.coordinates.longitude
      );
    }
    this.setMapCenter();
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    this.encounterForm.reset();
    if (this.checkpoint) {
      this.setDefaultCheckpointEncounterValues();
    }
    if (this.shouldEdit) {
      this.encounterForm.patchValue(this.encounter);
      this.encounterForm.patchValue({
        longitude: this.encounter.coordinates.longitude,
        latitude: this.encounter.coordinates.latitude,
      });
      this.mapComponent.addMarker(
        this.encounter.coordinates.latitude,
        this.encounter.coordinates.longitude
      );
    } else {
      this.encounterForm.get('status')?.setValue(0);
      this.encounterForm.get('type')?.setValue(this.typeValue);
      this.mapComponent.removeMarker();
    }
    this.setMapCenter();
  }

  setMapCenter(): void {
    if (this.shouldEdit){
      this.mapComponent.setMapCenter(this.encounter.coordinates.latitude, this.encounter.coordinates.longitude);
    }
    else {
      this.mapComponent.setMapCenter();
    }
  }

  private setDefaultCheckpointEncounterValues(): void {
    this.encounterForm.get('longitude')?.setValue(this.checkpoint!.longitude);
      this.encounterForm.get('latitude')?.setValue(this.checkpoint!.latitude);
      this.encounterForm.get('range')?.setValue(50);
      this.encounterForm.get('isRequired')?.setValue(false);
      this.encounterForm.get('status')?.setValue(0);
      this.encounterForm.get('longitude')?.disable();
      this.encounterForm.get('latitude')?.disable();
      this.encounterForm.get('range')?.disable();
      this.encounterForm.get('status')?.disable();
  }

  submitEncounter(): void {
    if (this.selectedFile && !this.shouldEdit) {
      this.uploadImage().subscribe({
        next: (response) => {
          this.addEncounter(response.text);
          this.encounterForm.reset();
        },
      });
    } else if (this.selectedFile && this.shouldEdit) {
      this.uploadImage().subscribe({
        next: (response) => {
          this.updateEncounter(response.text);
        },
      });
    } else if (!this.selectedFile && this.shouldEdit) {
      this.updateEncounter();
    } else {
      this.addEncounter();
      this.encounterForm.reset();
    }
  }

  addEncounter(imageURL?: string) {
    let encounter: Encounter = {
      coordinates: {
        longitude: this.encounterForm.value.longitude || 0,
        latitude: this.encounterForm.value.latitude || 0,
      },
      name: this.encounterForm.value.name || '',
      description: this.encounterForm.value.description || '',
      imageUrl: imageURL || undefined,
      type: this.encounterForm.value.type || 0,
      xp: this.encounterForm.value.xp || 0,
      status: this.encounterForm.value.status ?? 0,
      range: this.encounterForm.value.range || 0,
      miscEncounterTask: this.encounterForm.value.miscEncounterTask || undefined,
      socialEncounterRequiredPeople: this.encounterForm.value.socialEncounterRequiredPeople || undefined
    };

    if (this.checkpoint) {
      encounter.checkpointId = this.checkpoint.id;
      encounter.isRequired = this.encounterForm.value.isRequired!;
      encounter.coordinates.latitude = this.checkpoint.latitude;
      encounter.coordinates.longitude = this.checkpoint.longitude;
      encounter.range = 50;
    }

    this.service.addEncounter(encounter).subscribe({
      next: () => {
        this.encountersUpdated.emit();
        this.drawService.showEncounterCreated();
        this.mapComponent.removeMarker();
        this.selectedFile = null;
        this.fileInput.nativeElement.value = '';
      },
    });
  }

  updateEncounter(imageURL?: string): void {
    const encounter: Encounter = {
      id: this.encounter.id,
      coordinates: {
        longitude: this.encounterForm.value.longitude || 0,
        latitude: this.encounterForm.value.latitude || 0,
      },
      name: this.encounterForm.value.name || '',
      description: this.encounterForm.value.description || '',
      imageUrl: imageURL || this.encounter.imageUrl,
      type: this.encounter.type,
      xp: this.encounterForm.value.xp || 0,
      status: this.encounterForm.value.status ?? 0,
      range: this.encounterForm.value.range || 0,
      miscEncounterTask: this.encounterForm.value.miscEncounterTask || undefined,
      socialEncounterRequiredPeople: this.encounterForm.value.socialEncounterRequiredPeople || undefined,
    };
    this.service.updateEncounter(encounter).subscribe({
      next: () => {
        this.encountersUpdated.emit();
        this.drawService.showEncounterEdited();
        this.selectedFile = null;
        this.fileInput.nativeElement.value = '';
      },
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

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0] as File;
  }

  patchEncounterType(type: number): void {
    this.typeValue = type;
  }

  onPinPlaced(event: AddressTest): void {
    this.encounterForm.get('longitude')?.setValue(event.lng);
    this.encounterForm.get('latitude')?.setValue(event.lat);
  }

  emitCloseForm(): void {
    this.closeForm.emit();
  }
}
