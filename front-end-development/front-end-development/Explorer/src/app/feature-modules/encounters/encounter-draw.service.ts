import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Encounter, EncounterStatistics, EncounterType } from './model/encounters.model';
import { EncounterExecutionService } from './encounter-execution.service';
import { EncounterService } from './encounter.service';
import { EMPTY, Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { ImageService } from 'src/app/shared/image.service';

@Injectable({
  providedIn: 'root'
})
export class EncounterDrawService {

  constructor(private imageService: ImageService, private executionService: EncounterExecutionService, private toastr: ToastrService) { }

  generateEncounterPopUp(encounter: Encounter, encounterStats: EncounterStatistics): string {
    let specifics = '';
    switch (encounter.type) {
      case EncounterType.Social:
        specifics = this.generateSocialEncounterSpecifics(encounter);
        break;
      case EncounterType.HiddenLocation:
        specifics = this.generateHiddenLocationEncounterSpecifics(encounter);
        break;
      case EncounterType.Misc:
        specifics = this.generateMiscEncounterSpecifics(encounter);
        break;
    }
    return this.generateCommonEncounterHTML(encounter, encounterStats) + specifics + this.generateEncounterButton(encounter.id!);
  }

  generateCommonEncounterHTML(encounter: Encounter, encounterStats: EncounterStatistics): string {
    return `<div style="text-align: center; padding: 10px; padding-bottom: 0px; font-size: 1.15em;">
              <h2 style="font-weight: bold; margin-bottom: 10px;">${encounter.name}</h2>
              <p style="margin-bottom: 10px;">${encounter.description}</p>
              <p style="margin-bottom: 10px;"><strong>Type:</strong> ${EncounterType[encounter.type]}</p>
              <p style="margin-bottom: 10px;"><strong>XP:</strong> ${encounter.xp}</p>
              <p style="margin-bottom: 10px;"><strong>Success Rate:</strong> ${encounterStats.completedCount} / ${encounterStats.completedCount + encounterStats.abandonedCount} completed</p>
            </div>`;
  }
  
  generateSocialEncounterSpecifics(encounter: Encounter): string {
    return `<div style="text-align: center; font-size: 1.15em;"><strong>Required People:</strong> ${encounter.socialEncounterRequiredPeople}</div><br>`;
  }
  
  generateHiddenLocationEncounterSpecifics(encounter: Encounter): string {
    const imageUrl = this.getFullImageUrl(encounter.imageUrl);
    return `<div style="display: flex; justify-content: center; font-size: 1.15em; margin-bottom: 20px;">
              <img src="${imageUrl}" alt="Image" style="max-height: 175px; width: 270px;">
            </div>`;
  }
  
  generateMiscEncounterSpecifics(encounter: Encounter): string {
    return `<div style="text-align: center; font-size: 1.15em;"><strong>Task:</strong> ${encounter.miscEncounterTask}</div><br>`;
  }
  
  generateEncounterButton(encounterId: number): string {
    return `<div style="display: flex; justify-content: center;">
              <button onclick="activateEncounter(${encounterId})" style="background-color: #315149; border: none; border-radius: 20px; padding: 10px 20px; font-size: 1.2em; color: white; transition: all 0.3s ease 0s; cursor: pointer; outline: none;">
                Activate Encounter
              </button>
            </div>`;
  }
  getFullImageUrl(imageURL?: string): string {
    if (imageURL)
      return this.imageService.getFullImageUrl(imageURL);
    else
      return "No Image";
  }

  showEncounterCreated(): void {
    this.toastr.success('Encounter successfully created.', 'Encounter created');
  }

  showEncounterEdited(): void {
    this.toastr.success('Encounter successfully edited.', 'Encounter edited');
  }

  showEncounterDeleted(): void {
    this.toastr.success('Encounter successfully deleted.', 'Encounter deleted');
  }

  showHiddenLocationFound(): void {
    this.toastr.success('You\' found the hidden location, stay put for 30 seconds to complete the encounter.', 'Hidden location found');
  }

  showHiddenLocationExited(): void {
    this.toastr.warning('Yo\'ve gone too far from the hidden location.', 'Hidden location exited');
  }

  showEncounterActivated(): void {
    this.toastr.info('You activated the encounter successfully.', 'Encounter activated');
  }

  showEncounterCompleted(): void {
    this.toastr.success('You finished the encounter successfully.', 'Encounter completed');
  }

  showUnableToActivate(message: string): void {
    this.toastr.warning(`Error! ${message}`, 'Encounter can not be activated');
  }

  showAlreadyCompleted(): void {
    this.toastr.warning('You already completed the encounter..', 'Encounter can not be activated');
  }

  showEncounterAbandoned(): void {
    this.toastr.success('You abandoned the active encounter.', 'Encounter abandoned');
  }

  showForcedEncounterAbandon(): void {
    this.toastr.warning('Encounter abandoned, you\'ve left the encounter range.', 'Encounter abandoned');
  }

}
