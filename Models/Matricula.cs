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

        [Required(ErrorMessage = "Campo aluno é obrigatório")]
        [Display(Name = "Aluno: ")]
        [StringLength(35)]
        public Aluno aluno { get; set; }
        [Display(Name = "Aluno: ")]
        public int alunoID { get; set; }

        [Required(ErrorMessage = "Campo turma é obrigatório")]
        [Display(Name = "Turma: ")]
        [StringLength(35)]
        public Turma turma { get; set; }
        [Display(Name = "Turma: ")]
        public int turmaID { get; set; }

        [Required(ErrorMessage = "Campo data é obrigatório")]
        [Display(Name = "Data: ")]
        public DateOnly data { get; set; }
    }
}
