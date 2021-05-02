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
    public partial class FmrAlta : Form
    {
        private Articulo articulo = null;
        public FmrAlta()
        {
            InitializeComponent();
        }
        public FmrAlta(Articulo arti)
        {
            InitializeComponent();
            articulo = arti;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FmrAlta_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CBMarca.DataSource = marcaNegocio.listar();
            CBMarca.ValueMember = "id";
            CBMarca.DisplayMember = "Descripcion";

            CBMarca.SelectedIndex = -1;

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            CBCategoria.DataSource = categoriaNegocio.listar();
            CBCategoria.ValueMember = "id";
            CBCategoria.DisplayMember = "Descripcion";

            CBCategoria.SelectedIndex = -1;

            if (articulo != null)
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtUrlImage.Text = articulo.UrlImage;
                txtPrecio.Text = Convert.ToString(articulo.Precio);

                CBCategoria.SelectedValue = articulo.Categoria.id;
                CBMarca.SelectedValue = articulo.Marca.id;

                Text = "Modificar Articulo";

            }
        }
    }
}
