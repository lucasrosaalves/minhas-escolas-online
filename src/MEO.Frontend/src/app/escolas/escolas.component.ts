import { Component, OnInit } from '@angular/core';
import { EscolaService } from '../core/services/escola.service';
import { EscolaModel } from '../shared/models/escola.model';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.scss']
})
export class EscolasComponent implements OnInit {
  escolas: EscolaModel[] = []
  constructor(private escolaService: EscolaService) { }

  ngOnInit() {
    this.escolaService.obterEscolasPaginadas().subscribe(data => {
      this.escolas = data;
      console.log(data);  
    }, err => {
      console.log(err);
    })
  }

}
