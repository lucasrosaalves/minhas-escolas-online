import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UiService {
  private loading$ = new BehaviorSubject<boolean>(false);

  getLoading() {
    return this.loading$.asObservable()
  }

  setLoading(value: boolean) {
    this.loading$.next(value);
  }

}
