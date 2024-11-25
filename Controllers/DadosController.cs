using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ProjetoMonitor = Projeto_Casa_Criancas.Models.Monitor;



namespace Projeto_Casa_Criancas.Controllers
{
    [Authorize(Roles = "Admin,Assistente")]

    public class DadosController : Controller
    {
        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Responsavel()
        {
            contexto.Database.ExecuteSqlRaw("delete from Responsaveis");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Responsaveis', RESEED, 0)");
            Random rand = new Random();

            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vCelular = new string[100];

            for (int i = 0; i < 100; i++)
            {
                vCelular[i] = $"+55 9{rand.Next(100000000, 999999999)}";
            }


            for (int i = 0; i < 100; i++)
            {
                Responsavel responsavel = new Responsavel();

                responsavel.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                responsavel.celular = vCelular[i];

                contexto.Responsavel.Add(responsavel);
                
            }
            contexto.SaveChanges();

            return RedirectToAction("Index", "Responsaveis");
        }

        public IActionResult Colaborador()
        {
            contexto.Database.ExecuteSqlRaw("delete from Colaboradores");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Colaboradores', RESEED, 0)");
            Random rand = new Random();

            string[] vColaboradores ={"Faculdade XYZ","Escola ABC","Instituto Nacional de Educação","Escola Técnica Estadual","Universidade Federal do Estado","Colégio Estadual São Paulo","Faculdade Internacional de Tecnologia","Escola Municipal Nova Geração","Instituto de Ensino Superior de Ciências","Colégio Nossa Senhora da Paz"};
            string[] vEndereco = new string[100];
            string[] vCelular = new string[100];
            string[] vCNPJ = new string[100];
            string[] bairros = { "Centro", "Jardins", "Vila Nova", "Parque das Árvores", "Bela Vista", "Nova Esperança", "Residencial São Paulo", "Vila das Palmeiras", "Morada do Sol", "Parque Estrela" };
            string[] nomesDeRuas = { "Rua das Flores", "Avenida Paulista", "Rua do Sol", "Praça da Paz", "Rua São José", "Avenida Central", "Travessa das Palmeiras", "Rua Bela Vista", "Alameda dos Anjos", "Rua da Esperança" };
            string[] cidades = { "São Paulo", "Rio de Janeiro", "Curitiba", "Porto Alegre", "Florianópolis", "Belo Horizonte", "Recife", "Salvador", "Fortaleza", "Manaus" };

            for (int i = 0; i < 100; i++)
            {
                string rua = nomesDeRuas[rand.Next(nomesDeRuas.Length)];
                string bairro = bairros[rand.Next(bairros.Length)];
                string cidade = cidades[rand.Next(cidades.Length)];
                string cnpj = $"{rand.Next(10, 99)}.{rand.Next(100, 999)}.{rand.Next(100, 999)}/{rand.Next(1000, 9999)}-{rand.Next(10, 99)}";


                
                vEndereco[i] = $"{rua}, Bairro {bairro}, {cidade}";
                vCelular[i] = $"+55 9{rand.Next(100000000, 999999999)}";
                vCNPJ[i] = cnpj ;
            }

            for (int i = 0; i < 100; i++)
            {
                Colaborador colaborador = new Colaborador();

                colaborador.nome = vColaboradores[rand.Next(vColaboradores.Length)];
                colaborador.endereco = vEndereco[i];
                colaborador.celular = vCelular[i];
                colaborador.cnpj = vCNPJ[i];



                contexto.Colaborador.Add(colaborador);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Colaboradores");
        }


        public IActionResult AssistenteSocial()
        {
            contexto.Database.ExecuteSqlRaw("delete from AssistentesSociais");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('AssistentesSociais', RESEED, 0)");
            Random rand = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vEndereco = new string[5];
            string[] vCelular = new string[5];
            string[] vCPF = new string[5];
            string[] bairros = { "Centro", "Jardins", "Vila Nova", "Parque das Árvores", "Bela Vista", "Nova Esperança", "Residencial São Paulo", "Vila das Palmeiras", "Morada do Sol", "Parque Estrela" };
            string[] nomesDeRuas = { "Rua das Flores", "Avenida Paulista", "Rua do Sol", "Praça da Paz", "Rua São José", "Avenida Central", "Travessa das Palmeiras", "Rua Bela Vista", "Alameda dos Anjos", "Rua da Esperança" };
            string[] cidades = { "São Paulo", "Rio de Janeiro", "Curitiba", "Porto Alegre", "Florianópolis", "Belo Horizonte", "Recife", "Salvador", "Fortaleza", "Manaus" };

            for (int i = 0; i < 5; i++)
            {
                string rua = nomesDeRuas[rand.Next(nomesDeRuas.Length)];
                string bairro = bairros[rand.Next(bairros.Length)];
                string cidade = cidades[rand.Next(cidades.Length)];

                vEndereco[i] = $"{rua}, Bairro {bairro}, {cidade}";
                vCelular[i] = $"+55 9{rand.Next(100000000, 999999999)}";
                string cpf = $"{rand.Next(100, 1000)}.{rand.Next(100, 1000)}.{rand.Next(100, 1000)}-{rand.Next(10, 100)}";
                vCPF[i] = cpf;
            }

            for (int i = 0; i < 5; i++)
            {
                AssistenteSocial assistenteSocial = new AssistenteSocial();

                assistenteSocial.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                assistenteSocial.endereco = vEndereco[i];
                assistenteSocial.celular = vCelular[i];
                assistenteSocial.cpf = vCPF[i];

                contexto.AssistenteSocial.Add(assistenteSocial);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "AssistenteSociais");
        }

        public IActionResult Monitor()
        {
            contexto.Database.ExecuteSqlRaw("delete from Monitores");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Monitores', RESEED, 0)");
            Random rand = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vEndereco = new string[100];
            string[] vCelular = new string[100];
            string[] vCPF = new string[100];
            string[] bairros = { "Centro", "Jardins", "Vila Nova", "Parque das Árvores", "Bela Vista", "Nova Esperança", "Residencial São Paulo", "Vila das Palmeiras", "Morada do Sol", "Parque Estrela" };
            string[] nomesDeRuas = { "Rua das Flores", "Avenida Paulista", "Rua do Sol", "Praça da Paz", "Rua São José", "Avenida Central", "Travessa das Palmeiras", "Rua Bela Vista", "Alameda dos Anjos", "Rua da Esperança" };
            string[] cidades = { "São Paulo", "Rio de Janeiro", "Curitiba", "Porto Alegre", "Florianópolis", "Belo Horizonte", "Recife", "Salvador", "Fortaleza", "Manaus" };

            for (int i = 0; i < 100; i++)
            {
                string rua = nomesDeRuas[rand.Next(nomesDeRuas.Length)];
                string bairro = bairros[rand.Next(bairros.Length)];
                string cidade = cidades[rand.Next(cidades.Length)];

                vEndereco[i] = $"{rua}, Bairro {bairro}, {cidade}";
                vCelular[i] = $"+55 9{rand.Next(100000000, 999999999)}";
                string cpf = $"{rand.Next(100, 1000)}.{rand.Next(100, 1000)}.{rand.Next(100, 1000)}-{rand.Next(10, 100)}";
                vCPF[i] = cpf;
            }

            for (int i = 0; i < 100; i++)
            {
                 ProjetoMonitor monitor = new ProjetoMonitor();

                monitor.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                monitor.endereco = vEndereco[i];
                monitor.celular = vCelular[i];
                monitor.cpf = vCPF[i];

                contexto.Monitor.Add(monitor);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Monitores");
        }

        public IActionResult Professor()
        {
            contexto.Database.ExecuteSqlRaw("delete from Professores");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Professores', RESEED, 0)");
            Random rand = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vEndereco = new string[100];
            string[] vCelular = new string[100];
            string[] vCPF = new string[100];
            string[] bairros = { "Centro", "Jardins", "Vila Nova", "Parque das Árvores", "Bela Vista", "Nova Esperança", "Residencial São Paulo", "Vila das Palmeiras", "Morada do Sol", "Parque Estrela" };
            string[] nomesDeRuas = { "Rua das Flores", "Avenida Paulista", "Rua do Sol", "Praça da Paz", "Rua São José", "Avenida Central", "Travessa das Palmeiras", "Rua Bela Vista", "Alameda dos Anjos", "Rua da Esperança" };
            string[] cidades = { "São Paulo", "Rio de Janeiro", "Curitiba", "Porto Alegre", "Florianópolis", "Belo Horizonte", "Recife", "Salvador", "Fortaleza", "Manaus" };

            for (int i = 0; i < 100; i++)
            {
                string rua = nomesDeRuas[rand.Next(nomesDeRuas.Length)];
                string bairro = bairros[rand.Next(bairros.Length)];
                string cidade = cidades[rand.Next(cidades.Length)];

                vEndereco[i] = $"{rua}, Bairro {bairro}, {cidade}";
                vCelular[i] = $"+55 9{rand.Next(100000000, 999999999)}";
                string cpf = $"{rand.Next(100, 1000)}.{rand.Next(100, 1000)}.{rand.Next(100, 1000)}-{rand.Next(10, 100)}";
                vCPF[i] = cpf;
            }

            for (int i = 0; i < 100; i++)
            {
                Professor professor = new Professor();

                professor.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                professor.endereco = vEndereco[i];
                professor.celular = vCelular[i];
                professor.cpf = vCPF[i];

                contexto.Professor.Add(professor);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Professores");
        }


        public IActionResult Curso()
        {
            contexto.Database.ExecuteSqlRaw("delete from Cursos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Cursos', RESEED, 0)");
            Random rand = new Random();

            string[] nomesCursos = {"Futebol Infantil", "Informática Básica", "Natação","Artesanato Criativo", "Teatro Infantil", "Dança","Judô", "Inglês para Crianças", "Culinária Infantil", "Música"};
            string[] descricoes = {"Treinamento físico e partidas amistosas.","Introdução ao uso do computador e internet.","Aulas de técnicas de natação e segurança na água.","Produção de peças artísticas e trabalhos manuais.","Desenvolvimento de habilidades de atuação e expressão.","Aulas de coreografia e expressão corporal.","Aprendizado de técnicas de defesa pessoal.","Aprendizado básico da língua inglesa.","Ensino de receitas simples e saudáveis.","Aulas de instrumentos musicais e canto."};

         
            for (int i = 0; i < 10; i++)
            {
                Curso curso = new Curso();

                curso.nome = nomesCursos[i];
                curso.descricao = descricoes[i];
                curso.colaboradorID = rand.Next(1, 11); ;

                contexto.Curso.Add(curso);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Cursos");
        }

        public IActionResult Aluno()
        {
            contexto.Database.ExecuteSqlRaw("delete from Alunos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Alunos', RESEED, 0)");
            Random rand = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vEndereco = new string[100];
            string[] vCelular = new string[100];
            string[] bairros = { "Centro", "Jardins", "Vila Nova", "Parque das Árvores", "Bela Vista", "Nova Esperança", "Residencial São Paulo", "Vila das Palmeiras", "Morada do Sol", "Parque Estrela" };
            string[] nomesDeRuas = { "Rua das Flores", "Avenida Paulista", "Rua do Sol", "Praça da Paz", "Rua São José", "Avenida Central", "Travessa das Palmeiras", "Rua Bela Vista", "Alameda dos Anjos", "Rua da Esperança" };
            string[] cidades = { "São Paulo", "Rio de Janeiro", "Curitiba", "Porto Alegre", "Florianópolis", "Belo Horizonte", "Recife", "Salvador", "Fortaleza", "Manaus" };

            for (int i = 0; i < 100; i++)
            {
                string rua = nomesDeRuas[rand.Next(nomesDeRuas.Length)];
                string bairro = bairros[rand.Next(bairros.Length)];
                string cidade = cidades[rand.Next(cidades.Length)];

                vEndereco[i] = $"{rua}, Bairro {bairro}, {cidade}";
                vCelular[i] = $"+55 9{rand.Next(100000000, 999999999)}";
            }

            for (int i = 0; i < 100; i++)
            {
                Aluno aluno = new Aluno();

                aluno.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                aluno.data = DateOnly.FromDateTime(new DateTime(2005, 1, 1).AddDays(rand.Next(0, 4330)));
                aluno.endereco = vEndereco[i]; 
                aluno.celular = vCelular[i];
                aluno.responsavelID = rand.Next(0, 100);


                contexto.Aluno.Add(aluno);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Alunos");
        }

        public IActionResult Matricula()
        {
            contexto.Database.ExecuteSqlRaw("delete from Matriculas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Matriculas', RESEED, 0)");
            Random rand = new Random();

            var alunosIDs = contexto.Aluno.Select(a => a.Id).ToList();

            foreach (var alunoID in alunosIDs)
            {
                Matricula matricula = new Matricula();

                matricula.alunoID = alunoID;
                matricula.turmaID = rand.Next(0, 10);
                matricula.data = DateOnly.FromDateTime(new DateTime(2005, 1, 1).AddDays(rand.Next(0, 4330)));
                

                contexto.Matriculas.Add(matricula);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Matriculas");
        }

        public IActionResult Turma()
        {
            contexto.Database.ExecuteSqlRaw("delete from Turmas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Turmas', RESEED, 0)");
            Random rand = new Random();

            string[] nomesCursos = { "Futebol Infantil", "Informática Básica", "Natação", "Artesanato Criativo", "Teatro Infantil", "Dança", "Judô", "Inglês para Crianças", "Culinária Infantil", "Música" };


            string[] descricoesTurmas = new string[nomesCursos.Length];


            for (int i = 0; i < nomesCursos.Length; i++)
            {
                Turma turma = new Turma();

                turma.cursoID = rand.Next(0, 10);
                turma.monitorID = rand.Next(0, 100);
                turma.professorID = rand.Next(0, 100);
                turma.descricao = $"Turma {i + 1}: {nomesCursos[i]}";
                turma.horarioDasAulasID = rand.Next(0, 10);
               
                contexto.Turma.Add(turma);
            }

            contexto.SaveChanges();
            return RedirectToAction("Index", "Turmas");
        }
    }
}
