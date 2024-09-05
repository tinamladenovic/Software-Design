import { Equipment } from "../../administration/model/equipment.model"
import { Checkpoint } from "./checkpoint.model"
import { TravelTimeAndMethod } from "./travel-time-and-method.model"

export interface Tour{
    id: number,
    authorId: number,
    name: string,
    description: string,
    tags: string,
    difficult: number,
    price: number,
    status: number,
    publishTime : Date,
    archiveTime : Date,
    checkpoints: Checkpoint[],
    distance : number,
    travelTimeAndMethod : TravelTimeAndMethod[],
    tourEquipment : Equipment[],
}