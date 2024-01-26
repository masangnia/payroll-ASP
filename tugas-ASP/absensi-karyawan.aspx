<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="absensi-karyawan.aspx.vb" Inherits="tgs_jamur.absensi_karyawan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
 <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
 <style type="text/css">
  .latar
  {
  	background-image: url("bg-payroll.jpg");
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
        
<div style ="width:35%; height:415px; float:left; background:grey;" >
<div style =" width:100%; height:20px; background:bisque; margin:auto; padding-right :10px; padding-left:10px; padding-top:5px; padding-bottom:5px; margin-top:5px;">
<table align="center" >
<tr align="center" valign="middle">
<td align="center" valign="middle">ABSENSI KARYAWAN</td>
</tr>
</table>
</div>
<div style =" width:100%; height:360px; background:bisque; margin:auto; padding-right :10px; padding-left:0px; padding-top:5px; padding-bottom:5px; margin-top:5px; ">
<table>
<tr>
<td style="width:100px;">KODE</td>
<td>
<asp:TextBox ID="txtKodeKaryawan" runat="server" Width="100px"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width:180px;">TANGGAL</td>
<td>
<asp:TextBox ID="txtTanggal" runat="server" Width="100px"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width:150px;">NAMA KARYAWAN</td>
<td>
<asp:TextBox ID="txtNamaKaryawan" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>
<tr>
                        
                        <td>JENIS KELAMIN</td>
                        <td>
                        <!-- Daftar radio untuk memilih jenis kelamin -->
                        <asp:RadioButtonList ID="rbJK" runat="server" RepeatDirection="vertical">
                        <asp:ListItem Text="PEREMPUAN" Value="PEREMPUAN"></asp:ListItem>
                        <asp:ListItem Text="LAKI-LAKI" Value="LAKI-LAKI"></asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
</tr>
<tr>
                        
                        <td>JABATAN</td>
                        <td>
                        <!-- untuk memilih jenis kelamin -->
                         <asp:DropDownList ID="ddlJabatan" runat="server" Width="100px">
                         <asp:ListItem Text="ADMIN"   Value="ADMIN"></asp:ListItem>
                         <asp:ListItem Text="FINANCE" Value="FINANCE"></asp:ListItem>
                         <asp:ListItem Text="HRD"     Value="HRD"></asp:ListItem>
                         </asp:DropDownList>
                         </td>
</tr>
                   
<tr>
<td style="width:180px;">KETERANGAN</td>
<td>
<asp:TextBox ID="txtKeterangan" runat="server" Width="100px" ></asp:TextBox>
</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
        <asp:Button ID="btnSave" runat="server" Text="Save" width="80px" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" width="80px"/>
        <asp:Button ID="btnClear" runat="server" Text="Clear" width="80px"/>
</td>
</tr>
</table>
</div>
</div>
<div style ="width:45%; height:410px; float:right; background:pink; margin:auto; padding-top:10px;" >
<div style =" width:95%; height:198px; background:white; margin:auto; overflow:auto ; ">
<asp:GridView ID ="grdList" runat ="server" AutoGenerateColumns ="false"
ShowFooter ="false" Width ="600px" >
<Columns >
<asp:CommandField ControlStyle-ForeColor="Blue" HeaderText ="Select" ShowHeader="true" ShowSelectButton ="true" >
<ControlStyle ForeColor ="Blue" />
</asp:CommandField>
<asp:BoundField DataField ="KODE" HeaderText ="KODE" ItemStyle-Width ="100px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="TANGGAL" HeaderText ="TANGGAL" ItemStyle-Width ="100px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="NAMA" HeaderText ="NAMA" ItemStyle-Width ="100px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="JENIS_KELAMIN" HeaderText ="JENIS KELAMIN" ItemStyle-Width ="100px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="JABATAN" HeaderText ="JABATAN" ItemStyle-Width ="100px" >
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
<asp:BoundField DataField ="KETERANGAN" HeaderText ="KET" ItemStyle-Width ="80px" ItemStyle-HorizontalAlign="Right" DataFormatString ="{0:N2}">
<HeaderStyle Wrap ="false" />
<ItemStyle Wrap ="false" />
</asp:BoundField >
</Columns>
</asp:GridView>
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
