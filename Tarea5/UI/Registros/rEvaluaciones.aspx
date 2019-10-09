<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rEvaluaciones.aspx.cs" Inherits="Tarea5.UI.Registros.Evaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Evaluacion</div>
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
                                    <asp:Label ID="Label4" runat="server" Text="Estudiante"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="EstudianteDropDownList" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                            </div>
                        </div>
                         <div class="form-row">
                            <div class="form-group col-md-4">
                                    <asp:Label ID="Label3" runat="server" Text="Categoria"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="CategoriaDropDownList" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                             <div class="form-group col-md-2">
                                <asp:Label ID="Label2" runat="server" Text="Valor"></asp:Label>
                                <asp:TextBox class="form-control" ID="ValorTextBox" runat="server" AutoPostBack="true" Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValorREV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ValorTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                             </div>
                             &nbsp;&nbsp;
                             <div class="form-group col-md-2">
                                <asp:Label ID="Label5" runat="server" Text="Logrado"></asp:Label>
                                <asp:TextBox class="form-control" ID="LogradoTextBox" runat="server" AutoPostBack="true" Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LogradoREV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="LogradoTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                             </div>
                             <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="agregarLinkButton" CssClass="btn btn-dark mt-4" runat="server" OnClick="agregarLinkButton_Click">
                                <span class="fas fa-search"></span>Agregar
                                </asp:LinkButton>
                            </div>
                        </div>

                         <div class="table-responsive">
                            <hr>
                            <div class="col-md-12 col-md-offset-3">
                                <div class="container">
                                    <div class="form-group">
                                        <asp:Label ID="criterioLabel" runat="server" Text="Detalle" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                                        <div class="form-row justify-content-center">
                                            <asp:GridView ID="detalleGridView" runat="server" class="table table-condensed table-bordered table-responsive"
                                                 CellPadding="8" AllowPaging="True" PageSize="7" ForeColor="Black" GridLines="None"
                                                BackColor="White" OnRowCommand="detalleGridView_RowCommand" OnPageIndexChanging="detalleGridView_PageIndexChanging">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:Button ID="removerLinkButton" class="btn btn-danger btn-sm" runat="server" CausesValidation="False" CommandName="Select" CommandArgument="<%#((GridViewRow) Container).DataItemIndex %>" Text="Remover" ></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <HeaderStyle BackColor="#009900" Font-Bold="True" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr>
                        </div>
                                    <asp:UpdatePanel ID="EvaluacionUP" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-row">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-1">
                                <asp:Label ID="Label11" runat="server" Text="Total Perdido"></asp:Label>
                            </div>

                                    <div class="col-lg-1 p-0">
                                        <asp:TextBox class="form-control" ID="TotalPerdidoTextBox" Text="0" ReadOnly="true" runat="server" Width="180px"></asp:TextBox>
                                    </div>
                                </div>
                               
                            </ContentTemplate>
                        </asp:UpdatePanel>

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
