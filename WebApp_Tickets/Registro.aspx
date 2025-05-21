<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApp_Tickets.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/Style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-4">
        <section class="row justify-content-center">
            <!--principio tiltulo-->
            <article class="col-12 text-center mb-4">
                <h1><i>REGISTRAR CUENTA</i></h1>
            </article>
            <!--fin titulo-->

             <!--principio registro-->
            <article class="col-12 col-md-6 col-lg-6">

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Nombre" />
                    <asp:Label ID="lbl_Nombre" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Apellido" />
                    <asp:Label ID="lbl_Apellido" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" placeholder="Numero de Dni" />
                    <asp:Label ID="lbl_Dni" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email" />
                    <asp:Label ID="lbl_Email" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Telefono" />
                    <asp:Label ID="lbl_Telefono" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
                                
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtCalendarioFN" CssClass="form-control" TextMode="Date" placeholder="Fecha" />
                    <asp:Label ID="lbl_FechaNacimiento" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />
                    <asp:Label ID="lbl_Password" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>               

                <div class="mb-3 text-center">
                    <asp:Button ID="btn_registrar" runat="server" Text="Registrarme" class="btn btn-primary col-12" OnClick="Registro_btn" />
                </div>

            </article>
            <!--fin registro-->
        </section>        
    </div>
</asp:Content>
