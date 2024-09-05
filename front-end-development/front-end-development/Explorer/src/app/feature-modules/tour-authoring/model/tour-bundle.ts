import { TourStatus } from "./tour-status";

export default interface TourBundle {
    id: number;
    authorId: number;
    name: string;
    price: number;
    status: number;
    tours: TourStatus[];
}