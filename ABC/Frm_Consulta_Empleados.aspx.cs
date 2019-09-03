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
    public partial class Frm_Consulta_Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    if (!EsPerfilValido())
                        Response.Redirect("./Frm_Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    List<Empleado> empleados;

                    empleados = LogicaNegocio.Administracion.ListarEmpleado().GetAwaiter().GetResult().FindAll(x => x.NombreCompleto.Contains(TxtNombre.Text));
                    GVEmpleados.DataSource = empleados;
                    GVEmpleados.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool EsPerfilValido()
        {
            //var usuarioPerfiles = Administracion.;

            //if (usuarioPerfiles.Contains("ADMINISTRADOR"))
                return true;
            return false;
        }

        protected void GVEmpleados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    var empleado = LogicaNegocio.Administracion.ObtenerEmpleado(Convert.ToString(e.Row.Cells[0].Text)).GetAwaiter().GetResult();
                    if (empleado != null)
                    {
                        //Habilitacion de Editar Variable
                        if (true)
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnEditarEmpleado");
                            button.Visible = true;
                        }
                        if (true)
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnEliminarEmpleado");
                            button.Visible = true;

                            button = (LinkButton)e.Row.FindControl("LnkBtnEliminarEmpleado");
                            button.OnClientClick = "javascript:return msgConfirmar('',this.href, 'Desea Eliminar al Empleado " + empleado.IdUsuario.ToString() + "','Confirmación', 'Si','No');";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string idUsuario="";
                if (!e.CommandName.Equals("Page")) 
                {
                    using (var row = (GridViewRow)((System.Web.UI.Control)e.CommandSource).NamingContainer)
                    {
                        idUsuario = Convert.ToString(row.Cells[0].Text);
                    }
                }
                switch (e.CommandName)
                {
                    case "EDITAR_EMPLEADO":
                        Response.Redirect("./Frm_Editar_Empleado.aspx?idUsuario=" + idUsuario);
                        break;
                    case "ELIMINAR_EMPLEADO":
                        LogicaNegocio.Administracion.EliminarEmpleado(idUsuario).GetAwaiter().GetResult();
                        Response.Redirect("./Frm_Consulta_Empleados.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}