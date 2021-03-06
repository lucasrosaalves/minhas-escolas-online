import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EscolaService } from 'src/app/core/services/escola.service';
import { TipoLocalizacaoModel } from 'src/app/shared/models/tipo-localizacao.model';
import { CriarEscolaModel } from 'src/app/shared/models/criar-escola.model';
import { RouterService } from 'src/app/core/services/router.service';

@Component({
  selector: 'app-criar-escola',
  templateUrl: './criar-escola.component.html',
  styleUrls: ['./criar-escola.component.scss']
})
export class CriarEscolaComponent implements OnInit {
  possuiNotificacoes: boolean;
  notificacao: string;
  formSubmited: boolean;
  formEscola: FormGroup;
  tiposLocalizacao: TipoLocalizacaoModel[] = [];


  constructor(
    private escolaService: EscolaService,
    private formBuilder: FormBuilder,
    private routerService: RouterService) { }

  ngOnInit() {
    this.notificacao = null;
    this.possuiNotificacoes = false;
    this.obterTiposLocalizacao();
    this.createForm();
  }

  submit(form: FormGroup) {
    this.formSubmited = true;
    debugger;
    if (form.invalid) { return; }

    let model = this.criarEscolaModel(form);

      this.escolaService.criarEscola(model).subscribe(data=> {
        this.routerService.escolaDetalhes(model.codigo);
      }, err =>{
        this.mostrarAlerta();
        this.notificacao = err.error?.errors?.Mensagens[0];
      }); 
  }

  campoPossuiErro(campo: string){
    let obj = this.formEscola.controls[campo];
    return obj.hasError('required') && (!obj.untouched || this.formSubmited);
  }

  criarEscolaModel(form: FormGroup): CriarEscolaModel {
    return {
      bairro: form.controls.bairro.value,
      cep: form.controls.cep.value,
      codigo: form.controls.codigo.value,
      complemento: form.controls.complemento.value,
      email: form.controls.email.value,
      logradouro: form.controls.logradouro.value,
      nome: form.controls.nome.value,
      numero: form.controls.numero.value,
      site: form.controls.site.value,
      telefone: form.controls.telefone.value,
      tipoLocalizacaoId: form.controls.tipoLocalizacaoId.value,
    };
  }

  obterTiposLocalizacao() {
    this.tiposLocalizacao = Object.assign([], this.escolaService.obterTiposLocalizacao());
  }

  mostrarAlerta() {
    this.possuiNotificacoes = true;
  }

  fecharAlerta() {
    this.possuiNotificacoes = false;
    this.notificacao = null;
  }

  createForm() {
    this.formEscola = this.formBuilder.group({
      bairro: [null, [Validators.required, Validators.maxLength(50)]],
      cep: [null, [Validators.required, Validators.maxLength(20)]],
      codigo: [null, [Validators.required, Validators.maxLength(50)]],
      complemento: [null, [Validators.maxLength(100)]],
      email: [null, [Validators.required, Validators.email, Validators.maxLength(100)]],
      logradouro: [null, [Validators.required, Validators.maxLength(150)]],
      nome: [null, [Validators.required, Validators.maxLength(100)]],
      numero: [null, [Validators.required, Validators.maxLength(14)]],
      site: [null, [Validators.maxLength(100)]],
      telefone: [null, [Validators.required, Validators.maxLength(20)]],
      tipoLocalizacaoId: [null, [Validators.required]]
    });
  }

}
