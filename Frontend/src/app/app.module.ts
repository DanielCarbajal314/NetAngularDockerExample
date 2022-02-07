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
import { FileInputConfig, MaterialFileInputModule, NGX_MAT_FILE_INPUT_CONFIG } from 'ngx-material-file-input';
import { ImageThumbnailDisplayerComponent } from './use-cases/image-management/image-thumbnail-displayer/image-thumbnail-displayer.component';

export const config: FileInputConfig = {
  sizeUnit: 'Octet'
};

@NgModule({
  declarations: [
    AppComponent,
    ImageManagementComponent,
    ImageTableComponent,
    ImageFormComponent,
    ImageDisplayerComponent,
    ImageThumbnailDisplayerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    MaterialModule,
    MaterialFileInputModule
  ],
  providers: [{ provide: NGX_MAT_FILE_INPUT_CONFIG, useValue: config }],
  bootstrap: [AppComponent, ImageThumbnailDisplayerComponent]
})
export class AppModule { }
