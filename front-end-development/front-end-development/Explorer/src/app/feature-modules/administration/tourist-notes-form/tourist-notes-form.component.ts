import { Component, EventEmitter, Inject, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AdministrationService } from '../administration.service';
import { TouristNotes } from '../model/touristNotes.model';

@Component({
  selector: 'xp-tourist-notes-form',
  templateUrl: './tourist-notes-form.component.html',
  styleUrls: ['./tourist-notes-form.component.css']
})
export class TouristNotesFormComponent {

  @Output() touristNotesUpdated = new EventEmitter<null>();
  @Input() touristNote: TouristNotes;
  @Input() shouldEdit: boolean = false;

  constructor(private service: AdministrationService) {
  }

  ngOnChanges(): void {
    this.touristNoteForm.reset();
    if(this.shouldEdit) {
      this.touristNoteForm.patchValue(this.touristNote);
    }
  }

  touristNoteForm = new FormGroup({
    note: new FormControl('', [Validators.required]),
  });

  addTouristNote(): void {
    const touristNote: TouristNotes = {
      userId: 10,
      note: this.touristNoteForm.value.note || "",
    };
    this.service.addTouristNote(touristNote).subscribe({
      next: () => { this.touristNotesUpdated.emit() }
    });
  }

  updateTouristNote(): void {
    const touristNote: TouristNotes = {
      userId: 10,
      note: this.touristNoteForm.value.note || "",
    };
    touristNote.id = this.touristNote.id;
    this.service.updateTouristNote(touristNote).subscribe({
      next: () => { this.touristNotesUpdated.emit();}
    });
  }
}
