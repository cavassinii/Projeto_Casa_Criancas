using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Responsaveis")]
    public class Responsavel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [Required(ErrorMessage = "Campo celular é obrigatório")]
        [StringLength(20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }
    }
}
