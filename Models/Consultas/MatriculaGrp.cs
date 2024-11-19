using System.ComponentModel.DataAnnotations;

namespace Projeto_Casa_Criancas.Models.Consultas
{
    public class MatriculaGrp
    {
        
      [Display(Name = "ID Matrícula: ")]
      public int id { get; set; }

      [Display(Name = "Aluno: ")]
      public string aluno { get; set; }

      [Display(Name = "Turma: ")]
      public int turma { get; set; }

      [Display(Name = "Quntidade de Alunos: ")]
      public int qtdeAluno { get; set; }

    }

}

