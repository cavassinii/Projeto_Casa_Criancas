using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    public enum Status { Presente, Ausente };

    [Table("Chamadas")]
    public class Chamada
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Matrícula: ")]
        [StringLength(35)]
        public Matricula matricula { get; set; }
        [Display(Name = "Matrícula: ")]
        public int matriculaID { get; set; }

        [Display(Name = "Data: ")]
        public DateOnly data { get; set; }

        [Display(Name = "Status: ")]
        public Status status { get; set; }


    }
}
