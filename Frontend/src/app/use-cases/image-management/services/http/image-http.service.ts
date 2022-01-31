import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseHttpService } from 'src/app/shared/services/base-http-service';
import { ImageStatus } from './dto/image-status.dto';
import { RegisteredImage } from './dto/registered-image.dto';
import { UploadImageRequest } from './dto/upload-image-request.dto';
import { UploadImageResponse } from './dto/upload-image-response.dto';

@Injectable({
  providedIn: 'root'
})
export class ImageHttpService extends BaseHttpService {
  
  getAllImage(): Observable<RegisteredImage[]> {
    return this.http.get<RegisteredImage[]>(this.buildUrl('Image'));
  }

  getImage(id: number): Observable<ImageStatus> {
    return this.http.get<ImageStatus>(this.buildUrl(`Image/${id}`));
  }

  uploadImage(request: UploadImageRequest): Observable<UploadImageResponse> {
    const formData = new FormData();
    formData.append('fileName', request.fileName);
    formData.append('fileContent', request.fileContent);
    return this.http.post<UploadImageResponse>(this.buildUrl(`Image`), formData);
  }
}
