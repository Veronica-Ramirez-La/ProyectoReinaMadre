<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="ProyectoReinaMadre.Departamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="../../CSS/CssEstilo.css" type="text/css" />
    <link href="../../CSS/EstilosAlertasCore.css" rel="stylesheet" />
    <link href="../../CSS/EstilosAlertasDefault.css" rel="stylesheet" />
    <style type="text/css">
        .header-center {
            text-align:center;
        }
    </style>
    <link href="../../Estilos/jquery-ui-1.8.18.custom.css" rel="Stylesheet" />
    <link href="../../Estilos/style.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-header">
        <h3>
            CATALOGO DEPARTAMENTOS
        </h3>
            <asp:Button ID="cmdGra" runat="server" Text="Grabar" ToolTip="Grabar datos" OnClick="cmdGra_Click" />
            <asp:Button ID="cmdSta" runat="server" Text="Status" ToolTip="Cambiar status" OnClick="cmdSta_Click" />
            <asp:Button ID="cmdLim" runat="server" Text="Limpiar" ToolTip="Limpiar campos" OnClick="cmdLim_Click" />
            <asp:Button ID="cmdCar" runat="server" Text="Cargar" ToolTip="Cargar los departamentos" OnClick="cmdCar_Click" />
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
                    <td class="tdLabel">Departamento:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtDep" runat="server" MaxLength="50" ToolTip="Ingrese el departamento a dar de alta." />
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">Ubicacion:
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtUbi" runat="server" MaxLength="150" ToolTip="Ingrese la ubicacion departamento a dar de alta." />
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">Empresa:
                    </td>
                     <td class="tdControl">
                        <asp:DropDownList ID="ddlEmp" runat="server">
                            <asp:ListItem>-seleccione-</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>                            
                            <asp:ListItem>3</asp:ListItem>                          
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
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
            <asp:GridView ID="grvVerDep" runat="server"
                AutoGenerateColumns="False"
                GridLines="None"
                AllowPaging="true"
                CssClass="tablosaCatalogos"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="grvVerDep_PageIndexChanging" OnSelectedIndexChanged="grvVerDep_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" ButtonType="Link" SelectText="Cargar" HeaderText="Cargar" />
                    <asp:BoundField HeaderText="Id Dep" DataField="IdDepartamento" />
                    <asp:BoundField HeaderText="Departamento" DataField="Departamento" />
                    <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion" />
                    <asp:CheckBoxField HeaderText="Status" DataField="Status" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>




    <script src="../../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JS/alertify.min.js"></script>

</asp:Content>
