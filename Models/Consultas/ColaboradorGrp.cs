using System.ComponentModel.DataAnnotations;

namespace Projeto_Casa_Criancas.Models.Consultas
{
    public class ColaboradorGrp
    {
        [Display(Name = "ID Colaborador: ")]
        public int id { get; set; }

        [Display(Name = "Nome do Colaborador: ")]
        public string colaboradorNome { get; set; }

        [Display(Name = "Nome do Curso: ")]
        public string cursoNome { get; set; }

        [Display(Name = "Descrição do Curso: ")]
        public string cursoDescricao { get; set; }
    }
}
