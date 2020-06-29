import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EscolasComponent } from './escolas.component';
import { CriarEscolaComponent } from './criar-escola/criar-escola.component';
import { DetalhesComponent } from './detalhes/detalhes.component';

const routes: Routes = [
  {
    path: '',
    component: EscolasComponent
  },
  {
    path: 'criar-escola',
    component: CriarEscolaComponent
  },
  {
    path: 'detalhes',
    component: DetalhesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EscolasRoutingModule {
  static components = [EscolasComponent,CriarEscolaComponent, DetalhesComponent];
}

