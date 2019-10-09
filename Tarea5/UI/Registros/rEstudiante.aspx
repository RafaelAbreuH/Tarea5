<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rEstudiante.aspx.cs" Inherits="Tarea5.UI.Registros.rEstudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Estudiantes</div>
                <article class="card-body">
                    <form>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                                <asp:TextBox class="form-control" ID="IdTextBox" Text="0" type="number" runat="server" Width="110px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="IdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="IdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-6 p-0">
                                <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                                <span class="fas fa-search"></span>Buscar
                                </asp:LinkButton>
                            </div>
                        </div>
                         <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="FechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Nombre Estudiante"></asp:Label>
                                    <asp:TextBox class="form-control" ID="EstudianteTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EstudianteRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="EstudianteTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="EstudianteREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="EstudianteTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Puntos Perdidos"></asp:Label>
                                    <asp:TextBox class="form-control" ID="PuntosPerdidosTextBox" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button class="btn btn-primary btn-sm" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
                                    <asp:Button class="btn btn-success btn-sm" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click" ValidationGroup="Guardar" />
                                    <asp:Button class="btn btn-danger btn-sm" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click" />
                                </div>
                            </div>
                        </div>

                    </form>
                </article>
            </div>
     </aside>
    </div>
    <br>
</asp:Content>
