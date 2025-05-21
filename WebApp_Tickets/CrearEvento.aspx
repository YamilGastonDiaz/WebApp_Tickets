<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearEvento.aspx.cs" Inherits="WebApp_Tickets.CrearEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/Style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-4">
        <section class="row justify-content-center">
            <!--principio tiltulo-->
            <article class="col-12 text-center mb-4">
                <h1><i>CREAR EVENTO</i></h1>
            </article>
            <!--fin titulo-->

            <!--principio registro-->
            <article class="col-12 col-md-6 col-lg-6">

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Nombre Evento" />
                    <asp:Label ID="lbl_NombreEvento" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Descripcion" TextMode="MultiLine" />
                    <asp:Label ID="lbl_Descripcion" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" placeholder="Fecha y Hora" TextMode="DateTimeLocal" />
                    <asp:Label ID="lbl_Fecha" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtLugar" CssClass="form-control" placeholder="Lugar" />
                    <asp:Label ID="lbl_Lugar" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Direccion" />
                    <asp:Label ID="lbl_Direccion" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtTotalEntrada" CssClass="form-control" placeholder="Total Entradas" />
                    <asp:Label ID="lbl_TotalEntrada" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="Precio" />
                    <asp:Label ID="lbl_Precio" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
                
                <div class="mb-3">
                    <input type="file" id="txtImagen" runat="server" class="form-control"/>
                </div>

                <div class="mb-3 text-center">
                    <asp:Button ID="btn_registrar" runat="server" Text="Crear Evento" class="btn btn-primary col-12"  OnClick="ClickCrearEvento"/>
                </div>

            </article>
            <!--fin registro-->
        </section>
    </div>
</asp:Content>
