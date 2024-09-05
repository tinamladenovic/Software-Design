export interface Checkpoint{
    id? : number,
    name : string,
    description : string, 
    pictureURL : string,
    latitude : number,
    longitude : number,
    tourId? : number,
    encounterId? : number,
    PublicRequest?: CheckpointRequest, 
}

export interface CheckpointRequest{
    status : RequestStatus,
    comment? : string,
}

enum RequestStatus{
    Accepted = 0,
    Rejected = 1,
    Pending = 2,
}