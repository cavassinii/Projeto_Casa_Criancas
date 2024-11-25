using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(200)]
        [Display(Name = "Descrição: ")]
        public String descricao { get; set; }

        [Display(Name = "Colaborador: ")]
        [StringLength(35)]
        public Colaborador colaborador { get; set; }

        [Required(ErrorMessage = "Campo colaborador é obrigatório")]
        [Display(Name = "Colaborador: ")]
        public int colaboradorID { get; set; }

    }
}
