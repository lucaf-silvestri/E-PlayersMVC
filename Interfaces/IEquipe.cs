using System.Collections.Generic;
using E_PlayersMVC.Models;

namespace E_PlayersMVC.Interfaces
{
    public interface IEquipe
    {
        void Criar(Equipe e);
        List<Equipe> LerTodas();
        void Alterar(Equipe e);
        void Deletar(int id);
    }
}