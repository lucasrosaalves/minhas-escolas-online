import { ContatoModel } from './contato.model';
import { EnderecoModel } from './endereco.model';
import { TurmaModel } from './turma.model';

export interface EscolaModel {
    id:string;
    nome: string;
    codigo: string;
    contato: ContatoModel;
    endereco: EnderecoModel;
    quantidadeTurmas: number;
    turmas: TurmaModel[];
}