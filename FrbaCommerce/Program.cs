using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            FrbaCommerce.Login.FormLogin formLogin = new FrbaCommerce.Login.FormLogin();
            formLogin.ShowDialog();
            /*if (formLogin.DialogResult == DialogResult.OK)
            {
                FrbaCommerce.ABM_Rol.FormABMRol frmRol = new FrbaCommerce.ABM_Rol.FormABMRol();
                frmRol.ShowDialog();
                
                
                if (frmRol.DialogResult == DialogResult.OK)
                {
                    Application.Run(new FormMenu());
        }*/
    }
}
    }

    
