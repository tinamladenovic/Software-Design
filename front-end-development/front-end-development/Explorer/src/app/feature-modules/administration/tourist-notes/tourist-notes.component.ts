import { Component, OnInit } from '@angular/core';
import { TouristNotes } from '../model/touristNotes.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { AdministrationService } from '../administration.service';

@Component({
  selector: 'xp-tourist-notes',
  templateUrl: './tourist-notes.component.html',
  styleUrls: ['./tourist-notes.component.css']
})
export class TouristNotesComponent implements OnInit {

  touristNotes: TouristNotes[] = [];
  selectedTouristNote: TouristNotes;
  shouldRenderEquipmentForm: boolean = false;
  shouldEdit: boolean = false;
  
  constructor(private service: AdministrationService) { }

  ngOnInit(): void {
    this.getTouristNotes();
  }

  deleteTouristNote(id: number): void {
    this.service.deleteTouristNote(id).subscribe({
      next: () => {
        this.getTouristNotes();
      },
    })
  }

  getTouristNotes(): void {
    this.service.getTouristNotes().subscribe({
      next: (result: PagedResults<TouristNotes>) => {
        this.touristNotes = result.results;
        console.log(result.results)
      },
      error: () => {
      }
    })
  }
  onEditClicked(touristNotes: TouristNotes): void {
    this.selectedTouristNote = touristNotes;
    this.shouldRenderEquipmentForm = true;
    this.shouldEdit = true;
  }

  onAddClicked(): void {
    this.shouldEdit = false;
    this.shouldRenderEquipmentForm = true;
  }

}
