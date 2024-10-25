using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Aluno: ")]
        [StringLength(35)]
        public Aluno aluno { get; set; }
        [Display(Name = "Aluno: ")]
        public int alunoID { get; set; }

        [Display(Name = "Turma: ")]
        [StringLength(35)]
        public Turma turma { get; set; }
        [Display(Name = "Turma: ")]
        public int turmaID { get; set; }

        [Display(Name = "Data: ")]
        public DateOnly data { get; set; }
    }
}
