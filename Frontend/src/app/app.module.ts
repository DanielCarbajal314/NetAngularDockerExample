import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ImageManagementComponent } from './use-cases/image-management/image-management.component';
import { ImageTableComponent } from './use-cases/image-management/image-table/image-table.component';
import { ImageFormComponent } from './use-cases/image-management/image-form/image-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './shared/modules/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ImageDisplayerComponent } from './use-cases/image-management/image-displayer/image-displayer.component';

@NgModule({
  declarations: [
    AppComponent,
    ImageManagementComponent,
    ImageTableComponent,
    ImageFormComponent,
    ImageDisplayerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
