import { Component, Inject, Input, OnInit } from '@angular/core';
import { TourStatus } from '../model/tour-status';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import TourBundle from '../model/tour-bundle';
import { TourAuthoringService } from '../tour-authoring.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-tour-bundle-dialog',
  templateUrl: './tour-bundle-dialog.component.html',
  styleUrls: ['./tour-bundle-dialog.component.css']
})


export class TourBundleDialogComponent implements OnInit{
  selectedToursPrice: number;
  constructor(
    public dialogRef: MatDialogRef<TourBundleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: TourAuthoringService,
    private toastr: ToastrService
  ){}
  
  ngOnInit(): void {
    this.selectedToursPrice = this.data.selectedTourPrice;
  }

  bundleForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    price: new FormControl(null, [Validators.required])
  })

  createBundle() : void{
    const bundleName = this.bundleForm.get('name')!.value as string;
    const bundlePrice = this.bundleForm.get('price')?.value as unknown as number;

    const newBundle : TourBundle = {
      id: 0,
      authorId: -1,
      name: bundleName,
      price: bundlePrice,
      status: 0,
      tours: this.data.selectedTours
    }
    console.log(newBundle);
    this.service.createTourBundle(newBundle).subscribe({
      next: () => {
        this.toastr.success("You created bundle successfully.")
      },
      error: () => {
        this.toastr.warning('Failed to create tourBundle.', 'Warning');
      }
    });
    this.dialogRef.close();
  }
  
  closeDialog() : void {
    this.dialogRef.close();
  }
}
