Public Class Form1
    Dim viewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        viewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        viewer1.Dock = DockStyle.Fill
        Me.Controls.Add(viewer1)
    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)



        Dim dt As New DataSet1.DataTable1DataTable
        For i = 1 To 100
            Dim row = dt.NewDataTable1Row()
            row.GRP = i Mod 5
            row.NAME = "詳細データ " + i.ToString()
            dt.AddDataTable1Row(row)
        Next

        Dim lr = viewer1.LocalReport
        lr.ReportPath = "Report1.rdlc"
        viewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        viewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage

        lr.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", CType(dt, DataTable)))
        viewer1.RefreshReport()
    End Sub
End Class
