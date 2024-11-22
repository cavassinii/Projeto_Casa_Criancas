using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("HorarioDasAulas")]
    public class HorarioDasAulas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Dia da Semana: ")]
        [StringLength(40)]
        public string DiaDaSemana { get; set; }

        [Display(Name = "Abreviação: ")]
        [StringLength(40)]
        public string Abreviacao { get; set; }

        [Display(Name = "Hora Início: ")]
        [StringLength(40)]
        public string HoraInicio { get; set; }

        [Display(Name = "Hora Fim: ")]
        [StringLength(40)]
        public string HoraFim { get; set; }
    }
}
