import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TouristClub } from '../model/touristclub.model';
import { TouristclubService } from '../touristclub.service';

@Component({
  selector: 'xp-touristclub-edit',
  templateUrl: './touristclub-edit.component.html',
  styleUrls: ['./touristclub-edit.component.css']
})
export class TouristclubEditComponent implements OnInit{
  
  @Input() touristClub: TouristClub;
  @Input() isEditMode: boolean;

  @Output() editingComplete = new EventEmitter<boolean>();
  
  constructor(private service: TouristclubService) {}

  ngOnInit(): void {
  }

  submitChanges() : void{
    this.service.updateClubDetails(this.touristClub).subscribe({
      next: (result : TouristClub) => {
        this.touristClub = result;
      },
      error: (err: any) => {
      }
    })
    this.isEditMode = false;
    this.editingComplete.emit(this.isEditMode); 
  }

  goBack() : void {
    this.isEditMode = false;
    this.editingComplete.emit(this.isEditMode); 
  }

}
