import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { routes } from '../constants/routes';

@Injectable()
export class RouterService {
  constructor(private router: Router) {
  }

  escolaDetalhes(codigo: string) {
    this.navigate(routes.escola.detalhes, {
      queryParams: {
        'codigo': codigo
      }
    });
  }

  escolasCriar() {
    this.navigate(routes.escola.criar);
  }

  escolas() {
    this.navigate(routes.escola.escolas);
  }

  home() {
    this.navigate(routes.home);
  }


  private navigate(route: string, extras?: NavigationExtras) {
    this.router.navigate([route], extras);
  }
}
