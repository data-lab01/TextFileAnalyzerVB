Imports TextFileAnalyzerVB.Services

Module Program
    Sub Main()
        Console.WriteLine("Enter path to text file:")
        Dim path = Console.ReadLine()

        Dim reader = New FileReader()
        Dim analyzer = New Analyzer()

        If Not reader.FileExists(path) Then
            Console.WriteLine("File not found.")
            Return
        End If

        Dim lines = reader.ReadLines(path)
        Dim result = analyzer.AnalyzeText(lines)

        Console.WriteLine($"Lines: {result.LineCount}")
        Console.WriteLine($"Words: {result.WordCount}")
        Console.WriteLine($"Most frequent word(s) (Count {result.MaxFrequency}): {String.Join(", ", result.MostFrequentWords)}")

        Console.WriteLine("Enter a word to search for (or press Enter to skip):")
        Dim searchWord = Console.ReadLine()

        If Not String.IsNullOrWhiteSpace(searchWord) Then
            Dim count = analyzer.SearchWordFrequency(searchWord)
            Console.WriteLine($"The word '{searchWord}' appears {count} times.")
        End If

        Console.WriteLine("Save report to file? (y/n)")
        If Console.ReadLine()?.ToLower() = "y" Then
            Dim report = $"Lines: {result.LineCount}{vbCrLf}Words: {result.WordCount}{vbCrLf}Most frequent word(s): {String.Join(", ", result.MostFrequentWords)} (Count: {result.MaxFrequency}){vbCrLf}"
            IO.File.WriteAllText("analysis_report.txt", report)
            Console.WriteLine("Saved to analysis_report.txt")
        End If
    End Sub
End Module
