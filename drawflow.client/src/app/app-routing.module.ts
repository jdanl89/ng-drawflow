import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrawflowComponent } from './features/drawflow/drawflow.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', component: DrawflowComponent },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
