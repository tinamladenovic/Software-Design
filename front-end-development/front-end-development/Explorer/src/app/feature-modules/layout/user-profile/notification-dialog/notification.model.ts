export interface NotificationModel {
    id?: number;
    senderId: number;
    receiverId: number;
    message: string;
    isRead: boolean;
}