import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StatisticService } from '../statistic.service';
import { SingleTourStatistic } from '../model/single-tour-statistic.model';

@Component({
  selector: 'xp-single-tour-statistic',
  templateUrl: './single-tour-statistic.component.html',
  styleUrls: ['./single-tour-statistic.component.css']
})
export class SingleTourStatisticComponent {


  constructor(private service : StatisticService, private route : ActivatedRoute){}

  tourId : number;
  tourStatistic : SingleTourStatistic = {sales : 0, executions : 0, finishes : 0, checkpointPercentages : new Map()}
  abc : number[] = [1,2,3,4,5]
  checkpointPercentagesArray: { key: string; value: number }[] = [];

  ngOnInit(){
    this.route.params.subscribe((param) => (this.tourId = param['id']));
    this.service.getStatisticForTour(this.tourId).subscribe({
      next : (result : SingleTourStatistic) =>{
        if (result.checkpointPercentages && typeof result.checkpointPercentages === 'object') {
          // Convert object to array for *ngFor
          this.checkpointPercentagesArray = Object.entries(result.checkpointPercentages).map(([key, value]) => ({
            key,
            value,
          }));
          this.tourStatistic = result;
        } else {
          console.error('Checkpoint percentages is not an object:', result.checkpointPercentages);
        }
      }
    })
  }



}
