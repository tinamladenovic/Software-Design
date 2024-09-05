export interface TourReview{
    tourId: number,
    userId: number,
    grade: number,
    comment: string
    timeOfComment: Date,
    timeOfTour: Date
}