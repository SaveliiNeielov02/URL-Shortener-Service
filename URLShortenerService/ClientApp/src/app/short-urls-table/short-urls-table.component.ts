import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth-service/auth-service';
import { URLRecord } from '../record-model-interface/record-model-interface';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './short-urls-table.component.html',
  styleUrls: ['./short-urls-table.component.css']
})
export class ShortURLsTableComponent {
  public records: URLRecord[] = [];
  public AdditionURL: string = '';
  constructor(public authService: AuthService, public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.updateRecords();
  }
  onSubmit() {
    const url = `${this.baseUrl}urlservice/ShortenURL`;
    const postData= {
      LongURL: this.AdditionURL,
      UserLogin: this.authService.getLogin(),
      CreatedDate: new Date(),
    };

    this.http.post<any>(url, postData).subscribe(
      data => {
        this.updateRecords();
        const formattedData = data as { message: string };
        alert(formattedData.message);
      },
      error => {
        const formattedError = error as { message: string };
        alert(formattedError.message);
      }
    )
  }
  public onDeleteButtonClick(shortURL: any) {
    const encodedShortURL = encodeURIComponent(shortURL);
    const url = `${this.baseUrl}urlservice/DeleteRecord/${encodedShortURL}`;
    this.http.delete<any>(url).subscribe(
      data => {
        this.updateRecords();
      },
      error => {
        const formattedError = error as { message: string };
        alert(formattedError.message);
      })
  }
  public onDeleteAllRecordsButtonClick() {
    const url = `${this.baseUrl}urlservice/DeleteAllRecords`;
    this.http.delete<any>(url).subscribe(
      data => {
        this.updateRecords();
      },
      error => {
        const formattedError = error as { message: string };
        alert(formattedError.message);
      })
  }
  private updateRecords()
  {
    this.http.get<URLRecord[]>(this.baseUrl + 'urlservice/GetRecords').subscribe(
      result => {
        this.records = result;
      },
      error => alert(error));
  }
}

/*interface URLRecord {
  ShortURL?: string;
  LongURL: string;
  UserLogin: string;
  CreatedDate: Date,
}
*/
