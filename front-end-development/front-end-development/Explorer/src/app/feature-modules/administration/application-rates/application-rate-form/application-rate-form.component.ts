import { Component } from '@angular/core';
import { AdministrationService } from '../../administration.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'xp-application-rate-form',
  templateUrl: './application-rate-form.component.html',
  styleUrls: ['./application-rate-form.component.css'],
})
export class ApplicationRateFormComponent {
  applicationRateForm = new FormGroup({
    rate: new FormControl<number>(1, {
      nonNullable: true,
      validators: [Validators.required],
    }),
    comment: new FormControl<string>('', []),
  });

  constructor(private readonly _administrationService: AdministrationService) {}

  createApplicationRate() {
    console.log(this.applicationRateForm.getRawValue());
    this._administrationService
      .createApplicationRate(this.applicationRateForm.getRawValue())
      .subscribe({
        next: (value) => {
          console.log(value);
        },
      });
  }
}
