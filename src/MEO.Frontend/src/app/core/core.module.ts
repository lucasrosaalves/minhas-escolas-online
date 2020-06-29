import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from './topbar/topbar.component';
import { FooterComponent } from './footer/footer.component';
import { EscolaService } from './services/escola.service';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { LoadingComponent } from './loading/loading.component';
import { UiService } from './services/ui.service';
import { RouterService } from './services/router.service';

@NgModule({
  declarations: [TopbarComponent, FooterComponent, LoadingComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    HttpClientModule
  ],
  exports: [
    RouterModule,
    HttpClientModule,
    TopbarComponent,
    FooterComponent,
    LoadingComponent
],
  providers: [
    EscolaService,
    UiService,
    RouterService
  ]
})
export class CoreModule { }
