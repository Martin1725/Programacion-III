using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaOriginal;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaOriginal = negocio.listar();
            dgvLista.DataSource = listaOriginal;
            dgvLista.Columns[6].Visible = false;
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo art = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                pbArticulo.Load(art.UrlImage);

                Categoria cat = (Categoria)dgvLista.CurrentRow.DataBoundItem;
                pbArticulo.Load(cat.Descripcion);
            }

            catch (Exception)//que no se pinche si no hay URL
            {


            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo arti = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            FmrAlta alta = new FmrAlta(arti);
            alta.ShowDialog();
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
