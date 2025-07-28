Imports TextFileAnalyzerVB.Models

Namespace Services
    Public Class Analyzer
        Private wordFrequency As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

        Public Function AnalyzeText(lines As String()) As AnalysisResult
            Dim wordCount As Integer = 0

            For Each line In lines
                Dim words = line.Split({" "c, ","c, "."c, ";"c, ":"c, "!"c, "?"c, "-"c, vbTab}, StringSplitOptions.RemoveEmptyEntries)
                wordCount += words.Length

                For Each word In words
                    If wordFrequency.ContainsKey(word) Then
                        wordFrequency(word) += 1
                    Else
                        wordFrequency(word) = 1
                    End If
                Next
            Next

            Dim maxFreq = If(wordFrequency.Values.Any(), wordFrequency.Values.Max(), 0)
            Dim topWords = wordFrequency.Where(Function(kv) kv.Value = maxFreq).Select(Function(kv) kv.Key).ToList()

            Return New AnalysisResult With {
                .LineCount = lines.Length,
                .WordCount = wordCount,
                .MaxFrequency = maxFreq,
                .MostFrequentWords = topWords
            }
        End Function

        Public Function SearchWordFrequency(word As String) As Integer
            Return If(wordFrequency.TryGetValue(word, 0), wordFrequency(word), 0)
        End Function
    End Class
End Namespace
