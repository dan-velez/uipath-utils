' Excel_Format_Table.vb - Add formatting to a table to make it easier to read.

Sub Main(vstr_sheetname as String, vint_header_color as Integer, vint_num_rows, vint_num_columns)
    ' Main method that runs the formatting.

    Worksheets(vstr_sheetname).Activate
    
    Dim vrange_rng As Range
    Dim vrange_all As Range
    Dim vstr_lcolumn As String

    vstr_lcolumn = Number2Letter(vint_num_columns)
    set vrange_rng = Range("A1:"& vstr_lcolumn &"1")
    set vrange_all = Range("A1:"& vstr_lcolumn & vint_num_rows)

    ' Format headers
    For Each vcell in vrange_rng
        If vcell.Value <> "" Then
            ' Bold column headers
            vcell.Font.Bold = True
        
            ' Center column headers
            vcell.HorizontalAlignment = xlCenter
        
            ' BG Color on column headers
            vcell.Interior.ColorIndex = vint_header_color
        End If
    Next vcell

    ' Auto-fit column widths
    Worksheets(vstr_sheetname).Columns("A:" & vstr_lcolumn).AutoFit

    ' Borders on all cells
    For Each vcell in vrange_all
        vcell.Borders.LineStyle = xlContinuous
        vcell.Borders.Color = vbBlack
        vcell.Borders.Weight = xlThin
    Next vcell
End Sub

Function Number2Letter(ColumnNumber) As String
    'PURPOSE: Convert a given number into it's corresponding Letter Reference
    'SOURCE: www.TheSpreadsheetGuru.com/the-code-vault

    Dim ColumnLetter As String

    'Convert To Column Letter
    ColumnLetter = Split(Cells(1, ColumnNumber).Address, "$")(1)

    Number2Letter= ColumnLetter
End Function