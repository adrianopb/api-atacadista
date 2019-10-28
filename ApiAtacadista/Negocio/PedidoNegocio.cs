﻿using ApiAtacadista.Entidades;
using ApiAtacadista.Enum;

namespace ApiAtacadista.Negocios
{
    public class PedidoNegocio
    {
        public Pedido CriarPedido(Pedido pedido)
        {
            Pedido novoPedido = new Pedido()
            {
                //TODO: decidir melhor como o Id será implementado
                Id = 1,
                CodigoProduto = pedido.CodigoProduto,
                Observacao = pedido.Observacao,
                PedidoStatus = PedidoStatus.Solicitado,
                Quantidade = pedido.Quantidade
            };

            return novoPedido;
        }
        
        public Pedido AtualizarPedidoStatus(int idPedido, PedidoStatus status)
        {
            Pedido pedido = new Pedido() {};

            //Pesquisar na lista
//            Pedido pedido = Pedido.Where(idPedido);

            pedido.PedidoStatus = status;

            return pedido;
        }
    }
}