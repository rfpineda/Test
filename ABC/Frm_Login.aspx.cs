using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                    empleado = LogicaNegocio.Administracion.ListarEmpleado().Result.FirstOrDefault(x => x.IdUsuario.Equals(TxtEmpleado.Text));
                    contrasenaDesencriptada = Utilitarios.Criptografia.DecryptData(empleado.Contrasena, System.Configuration.ConfigurationManager.AppSettings["encriptionKey"].ToString());

                    if (!empleado.Contrasena.Equals(contrasenaDesencriptada))
                        Response.Write("<script>alert('Contraseña Invalida')</script>");


                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}