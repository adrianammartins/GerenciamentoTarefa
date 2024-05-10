using Microsoft.AspNetCore.Mvc;
using GerenciamentoTarefa.Models;

namespace GerenciamentoTarefa.Controllers
{
    public class TarefaController : Controller
    {

        private static List<Tarefa> _tarefa = new List<Tarefa>();
        private static int ultimoId = 0;
        public IActionResult Index()
        {
            return RedirectToAction("PorFazer");
        }
        public ActionResult PorFazer()
        {
            var tarefasPorFazer = _tarefa.Where(t => t.Status == "Por Fazer").ToList();
            return View(tarefasPorFazer);
        }

        public ActionResult Concluida()
        {
            var tarefasFeitas = _tarefa.Where(t => t.Status == "Concluida").ToList();
            return View(tarefasFeitas);
        }
        public ActionResult Concluir(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa != null)
            {
                tarefa.Status = "Concluida";
                tarefa.DataFim = DateTime.Now;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tarefa tarefa)
        {

            tarefa.TarefaId = ++ultimoId;
            tarefa.DataInico = DateTime.Now;
            tarefa.Status = "Por Fazer";
            _tarefa.Add(tarefa);
            return RedirectToAction("Index");
        }

        

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }


            _tarefa.Remove(tarefa);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }


        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefa.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);
                if (existingTarefa != null)
                {
                    existingTarefa.NomeTarefa = tarefa.NomeTarefa;
                    existingTarefa.Descricao = tarefa.Descricao;
                    existingTarefa.Prioridade = tarefa.Prioridade;

                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }
        public IActionResult Detalhes(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(p => p.TarefaId == id);
            if (tarefa == null)
                return NotFound(); 

            return View(tarefa);
        }


    }
}
