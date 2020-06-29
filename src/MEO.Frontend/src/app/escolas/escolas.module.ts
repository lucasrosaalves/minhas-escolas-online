import { NgModule } from '@angular/core';
import { EscolasRoutingModule } from './escolas-routing.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [EscolasRoutingModule, SharedModule],
  declarations: [EscolasRoutingModule.components]
})
export class EscolasModule { }
