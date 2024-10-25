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
        [Display(Name = "Curso: ")]
        public int cursoID { get; set; }

        [Display(Name = "Monitor: ")]
        [StringLength(35)]
        public Monitor monitor { get; set; }
        [Display(Name = "Monitor: ")]
        public int monitorID { get; set; }

        [Display(Name = "Professor: ")]
        [StringLength(35)]
        public Professor professor { get; set; }
        [Display(Name = "Professor: ")]
        public int professorID { get; set; }

        [StringLength(40)]
        [Display(Name = "Descrição: ")]
        public String descricao { get; set; }

        [Display(Name = "Data Hora: ")]
        public DateTime dataHora { get; set; }
    }
}
