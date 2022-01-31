import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImageManagementComponent } from './use-cases/image-management/image-management.component';

const routes: Routes = [
  { path: '', component: ImageManagementComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
