using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ABC
{
    public partial class Frm_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Empleado empleado;
                    String contrasenaDesencriptada;

                    empleado = LogicaNegocio.Administracion.ListarEmpleado().GetAwaiter().GetResult().FirstOrDefault(x => x.IdUsuario.ToUpper().Equals(TxtEmpleado.Text.ToUpper()));
                    if(empleado != null)
                    {
                        contrasenaDesencriptada = Utilitarios.Criptografia.DecryptData(empleado.Contrasena, System.Configuration.ConfigurationManager.AppSettings["encriptionKey"].ToString());

                        if (TxtContrasena.Text.Equals(contrasenaDesencriptada))
                        {
                            Session.Clear();
                            Session.RemoveAll();
                            Session["EMPLEADO"] = empleado;
                            Response.Redirect("~/Frm_Consulta_Empleados.aspx");
                        }
                    }
                    MessageBox.Show("Usuario y Contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}