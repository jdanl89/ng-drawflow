import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrawflowComponent } from './features/drawflow/drawflow.component';
import { FormCreateComponent } from './features/forms/form-create/form-create.component';
import { FormDetailsComponent } from './features/forms/form-details/form-details.component';
import { FormDashboardComponent } from './features/forms/form-dashboard/form-dashboard.component';
import { FormTemplateDetailsComponent } from './features/forms/form-template-details/form-template-details.component';
import { HomeComponent } from './features/home/home.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'drawflow', component: DrawflowComponent },
  { path: 'forms', component: FormDashboardComponent },
  { path: 'forms/create', component: FormCreateComponent },
  { path: 'forms/:id', component: FormDetailsComponent },
  {
    path: 'forms/:formId/templates/:templateId',
    component: FormTemplateDetailsComponent,
  },
  { path: '', component: HomeComponent },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
