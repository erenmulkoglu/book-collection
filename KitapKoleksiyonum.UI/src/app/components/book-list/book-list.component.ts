import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BookService } from '../../services/book.service';
import { Book, ReadingStatus } from '../../models/book.model';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  filteredBooks: Book[] = [];
  selectedStatus: string = 'all';
  ReadingStatus = ReadingStatus;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe({
      next: (data) => {
        this.books = data;
        this.filteredBooks = data;
      },
      error: (error) => {
        console.error('Kitaplar yüklenemedi:', error);
        alert('Kitaplar yüklenirken bir hata oluştu!');
      }
    });
  }

  filterByStatus(status: string): void {
    this.selectedStatus = status;
    if (status === 'all') {
      this.filteredBooks = this.books;
    } else {
      const statusValue = parseInt(status);
      this.filteredBooks = this.books.filter(book => book.status === statusValue);
    }
  }

  getStatusText(status: ReadingStatus): string {
    switch (status) {
      case ReadingStatus.ToRead:
        return 'Okunacak';
      case ReadingStatus.Reading:
        return 'Okunuyor';
      case ReadingStatus.Completed:
        return 'Okundu';
      default:
        return '';
    }
  }

  getStatusClass(status: ReadingStatus): string {
    switch (status) {
      case ReadingStatus.ToRead:
        return 'status-toread';
      case ReadingStatus.Reading:
        return 'status-reading';
      case ReadingStatus.Completed:
        return 'status-completed';
      default:
        return '';
    }
  }

 deleteBook(id: number): void {
  console.log('Silinecek kitap ID:', id);  // ← Debug ekledim
  console.log('API URL:', `http://localhost:5116/api/books/${id}`);  // ← Debug ekledim
  
  if (confirm('Bu kitabı silmek istediğinizden emin misiniz?')) {
    this.bookService.deleteBook(id).subscribe({
      next: () => {
        this.loadBooks();
        alert('Kitap başarıyla silindi!');
      },
      error: (error) => {
        console.error('Kitap silinemedi:', error);
        alert('Kitap silinirken bir hata oluştu!');
      }
    });
  }
}
}