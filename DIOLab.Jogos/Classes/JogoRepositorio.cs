using System;
using System.Collections.Generic;
using DIOLab.Jogos.Interfaces;

namespace DIOLab.Jogos
{
    public class JogoRepositorio : IRepositorio<Jogos>
    {
        private List<Jogos> ListaJogos = new List<Jogos>();
        public void Atualiza(int id, Jogos Produto)
        {
            ListaJogos[id] = Produto;
        }

        public void Exclui(int id)
        {
            ListaJogos[id].Excluir();
        }

        public void Insere(Jogos Produto)
        {
            ListaJogos.Add(Produto);
        }

        public List<Jogos> Lista()
        {
            return ListaJogos;
        }

        public int ProximoId()
        {
            return ListaJogos.Count;
        }

        public Jogos RetornaPorId(int id)
        {
            return ListaJogos[id];
        }
    }
}