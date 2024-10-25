using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Casa_Criancas.Models
{
    [Table("Visitas")]
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Aluno: ")]
        [StringLength(35)]
        public Aluno aluno { get; set; }
        [Display(Name = "Aluno: ")]
        public int alunoID { get; set; }

        [Display(Name = "Assistente Social: ")]
        [StringLength(35)]
        public AssistenteSocial assistenteSocial{ get; set; }
        [Display(Name = "Assistente Social: ")]
        public int assistenteID { get; set; }

        [Display(Name = "Data: ")]
        public DateOnly data { get; set; }

        [StringLength(300)]
        [Display(Name = "Objetivo: ")]
        public string status { get; set; }

        [StringLength(300)]
        [Display(Name = "Situação Familiar: ")]
        public string situacaoFamiliar { get; set; }

        [StringLength(300)]
        [Display(Name = "Ações Preliminares: ")]
        public string acoesPreliminares { get; set; }

        [StringLength(300)]
        [Display(Name = "Contexto Externo: ")]
        public string contextoExterno { get; set; }

        [StringLength(300)]
        [Display(Name = "Contexto Familiar: ")]
        public string contextoFamiliar { get; set; }

        [StringLength(300)]
        [Display(Name = "Rede Apoio: ")]
        public string redeApoio { get; set; }

        [StringLength(300)]
        [Display(Name = "Situações de Violação de Direito : ")]
        public string violacaoDireito { get; set; }

        [StringLength(300)]
        [Display(Name = "Emcaminhamento: ")]
        public string encaminhamento { get; set; }

        [StringLength(300)]
        [Display(Name = "Compactações: ")]
        public string compactacoes { get; set; }

        [StringLength(300)]
        [Display(Name = "Escolarização: ")]
        public string escolarizacao { get; set; }

        [StringLength(300)]
        [Display(Name = "Situações de Violência Doméstica: ")]
        public string violenciaDomestica { get; set; }
    }
}
