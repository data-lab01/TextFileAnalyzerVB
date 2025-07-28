Namespace Services
    Public Class FileReader
        Public Function FileExists(path As String) As Boolean
            Return IO.File.Exists(path)
        End Function

        Public Function ReadLines(path As String) As String()
            Return IO.File.ReadAllLines(path)
        End Function
    End Class
End Namespace
