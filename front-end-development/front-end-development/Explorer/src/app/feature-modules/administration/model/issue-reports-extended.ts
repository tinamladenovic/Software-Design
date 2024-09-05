export interface ReportE {
    id?: number,
    category: string;
    priority: number;
    description: string;
    dateCreated: Date;
    isPastDue: boolean;
}