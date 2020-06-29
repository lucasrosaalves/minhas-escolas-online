import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { EscolaModel } from 'src/app/shared/models/escola.model';
import { endpoints } from '../constants/endpoints';
import { CriarEscolaModel } from 'src/app/shared/models/criar-escola.model';
import { CriarTurmaModel } from 'src/app/shared/models/criar-turma.model';
import { TipoLocalizacaoModel } from 'src/app/shared/models/tipo-localizacao.model';
import { TipoTurnoModel } from 'src/app/shared/models/tipo-turno.model';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {
  private tamanhoPagina: number = 20;
  constructor(private httpClient: HttpClient) { }

  public obterEscolasPaginadas(pagina: number = 1) {
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append('tamanhoPagina', this.tamanhoPagina.toString());

    return this.httpClient.get<EscolaModel[]>(endpoints.escola.obterEscolasPaginada, { params: params });
  }

  public obterEscolaPorId(id: string) {
    let params = new HttpParams();
    params = params.append('id', id);

    return this.httpClient.get<EscolaModel>(endpoints.escola.obterEscolaPorId, { params: params });
  }

  public criarEscola(criarEscola: CriarEscolaModel) {
    return this.httpClient.post(endpoints.escola.criarEscola, criarEscola);
  }

  public criarTurma(criarTurma: CriarTurmaModel) {
    return this.httpClient.post(endpoints.escola.criarTurma, criarTurma);
  }

  public obterTiposLocalizacao(){
    let tipos: TipoLocalizacaoModel[] = [
      { id: 1, descricao: "Urbana" },
      { id: 2, descricao: "Rural" }
    ];
    return tipos;
  }

  public obterTiposTurnos(){
    let tipos: TipoTurnoModel[] = [
      { id: 1, descricao: "Manhã" },
      { id: 2, descricao: "Tarde" },
      { id: 3, descricao: "Noite" }
    ];
    return tipos;
  }
}
