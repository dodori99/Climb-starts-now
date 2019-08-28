<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Textbox_Multiplier.aspx.cs" Inherits="WebApplication2.Textbox_Multiplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 343px">
            <br />
            /* Needs CSS */<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="TextBox Play! "></asp:Label>
            &nbsp;(As of now, the textbox will accept and store data in string format &amp;&amp; Cannot be left blank!)<br />
            -------------------------------------------------------------------------------------------------------------------<br />
            <asp:Button ID="AddNewFieldButton" runat="server" Text="Add New TextBox" OnClick="AddNewFieldButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="S2DB_Button" runat="server" Text="Save" Width="136px" OnClick="S2DB_Button_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RemoveAll_Button" runat="server" Text="Remove All Fields" OnClick="RemoveAll_Button_Click" />
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RemoveLast_Button" runat="server" Text="Remove Last Field" OnClick="RemoveLast_Button_Click" />
            
            <br />
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
            <br />
            <br />
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////<br />
            Dependant Dropdown Boxes (The values in second drop down depend on the first drop down box) AKA Cascading Dropdown lists<br />
            ---------------------------------------------------------------------------------------------------------------------<br />
            Musical Categories&nbsp; :&nbsp;
            <asp:DropDownList ID="MusicalCategories_DropDown" runat="server" OnSelectedIndexChanged="MusicalCategories_DropDown_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;<br />
            Trainer(s) Available :&nbsp; <asp:DropDownList ID="MusicalTeachers_DropDown" runat="server">
            </asp:DropDownList>
            
        &nbsp;<br />
            <br />
           
            
        </div>
    </form>
</body>
</html>
