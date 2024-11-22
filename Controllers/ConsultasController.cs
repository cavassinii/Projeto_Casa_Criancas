using Projeto_Casa_Criancas.Models;
using Projeto_Casa_Criancas.Models.Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Projeto_Casa_Criancas.Extra;

namespace Projeto_Casa_Criancas.Controllers
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

        public IActionResult AgruparMatriculaAnoMes()
        {
            IEnumerable<MatriculaAnoMes> lstMatriculaAnoMes = from item in contexto.Matriculas
                                    .ToList()
                                                            let ano = item.data.Year
                                                            let mes = item.data.Month

                                                            group item by new { ano, mes }
                                   into grupo
                                                            orderby grupo.Key.ano, grupo.Key.mes
                                                            select new MatriculaAnoMes
                                                            {
                                                                ano = grupo.Key.ano,
                                                                mes = grupo.Key.mes,
                                                                quantidade = grupo.Count()
                                                            };

            return View(lstMatriculaAnoMes);

        }

        public IActionResult AgruparColaboradorCurso()
        {
            IEnumerable<ColaboradorGrp> lstGrupoColaborador = from item in contexto.Curso
                                   .Include(c => c.colaborador)
                                   .ToList()
                                                              let colaboradorId = item.colaborador.Id
                                                              let colaboradorNome = item.colaborador.nome
                                                              let cursoNome = item.nome
                                                              let cursoDescricao = item.descricao

                                                              group item by new { colaboradorId, colaboradorNome, cursoNome, cursoDescricao, }
                                   into grupo
                                                              orderby grupo.Key.colaboradorId, grupo.Key.colaboradorNome, grupo.Key.cursoNome, grupo.Key.cursoDescricao
                                                              select new ColaboradorGrp
                                                              {
                                                                  id = grupo.Key.colaboradorId,
                                                                  colaboradorNome = grupo.Key.colaboradorNome,
                                                                  cursoNome = grupo.Key.cursoNome,
                                                                  cursoDescricao = grupo.Key.cursoDescricao,
                                                              };

            return View(lstGrupoColaborador);

        }



        public IActionResult Pivot()
        {

            IEnumerable<MatriculaAnoMes> lstMatriculaAnoMes = from item in contexto.Matriculas
                                    .ToList()
                                                            let ano = item.data.Year
                                                            let mes = item.data.Month
                                                            group item by new { ano, mes }
                                   into grupo
                                                            orderby grupo.Key.ano, grupo.Key.mes
                                                            select new MatriculaAnoMes
                                                            {
                                                                ano = grupo.Key.ano,
                                                                mes = grupo.Key.mes,
                                                                quantidade = grupo.Count()
                                                            };

            //Gerar Pivot
            var PivotTableInsArea = lstMatriculaAnoMes.ToList().ToPivotTable(
                    pivo => pivo.mes, //coluna
                    pivo => pivo.ano, //linha
                    pivos => (pivos.Any() ? pivos.Sum(x => Convert.ToSingle(x.quantidade)) : 0)); //valor das células

            //Converter DataTable do Pivot para Lista, permitir que o asp net core, imprima depois
            List<PivotMatricula> lista = new List<PivotMatricula>();
            lista = (from DataRow linha in PivotTableInsArea.Rows
                     select new PivotMatricula()
                     {
                         ano = linha[0].ToString(),
                         janeiro = Convert.ToSingle(linha[1]),
                         fevereiro = Convert.ToSingle(linha[2]),
                         marco = Convert.ToSingle(linha[3]),
                         abril = Convert.ToSingle(linha[4]),
                         maio = Convert.ToSingle(linha[5]),
                         junho = Convert.ToSingle(linha[6]),
                         julho = Convert.ToSingle(linha[7]),
                         agosto = Convert.ToSingle(linha[8]),
                         setembro = Convert.ToSingle(linha[9]),
                         outubro = Convert.ToSingle(linha[10]),
                         novembro = Convert.ToSingle(linha[11]),
                         dezembro = Convert.ToSingle(linha[12]),
                         total = Convert.ToSingle(linha[1]) + Convert.ToSingle(linha[2]) + Convert.ToSingle(linha[3]) + Convert.ToSingle(linha[4]) + Convert.ToSingle(linha[5]) + Convert.ToSingle(linha[6]) +
                                 Convert.ToSingle(linha[7]) + Convert.ToSingle(linha[8]) + Convert.ToSingle(linha[9]) + Convert.ToSingle(linha[10]) + Convert.ToSingle(linha[11]) + Convert.ToSingle(linha[12]),
                     }).ToList();

            return View(lista);
        }

    }
}