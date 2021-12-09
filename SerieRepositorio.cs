using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SeriesRepositorio : IRepositoria<Series>
    {
        private List<Series> listSerie = new List<Series>();

        public void Atualiza(int id, Series entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listSerie[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Series>Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornPorId(int id)
        {
            return listaSerie[id];
        }

    }
}