<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilUser.aspx.cs" Inherits="WebApp_Tickets.PerfilUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mb-5 pb-5">
        <section class="row d-flex">
            <!--Inicio titulo-->
            <article class="col-12 text-center mb-4 order-1">
                <h1><i>PANEL USUARIO</i></h1>
            </article>
            <!--Fin titulo-->

            <!--Inicio Panel-->
            <article class="col-md-3 order-3 order-md-2 order-lg-2">
                <!-- Lista menú -->
                <div class="row mt-4">
                    <div class="col-12">
                        <div class="list-group">
                            <!-- Los enlaces activan las vistas -->
                            <asp:LinkButton ID="lnkEditarCuenta" runat="server" CssClass="list-group-item list-group-item-dark">
                                 <i class="bi bi-person-fill-gear"></i> Editar Cuenta
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkCambiarContrasena" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarCambiarContrasenia">
                                 <i class="bi bi-unlock-fill"></i> Cambiar Contraseña
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkEliminarCuenta" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarEliminarCuenta">
                                 <i class="bi bi-trash-fill"></i> Eliminar Cuenta
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </article>

            <article class="col-md-9 order-2 order-md-3 order-lg-3">
                <!-- Paneles de contenido dinámico -->
                <asp:MultiView ID="MultiViewUser" runat="server" ActiveViewIndex="0">

                    <!-- Vista de Editar Cuenta -->
                    <asp:View ID="ViewEditarCuenta" runat="server">
                        <h3 class="text-center">Editar Cuenta</h3>
                        <div class="row justify-content-center">
                            <div class="col-8">
                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtNombreUser" CssClass="form-control" placeholder="Nombre" />
                                    <asp:Label ID="lbl_NombreUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtApellidoUser" CssClass="form-control" placeholder="Apellido" />
                                    <asp:Label ID="lbl_ApellidoUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtDniUser" CssClass="form-control" placeholder="Numero de Dni" />
                                    <asp:Label ID="lbl_DniUSer" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtEmailUser" CssClass="form-control" placeholder="Email" />
                                    <asp:Label ID="lbl_EmailUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtTelefonoUser" CssClass="form-control" placeholder="Telefono" />
                                    <asp:Label ID="lbl_TelUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtCalendarioFnUser" CssClass="form-control" TextMode="Date" placeholder="Fecha" />
                                    <asp:Label ID="lbl_FnUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3 text-center">
                                    <asp:Button ID="Button1" runat="server" Text="Modificar" class="btn btn-primary col-12" OnClick="Modificar_btn" OnClientClick="return confirm('¿Estás seguro de que deseas modificar tus datos?');" />
                                </div>
                            </div>
                        </div>
                    </asp:View>

                    <!-- Vista de Cambiar Contraseña -->
                    <asp:View ID="ViewCambiarContrasena" runat="server">
                        <h3 class="text-center">Cambiar Contraseña</h3>
                        <div class="row justify-content-center">
                            <div class="col-8">
                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtPassUser" CssClass="form-control" placeholder="Contraseña Nueva" TextMode="Password" />
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtPassNuevo" CssClass="form-control" placeholder="Contraseña Nueva" TextMode="Password" />
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="lblMensajePassword" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3 text-center">
                                    <asp:Button ID="btn_ModificarPass" runat="server" Text="Modificar Contraseña" class="btn btn-primary col-12" OnClick="ModificarPass_btn" />
                                </div>
                            </div>
                        </div>
                    </asp:View>

                    <!-- Nueva Vista de Eliminar Cuenta -->
                    <asp:View ID="ViewEliminarCuenta" runat="server">
                        <h3 class="text-center">Eliminar Cuenta</h3>
                        <p class="text-center fs-5">
                            Esta acción es irreversible. Si eliminas tu cuenta, perderás toda la información asociada.
                        </p>
                        <div class="d-grid col-6 mx-auto">
                            <asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-danger" OnClick="ClickEliminarUser" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar tu cuenta?');" />
                        </div>
                    </asp:View>

                </asp:MultiView>
            </article>
            <!--Fin Panel-->
        </section>
    </div>

</asp:Content>
