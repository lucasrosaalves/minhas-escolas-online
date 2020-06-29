import { Component } from '@angular/core';
import { UiService } from './core/services/ui.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  private subscriptions : Subscription[] = [];

  title: string = 'Minha escola online';
  loading: boolean;

  constructor(private uiService: UiService) {
  }

  ngOnInit() {
    this.subscribe();
    this.uiService.setLoading(true);
    setTimeout(() => { 
      this.uiService.setLoading(false);
    }, 1500)
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  subscribe(){
    this.subscriptions.push(this.uiService.getLoading().subscribe(data =>  this.loading = data));
  }
}
