using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WPF2.Model;

namespace WPF2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Vendedor> lista = new List<Vendedor>();
        public MainWindow()
        {

            InitializeComponent();


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Vendedor V = new Vendedor();
            int codigo = 0;
            double TotalVendas = 0;
            Int32.TryParse(txtcodigo.Text, out codigo);
            Double.TryParse(txttotalVendas.Text, out TotalVendas);
            V.codigo = codigo;
            V.nome = txtnome.Text;
            V.TotalVendas = TotalVendas;
            //validar os campos
            if (!V.ValidarCampos())
            {
                MessageBox.Show("Os campos devem ser preenchidos corretamente");
                return;
            }

            if (lista.Count > 0)
            {
                int? index = null;
                foreach (var item in lista)
                {
                 
                    //Verifica se a lista está preenchida e estou editando neste caso são dados que já existem
                    if (item.codigo == V.codigo)
                    {
                        V.codigo = codigo;
                        V.nome = txtnome.Text;
                        V.TotalVendas = TotalVendas;
                        V.CalculaComissao(V.TotalVendas);
                        index = lista.IndexOf(item);
                    }
                }
                if (index != null)
                {
                    lista.RemoveAt((Int32)index);
                }

                V.CalculaComissao(TotalVendas);
                lista.Add(V);

            }
            else
            {
                V.CalculaComissao(TotalVendas);
                lista.Add(V);
            }
            //Adiciona a Lista
            dg.ItemsSource = lista;
            dg.Items.Refresh();
            dg.UpdateLayout();
            limparCampos();

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            foreach (var data in dg.SelectedItems)
            {
                Vendedor d = data as Vendedor;
                txtcodigo.Text = d.codigo.ToString();
                txtnome.Text = d.nome.ToString();
                txttotalVendas.Text = d.TotalVendas.ToString();
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            int? index = null;
            foreach (var data2 in dg.SelectedItems)
            {
                Vendedor d = data2 as Vendedor;
                foreach (var item in lista)
                {
                    if (d.codigo == item.codigo)
                        index = lista.IndexOf(item);
                }
            }
            if(index != null)
            {
                lista.RemoveAt((Int32)index);
            }
            dg.Items.Refresh();
            dg.UpdateLayout();
        }
        public void limparCampos()
        {
            txtnome.Text = "";
            txtcodigo.Text = "";
            txttotalVendas.Text = "";
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
