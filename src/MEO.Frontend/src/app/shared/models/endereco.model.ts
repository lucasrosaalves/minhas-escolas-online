import { TipoLocalizacaoModel } from './tipo-localizacao.model';

export interface EnderecoModel {
    logradouro: string;
    numero: string;
    complemento: string;
    bairro: string;
    cep: string;
    enderecoCompleto: string;
    tipoLocalizacao: TipoLocalizacaoModel;
}


