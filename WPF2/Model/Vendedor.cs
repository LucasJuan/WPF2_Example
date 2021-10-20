using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF2.Model
{
    class Vendedor
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public double TotalVendas { get; set; }
        public double ValorComissao { get; set; }

        public void CalculaComissao(double TotalVendas)
        {
            if(TotalVendas >= (double)1000 && TotalVendas <= (double)5000)
            {
                ValorComissao = 0.03*TotalVendas;
            }
            if (TotalVendas > (double)5000 && TotalVendas <= (double) 10000)
            {
                ValorComissao = 0.07* TotalVendas;
            }
            if (TotalVendas > (double) 10000)
            {
                ValorComissao = 0.12*TotalVendas;
            }
        }
        public bool ValidarCampos()
        {
            if (codigo <= 0)
                return false;
            if (String.IsNullOrEmpty(nome))
                return false;
            if (TotalVendas < 0)
                return false;

            return true;
        }
    }
}
