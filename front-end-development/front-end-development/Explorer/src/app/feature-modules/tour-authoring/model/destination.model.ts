export interface Destination{
    id: number,
    personId: number,
    longitude: number,
    latitude: number, 
    name: string,
    description?: string,
    imageURL?: string,
    type: string
}