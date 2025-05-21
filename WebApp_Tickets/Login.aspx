<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp_Tickets.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/Style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-4">
        <section class="row justify-content-center">
            <!--principio tiltulo-->
            <article class="col-12 text-center mb-4">
                <h1><i>LOGIN</i></h1>
            </article>
            <!--fin titulo-->

            <!--principio form login-->
            <article class="col-sm-12 col-md-6 col-lg-6">
                <div class="mb-4">                    
                    <asp:TextBox runat="server" ID="txt_Email" CssClass="form-control" placeholder="Email" TextMode="Email" />
                    <asp:Label ID="lbl_UsuarioError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-4">                    
                    <asp:TextBox runat="server" ID="txt_Pass" CssClass="form-control" placeholder="Contaseña" TextMode="Password" />
                    <asp:Label ID="lbl_PassError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="text-center mb-4">
                    <a href="#">¿Olvidaste tu contraseña?</a>
                </div>

                <div class="mb-4 text-center">
                    <asp:Button ID="btn_login" runat="server" Text="Entrar" class="btn btn-primary col-12" OnClick="Ingresar_btn" />
                </div>

                <div id="CrearCuenta" class="text-center mb-4">
                    <a href="Registro.aspx">¿No tienes cuenta? Regístrate</a>
                </div>
            </article>
        </section>
        <!--fin form login-->
       
    </div>
</asp:Content>
