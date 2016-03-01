module Model {
    export class Question {
        answered:boolean;
        title:string;
        options: string[];
        correctAnswer: boolean;
        working: boolean;
    }
}