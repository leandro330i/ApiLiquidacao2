using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLiquideixon.Models
{
    public interface ICliente
    {
        IEnumerable<Tblcliente> AllCliente { get; }
        Tblcliente FindCliente(int id);
        void InsertCliente(Tblcliente item);
        void UpdateCliente(Tblcliente item);
        void DeleteCliente(int id);
    }
    
    public interface ILiquidacao
    {
        IEnumerable<Tblliquidacao> AllLiquidacao { get; }
        Tblliquidacao FindLiquidacao(int id);
        void InsertLiquidacao(Tblliquidacao item);
        void UpdateLiquidacao(Tblliquidacao item);
        void DeleteLiquidacao(int id);
    }

    public interface IProduto
    {
        IEnumerable<Tblproduto> AllProduto { get; }
        Tblproduto FindProduto(int id);
        void InsertProduto(Tblproduto item);
        void UpdateProduto(Tblproduto item);
        void DeleteProduto(int id);
    }

    public interface ICategoria
    {
        IEnumerable<Tblcategoria> AllCategoria { get; }
        Tblcategoria FindCategoria(int id);
        void InsertCategoria(Tblcategoria item);
        void UpdateCategoria(Tblcategoria item);
        void DeleteCategoria(int id);
    }

    public interface ILocalidade
    {
        IEnumerable<Tbllocalidade> AllLocalidade { get; }
        Tbllocalidade FindLocalidade(int id);
        void InsertLocalidade(Tbllocalidade item);
        void UpdateLocalidade(Tbllocalidade item);
        void DeleteLocalidade(int id);
    }
}
