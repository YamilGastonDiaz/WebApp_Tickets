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
                                    <asp:Button ID="ModificarAdmin_btn" runat="server" Text="Modificar" class="btn btn-primary col-12" OnClick="ModificarAdminBtn" OnClientClick="return confirm('¿Estás seguro de que deseas modificar tus datos?');" />
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
                                    <asp:TextBox runat="server" ID="txtPassAdmin" CssClass="form-control" placeholder="Contraseña Nueva" TextMode="Password" />
                                </div>

                                <div class="mb-3">
                                    <asp:TextBox runat="server" ID="txtPassNuevoAdmin" CssClass="form-control" placeholder="Contraseña Nueva" TextMode="Password" />
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="lblMensajePassword" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
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
                                                <asp:Button ID="Eliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" CommandArgument='<%# Eval("ID") %>' OnClick="EliminarEvento" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este evento?');" />
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
                            <div class="container mt-4">
                                <!-- Tarjetas con información -->
                                <section class="row">
                                    <!-- Total usuarios activos -->
                                    <article class="col-md-4">
                                        <div class="card text-bg-primary mb-3">
                                            <div class="card-header">Usuarios activos</div>
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <asp:Label ID="lblUsuariosActivos" runat="server" CssClass="fw-bold fs-4" />
                                                </h5>
                                                <p class="card-text">Cantidad de usuarios registrados actualmente.</p>
                                            </div>
                                        </div>
                                    </article>

                                    <!-- Recaudación total -->
                                    <article class="col-md-4">
                                        <div class="card text-bg-success mb-3">
                                            <div class="card-header">Recaudación total</div>
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                     <asp:Label ID="lblRecaudacionTotal" runat="server" CssClass="fw-bold fs-4" />
                                                </h5>
                                                <p class="card-text">Monto total recaudado en todos los eventos.</p>
                                            </div>
                                        </div>
                                    </article>

                                    <!-- Usuarios dados de baja -->
                                    <article class="col-md-4">
                                        <div class="card text-bg-danger mb-3">
                                            <div class="card-header">Usuarios dados de baja</div>
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <asp:Label ID="lblUsuariosBaja" runat="server" CssClass="fw-bold fs-4" />
                                                </h5>
                                                <p class="card-text">Usuarios que dieron de baja su cuenta.</p>
                                            </div>
                                        </div>
                                    </article>
                                </section>

                                <h4 class="m-3"><i>Recaudacion</i></h4>

                                <div class="mb-3 d-flex">
                                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control form-control-lg me-2 rounded-pill" placeholder="Ingrese el año Ej: 2025" />
                                    <asp:Button ID="btnFiltrarAnio" runat="server" Text="Filtrar" CssClass="btn btn-secondary mt-2" OnClick="FiltrarAnio" />
                                </div>

                                <!-- Gráficos -->
                                <div class="row">
                                    <div class="col-12">
                                        <div class="card">
                                            <div class="card-header">Recaudacion mensual</div>
                                            <div class="card-body">
                                                <canvas id="barChart"></canvas>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <h4 class="m-3"><i>Ranking Eventos</i></h4> <!--Eventos con más demanda-->
                            <div class="col-12 table-fija">
                                <asp:GridView ID="GridViewRankingEventos" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="nombreEvento" HeaderText="Eventos" />
                                        <asp:BoundField DataField="entradasVendidas" HeaderText="Entradas Vendidas" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                            <h4 class="m-3"><i>Ranking Usuarios</i></h4> <!--(útil para campañas de fidelización).-->

                            <div class="col-12 table-fija">
                                <asp:GridView ID="GridViewRankingUsuarios" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="nombreUsuario" HeaderText="Usuarios" />
                                        <asp:BoundField DataField="entradasCompradas" HeaderText="Entradas Compradas" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <h4 class="m-3"><i>Detalle por Evento</i></h4>

                            <div class="d-flex p-2">
                                <asp:TextBox ID="txtEventoBuscar" runat="server" CssClass="form-control form-control-lg me-2 rounded-pill" placeholder="Ingrese nombre del evento" />
                                <asp:Button ID="btnBuscarEvento" runat="server" Text="Buscar" CssClass="btn btn-secondary mt-2" OnClick="BuscarEvento" />
                            </div>

                            <div class="col-12 table-fija">
                            <asp:GridView ID="GridViewDetalleEvento" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="totalEntradas" HeaderText="Total Entradas" />
                                    <asp:BoundField DataField="entradasVendidas" HeaderText="Vendidas" />
                                    <asp:BoundField DataField="entradasNoVendidas" HeaderText="No Vendidas" />
                                    <asp:BoundField DataField="recaudacion" HeaderText="Recaudación" DataFormatString="${0:N2}" />
                                </Columns>
                            </asp:GridView>
                            </div>

                            <asp:Literal ID="litDatosRecaudacion" runat="server" EnableViewState="false" />
                            <!-- Script para gráficos con Chart.js -->
                            <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
                            <script>
                                // Gráfico de Barras
                                var ctxBar = document.getElementById('barChart').getContext('2d');

                                var datos = typeof datosRecaudacion !== 'undefined' ? datosRecaudacion : [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

                                var barChart = new Chart(ctxBar, {
                                    type: 'bar',
                                    data: {
                                        labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Nobiembre', 'Diciembre'],
                                        datasets: [{
                                            label: 'Recaudación mensual ($)',
                                            data: datos,
                                            backgroundColor: 'rgba(54, 162, 235, 0.5)',
                                            borderColor: 'rgba(54, 162, 235, 1)',
                                            borderWidth: 1
                                        }]
                                    },
                                    options: {
                                        responsive: true,
                                        scales: {
                                            y: {
                                                beginAtZero: true
                                            }
                                        }
                                    }
                                });
                            </script>
                        </div>
                    </asp:View>

                </asp:MultiView>
            </article>
            <!--Fin Panel-->
        </section>
    </div>
</asp:Content>
