using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FrbaCommerce
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        public class OpcionMenu
        {
            public int IdFuncionalidad = 1;
            public string NombreFuncionalidad = "carla";
            public string NombreForm = "FormABMEmpresa";
            public int NodoPadre = 0;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            SortedList<int, OpcionMenu> opcionesMenu = new SortedList<int, OpcionMenu>();

            //BaseDeDatos.ObtenerOpcionesMenu(opcionesMenu);

            ToolStripMenuItem menuItem = new ToolStripMenuItem("&Menu");

            foreach (KeyValuePair<int, OpcionMenu> kvp in opcionesMenu)
            {
                ToolStripMenuItem subItem = new ToolStripMenuItem("Hola", null, opcionMenu_Click);
                subItem.Tag = kvp.Value.NombreForm;

                menuItem.DropDownItems.Add(subItem);
            }

            //MenuStrip menuStrip = Formularios.ObtenerMenuStrip();

            // Agrego el boton salir al menu
            ToolStripMenuItem subItemSalir = new ToolStripMenuItem("Salir", null, opcionMenuSalir_Click);
            subItemSalir.Tag = "Salir";

            menuItem.DropDownItems.Add(subItemSalir);

            //menuStrip.Items.Add(menuItem);

            //this.Controls.Add(menuStrip);

        }
        // Event that is called from menu item.}

        private void opcionMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            Form formAux;
            formAux = (Form)Activator.CreateInstance(null, "Clinica_Frba." + menuItem.Tag.ToString()).Unwrap();

            formAux.MdiParent = this;

            Form formActivo = (Form)this.ActiveMdiChild;

            if (formActivo != null)
            {
                //Formularios.setearValidacion(formActivo, false);
                formActivo.Close();
            }

            formAux.Show();

            /*
            Form formulario;
            Type tipoObjeto = Type.GetType("Clinica_Frba" + menuItem.Tag.ToString());
            Object objeto = Activator.CreateInstance(tipoObjeto);
            formulario = (Form)objeto;
            formulario.Show();
            */
        }

        // Event that is called from menu item.

        private void opcionMenuSalir_Click(object sender, EventArgs e)
        {

            Form formActivo = (Form)this.ActiveMdiChild;

            if (formActivo != null)
            {
                //Formularios.setearValidacion(formActivo, false);
                formActivo.Close();
            }

            this.Close();
        }

    }
}