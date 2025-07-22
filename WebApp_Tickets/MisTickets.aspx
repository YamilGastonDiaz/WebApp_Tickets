<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisTickets.aspx.cs" Inherits="WebApp_Tickets.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="row">
            <article class="col-12">
                <h2>Mis Tickets</h2>
                <hr />
            </article>
        </section>

        <section class="row align-items-lg-center">
            <asp:Repeater ID="rpt_Tickets" runat="server">
                <ItemTemplate>
                    <article class="col-12 col-md-6 col-lg-3 d-flex">
                        <div class="card mx-auto mb-3" style="width: 18rem;">
                            <img src='<%# ResolveUrl("~/Img/ImgEvento/" + Eval("EventoImagen")) %>' class="card-img-top" alt="Evento">
                            <div class="card-body bg-color">
                                <span>pdf</span>
                                <h4 class="card-title"><b><%# Eval("EventoNombre") %></b></h4>
                                <a href='<%# ResolveUrl("~/Entradas/PDFs/" + Eval("nameArchivo")) %>' target="_blank" class="btn btn-primary">Ver PDF</a>
                            </div>
                        </div>
                    </article>
                </ItemTemplate>
            </asp:Repeater>
        </section>

    </div>
</asp:Content>
