<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Frm_Consulta_Clientes.aspx.cs" Inherits="ABC.Frm_Consulta_Clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPnlPpal" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <div class="bg-light container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="mb-3">Consulta Clientes</h4>
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
                    <div class="col-md-2">
                        <asp:Button ID="BtnConsultar" runat="server" Style="padding: 5px; font-size: 1em;"
                            class="btn btn-primary btn-block" Text="Consultar" OnClick="BtnConsultar_Click" />
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="BtnCrear" runat="server" Style="padding: 5px; font-size: 1em;"
                            class="btn btn-primary btn-block" Text="Crear" OnClick="BtnCrear_Click" Visible="false" />
                    </div>
                </div>
                <hr class="mb-4">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="GVClientes" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="Sin Clientes para mostrar" OnRowCommand="GVClientes_RowCommand" OnRowDataBound="GVClientes_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="IdCliente" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderText="No."/>
                                <asp:BoundField DataField="Nit" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center" HeaderText="Nit"/>
                                <asp:BoundField DataField="Nombre" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre"/>
                                <asp:BoundField DataField="Descripcion" HeaderStyle-Width="500px" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion"/>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnEditarCliente" runat="server" Text="Editar Cliente" CausesValidation="False" CommandName="EDITAR_CLIENTE" Visible="false">
                                                            <i class="fa fa-pencil">Editar</i>
                                        </asp:LinkButton>         
                                        <asp:LinkButton ID="LnkBtnEliminarCliente" runat="server" Text="Eliminar Cliente" CausesValidation="False" CommandName="ELIMINAR_CLIENTE" Visible="false">
                                                            <i class="fa fa-trash-o">Eliminar</i>
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
