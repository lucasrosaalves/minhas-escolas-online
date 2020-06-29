import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EscolaService } from 'src/app/core/services/escola.service';
import { RouterService } from 'src/app/core/services/router.service';
import { EscolaModel } from 'src/app/shared/models/escola.model';
import { TipoTurnoModel } from 'src/app/shared/models/tipo-turno.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CriarTurmaModel } from 'src/app/shared/models/criar-turma.model';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.scss']
})
export class DetalhesComponent implements OnInit {
  codigoEscola: string;
  escola: EscolaModel;
  tiposTurnos: TipoTurnoModel[] = [];

  criandoTurma: boolean;
  possuiNotificacoes: boolean;
  notificacao: string;
  formSubmited: boolean;
  formTurma: FormGroup;

  constructor(
    private escolaService: EscolaService,
    private routerService: RouterService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.codigoEscola = this.activatedRoute.snapshot.queryParams.codigo;

    if (!this.codigoEscola) {
      this.routerService.escolas();
      return;
    }

    this.obterEscolaPorCodigo();
    this.obterTiposTurnos();
  }

  obterTiposTurnos() {
    this.tiposTurnos = Object.assign([], this.escolaService.obterTiposTurnos());
  }

  obterEscolaPorCodigo() {
    this.escolaService.obterEscolaPorCodigo(this.codigoEscola).subscribe(data => {
      this.escola = data;
      console.log(data);
    }, err => {
      this.routerService.escolas();
    });
  }
  
  submit(form: FormGroup) {
    this.formSubmited = true;
    if (form.invalid) { return; }

    let model = this.criarTurmaModel(form);

      this.escolaService.criarTurma(model).subscribe(data=> {
        this.voltar();
        this.obterEscolaPorCodigo();
      }, err =>{
        this.mostrarAlerta();
        this.notificacao = err.error?.errors?.Mensagens[0];
      }); 
  }

  criarTurmaModel(form: FormGroup): CriarTurmaModel {
    return {
      codigo: form.controls.codigo.value,
      tipoTurnoId: form.controls.tipoTurnoId.value,
      quantidadeAlunos: form.controls.quantidadeAlunos.value,
      escolaId: this.escola.id
    };
  }

  campoPossuiErro(campo: string){
    let obj = this.formTurma.controls[campo];
    return obj.hasError('required') && (!obj.untouched || this.formSubmited);
  }

  voltar(){
    this.formSubmited = false;
    this.criandoTurma = false;
    this.formTurma.reset();
  }

  exibirTelaCriarTurma(){
    this.criandoTurma = true;
    this.createForm();
  }

  createForm() {
    this.formTurma = this.formBuilder.group({
      codigo: [null, Validators.required],
      tipoTurnoId: [null, Validators.required],
      quantidadeAlunos: [null, Validators.required]
    });
  }

  mostrarAlerta() {
    this.possuiNotificacoes = true;
  }

  fecharAlerta() {
    this.possuiNotificacoes = false;
    this.notificacao = null;
  }
}
