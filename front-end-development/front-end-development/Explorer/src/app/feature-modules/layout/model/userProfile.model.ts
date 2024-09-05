export interface UserProfile {
  id: number;
  userId: number;
  name: string;
  surname: string;
  email: string;
  motto: string;
  biography: string;
  image?: File | null;
}

export interface TouristWallet {
  id: number;
  userId: number;
  adventureCoins: number;
}

export interface Questionnaire {
  id: number;
  question: string;
  answer: string;
}

export interface AnswerDate {
  id: number;
  userId: number;
  lastAnswerDate: Date;
}
