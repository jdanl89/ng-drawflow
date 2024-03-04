import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DrawflowComponent } from './features/drawflow/drawflow.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { HomeComponent } from './features/home/home.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { FormDashboardComponent } from './features/forms/form-dashboard/form-dashboard.component';
import { FormCreateComponent } from './features/forms/form-create/form-create.component';
import { FormDetailsComponent } from './features/forms/form-details/form-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    DrawflowComponent,
    PageNotFoundComponent,
    HomeComponent,
    NavbarComponent,
    FormDashboardComponent,
    FormCreateComponent,
    FormDetailsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
