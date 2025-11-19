export interface Book {
  id: number;
  title: string;
  author: string;
  isbn?: string;
  pageCount?: number;
  publishDate?: Date;
  status: ReadingStatus;
  rating?: number;
  notes?: string;
  categoryId: number;
  categoryName: string;
  createdAt: Date;
}

export interface CreateBook {
  title: string;
  author: string;
  isbn?: string;
  pageCount?: number;
  publishDate?: Date;
  status: ReadingStatus;
  rating?: number;
  notes?: string;
  categoryId: number;
}

export interface UpdateBook {
  title: string;
  author: string;
  isbn?: string;
  pageCount?: number;
  publishDate?: Date;
  status: ReadingStatus;
  rating?: number;
  notes?: string;
  categoryId: number;
}

export enum ReadingStatus {
  ToRead = 0,
  Reading = 1,
  Completed = 2
}