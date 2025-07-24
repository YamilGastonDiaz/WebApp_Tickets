<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebApp_Tickets.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-4">
        <section class="row justify-content-center">
            <!--principio tiltulo-->
            <article class="col-12 text-center mb-4">
                <h1><i>Contacto</i></h1>
            </article>
            <!--fin titulo-->

            <!--principio contacto -->
            <article class="col-12 col-md-6 col-lg-6">

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Nombre" />
                    <asp:Label ID="lbl_Nombre" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email" />
                    <asp:Label ID="lbl_Email" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtMensaje" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Escribe tu mensaje aquí..." />
                    <asp:Label ID="lbl_Mensaje" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3 text-center">
                    <asp:Button ID="btn_contacto" runat="server" Text="Enviar" class="btn btn-primary col-12" OnClick="btn_Contacto" />
                </div>

                <asp:Label ID="lblConfirmacion" runat="server" Text="" ForeColor="Green" Visible="false" />
            </article>
            <!--fin contacto -->
        </section>
    </div>
</asp:Content>
