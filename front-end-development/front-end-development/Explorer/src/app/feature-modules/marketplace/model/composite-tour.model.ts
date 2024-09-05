import { Equipment } from "../../administration/model/equipment.model";
import { Checkpoint } from "../../tour-authoring/model/checkpoint.model";
import { Tour } from "../../tour-authoring/model/tour.model";

export interface CompositeTour {
    id: number;
    touristId : number;
    name: string;
    tours : Tour[];
    distance: number;
    difficult : number;
    equipments : Equipment[];
    checkpoints : Checkpoint[];
  }