using System.ComponentModel.DataAnnotations;

namespace Projeto_Casa_Criancas.Models.Consultas
{
    public class TurmaGrp
    {
        [Display(Name = "ID Turma: ")]
        public int id { get; set; }
        
        [Display(Name = "Curso: ")]
        public string curso { get; set; }
        
        [Display(Name = "Colaborador: ")]
        public string colaborador { get; set; }
    }
}
