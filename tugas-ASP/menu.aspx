<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="menu.aspx.vb" Inherits="tgs_jamur.menu" %>

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
             <li><a href="menu.aspx">LOGOUT</a></li>
         </ul>
         </ul>
         </div>
        </div>
        </div>
        </div>
    </div></form>
</body>
</html>