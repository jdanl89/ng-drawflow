import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { FormTemplate } from '../models/formTemplate';

@Component({
  selector: 'app-form-template-details',
  templateUrl: './form-template-details.component.html',
  styleUrl: './form-template-details.component.scss',
})
export class FormTemplateDetailsComponent implements OnInit {
  editMode: boolean = false;
  formId!: number;
  formTemplateId!: number;
  formTemplate!: FormTemplate;
  formGroup: FormGroup = this.formBuilder.group({
    name: ['', [Validators.required, Validators.maxLength(50)]],
    description: ['', [Validators.required, Validators.maxLength(200)]],
  });
  iframeSrc: any = '';
  previewLink: any = '';

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private sanitizer: DomSanitizer,
  ) {}

  ngOnInit(): void {
    this.formId = this.route.snapshot.params['formId'];
    this.formTemplateId = this.route.snapshot.params['templateId'];

    this.getFormTemplate().subscribe({
      next: (result) => {
        this.formTemplate = result;
        this.resetForm();

        this.generatePreview();
      },
      error: (error) => console.error(error),
      complete: () => {},
    });
  }

  getFormTemplate = (): Observable<FormTemplate> =>
    this.http.get<FormTemplate>(`/api/forms/templates/${this.formTemplateId}`);

  generatePreview(): void {
    // https://stackoverflow.com/a/55626497/7848128
    // https://stackblitz.com/edit/display-image-from-api?file=src%2Fapp%2Fapp.component.ts

    this.http
      .get(`/api/forms/templates/${this.formTemplateId}/file`, {
        observe: 'response',
        responseType: 'blob',
      })
      .subscribe({
        next: (result) => {
          let blob: Blob = result.body as Blob;
          let formUrl = URL.createObjectURL(blob);

          console.log(blob.type);
          console.log(formUrl.toString().substring(5));

          switch (blob.type) {
            case 'text/trf': // rich text format
            case 'text/richtext': // rich text format
            case 'application/rtf': // rich text format
            case 'application/msword': // .doc
            case 'application/vnd.ms-word.document.macroEnabled.12': // .docm
            case 'application/vnd.openxmlformats-officedocument.wordprocessingml.document': // .docx
              // word documents will need to be downloaded.
              this.previewLink = formUrl.toString();
              break;
            case 'text/html': // .html
            case 'text/plain': // .txt
            case 'application/pdf': // pdf
            default:
              // text and PDF documents can be previewed in the browser.
              this.iframeSrc = this.sanitizer.bypassSecurityTrustResourceUrl(
                formUrl.toString(),
              );
              break;
          }
        },
        error: (error) => console.error(error),
        complete: () => {},
      });
  }

  resetForm(): void {
    this.editMode = false;

    this.formGroup.setValue({
      name: this.formTemplate.name,
      description: this.formTemplate.description,
    });

    this.formGroup.markAsPristine();
  }

  submitForm(): void {
    if (this.formGroup.valid) {
      this.http
        .put<FormTemplate>(
          `/api/forms/templates/${this.formTemplateId}`,
          this.formGroup.value,
        )
        .subscribe({
          next: (result) => {
            this.formTemplate = result;
            this.resetForm();
          },
          error: (error) => console.error(error),
          complete: () => {},
        });
    }
  }
}
