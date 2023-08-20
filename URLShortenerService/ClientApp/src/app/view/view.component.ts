import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { URLRecord } from '../record-model-interface/record-model-interface';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'view-component',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent {
  public shortURL: string = '';
  public record: URLRecord | undefined;
  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, public route: ActivatedRoute) {
    this.shortURL = this.route.snapshot.paramMap.get('shortUrl') as string;
    const encodedShortURL = encodeURIComponent(this.shortURL);
    this.http.get<URLRecord>(`${this.baseUrl}urlservice/GetRecordByURL/${encodedShortURL}`).subscribe(
      result => {
        this.record = result;
      },
      error => alert(error));
  }
}
