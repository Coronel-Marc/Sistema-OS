using System;
using System.Collections.Generic;
using OsSistemas.Interfaces;

namespace OsSistemas.Classes
{
    public class OSrepositorio : IRepositorio<OrdemServico>
    {
        private List<OrdemServico> listaServico = new List<OrdemServico>();
        public void Atualiza(int id, OrdemServico objeto)
        {
            listaServico[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaServico[id].excluir();
        }

        public void Insere(OrdemServico objeto)
        {
            listaServico.Add(objeto);
        }

        public List<OrdemServico> Lista()
        {
            return listaServico;
        }

        public int ProximoId()
        {
            return listaServico.Count;
        }

        public OrdemServico RetornaPorId(int id)
        {
            return listaServico[id];
        }
    }
}