using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento é obrigatório")]
        [Display(Name = "Data de Nascimento: ")]
        public DateOnly data { get; set; }

        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Endereço: ")]
        public String endereco { get; set; }

        [Required(ErrorMessage = "Campo celular é obrigatório")]
        [StringLength(20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }

        
        [Display(Name = "Responsável: ")]
        [StringLength(35)]
        public Responsavel responsavel { get; set; }

        [Required(ErrorMessage = "Campo responsável é obrigatório")]
        [Display(Name = "Responsável: ")]
        public int responsavelID { get; set; }

    }
}
