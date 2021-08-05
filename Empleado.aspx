<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="ProyectoReinaMadre.Empleado"   StylesheetTheme="Tema1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="Stylesheet" href="../../CSS/CssEstilo.css" type="text/css" />
    <link href="Recrsos/CSS/EstilosAlertasCore.css" rel="stylesheet" />
    <link href="Recursos/CSS/EstilosAlertasDefault.css" rel="stylesheet" />
    <style type="text/css">
        .header-center {
            text-align:center;
        }
        .auto-style1 {
            width: 571px;
        }
        .auto-style2 {
            padding: 1px;
            text-align: left;
            width: 413px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="page-header">
        <h3>
            CATALOGO EMPLEADOS
        </h3>
            <asp:Button ID="cmdGra" runat="server" Text="Grabar" ToolTip="Grabar datos" OnClick="cmdGra_Click" />
            <asp:Button ID="cmdSta" runat="server" Text="Status" ToolTip="Cambiar status" OnClick="cmdSta_Click" />
            <asp:Button ID="cmdLim" runat="server" Text="Limpiar" ToolTip="Limpiar campos" OnClick="cmdLim_Click" />
            <asp:Button ID="cmdCar" runat="server" Text="Cargar" ToolTip="Cargar empleados" OnClick="cmdCar_Click" />
            <asp:Label  ID="lblInfo" runat="server" Text="" />
    </div>
    <div >
        <fieldset>
            <asp:Panel runat="server"  style="position:relative;"  >
                <asp:Panel runat="server" CssClass="panelColor"></asp:Panel>
                <legend class="titLegend">
                    <span class="number">1</span>
                    Parametros
                </legend>
            </asp:Panel>
            <table>
                <tr>
                    <td class="tdLabel">Nombre:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtNom" runat="server" MaxLength="20" ToolTip="Ingrese el nombre del empleado." />
                    </td>
                </tr>
                 <tr>
                    <td class="tdLabel">Apellido Paterno:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtApePat" runat="server" MaxLength="20" ToolTip="Ingrese el apellido paterno del empleado." />
                    </td>
                </tr>                
                 <tr>
                    <td class="tdLabel">Apellido Materno:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtApeMat" runat="server" MaxLength="20" ToolTip="Ingrese el apellido materno del empleado." />
                    </td>
                </tr>
                 <tr>
                    <td class="tdLabel">Fecha Nacimiento:
                    </td>
                     <td class="tdControl">
                                <asp:TextBox ID="txtFecNac" runat="server"  ReadOnly="true"/>
                                <asp:Button ID="cmdFecNac" runat="server" Text="..." Width="43" OnClick="cmdFecNac_Click" />
                                <asp:Calendar ID="dtpFecNac" runat="server"  Visible="false" OnSelectionChanged="dtpFecNac_SelectionChanged" />
                     </td>
                </tr>
                   <tr>
                    <td class="tdLabel">correo electronico:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtCorEle" runat="server" MaxLength="20" ToolTip="Ingrese el correo electronico del empleado." />
                    </td>
                </tr>
                   <tr>
                    <td class="tdLabel">Género:
                    </td>
                   <td class="tdControl">
                        <asp:DropDownList ID="ddlGen" runat="server">
                            <asp:ListItem>-seleccione-</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Masculino</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">Telefono:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtTelefono" runat="server" MaxLength="10" ToolTip="Ingrese el telefono del empleado." />
                    </td>
                </tr>                  
                <tr>
                    <td class="tdLabel">celular:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtCel" runat="server" MaxLength="10" ToolTip="Ingrese el celular del empleado." />
                    </td>
                </tr>

                  <tr>
                    <td class="tdLabel">Fecha Alta:
                    </td>
                    <td class="tdControl">
                                <asp:TextBox ID="txtFecIni" runat="server"  ReadOnly="true"/>
                                <asp:Button ID="cmdFecIni" runat="server" Text="..." Width="43" OnClick="cmdFecIni_Click" />
                                <asp:Calendar ID="dtpFecIni" runat="server"  Visible="false" OnSelectionChanged="dtpFecIni_SelectionChanged" />
                            </td>
                </tr>

            </table>
        </fieldset>
    </div>
    <div class="divDivisor" />
    <div >
        <fieldset>
            <asp:Panel runat="server"  style="position:relative;"  >
                <asp:Panel runat="server" CssClass="panelColor"></asp:Panel>
                <legend class="titLegend"> 
                    <span class="number">2</span>
                    De clic en cargar para visualizar los datos.
                </legend>                
            </asp:Panel>
            <asp:GridView ID="grvVerEmp" runat="server"  AutoGenerateColumns="False"    GridLines="None" AllowPaging="true"
                CssClass="tablosaCatalogos"  PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                OnPageIndexChanging="grvVerEmp_PageIndexChanging" OnSelectedIndexChanged="grvVerEmp_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" ButtonType="Link" SelectText="Cargar" HeaderText="Cargar" />
                    <asp:BoundField HeaderText="Id Emp." DataField="IdEmpleado" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido Paterno" DataField="ApellidoPaterno" />
                    <asp:CheckBoxField HeaderText="Status" DataField="Status" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>



       <!-- INIIO LIBRERIAS PIE DEPAGINA-->
    <script src="../../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JS/alertify.min.js"></script>
    <!-- FIN LIBRERIAS PIE DEPAGINA-->
     
</asp:Content>
