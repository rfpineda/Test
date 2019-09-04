<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Frm_Consulta_Facturas.aspx.cs" Inherits="ABC.Frm_Consulta_Facturas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPnlPpal" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <div class="bg-light container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="mb-3">Consulta Facturas</h4>
                        <div class="card" style="width: 18rem;">
                            <div class="card-body">
                                <asp:Literal ID="LtIdFactura" runat="server" Text="Codigo Factura"></asp:Literal>
                                <asp:TextBox ID="TxtIdFactura" runat="server" Width="300px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="BtnConsultar" runat="server" Style="padding: 5px; font-size: 1em;"
                            class="btn btn-primary btn-block" Text="Consultar" OnClick="BtnConsultar_Click" />
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="BtnCrear" runat="server" Style="padding: 5px; font-size: 1em;"
                            class="btn btn-primary btn-block" Text="Crear" OnClick="BtnCrear_Click" Visible="false" />
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="BtnExportar" runat="server" Style="padding: 5px; font-size: 1em;"
                            class="btn btn-primary btn-block" Text="Exportar XML" OnClick="BtnExportar_Click" Visible="false" />
                    </div>
                </div>
                <hr class="mb-4">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="GVFacturas" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="Sin Facturas para mostrar" OnRowCommand="GVFacturas_RowCommand" OnRowDataBound="GVFacturas_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="IdFactrura" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderText="No."/>
                                <asp:BoundField DataField="Cliente.Nombre" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente"/>
                                <asp:BoundField DataField="Empleado.NombreCompleto" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Center" HeaderText="Creador"/>
                                <asp:BoundField DataField="MomentoCreacion" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha de Factura"/>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnEditarFactura" runat="server" Text="Editar Factura" CausesValidation="False" CommandName="EDITAR_FACTURA" Visible="false">
                                                            <i class="fa fa-pencil">Editar</i>
                                        </asp:LinkButton>         
                                        <asp:LinkButton ID="LnkBtnEliminarFactura" runat="server" Text="Eliminar Factura" CausesValidation="False" CommandName="ELIMINAR_FACTURA" Visible="false">
                                                            <i class="fa fa-trash-o">Eliminar</i>
                                        </asp:LinkButton>        
                                        <asp:LinkButton ID="LnkBtnVerFactura" runat="server" Text="Ver Factura" CausesValidation="False" CommandName="VER_FACTURA" Visible="false">
                                                            <i class="fa fa-eye">Ver</i>
                                        </asp:LinkButton> 
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="300px"/>
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
