export interface SingleTourStatistic{
    sales : number,
    executions : number,
    finishes : number,
    checkpointPercentages : Map<string,number>
}