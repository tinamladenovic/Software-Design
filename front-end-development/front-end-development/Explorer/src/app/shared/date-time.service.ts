import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateTimeService {

  constructor() { }

  getEndOfMonth(): Date {
    const now = new Date();
    const endOfMonth = new Date(now.getFullYear(), now.getMonth() + 1, 0);
    endOfMonth.setHours(23, 59, 59, 999); // Set the time to the end of the day

    return endOfMonth;
  }

  getEndOfWeek(): Date {
    const now = new Date();
    const dayOfWeek = now.getDay() ? now.getDay() : 7;
    const numDay = now.getDate();

    const startOfWeek = new Date(now.setDate(numDay - dayOfWeek));
    const endOfWeek = new Date(startOfWeek);
    endOfWeek.setDate(endOfWeek.getDate() + 7);
    endOfWeek.setHours(23, 59, 59, 999); // Set the time to the end of the day

    return endOfWeek;
  }

  getCountdown(endTime: Date): string {
    const now = new Date();
    const distance = endTime.getTime() - now.getTime();

    const days = Math.floor(distance / (1000 * 60 * 60 * 24));
    const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    const seconds = Math.floor((distance % (1000 * 60)) / 1000);

    return `${days}d ${hours}h ${minutes}m ${seconds}s`;
  }
}
