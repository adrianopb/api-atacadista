namespace ApiAtacadista.Entidades
{
    public class Orcamento
    {
        public string Status { get; set; }
        public int Preco { get; set; }
        public Pedido Pedido { get; set; }
    }
}