import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BookService } from '../../services/book.service';
import { CategoryService } from '../../services/category.service';
import { CreateBook, UpdateBook, ReadingStatus } from '../../models/book.model';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-book-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.css'
})
export class BookFormComponent implements OnInit {
  bookId: number | null = null;
  isEditMode = false;
  categories: Category[] = [];
  ReadingStatus = ReadingStatus;

  book = {
    title: '',
    author: '',
    isbn: '',
    pageCount: null as number | null,
    publishDate: null as Date | null,
    status: ReadingStatus.ToRead,
    rating: null as number | null,
    notes: '',
    categoryId: 0
  };

  constructor(
    private bookService: BookService,
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadCategories();

    this.route.params.subscribe(params => {
      if (params['id']) {
        this.bookId = +params['id'];
        this.isEditMode = true;
        this.loadBook(this.bookId);
      }
    });
  }

  loadCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (data) => {
        this.categories = data;
        if (this.categories.length > 0 && !this.isEditMode) {
          this.book.categoryId = this.categories[0].id;
        }
      },
      error: (error) => {
        console.error('Kategoriler yüklenemedi:', error);
      }
    });
  }

 loadBook(id: number): void {
  this.bookService.getBook(id).subscribe({
    next: (data) => {
      this.book = {
        title: data.title,
        author: data.author,
        isbn: data.isbn || '',
        pageCount: data.pageCount ?? null,  
        publishDate: data.publishDate || null,
        status: data.status,
        rating: data.rating ?? null,  
        notes: data.notes || '',
        categoryId: data.categoryId
      };
    },
    error: (error) => {
      console.error('Kitap yüklenemedi:', error);
      alert('Kitap yüklenirken bir hata oluştu!');
      this.router.navigate(['/']);
    }
  });
}

formatDate(date: Date | null): string {
  if (!date) return '';
  const d = new Date(date);
  const year = d.getFullYear();
  const month = String(d.getMonth() + 1).padStart(2, '0');
  const day = String(d.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

onDateChange(event: Event): void {
  const input = event.target as HTMLInputElement;
  this.book.publishDate = input.value ? new Date(input.value) : null;
}
onStatusChange(event: Event): void {
  const select = event.target as HTMLSelectElement;
  this.book.status = Number(select.value);
}

 onSubmit(): void {
  if (!this.book.title || !this.book.author || !this.book.categoryId) {
    alert('Lütfen zorunlu alanları doldurun!');
    return;
  }

 if (this.isEditMode && this.bookId) {
  console.log('=== UPDATE MOD ===');
  console.log('Book Status:', this.book.status);
  console.log('Status Type:', typeof this.book.status);
  console.log('Book Data:', this.book);
  
  const updateBook: UpdateBook = {
    title: this.book.title,
    author: this.book.author,
    isbn: this.book.isbn || undefined,
    pageCount: this.book.pageCount || undefined,
    publishDate: this.book.publishDate ? new Date(this.book.publishDate).toISOString() as any : undefined,  
    status: this.book.status,
    rating: this.book.rating || undefined,
    notes: this.book.notes || undefined,
    categoryId: this.book.categoryId
  };

  console.log('Gönderilecek UpdateBook:', updateBook);  

  this.bookService.updateBook(this.bookId, updateBook).subscribe({
    next: () => {
      alert('Kitap başarıyla güncellendi!');
      this.router.navigate(['/']);
    },
    error: (error) => {
      console.error('Kitap güncellenemedi:', error);
      console.error('Error response:', error.error);  
      alert('Kitap güncellenirken bir hata oluştu!');
    }
  });
} else {
  const createBook: CreateBook = {
    title: this.book.title,
    author: this.book.author,
    isbn: this.book.isbn || undefined,
    pageCount: this.book.pageCount || undefined,
    publishDate: this.book.publishDate ? new Date(this.book.publishDate).toISOString() as any : undefined,  
    status: this.book.status,
    rating: this.book.rating || undefined,
    notes: this.book.notes || undefined,
    categoryId: this.book.categoryId
  };

    this.bookService.createBook(createBook).subscribe({
      next: () => {
        alert('Kitap başarıyla eklendi!');
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.error('Kitap eklenemedi:', error);
        console.log('Gönderilen veri:', createBook);  
        alert('Kitap eklenirken bir hata oluştu!');
      }
    });
  }
}

  cancel(): void {
    this.router.navigate(['/']);
  }
}