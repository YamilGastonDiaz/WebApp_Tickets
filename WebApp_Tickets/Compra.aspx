<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="WebApp_Tickets.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/Style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <!--principio tiltulo-->
        <section class="row">
            <article class="col-12 text-center mb-3">
                <h1><i>COMPRA TUS ENTRADAS</i></h1>
            </article>
        </section>
        <!--fin titulo-->

        <!--principio tiltulo del evento-->
        <section class="row">
            <asp:Repeater ID="rpt_Name" runat="server">
                <ItemTemplate>
                    <h2 class="ms-3"><i><%# Eval("name") %></i></h2>
                </ItemTemplate>
            </asp:Repeater>
        </section>
        <!--fin titulo del evento-->

        <!--principio hora y fecha del evento-->
        <section class="row">
            <div calss="container">
                <div class="bg-color p-1 m-3 text-center fs-6 border rounded-5">
                    <asp:Repeater ID="rpt_Hora" runat="server">
                        <ItemTemplate>
                            <div class="col-12 pt-2 pb-2 evento-h">
                                <span><i class="bi bi-clock"></i></span>
                                <span style="font-size: 16px; padding-top: 2px; font-weight: bold;">
                                    <%# Eval("fecha", "{0:dddd}") %>
                                    <%# Eval("fecha", "{0:dd}") %> de
                                    <%# Eval("fecha", "{0:MMMM}") %> a las
                                    <%# Eval("fecha", "{0:HH:mm}") %>
                                </span>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
        <!--fin hora y fecha del evento-->

        <section class="row">
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="container d-flex flex-lg-row flex-md-row flex-column">
                        <!--inicio columna izq-->
                        <div class="col-12 col-md-6 col-lg-6 bg-color p-2 m-1 border">
                            <p class="fs-5">Entrada General</p>
                            <hr />
                            <div>
                                <asp:Button ID="decremento" runat="server" Text="-" OnClick="Decrementar_Click" />
                                <asp:Label ID="lbl_Contar" runat="server" Text="0"></asp:Label>
                                <asp:Button ID="incremento" runat="server" Text="+" OnClick="Incrementar_Click" />
                            </div>
                            <div>
                                <asp:Repeater ID="rpt_Price" runat="server">
                                    <ItemTemplate>
                                        <br />
                                        <p>
                                            PRECIO ENTRADA:
                                                <br />
                                            <asp:Label ID="pricieEvento" runat="server" CssClass="pricieEvento fs-3 bold" Text='<%# Eval("price", "{0:F2}")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!--fin columna izq-->

                        <!--principio columna derecha-->

                        <div class="col-12 col-md-6 col-lg-6 bg-color p-2 m-1 border">
                            <p class="fs-5">Resumen de compra</p>
                            <hr />
                            <p>
                                Precio ticket:
                                    <asp:Label ID="lbl_TicketPrecio" runat="server" Text="$0.00"></asp:Label>
                            </p>
                            <p>
                                Cantidad de tickets:
                                    <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                            </p>
                            <hr />
                            <p>
                                TOTAL:
                                    <asp:Label ID="lbl_Total" runat="server" Text="$0.00"></asp:Label>
                            </p>
                        </div>
                        <!--fin columna derecha-->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!--principio btn compra-->
            <div class="container d-flex flex-lg-colum flex-md-colum flex-column">
                <div class="form-check mt-3">
                    <asp:CheckBox ID="checkCondiciones" class="form-check-label" runat="server" />
                    <label for="check_TC" class="form-check-label">Acepto los <a class="color-tyc" href="#">términos y condiciones</a>.</label>
                </div>
                <asp:Label runat="server" ID="lbl_Chek" Text="" CssClass="ms-4 p-1" Visible="false" ForeColor="Red" />
                <br />

                <div class="d-grid m-3">
                    <asp:Button ID="btn_Comprar" runat="server" Text="PAGAR" CssClass="btn btn-mercado btn-primary col-12 col-md-4 col-lg-4 " OnClick="Pagar_click" />
                </div>
              
            </div>
            <p class="fs-5 text-center">*El máximo permitido por compra es de 5 entradas. Si desea adquirir más, por favor repita  la operación.</p>
            <!--fin btn compra-->
        </section>

    </div>
</asp:Content>
