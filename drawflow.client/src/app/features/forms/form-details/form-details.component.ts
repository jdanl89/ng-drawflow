import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { Form } from '../models/form';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-details',
  templateUrl: './form-details.component.html',
  styleUrl: './form-details.component.scss',
})
export class FormDetailsComponent implements OnInit {
  editMode: boolean = false;
  formId!: number;
  form!: Form;
  formGroup: FormGroup = this.formBuilder.group({
    name: [
      '',
      [Validators.required, Validators.maxLength(50), Validators.nullValidator],
    ],
    description: [
      '',
      [
        Validators.required,
        Validators.maxLength(200),
        Validators.nullValidator,
      ],
    ],
  });

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private http: HttpClient,
  ) {}

  ngOnInit(): void {
    this.formId = this.route.snapshot.params['id'];

    this.getForm().subscribe({
      next: (result) => {
        this.form = result;
        this.formGroup.setValue({
          name: this.form.name,
          description: this.form.description,
        });
      },
      error: (error) => console.error(error),
      complete: () => {},
    });
  }

  getForm = (): Observable<Form> =>
    this.http.get<Form>(`/api/forms/${this.formId}`);

  resetForm(): void {
    this.editMode = false;
    this.formGroup.setValue({
      name: this.form.name,
      description: this.form.description,
    });
    this.formGroup.markAsPristine();
  }

  submitChanges(): void {
    if (this.formGroup.valid) {
      console.log('Form data:', this.formGroup.value);
      this.http
        .put<Form>(`/api/forms/${this.formId}`, this.formGroup.value)
        .subscribe({
          next: (result) => {
            this.form = result;
            this.formGroup.setValue({
              name: this.form.name,
              description: this.form.description,
            });
            this.formGroup.markAsPristine();
            this.editMode = false;
          },
          error: (error) => console.error(error),
          complete: () => {},
        });
    }
  }
}
