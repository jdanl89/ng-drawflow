import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Form } from '../models/form';

@Component({
  selector: 'app-form-dashboard',
  templateUrl: './form-dashboard.component.html',
  styleUrl: './form-dashboard.component.scss',
})
export class FormDashboardComponent implements OnInit {
  forms: Form[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getForms().subscribe({
      next: (result) => {
        this.forms = result;
      },
      error: (error) => console.error(error),
      complete: () => {},
    });
  }

  getForms = (): Observable<Form[]> => this.http.get<Form[]>('/api/forms');
}
