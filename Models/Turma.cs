using System.Collections.Generic;
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
        [Required(ErrorMessage = "Campo curso é obrigatório")]
        public int cursoID { get; set; }
        public Curso curso { get; set; }

        [Display(Name = "Monitor: ")]
        [Required(ErrorMessage = "Campo monitor é obrigatório")]
        public int monitorID { get; set; }
        public Monitor monitor { get; set; }

        [Display(Name = "Professor: ")]
        [Required(ErrorMessage = "Campo professor é obrigatório")]
        public int professorID { get; set; }
        public Professor professor { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(40)]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }


        [Display(Name = "Horario: ")]
        [Required(ErrorMessage = "Campo horario é obrigatório")]
        public int horarioDasAulasID { get; set; }
        public HorarioDasAulas horarioDasAulas { get; set; }



    }
}
