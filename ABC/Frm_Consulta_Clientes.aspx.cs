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
    public partial class Frm_Consulta_Clientes : System.Web.UI.Page
    {

        public Empleado Empleado => (Empleado)HttpContext.Current.Session["EMPLEADO"];

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["EMPLEADO"] == null)
                    { 
                        Response.Redirect("./Frm_Login.aspx");
                    }
                    if (!EsPerfilValido())
                    {
                        MessageBox.Show("No tiene perfil para consulta de Clientes.");
                        Response.Redirect("./Frm_Login.aspx");
                    }
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
                    List<Cliente> clientes;

                    clientes = LogicaNegocio.Administracion.ListarClientes().GetAwaiter().GetResult().FindAll(x => x.Nombre.Contains(TxtNombre.Text));
                    GVClientes.DataSource = clientes;
                    GVClientes.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool EsPerfilValido()
        {
            var usuarioPerfiles = LogicaNegocio.Administracion.ListarEmpleadoPerfil().GetAwaiter().GetResult().FindAll(x => x.Empleado.IdUsuario.Equals(Empleado.IdUsuario));

            if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("ADMINISTRADOR")))
            {
                BtnCrear.Visible = true;
                return true;
            }
            else if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("PARTICIPANTE")))
            {
                return true;
            }
            return false; 
        }

        protected void GVClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    var cliente = LogicaNegocio.Administracion.ObtenerCliente(Convert.ToString(e.Row.Cells[0].Text)).GetAwaiter().GetResult();
                    var usuarioPerfiles = LogicaNegocio.Administracion.ListarEmpleadoPerfil().GetAwaiter().GetResult().FindAll(x => x.Empleado.IdUsuario.Equals(Empleado.IdUsuario));

                    if (cliente != null)
                    {
                        if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("ADMINISTRADOR")))
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnEditarCliente");
                            button.Visible = true;
                        }
                        if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("ADMINISTRADOR")))
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnEliminarCliente");
                            button.Visible = true;

                            button = (LinkButton)e.Row.FindControl("LnkBtnEliminarCliente");
                            button.OnClientClick = "javascript:return msgConfirmar('',this.href, 'Desea Eliminar al Cliente " + cliente.Nombre.ToString() + "','Confirmación', 'Si','No');";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idCliente=0;
                if (!e.CommandName.Equals("Page")) 
                {
                    using (var row = (GridViewRow)((System.Web.UI.Control)e.CommandSource).NamingContainer)
                    {
                        idCliente = Convert.ToInt32(row.Cells[0].Text);
                    }
                }
                switch (e.CommandName)
                {
                    case "EDITAR_CLIENTE":
                        Response.Redirect("./Frm_Editar_Empleado.aspx?idUsuario=" + idCliente.ToString());
                        break;
                    case "ELIMINAR_CLIENTE":
                        LogicaNegocio.Administracion.EliminarCliente(idCliente).GetAwaiter().GetResult();
                        Response.Redirect("./Frm_Consulta_Clientes.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Frm_Crear_Cliente.aspx");
        }
    }
}