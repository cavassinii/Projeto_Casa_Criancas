using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Curso: ")]
        [StringLength(35)]
        public Curso curso { get; set; }

        [Required(ErrorMessage = "Campo curso é obrigatório")]
        [Display(Name = "Curso: ")]
        public int cursoID { get; set; }

        [Display(Name = "Monitor: ")]
        [StringLength(35)]
        public Monitor monitor { get; set; }

        [Required(ErrorMessage = "Campo monitor é obrigatório")]
        [Display(Name = "Monitor: ")]
        public int monitorID { get; set; }

        [Display(Name = "Professor: ")]
        [StringLength(35)]
        public Professor professor { get; set; }

        [Required(ErrorMessage = "Campo professor é obrigatório")]
        [Display(Name = "Professor: ")]
        public int professorID { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(40)]
        [Display(Name = "Descrição: ")]
        public String descricao { get; set; }

        [Required(ErrorMessage = "Campo data e hora é obrigatório")]
        [Display(Name = "Data Hora: ")]
        public DateTime dataHora { get; set; }
    }
}
