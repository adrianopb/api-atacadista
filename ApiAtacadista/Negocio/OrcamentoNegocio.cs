﻿using System.Collections.Generic;
using System.Linq;
using ApiAtacadista.Entidades;
using ApiAtacadista.Enum;

namespace ApiAtacadista.Negocios
{
    public class OrcamentoNegocio
    {
        public IEnumerable<Orcamento> ListaOrcamento()
        {
            return new List<Orcamento>()
            {
                Orcamento1(),
                Orcamento2()
            };
        }

        public Orcamento Orcamento1()
        {
            Preco preco = new Preco()
            {
                preco = 5000
            };
            
            return new Orcamento()
            {
                Id = 3,
                Status = OrcamentoStatus.Pendente,
                Preco = preco,
                IdPedido = 2
            };
        }

        public Orcamento Orcamento2()
        {
            Preco preco = new Preco()
            {
                preco = 25000
            };
            
            return new Orcamento()
            {
                Id = 3,
                Status = OrcamentoStatus.Pendente,
                Preco = preco,
                IdPedido = 4
            };
        }
        
        public Orcamento AtualizarOrcamentoStatus(int id, int status)
        {
            Orcamento orcamento = BuscarOrcamento(id);
            orcamento.Status = (OrcamentoStatus)status;

            return orcamento;
        }

        public Orcamento BuscarOrcamento(int idOrcamento)
        {
            Orcamento orcamento = ListaOrcamento().SingleOrDefault(q => q.Id == idOrcamento);

            return orcamento;
        }
        
        public Orcamento CriarOrcamento(int idPedido, Preco preco)
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