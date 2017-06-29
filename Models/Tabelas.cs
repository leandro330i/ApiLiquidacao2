using System;

namespace ApiLiquideixon.Models
{

    public class Tbllocalidade
    {
        public int IDCID { get; set; }
        public string NOMECID { get; set; }
       
    }

    public class Tblliquidacao
    {
        public int IDLIQ { get; set; }
        public string NOMELIQ { get; set; }
        public string DESCRICAOLIQ { get; set; }
        public string FOTOLIQ { get; set; }
        public DateTime DATAFIMLIQ { get; set; }
        public int TBLCLIENTE_ID { get; set; }
        public Tblcliente Tblcliente { get; set; }
    }
    
    public class Tblproduto
    {
        public int IDPROD { get; set; }
        public string NOMEPROD { get; set; }
        public string DESCRICAOPROD { get; set; }
        public string FOTOPROD { get; set; }
        public Decimal PRECOPROD { get; set; }

    }

    public class Tblproduto_has_Tblliquidacao
    {
        public int tblproduto_IDPROD { get; set; }
        public int tblliquidacao_IDLIQ { get; set; }
        public Tblproduto Tblproduto { get; set; }
        public Tblliquidacao Tblliquidacao { get; set; }
    }
    
    public class Tblcliente
    {
        public int IDCLI { get; set; }
        public string NOMECLI { get; set; }
        public string SENHACLI { get; set; }        
        public string EMAILCLI { get; set; }        
        public string ENDERECOCLI { get; set; }        
        public string FONECLI { get; set; }        
        public string FOTOLOGOCLI { get; set; }        
        public string CNPJCPFCLI { get; set; }
        public int TBLCIDADE_IDCID { get; set; }
        public int TBLCATEGORIA_IDCAT { get; set; }        
        public Tbllocalidade Tbllocalidade { get; set; }        
        public Tblcategoria Tblcategoria { get; set; }
    }
        
    public class Tblcategoria
    {
        
        public int IDCAT { get; set; }
        public string NOMECAT { get; set; }
    }

}