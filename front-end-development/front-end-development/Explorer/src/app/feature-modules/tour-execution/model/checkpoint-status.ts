import { DatePipe } from "@angular/common";

export interface CheckpointStatus {
    checkpointId : number,
    isCompleted : boolean,
    completionTime? : Date 
}