import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private readonly ACCESS_KEY = '7wlsmKsfTc9vJ_N0je6GZjr-Rmnc-_1Fn1dp4q72DgM';
  private readonly API_URL = 'https://api.unsplash.com/search/photos';

  constructor(private http: HttpClient) { }

  public getImageUrl(query: string): Observable<string> {
    const url = `${this.API_URL}?query=${query}&client_id=${this.ACCESS_KEY}`;
    return this.http.get(url).pipe(
      map((response: any) => response.results[0].urls.regular)
    );
  }
}
