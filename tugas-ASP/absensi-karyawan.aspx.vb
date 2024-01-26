Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Public Class absensi_karyawan
    Inherits System.Web.UI.Page
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private objAdapter As OleDbDataAdapter
    Private objDataset As DataSet
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private strCon As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ASP-siti\baru\tgs-jamur\dbkarya.mdb"
            If Not IsPostBack Then
                Call ListGrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ListGrid()
        Try
            objDataset = New DataSet
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "SELECT * FROM TBL_ABSENSI ORDER BY KODE ASC"
            objAdapter = New OleDbDataAdapter(strSQL, myCon)
            objAdapter.Fill(objDataset)
            grdList.DataSource = objDataset
            grdList.DataBind()
            myCon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            myCon = New OleDbConnection(strCon)
            Try
                myCon.Open()
                strSQL = "Select * FROM TBL_ABSENSI WHERE KODE = '" & Trim(txtKodeKaryawan.Text) & "'"
                objCommand = New OleDbCommand(strSQL, myCon)
                objReader = objCommand.ExecuteReader(CommandBehavior.Default)
                If objReader.HasRows Then
                    MsgBox("Duplicate Data")
                Else
                    objCommand.Dispose()
                    strSQL = "INSERT INTO TBL_ABSENSI (KODE,TANGGAL,NAMA,JENIS_KELAMIN,JABATAN,KETERANGAN) VALUES('" & txtKodeKaryawan.Text & "','" & txtTanggal.Text & "','" & txtNamaKaryawan.Text & "','" & rbJK.Text & "','" & ddlJabatan.Text & "','" & (txtKeterangan.Text) & "')"
                    objCommand = New OleDbCommand(strSQL, myCon)
                    If objCommand.ExecuteNonQuery Then
                        MsgBox("Data telah di simpan")
                    Else
                        MsgBox("Data error di simpan")
                    End If
                End If
                objReader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                myCon.Close()
                objCommand = Nothing
                objReader = Nothing
                myCon = Nothing
                Call ListGrid()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub grdList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectedIndexChanged
        Try
            txtKodeKaryawan.Text = grdList.SelectedRow.Cells(1).Text
            txtTanggal.Text = grdList.SelectedRow.Cells(2).Text
            txtNamaKaryawan.Text = grdList.SelectedRow.Cells(2).Text
            rbJK.Text = grdList.SelectedRow.Cells(3).Text
            ddlJabatan.Text = grdList.SelectedRow.Cells(4).Text
            txtKeterangan.Text = Format(CDbl(grdList.SelectedRow.Cells(5).Text), "#,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ClearObject()
        txtKodeKaryawan.Text = ""
        txtTanggal.Text = ""
        txtNamaKaryawan.Text = ""
        rbJK.Text = ""
        ddlJabatan.Text = ""
        txtKeterangan.Text = ""
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            'Untuk Pesan Delete bisa menggunakan JavaScript jika akan di running dalam Web Server
            If MsgBox("Yakin akan dihapus ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                myCon = New OleDbConnection(strCon)
                myCon.Open()
                strSQL = "DELETE FROM TBL_ABSENSI WHERE KODE='" & txtKodeKaryawan.Text & "' "
                objCommand = New OleDbCommand(strSQL, myCon)
                If objCommand.ExecuteNonQuery Then
                    MsgBox("DATA SUDAH DI DELETE")
                Else
                    MsgBox("DATA TIDAK DAPAT DI DELETE")
                End If
                myCon.Close()
                Call ListGrid()
            Else
                MsgBox("Data Batal DIhapus")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call ClearObject()
    End Sub
End Class