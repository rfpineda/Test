using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ABC
{
    public partial class Frm_Consulta_Facturas : System.Web.UI.Page
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
                        MessageBox.Show("No tiene perfil para consulta de Facturas.");
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
                    List<Factura> facturas;

                    facturas = LogicaNegocio.Facturacion.ListarFacturas().GetAwaiter().GetResult().FindAll(x => x.IdFactura == Convert.ToInt32(TxtIdFactura.Text));
                    GVFacturas.DataSource = facturas;
                    GVFacturas.DataBind();
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

        protected void GVFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    var factura = LogicaNegocio.Facturacion.ObtenerFactura(Convert.ToInt32(e.Row.Cells[0].Text)).GetAwaiter().GetResult();
                    var usuarioPerfiles = LogicaNegocio.Administracion.ListarEmpleadoPerfil().GetAwaiter().GetResult().FindAll(x => x.Empleado.IdUsuario.Equals(Empleado.IdUsuario));

                    if (factura != null)
                    {
                        if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("ADMINISTRADOR") || x.Perfil.Codigo.Contains("PARTICIPANTE")))
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnEditarFactura");
                            button.Visible = true;
                        }
                        if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("ADMINISTRADOR")))
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnEliminarFactura");
                            button.Visible = true;

                            button = (LinkButton)e.Row.FindControl("LnkBtnEliminarFactura");
                            button.OnClientClick = "javascript:return msgConfirmar('',this.href, 'Desea Eliminar la Factura " + factura.IdFactura.ToString() + "','Confirmación', 'Si','No');";
                        }
                        if (usuarioPerfiles.Any(x => x.Perfil.Codigo.Contains("ADMINISTRADOR") || x.Perfil.Codigo.Contains("PARTICIPANTE")))
                        {
                            var button = (LinkButton)e.Row.FindControl("LnkBtnVerFactura");
                            button.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVFacturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idFactura=0;
                if (!e.CommandName.Equals("Page")) 
                {
                    using (var row = (GridViewRow)((System.Web.UI.Control)e.CommandSource).NamingContainer)
                    {
                        idFactura = Convert.ToInt32(row.Cells[0].Text);
                    }
                }
                switch (e.CommandName)
                {
                    case "EDITAR_FACTURA":
                        Response.Redirect("./Frm_Editar_Factura.aspx?idFactura=" + idFactura);
                        break;
                    case "ELIMINAR_FACTURA":
                        LogicaNegocio.Facturacion.EliminarFactura(idFactura).GetAwaiter().GetResult();
                        Response.Redirect("./Frm_Consulta_Facturas.aspx");
                        break;
                    case "VER_FACTURA":
                        Response.Redirect("./Frm_Ver_Factura.aspx?idFactura=" + idFactura);
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
            Response.Redirect("./Frm_Crear_Factura.aspx");            
        }

        protected void BtnExportar_Click(object sender, EventArgs e)
        {
            var serializer = new XmlSerializer(typeof(List<Factura>),
                                    new XmlRootAttribute("Branches"));
            using (var stream = new StringWriter())
            {
                serializer.Serialize(stream, LogicaNegocio.Facturacion.ListarFacturas().GetAwaiter().GetResult().FindAll(x => x.IdFactura == Convert.ToInt32(TxtIdFactura.Text)));
                string attachment = "attachment; filename=test.xml";
                Response.ClearContent();
                Response.ContentType = "application/xml";
                Response.AddHeader("content-disposition", attachment);
                Response.Write(stream);
                Response.End();
            }

        }
    }
}