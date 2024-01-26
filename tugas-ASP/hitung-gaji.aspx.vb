Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Public Class hitung_gaji
    Inherits System.Web.UI.Page
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private objAdapter As OleDbDataAdapter
    Private objDataset As DataSet
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private strCon As String
    Private db1Gaji As Double
    Private db1Pajak As Double
    Private db1Total As Double

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
            strSQL = "SELECT * FROM TBL_GAJI ORDER BY KODE ASC"
            objAdapter = New OleDbDataAdapter(strSQL, myCon)
            objAdapter.Fill(objDataset)
            grdList.DataSource = objDataset
            grdList.DataBind()
            myCon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnHitung_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHitung.Click
        Try

            If UCase(txtKodeKaryawan.Text) = "KD001" Then
                txtNamaKaryawan.Text = "syarifah"
                db1Gaji = 10000000
                If optJabatan.Text = "ADMIN" Then
                    db1Pajak = (db1Gaji * 5) / 100
                End If

            ElseIf UCase(txtKodeKaryawan.Text) = "KD002" Then
                txtNamaKaryawan.Text = "rocy gerung"
                db1Gaji = 12000000
                If optJabatan.Text = "FINANCE" Then
                    db1Pajak = (db1Gaji * 10) / 100
                End If

            ElseIf UCase(txtKodeKaryawan.Text) = "KD003" Then
                txtNamaKaryawan.Text = "syireen"
                db1Gaji = 17000000
                If optJabatan.Text = "HRD" Then
                    db1Pajak = (db1Gaji * 15) / 100
                End If

            Else
                MsgBox("Gaji tidak di proses")
            End If

            db1Total = db1Gaji - db1Pajak

            txtGaji.Text = Format(db1Gaji, "#,##0.00")
            txtPajak.Text = Format(db1Pajak, "#,##0.00")
            txtTotal.Text = Format(db1Total, "#,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            myCon = New OleDbConnection(strCon)
            Try
                myCon.Open()
                strSQL = "Select * FROM TBL_GAJI WHERE KODE = '" & Trim(txtKodeKaryawan.Text) & "'"
                objCommand = New OleDbCommand(strSQL, myCon)
                objReader = objCommand.ExecuteReader(CommandBehavior.Default)
                If objReader.HasRows Then
                    MsgBox("Duplicate Data")
                Else
                    objCommand.Dispose()
                    strSQL = "INSERT INTO TBL_GAJI (KODE,NAMA,JABATAN,GAJI_POKOK,PAJAK,TOTAL_GAJI) VALUES('" & txtKodeKaryawan.Text & "','" & txtNamaKaryawan.Text & "','" & optJabatan.Text & "','" & txtGaji.Text & "','" & txtPajak.Text & "','" & (txtTotal.Text) & "')"
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
            txtKodeKaryawan.Text = grdList.SelectedRow.Cells(1).Text
            txtNamaKaryawan.Text = grdList.SelectedRow.Cells(2).Text
            optJabatan.Text = grdList.SelectedRow.Cells(3).Text
            txtGaji.Text = grdList.SelectedRow.Cells(4).Text
            txtPajak.Text = grdList.SelectedRow.Cells(5).Text
            txtTotal.Text = Format(CDbl(grdList.SelectedRow.Cells(6).Text), "#,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call ClearObject()
    End Sub
    Private Sub ClearObject()
        txtKodeKaryawan.Text = ""
        txtNamaKaryawan.Text = ""
        optJabatan.Text = ""
        txtGaji.Text = ""
        txtPajak.Text = ""
        txtTotal.Text = ""
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            'Untuk Pesan Delete bisa menggunakan JavaScript jika akan di running dalam Web Server
            If MsgBox("Yakin akan dihapus ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                myCon = New OleDbConnection(strCon)
                myCon.Open()
                strSQL = "DELETE FROM TBL_GAJI WHERE KODE='" & txtKodeKaryawan.Text & "' "
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
End Class