import { DatePipe } from "@angular/common";
import { CheckpointStatus } from "./checkpoint-status";

export enum TourExecutionStatus {
    Active,
    Completed,
    Abandoned
  }
export interface TourExecution{
    id : number,
    touristId : number,
    tourId : number,
    isComposite: boolean,
    lastActivity? : Date,
    status: TourExecutionStatus
    checkpointStatuses : CheckpointStatus[]
    completionPercentage?: number;
}