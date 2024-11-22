using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models.Consultas;

namespace Projeto_Casa_Criancas.Models
{
        public class Contexto : DbContext
        {
            public Contexto(DbContextOptions<Contexto> options) : base(options) { }

            public DbSet<Professor> Professor { get; set; }

            public DbSet<Curso> Curso { get; set; }

            public DbSet<Colaborador> Colaborador { get; set; }

            public DbSet<Chamada> Chamada { get; set; }

            public DbSet<Responsavel> Responsavel { get; set; }

            public DbSet<Matricula> Matriculas { get; set; }

            public DbSet<Aluno> Aluno { get; set; }

            public DbSet<AssistenteSocial> AssistenteSocial { get; set; }

            public DbSet<Visita> Visita { get; set; }

            public DbSet<Turma> Turma { get; set; }

            public DbSet<Monitor> Monitor { get; set; }
            public DbSet<Projeto_Casa_Criancas.Models.Consultas.TurmaGrp> TurmaGrp { get; set; }
            public DbSet<Projeto_Casa_Criancas.Models.Consultas.MatriculaGrp> MatriculaGrp { get; set; }
            public DbSet<Projeto_Casa_Criancas.Models.Consultas.MatriculaAnoMes> MatriculaAnoMes { get; set; }
            public DbSet<Projeto_Casa_Criancas.Models.Consultas.PivotMatricula> PivotMatricula { get; set; }


            public DbSet<HorarioDasAulas> HorarioDasAulas { get; set; }        

    }
}