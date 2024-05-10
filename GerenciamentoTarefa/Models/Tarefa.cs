using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefa.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name ="Nome")]
        public string NomeTarefa { get; set; } = string.Empty;

        [Display(Name ="Data Início")]
        public DateTime DataInico { get; set; }

        [Display(Name ="Data de Conclusão")]
        public DateTime DataFim { get; set; }
       public string Status { get; set; } = string.Empty;

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }= string.Empty;
        public string Prioridade { get; set; }=string.Empty;
    }
}
