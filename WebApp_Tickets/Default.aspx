﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_Tickets.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--pricipio baner-->

    <div class="container">
        <!--
        <section class="row pb-5">
            <div id="carouselExample" class="col-12 carousel slide">
                <div class="carousel-inner">
                    <asp:Repeater ID="rpt_Banner" runat="server">
                        <ItemTemplate>
                            <div class='carousel-item  <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                <img class="d-block w-100 h-10" src='<%# ResolveUrl("~/Img/ImgEvento/" + Eval("image")) %>' alt="...">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <button
                    class="carousel-control-prev"
                    type="button"
                    data-bs-target="#carouselExample"
                    data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button
                    class="carousel-control-next"
                    type="button"
                    data-bs-target="#carouselExample"
                    data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </section>
        -->

        <!--pricipio buscar-->
        <section class="row mb-5">
            <article class="col-12">
                <input class="form-control form-control-lg me-2 rounded-pill" type="search" placeholder="Buscar" aria-label="Search">
            </article>
        </section>
        <!--fin buscar-->

        <!--principio tiltulo-->
        <section class="row">
            <article class="col-12">
                <h2>Todos los eventos en <b>Tu Marca</b></h2>
                <hr />
            </article>
        </section>
        <!--fin titulo-->

        <!--pricipio card-->
        <section class="row align-items-lg-center min-vh-100">
            <asp:Repeater ID="rpt_Eventos" runat="server">
                <ItemTemplate>
                    <article class="col-12 col-md-6 col-lg-3 d-flex">
                        <div class="card mx-auto mb-3" style="width: 18rem;">
                            <img src='<%# ResolveUrl("~/Img/ImgEvento/" + Eval("image")) %>' class="card-img-top" alt="...">
                            <div class="card-body bg-color">
                                <span>show</span>
                                <h4 class="card-title"><b><%# Eval("name") %></b></h4>
                                <span class="mb-1">
                                    <b>
                                        <%# Eval("fecha", "{0:dd}") %> de
                                        <%# Eval("fecha", "{0:MMMM}") %> /
                                        <%# Eval("fecha", "{0:HH:mm}") %>
                                    </b>
                                </span>
                                <a href="#" class="text-card-color btn btn-primary color-link" data-bs-toggle="modal" data-bs-target="#eventoModal<%# Eval("id") %>">Ver detalles</a>
                            </div>
                        </div>
                    </article>

                    <!--principio modal-->
                    <div class="modal fade" id="eventoModal<%# Eval("id") %>" tabindex="-1" aria-labelledby="eventoModalLabel<%# Eval("id") %>" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title fs-2" id="exampleModalLabel"><b><%# Eval("name") %></b></h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body bg-color">
                                    <img src='<%# ResolveUrl("~/Img/ImgEvento/" + Eval("image")) %>' alt="Commerce AI" class="img-fluid">
                                    <span><b>DESCRIPCION:</b></span>
                                    <p class="fs-5"><%# Eval("description") %></p>
                                    <span><b>LUGAR:</b></span>
                                    <p class="fs-5"><%# Eval("locale") %></p>
                                    <span><b>DIRECCION:</b></span>
                                    <p class="fs-5"><%# Eval("direction") %></p>
                                    <span><b>FECHA Y HORA:</b></span>
                                    <p class="fs-5">
                                        <%# Eval("fecha", "{0:dddd}") %>
                                        <%# Eval("fecha", "{0:dd}") %> de
                                        <%# Eval("fecha", "{0:MMMM}") %> a las
                                        <%# Eval("fecha", "{0:HH:mm}") %>
                                    </p>
                                    <span><b>PRECIO ENTRADA:</b></span>
                                    <p class="fs-5">$ <%# Eval("price", "{0:F2}") %></p>

                                    <!--principio boton-->
                                    <div class="d-grid gap-2">
                                        <asp:Button ID="btn_Comprar" runat="server" class="btn btn-primary" Text="Obtene tus entradas" CommandArgument='<%# Eval("id") %>' CommandName="EventoId" OnClick="IrCompraClick" />
                                    </div>
                                    <!--fin boton-->
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--fin modal-->

                </ItemTemplate>
            </asp:Repeater>
        </section>
        <!--fin card-->
    </div>


</asp:Content>
