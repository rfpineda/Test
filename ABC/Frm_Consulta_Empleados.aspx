<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Frm_Consulta_Empleados.aspx.cs" Inherits="ABC.Frm_Consulta_Empleados" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPnlPpal" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <div class="bg-light container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="mb-3">Consulta Empleado</h4>
                        <div class="card" style="width: 18rem;">
                            <div class="card-body">
                                <asp:Literal ID="LtNombre" runat="server" Text="Nombre"></asp:Literal>
                                <asp:TextBox ID="TxtNombre" runat="server" Width="300px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="BtnConsultar" runat="server" Style="padding: 5px; font-size: 1em;"
                            class="btn btn-primary btn-block" Text="Ingresar" OnClick="BtnConsultar_Click" />
                    </div>
                </div>
                <hr class="mb-4">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="GVEmpleados" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="Sin Empleados para mostrar" OnRowCommand="GVEmpleados_RowCommand" OnRowDataBound="GVEmpleados_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="IdUsuario" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario"/>
                                <asp:BoundField DataField="Identificacion" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderText="Identificacion"/>
                                <asp:BoundField DataField="NombreCompleto" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre Completo"/>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnEditarEmpleado" runat="server" Text="Editar Empleado" CausesValidation="False" CommandName="EDITAR_EMPLEADO" Visible="false">
                                                            <i class="fa fa-pencil"></i>
                                        </asp:LinkButton>         
                                        <asp:LinkButton ID="LnkBtnEliminarEmpleado" runat="server" Text="Eliminar Empleado" CausesValidation="False" CommandName="ELIMINAR_EMPLEADO" Visible="false">
                                                            <i class="fa fa-trash-o"></i>
                                        </asp:LinkButton> 
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
