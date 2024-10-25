using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [StringLength(14)]
        [Display(Name = "CPF: ")]
        public String cpf { get; set; }


        [StringLength(50)]
        [Display(Name = "Endereço: ")]
        public String endereco { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }

    }
}
