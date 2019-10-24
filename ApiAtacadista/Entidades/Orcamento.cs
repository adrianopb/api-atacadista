using ApiAtacadista.Enum;

namespace ApiAtacadista.Entidades
{
    public class Orcamento
    {
        public int Id { get; set; }
        public OrcamentoStatus Status { get; set; }
        public int Preco { get; set; }
        public int IdPedido { get; set; }
    }
}