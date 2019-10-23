namespace ApiAtacadista.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
    }
}