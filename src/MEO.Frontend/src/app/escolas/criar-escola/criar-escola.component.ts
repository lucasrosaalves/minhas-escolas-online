import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EscolaService } from 'src/app/core/services/escola.service';
import { TipoLocalizacaoModel } from 'src/app/shared/models/tipo-localizacao.model';
import { CriarEscolaModel } from 'src/app/shared/models/criar-escola.model';

@Component({
  selector: 'app-criar-escola',
  templateUrl: './criar-escola.component.html',
  styleUrls: ['./criar-escola.component.scss']
})
export class CriarEscolaComponent implements OnInit {
  possuiNotificacoes: boolean;
  tiposLocalizacao: TipoLocalizacaoModel[] = [];
  constructor(private escolaService: EscolaService) { }

  ngOnInit() {
    this.obterTiposLocalizacao();
  }

  submit(form: NgForm){
    if(form.invalid){ return;}
    let model: CriarEscolaModel = {
      bairro : form.value.bairro,
      cep: form.value.cep,
      codigo: form.value.codigo,
      complemento: form.value.complemento,
      email: form.value.email,
      logradouro: form.value.logradouro,
      nome: form.value.nome,
      numero: form.value.numero,
      site: form.value.site,
      telefone: form.value.telefone,
      tipoLocalizacaoId: form.value.tipoLocalizacaoId,
    };
    this.escolaService.criarEscola(model).subscribe(resp =>{
      console.log(resp);
    },err =>{
      this.mostrarAlerta();
    })
  }

  obterTiposLocalizacao(){
    this.tiposLocalizacao = Object.assign([], this.escolaService.obterTiposLocalizacao());
  }

  mostrarAlerta() {
    this.possuiNotificacoes = true;
  }

  fecharAlerta() {
    this.possuiNotificacoes = false;
  }
}
