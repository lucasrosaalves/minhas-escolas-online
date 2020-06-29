import { TipoTurnoModel } from './tipo-turno.model';

export interface TurmaModel {
    id: string;
    codigo: string;
    tipoTurno: TipoTurnoModel;
    quantidadeAlunos : number;
}