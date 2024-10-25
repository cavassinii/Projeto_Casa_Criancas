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

        [Required]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [Display(Name = "Data de Nascimento: ")]
        public DateOnly data { get; set; }

        [StringLength(50)]
        [Display(Name = "Endereço: ")]
        public String endereco { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }

        [Display(Name = "Responsável: ")]
        [StringLength(35)]
        public Responsavel responsavel { get; set; }
        [Display(Name = "Responsável: ")]
        public int responsavelID { get; set; }

    }
}
