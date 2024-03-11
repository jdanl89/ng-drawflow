import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { Form } from '../models/form';
import { ActivatedRoute } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

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
    name: ['', [Validators.required, Validators.maxLength(50)]],
    description: ['', [Validators.required, Validators.maxLength(200)]],
  });

  addTemplateMode: boolean = false;
  templateFileName!: string;
  templateData: FormData = new FormData();
  templateGroup: FormGroup = this.formBuilder.group({
    name: ['', [Validators.required, Validators.maxLength(50)]],
    description: ['', [Validators.required, Validators.maxLength(200)]],
    templateFile: [null, Validators.required],
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

  submitForm(): void {
    if (this.formGroup.valid) {
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

  onTemplateFileSelected(event: any): void {
    if (event.target.files?.length != 1) {
      return;
    }

    const file: File = event.target.files[0];
    this.templateFileName = file.name;
    this.templateGroup.setControl('templateFile', new FormControl(file));
  }

  resetTemplate(): void {
    this.addTemplateMode = false;
    this.templateGroup.reset();
  }

  submitTemplate(): void {
    if (this.templateGroup.valid) {
      let formValues = this.templateGroup.value;
      let formData = new FormData();

      for (let key in formValues) {
        formData.append(key, formValues[key]);
      }

      console.log('Template data:', formData);
      this.http
        .post<Form>(`/api/forms/${this.formId}/template`, formData)
        .subscribe({
          next: (result) => {
            this.form = result;
            this.formGroup.setValue({
              name: this.form.name,
              description: this.form.description,
            });
            this.formGroup.markAsPristine();
            this.editMode = false;

            this.templateGroup.reset();
            this.addTemplateMode = false;
          },
          error: (error) => console.error(error),
          complete: () => {},
        });
    }
  }
}
