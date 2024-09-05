import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TourExecutionService } from '../tour-execution.service';
import { Report } from '../../administration/model/issue-reports.model'
import { DatePipe} from '@angular/common'

@Component({
  selector: 'xp-report-form',
  templateUrl: './report-form.component.html',
  styleUrls: ['./report-form.component.css']
})
export class ReportFormComponent {

  constructor(private service: TourExecutionService) {}

  reportForm = new FormGroup({
    category: new FormControl('', [Validators.required]),
    priority: new FormControl(-1, [Validators.required]),
    description: new FormControl('', [Validators.required]),
    dateCreated: new FormControl(new Date, [Validators.required])
  })

  addReport(): void {
    console.log(this.reportForm.value)
    const currentDate = this.reportForm.get('dateCreated')?.value;
    

    const report: Report = {
      category: this.reportForm.value.category || "",
      priority: 0,
      description: this.reportForm.value.description || "",
      dateCreated: new Date(2023, 10, 2, 10, 48, 12, 123)
    } 
    
    this.service.addReport(report).subscribe({
      next: (_) => {
        
      }
    });

    this.reportForm.reset();
  }
}
