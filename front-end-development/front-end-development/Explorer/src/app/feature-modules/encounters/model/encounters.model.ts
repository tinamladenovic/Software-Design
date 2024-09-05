import { Coordinate } from "../../tour-execution/model/coordinate";

export enum EncounterStatus {
    Active = 0,
    Draft = 1,
    Archived = 2
}

export enum EncounterType {
    Social = 0,
    HiddenLocation = 1,
    Misc = 2
}

export interface Encounter{
    id? : number;
    name: string;
    description : string;
    coordinates: Coordinate;
    xp : number;
    status: EncounterStatus;
    type : EncounterType;
    range: number;
    imageUrl?: string;
    miscEncounterTask?: string;
    socialEncounterRequiredPeople?: number;
    checkpointId?: number;
    isRequired?: boolean;
}

export interface EncounterStatistics{
    encounterId: number;
    activeCount: number;
    completedCount: number;
    abandonedCount: number;
}