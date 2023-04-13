<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="bth6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 28px;
        }

        .auto-style3 {
            width: 95px;
        }

        .auto-style4 {
            height: 28px;
            width: 95px;
        }

        .auto-style5 {
            width: 89px;
        }

        .auto-style6 {
            height: 28px;
            width: 89px;
        }

        .auto-style7 {
            width: 95px;
            height: 76px;
        }

        .auto-style8 {
            width: 89px;
            height: 76px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Mật khẩu"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="Tên"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Text="Họ và tên đệm"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label6" runat="server" Text="Giới tính"></asp:Label></td>
                    <td class="auto-style8">
                        <asp:RadioButtonList ID="rblGender" runat="server">
                            <asp:ListItem Value= "true">Nam</asp:ListItem>
                            <asp:ListItem Value="false">Nữ</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label7" runat="server" Text="Địa chỉ"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" /></td>
                    <td class="auto-style2">
                        <asp:Button ID="btnDelete" runat="server" Text="Xoá" OnClick="btnDelete_Click" /></td>
                     <td class="auto-style2">
                        <asp:Button ID="btnUpDate" runat="server" Text="Cập Nhật" OnClick="btnUpDate_Click" /></td>
                    <td class="auto-style2">
                        <asp:Button ID="btnClear" runat="server" Text="Xoá trống form" OnClick="btnClear_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label ID="lblMessage" runat="server" Text="Thông báo"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
