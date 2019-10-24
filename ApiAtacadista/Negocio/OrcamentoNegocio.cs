using ApiAtacadista.Entidades;
using ApiAtacadista.Enum;

namespace ApiAtacadista.Negocios
{
    public class OrcamentoNegocio
    {
        public Orcamento CriarOrcamento(int idPedido, int preco)
        {
            Orcamento Orcamento = new Orcamento()
            {
                //TODO: decidir melhor como o Id será implementado
                Id = 1 ,
                Status = OrcamentoStatus.Pendente,
                IdPedido = idPedido,
                Preco = preco
            };

            return Orcamento;
        }
    }
}