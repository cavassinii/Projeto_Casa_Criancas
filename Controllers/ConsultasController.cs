using Projeto_Casa_Criancas.Models;
using Projeto_Casa_Criancas.Models.Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace BCCAlunos2024.Controllers
{
    public class ConsultasController : Controller
    {

        private readonly Contexto contexto;

        public ConsultasController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Turmas()
        {
            var turmas = contexto.Turma
                .Include(a => a.curso)
                .ThenInclude(a=> a.colaborador)
                .ToList();
            return View(turmas);
        }

        public IActionResult Matriculas()
        {
            var matriculas = contexto.Matriculas
                .Include(a => a.aluno)
                .Include(b => b.turma)
                .ToList();

                return View(matriculas);
        }

        public IActionResult AgruparMatriculaAlunoTurma()
        {
            IEnumerable<MatriculaGrp> lstGrupoMatricula = from item in contexto.Matriculas
                                   .Include(a => a.aluno)
                                   .Include(c => c.turma)
                                   .ToList()
                                                  let matricula = item.Id
                                                  let aluno = item.aluno.nome
                                                  let turma = item.turma.Id

                                                  group item by new { matricula, aluno, turma }
                                   into grupo
                                                  orderby grupo.Key.matricula, grupo.Key.aluno, grupo.Key.turma
                                                  select new MatriculaGrp
                                                  {
                                                      id = grupo.Key.matricula,
                                                      aluno = grupo.Key.aluno,
                                                      turma = grupo.Key.turma,
                                                      qtdeAluno = grupo.Count()

                                                  };

            return View(lstGrupoMatricula);

        }


        public IActionResult AgruparCursoColaboradorTurma()
        {
            IEnumerable<TurmaGrp> lstGrupoTurma = from item in contexto.Turma
                                   .Include(a => a.curso)
                                    .ThenInclude(c => c.colaborador)
                                   .ToList()
                                                              let turma = item.Id
                                                              let curso = item.curso.nome
                                                              let colaborador = item.curso.colaborador.nome

                                                              group item by new { turma, curso, colaborador }
                                   into grupo
                                                              orderby grupo.Key.turma,grupo.Key.curso,grupo.Key.colaborador
                                                              select new TurmaGrp
                                                              {
                                                                  id = grupo.Key.turma,
                                                                  curso = grupo.Key.curso,
                                                                  colaborador = grupo.Key.colaborador,

                                                              };

            return View(lstGrupoTurma);

        }

    }
}