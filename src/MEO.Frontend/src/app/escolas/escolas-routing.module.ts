import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EscolasComponent } from './escolas.component';
import { CriarEscolaComponent } from './criar-escola/criar-escola.component';

const routes: Routes = [
  {
    path: '',
    component: EscolasComponent
  },
  {
    path: 'criar-escola',
    component: CriarEscolaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EscolasRoutingModule {
  static components = [EscolasComponent,CriarEscolaComponent];
}

