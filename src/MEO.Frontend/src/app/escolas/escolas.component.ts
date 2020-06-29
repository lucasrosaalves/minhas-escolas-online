import { Component, OnInit } from '@angular/core';
import { EscolaService } from '../core/services/escola.service';
import { EscolaModel } from '../shared/models/escola.model';
import { RouterService } from '../core/services/router.service';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.scss']
})
export class EscolasComponent implements OnInit {
  escolas: EscolaModel[] = []
  constructor(
    private escolaService: EscolaService,
    private routerService: RouterService) { }

  ngOnInit() {
    this.escolaService.obterEscolasPaginadas().subscribe(data => {
      this.escolas = data;
    }, err => {
      this.routerService.home();
    })
  }

  selecionar(escola : EscolaModel){
    this.routerService.escolaDetalhes(escola.codigo);
  }

}
