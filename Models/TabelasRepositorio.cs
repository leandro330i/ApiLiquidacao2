using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ApiLiquideixon.Models
{
    public class Cliente : ICliente
    {
        private List<Tblcliente> _clientes;

        public Cliente()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _clientes = CrudMySql.GetClientes();
        }

        public IEnumerable<Tblcliente> AllCliente
        {
            get
            {
                return _clientes;
            }
        }

        public void DeleteCliente(int id)
        {
            CrudMySql.DeleteCliente(id);
        }
        
        public Tblcliente FindCliente(int id)
        {
            return CrudMySql.GetCliente(id);
        }

        public void InsertCliente(Tblcliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("cliente");
            }
            CrudMySql.InsertCliente(cliente);
        }

        public void UpdateCliente(Tblcliente cliente)
        {
            CrudMySql.UpdateCliente(cliente);
        }

    }

    public class Liquidacao : ILiquidacao
    {
        private List<Tblliquidacao> _liquidacoes;

        public Liquidacao()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _liquidacoes = CrudMySql.GetLiquidacoes();
        }

        public IEnumerable<Tblliquidacao> AllLiquidacao
        {
            get
            {
                return _liquidacoes;
            }
        }

        public void DeleteLiquidacao(int id)
        {
            CrudMySql.DeleteLiquidacao(id);
        }

        public Tblliquidacao FindLiquidacao(int id)
        {
            return CrudMySql.GetLiquidacao(id);
        }

        public void InsertLiquidacao(Tblliquidacao liquidacao)
        {
            if (liquidacao == null)
            {
                throw new ArgumentNullException("liquidacao");
            }
            CrudMySql.InsertLiquidacao(liquidacao);
        }

        public void UpdateLiquidacao(Tblliquidacao liquidacao)
        {
            CrudMySql.UpdateLiquidacao(liquidacao);
        }

    }

    public class Categoria : ICategoria
    {
        private List<Tblcategoria> _categorias;

        public Categoria()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _categorias = CrudMySql.GetCategorias();
        }

        public IEnumerable<Tblcategoria> AllCategoria
        {
            get
            {
                return _categorias;
            }
        }

        public void DeleteCategoria(int id)
        {
            CrudMySql.DeleteCategoria(id);
        }

        public Tblcategoria FindCategoria(int id)
        {
            return CrudMySql.GetCategoria(id);
        }

        public void InsertCategoria(Tblcategoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException("categoria");
            }
            CrudMySql.InsertCategoria(categoria);
        }

        public void UpdateCategoria(Tblcategoria categoria)
        {
            CrudMySql.UpdateCategoria(categoria);
        }

    }

    public class Produto : IProduto
    {
        private List<Tblproduto> _produtos;

        public Produto()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _produtos = CrudMySql.GetProdutos();
        }

        public IEnumerable<Tblproduto> AllProduto
        {
            get
            {
                return _produtos;
            }
        }

        public void DeleteProduto(int id)
        {
            CrudMySql.DeleteProduto(id);
        }

        public Tblproduto FindProduto(int id)
        {
            return CrudMySql.GetProduto(id);
        }

        public void InsertProduto(Tblproduto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }
            CrudMySql.InsertProduto(produto);
        }

        public void UpdateProduto(Tblproduto produto)
        {
            CrudMySql.UpdateProduto(produto);
        }

    }

    public class Localidade : ILocalidade
    {
        private List<Tbllocalidade> _localidades;

        public Localidade()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _localidades = CrudMySql.GetLocalidades();
        }

        public IEnumerable<Tbllocalidade> AllLocalidade
        {
            get
            {
                return _localidades;
            }
        }

        public void DeleteLocalidade(int id)
        {
            CrudMySql.DeleteLocalidade(id);
        }

        public Tbllocalidade FindLocalidade(int id)
        {
            return CrudMySql.GetLocalidade(id);
        }

        public void InsertLocalidade(Tbllocalidade localidade)
        {
            if (localidade == null)
            {
                throw new ArgumentNullException("localidade");
            }
            CrudMySql.InsertLocalidade(localidade);
        }

        public void UpdateLocalidade(Tbllocalidade localidade)
        {
            CrudMySql.UpdateLocalidade(localidade);
        }

    }
}