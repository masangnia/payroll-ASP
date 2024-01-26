Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Public Class data_jabatan
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
            strSQL = "SELECT * FROM TBL_JABATAN ORDER BY KODE ASC"
            objAdapter = New OleDbDataAdapter(strSQL, myCon)
            objAdapter.Fill(objDataset)
            grdList.DataSource = objDataset
            grdList.DataBind()
            myCon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ClearObject()
        txtKode.Text = ""
        txtNama.Text = ""
        txtJabatan.Text = ""
        txtGaji.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            myCon = New OleDbConnection(strCon)
            Try
                myCon.Open()
                strSQL = "Select * FROM TBL_JABATAN WHERE KODE = '" & Trim(txtKode.Text) & "'"
                objCommand = New OleDbCommand(strSQL, myCon)
                objReader = objCommand.ExecuteReader(CommandBehavior.Default)
                If objReader.HasRows Then
                    MsgBox("Duplicate Data")
                Else
                    objCommand.Dispose()
                    strSQL = "INSERT INTO TBL_JABATAN (KODE,NAMA,JABATAN,GAJI_POKOK) VALUES('" & txtKode.Text & "','" & txtNama.Text & "','" & txtJabatan.Text & "','" & (txtGaji.Text) & "')"
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
                Call ClearObject()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub grdList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectedIndexChanged
        Try
            txtKode.Text = grdList.SelectedRow.Cells(1).Text
            txtNama.Text = grdList.SelectedRow.Cells(2).Text
            txtJabatan.Text = grdList.SelectedRow.Cells(3).Text
            txtGaji.Text = Format(CDbl(grdList.SelectedRow.Cells(4).Text), "#,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call ClearObject()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            'Untuk Pesan Delete bisa menggunakan JavaScript jika akan di running dalam Web Server
            If MsgBox("Yakin akan dihapus ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                myCon = New OleDbConnection(strCon)
                myCon.Open()
                strSQL = "DELETE FROM TBL_JABATAN WHERE KODE='" & txtKode.Text & "' "
                objCommand = New OleDbCommand(strSQL, myCon)
                If objCommand.ExecuteNonQuery Then
                    MsgBox("DATA SUDAH DI DELETE")
                Else
                    MsgBox("DATA TIDAK DAPAT DI DELETE")
                End If
                myCon.Close()
                Call ListGrid()
            Else
                MsgBox("Data Batal Dihapus")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "UPDATE TBL_JABATAN SET NAMA='" & txtNama.Text & "',JABATAN='" & txtJabatan.Text & "',GAJI_POKOK='" & txtGaji.Text & " WHERE KODE='" & txtKode.Text & "' "
            objCommand = New OleDbCommand(strSQL, myCon)
            If objCommand.ExecuteNonQuery Then
                MsgBox("DATA SUDAH DIUPDATE")
            Else
                MsgBox("DATA TIDAK DAPAT DIUPDATE")
            End If
            myCon.Close()
            Call ListGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class