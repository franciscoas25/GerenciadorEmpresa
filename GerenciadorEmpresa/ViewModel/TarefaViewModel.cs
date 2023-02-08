namespace GerenciadorEmpresa.ViewModel
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }
        public string NomeTarefa { get; set; }
        public bool Concluida { get; set; }
        public string NomeColaborador { get; set; }
    }
}
