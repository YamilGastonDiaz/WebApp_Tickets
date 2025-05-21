<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilAdmin.aspx.cs" Inherits="WebApp_Tickets.PerfilAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-5 pb-5">
        <section class="row d-flex">
            <!--Inicio titulo-->
            <article class="col-12 text-center mb-4 order-1">
                <h1><i>PANEL ADMIN</i></h1>
            </article>
            <!--Fin titulo-->

            <!--Inicio Panel-->
            <article class="col-md-3 order-3 order-md-2 order-lg-2">
                <!-- Lista menú -->
                <div class="row mt-4">
                    <div class="col-12">
                        <div class="list-group">
                            <!-- Los enlaces activan las vistas -->
                            <asp:LinkButton ID="lnkEditarCuenta" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarEditarCuentaAdmin">
                                <i class="bi bi-person-fill-gear"></i> Editar Cuenta
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkCambiarContrasena" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarCambiarContraseniaAdmin">
                                <i class="bi bi-unlock-fill"></i> Cambiar Contraseña
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkUsuarios" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarUsuarios">
                                <i class="bi bi-people-fill"></i> Usuarios
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkEventos" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarEventos">
                               <i class="bi bi-calendar-event"></i> Eventos
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkEstadisticas" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarEstadisticas">
                                <i class="bi bi-graph-up-arrow"></i> Estadisticas
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
                                    <asp:TextBox runat="server" ID="txtNombreAdmin" CssClass="form-control" placeholder="Nombre" />
                                    <asp:Label ID="lbl_NombreAdmin" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtApellidoAdmin" CssClass="form-control" placeholder="Apellido" />
                                    <asp:Label ID="lbl_ApellidoAdmin" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtDniAdmin" CssClass="form-control" placeholder="Numero de Dni" />
                                    <asp:Label ID="lbl_DniUSer" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtEmailAdmin" CssClass="form-control" placeholder="Email" />
                                    <asp:Label ID="lbl_EmailUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtTelefonoAdmin" CssClass="form-control" placeholder="Telefono" />
                                    <asp:Label ID="lbl_TelAdmin" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtCalendarioFnAdmin" CssClass="form-control" TextMode="Date" placeholder="Fecha" />
                                    <asp:Label ID="lbl_FnAdmin" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3 text-center">
                                    <asp:Button ID="ModificarAdmin_btn" runat="server" Text="Modificar" class="btn btn-primary col-12" OnClick="ModificarAdminBtn" />
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
                                    <asp:TextBox runat="server" ID="txtPassAdmin" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />
                                    <asp:Label ID="lbl_PassUser" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtxPassNuevoAdmin" CssClass="form-control" placeholder="Contraseña Nueva" TextMode="Password" />
                                    <asp:Label ID="lbl_PassNuevo" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="mb-3 text-center">
                                    <asp:Button ID="btn_ModificarPass" runat="server" Text="Modificar Contraseña" class="btn btn-primary col-12" OnClick="ModificarPassAdminBtn" />
                                </div>
                            </div>
                        </div>
                    </asp:View>

                    <asp:View ID="ViewUsuarios" runat="server">
                        <h3 class="text-center">Usuarios</h3>
                        <div class="row justify-content-center">
                            <div class="col-12 table-fija">
                                <asp:GridView ID="GridViewUsuarios" CssClass="table table-striped table-bordered" DataKeyNames="idUser" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nombre" DataField="name" />
                                        <asp:BoundField HeaderText="Apellido" DataField="lastname" />
                                        <asp:BoundField HeaderText="Dni" DataField="dni" />
                                        <asp:BoundField HeaderText="Email" DataField="email" />
                                        <asp:BoundField HeaderText="Fecha Nacimiento" DataField="birthdate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Telefono" DataField="numerphone" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:View>

                    <asp:View ID="ViewEventos" runat="server">
                        <h3 class="text-center">Eventos</h3>
                        <div class="row justify-content-center">
                            <div class="col-12 table-fija">
                                <asp:GridView ID="GridViewEventos" CssClass="table table-striped table-bordered" DataKeyNames="id" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="id" />
                                        <asp:BoundField HeaderText="Nombre" DataField="name" />
                                        <asp:BoundField HeaderText="Descripcion" DataField="description" />
                                        <asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                                        <asp:BoundField HeaderText="Lugar" DataField="locale" />
                                        <asp:BoundField HeaderText="Direccion" DataField="direction" />
                                        <asp:BoundField HeaderText="Total Ticket" DataField="totalTickt" />
                                        <asp:BoundField HeaderText="Precio" DataField="price" />
                                        <asp:BoundField HeaderText="Imagen" DataField="image" />

                                        <asp:TemplateField HeaderText="Modificar">
                                            <ItemTemplate>
                                                 <asp:Button ID="EditarEvento" runat="server" CssClass="btn btn-secondary" Text="Modificar" CommandArgument='<%# Eval("ID") %>' OnClick="ModificarEvento" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:Button ID="Eliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" CommandArgument='<%# Eval("ID") %>' OnClick="EliminarEvento" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-12 m-3">
                                <asp:Button ID="AgregarEvento" runat="server" CssClass="btn btn-primary col-3" Text="Crear Evento" OnClick="CrearEvento" />    
                            </div>
                        </div>
                    </asp:View>

                    <asp:View ID="ViewEstadisticas" runat="server">
                        <h3 class="text-center">Estadisticas</h3>
                        <div class="row justify-content-center">
                            <div class="col-8">
                            </div>
                        </div>
                    </asp:View>

                </asp:MultiView>
            </article>
            <!--Fin Panel-->
        </section>
    </div>
</asp:Content>
