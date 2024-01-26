<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="data-jabatan.aspx.vb" Inherits="tgs_jamur.data_jabatan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PAYROLL</title>
 <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
 <style type="text/css">
  .latar
  {
  	background-image: url("bg-payroll.jpg");
  	}
  .foto
    {
  	background-image: url("foto.png");
  	}
  .style1
 {
 text-align: center;
 }
 .style2
 {
 font-family: "Courier New";
 font-size: small;
 color: #FFFFFF;
 }
 </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; height:100%; margin:auto; background:bisque; padding-top:10px; border:1px; " >
<div style="width:100%; height:125px; margin:auto; background:pink; " >
<div class="latar" style ="width:100%; height:120px; margin:auto; padding-top:0px; padding-bottom:0px;">
</div>
</div>

<div style ="width:100%; height:415px; margin:auto; background:pink; margin-top:5px; padding-bottom :5px; " >
<div style="width:20%; height:415px; float:left; background:pink; " >
<div style ="width:215px; height:395px; background:grey; margin:auto; padding-left:5px; padding-top:5px; padding-bottom:5px; margin-top:5px;">
<div class="StyleMenu">

        <div style ="width:165px; height:20px; background:grey; margin:auto; padding-left:20px;">
        <h3 class="HeaderBar">MENU UTAMA</h3>

        <ul>
             <li><a href="page-login.aspx">LOGIN</a></li>
             <li><a href="data-karyawan.aspx">Data Karyawan</a></li>
             <li><a href="data-jabatan.aspx">Data Jabatan</a></li>
             <li><a href="absensi-karyawan.aspx">Absensi Karyawan</a></li>
             <li><a href="hitung-gaji.aspx">Hitung Gaji Karyawan</a></li>
             <li><a href="page-login.aspx">LOGOUT</a></li>
         </ul>
         </div>
        </div>
        </div>
        </div>
        
<div style ="width:60%; height:415px; float:left; background:grey;" >
<div style =" width:100%; height:20px; background:bisque; margin:auto; padding-right :10px; padding-left:10px; padding-top:5px; padding-bottom:5px; margin-top:5px;">
<table align="center" >
<tr align="center" valign="middle">
<td align="center" valign="middle">OLAH DATA JABATAN</td>
</tr>
</table>
</div>
<div style =" width:100%; height:150px; background:bisque; margin:auto; padding-right :10px; padding-left:0px; padding-top:5px; padding-bottom:5px; margin-top:5px; ">
<table>
<tr>
<td style="width:180px;">KODE</td>
<td>
<asp:TextBox ID="txtKode" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width:180px;">NAMA KARYAWAN</td>
<td>
<asp:TextBox ID="txtNama" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width:180px;">JABATAN</td>

                        <td>
                        <!-- untuk memilih jabatan -->
                         <asp:DropDownList ID="txtJabatan" runat="server" Width="100px">
                         <asp:ListItem Text="ADMIN" Value="ADMIN"></asp:ListItem>
                         <asp:ListItem Text="FINANCE" Value="FINANCE"></asp:ListItem>
                         <asp:ListItem Text="HRD" Value="HRD"></asp:ListItem>
                         </asp:DropDownList>
                         </td>

</tr>
<tr>
<td style="width:70px;">GAJI POKOK</td>
<td>
<asp:TextBox ID="txtGaji" runat="server" Width="300px"></asp:TextBox>
</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
<asp:Button ID="btnSave" Width="80px" runat="server" Text="Save" />
<asp:Button ID="btnUpdate" Width="80px" runat="server" Text="Update" />
<asp:Button ID="btnDelete" Width="80px" runat="server" Text="Delete" />
<asp:Button ID="btnClear" Width="80px" runat="server" Text="Clear" />
</td>
</tr>
</table>
</div>
<div style =" width:100%; height:200px; background:pink; margin:auto; padding-right :5px; padding-left:5px; margin-top:5px; padding-top:5px; ">
<div style =" width:77%; height:198px; background:white; margin:auto; overflow:auto ; ">
<asp:GridView ID ="grdList" runat ="server" AutoGenerateColumns ="false"
ShowFooter ="false" Width ="600px" >
<Columns >
<asp:CommandField ControlStyle-ForeColor="Blue" HeaderText ="Select" ShowHeader="true" ShowSelectButton ="true" >
<ControlStyle ForeColor ="Blue" />
</asp:CommandField>
<asp:BoundField DataField ="KODE" HeaderText ="KODE" ItemStyle-Width ="40px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width ="250px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="JABATAN" HeaderText ="JABATAN" ItemStyle-Width ="100px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="GAJI_POKOK" HeaderText ="GAJI POKOK" ItemStyle-Width ="80px" ItemStyle-HorizontalAlign="Right" DataFormatString ="{0:N2}">
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
</Columns>
</asp:GridView>
</div>
</div>
</div>
<div style ="width:20%; height:415px; float:right; background:pink;" >
<div class="foto" style ="width:215px; height:395px; margin:auto; padding-left:5px; padding-top:5px; padding-bottom:5px; margin-top:5px;">
</div>
</div>
</div>
<div style="width:100%; height:40px; margin:auto; background:grey; padding-top:5px;"  >
<table align="center" >
<td align="center" valign="middle">Copyrights by SITI, SHILMI, APRIL</td>
</table>
</div>
</div>
</form>
</body>
</html>
