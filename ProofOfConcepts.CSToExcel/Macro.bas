Sub CreateAMessageBox_Click()

    MsgBox "Hi There, I am outside xlsx,in Macro.bas"
  
End Sub


Sub Test()

    MsgBox "Hi There, I am in Test(),in Macro.bas"
  
End Sub


Sub TestDlls()

    Dim s As String
    Dim c As New ClassSupplyingJson
    
    s = c.Init("D:\Temp\sampleTextAsJson.json")
    
    MsgBox s

End Sub
