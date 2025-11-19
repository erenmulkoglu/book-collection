import { Routes } from '@angular/router';
import { BookListComponent } from './components/book-list/book-list.component';
import { BookFormComponent } from './components/book-form/book-form.component';

export const routes: Routes = [
  { 
    path: '', 
    component: BookListComponent 
  },
  { 
    path: 'book-form', 
    component: BookFormComponent 
  },
  { 
    path: 'book-form/:id', 
    component: BookFormComponent 
  }
];