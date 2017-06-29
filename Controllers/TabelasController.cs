using ApiLiquideixon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLiquideixon.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly ICliente _cliente;

        public ClientesController()
        {
            _cliente = new Cliente();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Tblcliente> List()
        {
            return _cliente.AllCliente;
        }

        // GET: api/Clientes/5
        public Tblcliente GetCliente(int id)
        {
            var cliente = _cliente.FindCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return cliente;
        }

        // POST: api/Clientes
        [HttpPost()]
        public void Post([FromBody]Tblcliente cliente)
        {
            _cliente.InsertCliente(cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put(int id, [FromBody]Tblcliente cliente)
        {
            cliente.IDCLI = id;
            _cliente.UpdateCliente(cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            _cliente.DeleteCliente(id);
        }
    }

    public class LiquidacoesController : ApiController
    {
        private readonly ILiquidacao _liquidacao;

        public LiquidacoesController()
        {
            _liquidacao = new Liquidacao();
        }

        // GET: api/Liquidacoes
        [HttpGet]
        public IEnumerable<Tblliquidacao> List()
        {
            return _liquidacao.AllLiquidacao;
        }

        // GET: api/Liquidacoes/5
        public Tblliquidacao GetLiquidacao(int id)
        {
            var liquidacao = _liquidacao.FindLiquidacao(id);
            if (liquidacao == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return liquidacao;
        }

        // POST: api/Liquidacoes
        [HttpPost()]
        public void Post([FromBody]Tblliquidacao liquidacao)
        {
            _liquidacao.InsertLiquidacao(liquidacao);
        }

        // PUT: api/Liquidacoes/5
        [HttpPut()]
        public void Put(int id, [FromBody]Tblliquidacao liquidacao)
        {
            liquidacao.IDLIQ = id;
            _liquidacao.UpdateLiquidacao(liquidacao);
        }

        // DELETE: api/Liquidacoes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            _liquidacao.DeleteLiquidacao(id);
        }
    }

    public class ProdutosController : ApiController
    {
        private readonly IProduto _produto;

        public ProdutosController()
        {
            _produto = new Produto();
        }

        // GET: api/Produtos
        [HttpGet]
        public IEnumerable<Tblproduto> List()
        {
            return _produto.AllProduto;
        }

        // GET: api/Produtos/5
        public Tblproduto GetProduto(int id)
        {
            var produto = _produto.FindProduto(id);
            if (produto == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return produto;
        }

        // POST: api/Produtos
        [HttpPost()]
        public void Post([FromBody]Tblproduto produto)
        {
            _produto.InsertProduto(produto);
        }

        // PUT: api/Produtos/5
        [HttpPut()]
        public void Put(int id, [FromBody]Tblproduto produto)
        {
            produto.IDPROD = id;
            _produto.UpdateProduto(produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete()]
        public void Delete(int id)
        {
            _produto.DeleteProduto(id);
        }
    }

    public class CategoriasController : ApiController
    {
        private readonly ICategoria _categoria;

        public CategoriasController()
        {
            _categoria = new Categoria();
        }

        // GET: api/Categorias
        [HttpGet]
        public IEnumerable<Tblcategoria> List()
        {
            return _categoria.AllCategoria;
        }

        // GET: api/Categorias/5
        public Tblcategoria GetCategoria(int id)
        {
            var categoria = _categoria.FindCategoria(id);
            if (categoria == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return categoria;
        }

        // POST: api/Categorias
        [HttpPost()]
        public void Post([FromBody]Tblcategoria categoria)
        {
            _categoria.InsertCategoria(categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut()]
        public void Put(int id, [FromBody]Tblcategoria categoria)
        {
            categoria.IDCAT = id;
            _categoria.UpdateCategoria(categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete()]
        public void Delete(int id)
        {
            _categoria.DeleteCategoria(id);
        }
    }

    public class LocalidadesController : ApiController
    {
        private readonly ILocalidade _localidade;

        public LocalidadesController()
        {
            _localidade = new Localidade();
        }

        // GET: api/Localidades
        [HttpGet]
        public IEnumerable<Tbllocalidade> List()
        {
            return _localidade.AllLocalidade;
        }

        // GET: api/Localidades/5
        public Tbllocalidade GetLocalidade(int id)
        {
            var localidade = _localidade.FindLocalidade(id);
            if (localidade == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return localidade;
        }

        // POST: api/Localidades
        [HttpPost()]
        public void Post([FromBody]Tbllocalidade localidade)
        {
            _localidade.InsertLocalidade(localidade);
        }

        // PUT: api/Localidades/5
        [HttpPut()]
        public void Put(int id, [FromBody]Tbllocalidade localidade)
        {
            localidade.IDCID = id;
            _localidade.UpdateLocalidade(localidade);
        }

        // DELETE: api/Localidades/5
        [HttpDelete()]
        public void Delete(int id)
        {
            _localidade.DeleteLocalidade(id);
        }
    }
}
