import { environment } from './../../../environments/environment';

export const endpoints = {
    escola: {
        obterEscolasPaginada: environment.apiUrl + "/v1/escola/obterescolaspaginadas",
        obterEscolaPorId: environment.apiUrl + "/v1/escola/obterescolaporid",
        obterEscolaPorCodigo: environment.apiUrl + "/v1/escola/obterescolaporcodigo",
        criarEscola: environment.apiUrl + "/v1/escola/criarescola",
        criarTurma: environment.apiUrl + "/v1/escola/criarturma",
    }
}