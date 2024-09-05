import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TouristclubService } from '../touristclub.service';
import { TouristClub } from '../model/touristclub.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-touristclub-form',
  templateUrl: './touristclub-form.component.html',
  styleUrls: ['./touristclub-form.component.css']
})
export class TouristclubFormComponent{
 
  @Output() clubUpdated = new EventEmitter<null>(); 

  selectedFile: File | null = null;
  selectedFileName: string | undefined;



  public message: string;
  public progress: number;
  @Output() public onUploadFinished = new EventEmitter();
 
  touristClubForm = new FormGroup({
    clubName: new FormControl('', [Validators.required ]),
    description: new FormControl(''),
    image: new FormControl('')
  });

  constructor(private service: TouristclubService,
              private toastr: ToastrService,
    ) { }

  addTouristClub() : void {
    const newClub: TouristClub = {
      clubName: this.touristClubForm.value.clubName || "",
      description: this.touristClubForm.value.description || ""
    };
    this.service.createTouristClub(newClub, this.selectedFile!).subscribe({
      next: () => {
         this.clubUpdated.emit();
          this.toastr.success("Club successfully created!")
      }
    });
  };

  onFileSelected(event: any) : void {
    const inputElement = event.target as HTMLInputElement;
    this.selectedFile = event.target.files[0] ?? null;
    this.selectedFileName = inputElement.files?.[0]?.name;
  }
}