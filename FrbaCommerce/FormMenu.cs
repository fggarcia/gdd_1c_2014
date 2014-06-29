using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;

namespace FrbaCommerce
{
    public partial class FormMenu : Form
    {
        public SortedList<int, OpcionMenu> opcionesMenu = new SortedList<int, OpcionMenu>();
        public Usuarios usuario;
        public FormMenu(Usuarios usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI; 
            foreach (Control ctl in this.Controls)
            { 
                try 
                { 
                    ctlMDI = (MdiClient)ctl; ctlMDI.BackColor = this.BackColor; 
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            ToolStripMenuItem menuItem = new ToolStripMenuItem("&Menu");

            Procedimientos.obtenerOpcionesMenu(opcionesMenu, usuario.Id_Rol);

            foreach (KeyValuePair<int, OpcionMenu> kvp in opcionesMenu)
            {
                ToolStripMenuItem subItem = new ToolStripMenuItem(kvp.Value.DescripcionFuncionalidad, null, opcionMenu_Click);
                subItem.Tag = kvp.Value.DescripcionFuncionalidad;
                menuItem.DropDownItems.Add(subItem);
            }

            ToolStripMenuItem subItemSalir = new ToolStripMenuItem("Salir", null, opcionMenuSalir_Click);
            subItemSalir.Tag = "Salir";

            menuItem.DropDownItems.Add(subItemSalir);

            menuStrip.Items.Add(menuItem);
            this.Controls.Add(menuStrip);
        }

        private void opcionMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            Constantes.funcionalidad func;

            func = Constantes.obtenerFuncionalidad(menuItem.Tag.ToString());

            Form formAux;

            formAux = (Form)Activator.CreateInstance(null, "FrbaCommerce." + func.carpeta + "." + func.form).Unwrap();

            formAux.MdiParent = this;

            formAux.StartPosition = FormStartPosition.CenterScreen;
          
            Form formActivo = (Form)this.ActiveMdiChild;

            if (formActivo != null)
            {
                Validaciones.setearValidacion(formActivo, false);
                formActivo.Close();
            }
            Size tamanio = new Size(30, 30);
            this.Size = formAux.Size + tamanio;
            formAux.Show();
        }
    
        private void opcionMenuSalir_Click(object sender, EventArgs e)
        {

            Form formActivo = (Form)this.ActiveMdiChild;

            if (formActivo != null)
            {
                Validaciones.setearValidacion(formActivo, false);
                formActivo.Close();
            }

            this.Close();
        }

    }
}
