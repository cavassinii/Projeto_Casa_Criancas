using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Colaboradores")]
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [Required(ErrorMessage = "Campo CNPJ é obrigatório")]
        [StringLength(25)]
        [Display(Name = "CNPJ: ")]
        public String cnpj { get; set; }

        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [StringLength(200)]
        [Display(Name = "Endereço: ")]
        public String endereco { get; set; }

        [Required(ErrorMessage = "Campo celular é obrigatório")]
        [StringLength(20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }
    }
}
