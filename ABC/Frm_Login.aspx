<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Frm_Login.aspx.cs" Inherits="ABC.Frm_Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPnlPpal" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <div class="bg-light container-fluid">
                <div class="row justify-content-center">
                    <div class="col-10 col-sm-9 col-md-7 col-lg-4 col-xl-4">
                        <div class="card mt-5">
                            <div class="card-body">
                                <div class="form-group mt-3">
                                    <asp:TextBox ID="TxtEmpleado" runat="server" PlaceHolder="Empleado" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqValTxtUsuario" runat="server"
                                        ControlToValidate="TxtEmpleado" Display="Dynamic" EnableClientScript="False"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="TxtContrasena" runat="server" PlaceHolder="Contraseña" Text="" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqValTxtContrasena" runat="server"
                                        ControlToValidate="TxtContrasena" Display="Dynamic" EnableClientScript="False"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="BtnIngresar" runat="server" Style="padding: 5px; font-size: 1em;"
                                        class="btn btn-primary btn-block" Text="Ingresar" OnClick="BtnIngresar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>