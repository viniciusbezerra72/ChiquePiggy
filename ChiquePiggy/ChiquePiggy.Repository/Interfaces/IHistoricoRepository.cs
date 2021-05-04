using ChiquePiggy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Repository.Interfaces
{
    public interface IHistoricoRepository
    {
        void Salvar(Historico historico);
        List<Historico> ConsultarHistorico(int id);
        void Update(Historico historico);
    }
}
