using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using MySql.Data.MySqlClient;
using MySql.Web;

namespace ApiLiquideixon.Models
{
    public class CrudMySql
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["StringConexaoMySql"].ConnectionString;
        }
        
        public static List<Tblcliente> GetClientes()
        {
            List<Tblcliente> _clientes = new List<Tblcliente>();
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblcliente, Tblcategoria, Tbllocalidade WHERE Tblcategoria.IDCAT = Tblcliente.TBLCATEGORIA_IDCAT AND Tbllocalidade.IDCID = Tblcliente.TBLCIDADE_IDCID", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var cliente = new Tblcliente();
                                cliente.IDCLI = Convert.ToInt32(dr["IDCLI"]);
                                cliente.NOMECLI = dr["NOMECLI"].ToString();
                                cliente.SENHACLI = dr["SENHACLI"].ToString();
                                cliente.CNPJCPFCLI = dr["CNPJCPFCLI"].ToString();
                                cliente.EMAILCLI = dr["EMAILCLI"].ToString();
                                cliente.ENDERECOCLI = dr["ENDERECOCLI"].ToString();
                                cliente.FONECLI = dr["FONECLI"].ToString();
                                cliente.FOTOLOGOCLI = dr["FOTOLOGOCLI"].ToString();
                                //cliente.Tblcategoria.NOMECAT = dr["NOMECAT"].ToString();
                                //cliente.Tbllocalidade.NOMECID = dr["NOMECID"].ToString();
                                _clientes.Add(cliente);
                            }
                        }
                        return _clientes;
                    }
                }
            }
        }

        public static Tblcliente GetCliente(int id)
        {
            Tblcliente cliente = null;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblcliente WHERE IDCLI =" + id, con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                cliente = new Tblcliente();
                                cliente.IDCLI = Convert.ToInt32(dr["IDCLI"]);
                                cliente.NOMECLI = dr["NOMECLI"].ToString();
                                cliente.SENHACLI = dr["SENHACLI"].ToString();
                                cliente.CNPJCPFCLI = dr["CNPJCPFCLI"].ToString();
                                cliente.EMAILCLI = dr["EMAILCLI"].ToString();
                                cliente.ENDERECOCLI = dr["ENDERECOCLI"].ToString();
                                cliente.FONECLI = dr["FONECLI"].ToString();
                                cliente.FOTOLOGOCLI = dr["FOTOLOGOCLI"].ToString();
                                //cliente.Tblcategoria.NOMECAT = dr["NOMECAT"].ToString();
                                //cliente.Tbllocalidade.NOMECID = dr["NOMECID"].ToString();
                                
                            }
                        }
                        return cliente;
                    }
                }
            }
        }

        public static int InsertCliente(Tblcliente cliente)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO Tblcliente(NOMECLI, SENHACLI, CNPJCPFCLI, EMAILCLI, ENDERECOCLI, FONECLI, TBLCIDADE_IDCID, TBLCATEGORIA_IDCAT) VALUES (@NOMECLI, @SENHACLI, @CNPJCPFCLI, @EMAILCLI, @ENDERECOCLI, @FONECLI, @TBLCIDADE_IDCID, @TBLCATEGORIA_IDCAT)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMECLI", cliente.NOMECLI);
                    cmd.Parameters.AddWithValue("@SENHACLI", cliente.SENHACLI);
                    cmd.Parameters.AddWithValue("@CNPJCPFCLI", cliente.CNPJCPFCLI);
                    cmd.Parameters.AddWithValue("@EMAILCLI", cliente.EMAILCLI);
                    cmd.Parameters.AddWithValue("@ENDERECOCLI", cliente.ENDERECOCLI);
                    cmd.Parameters.AddWithValue("@FONECLI", cliente.FONECLI);
                    cmd.Parameters.AddWithValue("@TBLCIDADE_IDCID", cliente.TBLCIDADE_IDCID);
                    cmd.Parameters.AddWithValue("@TBLCATEGORIA_IDCAT", cliente.TBLCATEGORIA_IDCAT);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateCliente(Tblcliente cliente)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE Tblcliente SET NOMECLI=@NOMECLI, SENHACLI=@SENHACLI, CNPJCPFCLI=@CNPJCPFCLI, EMAILCLI=@EMAILCLI, ENDERECOCLI=@ENDERECOCLI, FONECLI=@FONECLI";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMECLI", cliente.NOMECLI);
                    cmd.Parameters.AddWithValue("@SENHACLI", cliente.SENHACLI);
                    cmd.Parameters.AddWithValue("@CNPJCPFCLI", cliente.CNPJCPFCLI);
                    cmd.Parameters.AddWithValue("@EMAILCLI", cliente.EMAILCLI);
                    cmd.Parameters.AddWithValue("@ENDERECOCLI", cliente.ENDERECOCLI);
                    cmd.Parameters.AddWithValue("@FONECLI", cliente.FONECLI);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteCliente(int id)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM Tblcliente WHERE IDCLI =" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDCLI", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Tblliquidacao> GetLiquidacoes()
        {
            List<Tblliquidacao> _liquidacoes = new List<Tblliquidacao>();
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblliquidacao", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var liquidacao = new Tblliquidacao();
                                liquidacao.IDLIQ = Convert.ToInt32(dr["IDLIQ"]);
                                liquidacao.NOMELIQ = dr["NOMELIQ"].ToString();
                                liquidacao.DESCRICAOLIQ = dr["DESCRICAOLIQ"].ToString();
                                liquidacao.DATAFIMLIQ = Convert.ToDateTime(dr["DATAFIMLIQ"]);
                                //liquidacao.Tblcliente.NOMECLI = dr["NOMECLI"].ToString();
                                _liquidacoes.Add(liquidacao);
                            }
                        }
                        return _liquidacoes;
                    }
                }
            }
        }

        public static Tblliquidacao GetLiquidacao(int id)
        {
            Tblliquidacao liquidacao = null;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblliquidacao WHERE IDLIQ =" + id, con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                liquidacao = new Tblliquidacao();
                                liquidacao.IDLIQ = Convert.ToInt32(dr["IDLIQ"]);
                                liquidacao.NOMELIQ = dr["NOMELIQ"].ToString();
                                liquidacao.DESCRICAOLIQ = dr["DESCRICAOLIQ"].ToString();
                                liquidacao.DATAFIMLIQ = Convert.ToDateTime(dr["DATAFIMLIQ"]);
                                //liquidacao.Tblcliente.NOMECLI = dr["NOMECLI"].ToString();

                            }
                        }
                        return liquidacao;
                    }
                }
            }
        }

        public static int InsertLiquidacao(Tblliquidacao liquidacao)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO Tblliquidacao(NOMELIQ, DESCRICAOLIQ, DATAFIMLIQ) VALUES (@NOMELIQ, @DESCRICAOLIQ, @DATAFIMLIQ)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMELIQ", liquidacao.NOMELIQ);
                    cmd.Parameters.AddWithValue("@DESCRICAOLIQ", liquidacao.DESCRICAOLIQ);
                    cmd.Parameters.AddWithValue("@DATAFIMLIQ", liquidacao.DATAFIMLIQ);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateLiquidacao(Tblliquidacao liquidacao)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE Tblliquidacao SET NOMELIQ=@NOMELIQ, DESCRICAOLIQ=@DESCRICAOLIQ, DATAFIMLIQ=@DATAFIMLIQ";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMELIQ", liquidacao.NOMELIQ);
                    cmd.Parameters.AddWithValue("@DESCRICAOLIQ", liquidacao.DESCRICAOLIQ);
                    cmd.Parameters.AddWithValue("@DATAFIMLIQ", liquidacao.DATAFIMLIQ);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteLiquidacao(int id)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM Tblliquidacao WHERE IDLIQ =" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDLIQ", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Tblproduto> GetProdutos()
        {
            List<Tblproduto> _produtos = new List<Tblproduto>();
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblproduto", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var produto = new Tblproduto();
                                produto.IDPROD = Convert.ToInt32(dr["IDPROD"]);
                                produto.NOMEPROD = dr["NOMEPROD"].ToString();
                                produto.DESCRICAOPROD = dr["DESCRICAOPROD"].ToString();
                                produto.PRECOPROD = Convert.ToDecimal(dr["PRECOPROD"]);
                                _produtos.Add(produto);
                            }
                        }
                        return _produtos;
                    }
                }
            }
        }

        public static Tblproduto GetProduto(int id)
        {
            Tblproduto produto = null;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblproduto WHERE IDPROD =" + id, con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                produto = new Tblproduto();
                                produto.IDPROD = Convert.ToInt32(dr["IDPROD"]);
                                produto.NOMEPROD = dr["NOMEPROD"].ToString();
                                produto.DESCRICAOPROD = dr["DESCRICAOPROD"].ToString();
                                produto.PRECOPROD = Convert.ToDecimal(dr["PRECOPROD"]);

                            }
                        }
                        return produto;
                    }
                }
            }
        }

        public static int InsertProduto(Tblproduto produto)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO Tblproduto(NOMEPROD, DESCRICAOPROD, PRECOPROD) VALUES (@NOMEPROD, @DESCRICAOPROD, @PRECOPROD)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMEPROD", produto.NOMEPROD);
                    cmd.Parameters.AddWithValue("@DESCRICAOPROD", produto.DESCRICAOPROD);
                    cmd.Parameters.AddWithValue("@PRECOPROD", produto.PRECOPROD);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateProduto(Tblproduto produto)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE Tblproduto SET NOMEPROD=@NOMEPROD, DESCRICAOPROD=@DESCRICAOPROD, PRECOPROD=@PRECOPROD";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMEPROD", produto.NOMEPROD);
                    cmd.Parameters.AddWithValue("@DESCRICAOPROD", produto.DESCRICAOPROD);
                    cmd.Parameters.AddWithValue("@PRECOPROD", produto.PRECOPROD);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteProduto(int id)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM Tblproduto WHERE IDPROD =" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPROD", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Tblcategoria> GetCategorias()
        {
            List<Tblcategoria> _categorias = new List<Tblcategoria>();
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblcategoria", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var categoria = new Tblcategoria();
                                categoria.IDCAT = Convert.ToInt32(dr["IDCAT"]);
                                categoria.NOMECAT = dr["NOMECAT"].ToString();
                                _categorias.Add(categoria);
                            }
                        }
                        return _categorias;
                    }
                }
            }
        }

        public static Tblcategoria GetCategoria(int id)
        {
            Tblcategoria categoria = null;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tblcategoria WHERE IDCAT =" + id, con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                categoria = new Tblcategoria();
                                categoria.IDCAT = Convert.ToInt32(dr["IDCAT"]);
                                categoria.NOMECAT = dr["NOMECAT"].ToString();

                            }
                        }
                        return categoria;
                    }
                }
            }
        }

        public static int InsertCategoria(Tblcategoria categoria)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO Tblcategoria(NOMECAT) VALUES (@NOMECAT)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMECAT", categoria.NOMECAT);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateCategoria(Tblcategoria categoria)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE Tblcategoria SET NOMECAT=@NOMECAT";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMECAT", categoria.NOMECAT);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteCategoria(int id)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM Tblcategoria WHERE IDCAT =" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDCAT", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Tbllocalidade> GetLocalidades()
        {
            List<Tbllocalidade> _localidades = new List<Tbllocalidade>();
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tbllocalidade", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var localidade = new Tbllocalidade();
                                localidade.IDCID = Convert.ToInt32(dr["IDCID"]);
                                localidade.NOMECID = dr["NOMECID"].ToString();
                                _localidades.Add(localidade);
                            }
                        }
                        return _localidades;
                    }
                }
            }
        }

        public static Tbllocalidade GetLocalidade(int id)
        {
            Tbllocalidade localidade = null;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tbllocalidade WHERE IDCID =" + id, con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                localidade = new Tbllocalidade();
                                localidade.IDCID = Convert.ToInt32(dr["IDCID"]);
                                localidade.NOMECID = dr["NOMECID"].ToString();

                            }
                        }
                        return localidade;
                    }
                }
            }
        }

        public static int InsertLocalidade(Tbllocalidade localidade)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO Tbllocalidade(NOMECID) VALUES (@NOMECID)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMECID", localidade.NOMECID);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateLocalidade(Tbllocalidade localidade)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE Tbllocalidade SET NOMECID=@NOMECID";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMECID", localidade.NOMECID);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteLocalidade(int id)
        {
            int reg = 0;
            using (MySqlConnection con = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM Tbllocalidade WHERE IDCID =" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDCID", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
    }
}