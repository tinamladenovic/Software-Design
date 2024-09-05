import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Checkpoint } from '../model/checkpoint.model';

@Component({
  selector: 'xp-tour-checkpoint',
  templateUrl: './tour-checkpoint.component.html',
  styleUrls: ['./tour-checkpoint.component.css']
})
export class TourCheckpointComponent {
  @Input() checkpoint : Checkpoint;
  @Output() removeCheckpoint = new EventEmitter<Checkpoint>

  removeCheckpointClick(){
    this.removeCheckpoint.emit(this.checkpoint);
  }
}
