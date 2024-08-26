Imports FalzoniCalculo.Models.Classes

Namespace Classes
    Public Class CalcService
        Implements IDisposable


        Public Function CalculateCurrency(model As CurrencyEntryModel) As CurrencyReturnModel
            If model.Date.Month <= DateTime.Now.Date.Month Then
                Throw New ApplicationException("Data precisa ser maior que a data atual")
            End If

            If model.Value = 0 Then
                Throw New ApplicationException("O Valor precisa ser maior do que zero")
            End If

            Dim valueLiquid As Decimal = 0
            Dim valueGross As Decimal = 0

            Dim meses = model.Date.Month - DateTime.Now.Month

            For i As Integer = 1 To meses
                valueLiquid += model.Value * 1 + ((0.9 * 108) / 100)
            Next

            Select Case model.Date.Month - DateTime.Now.Month
                Case 0 To 6
                    valueGross = valueLiquid + (model.Value * 22.5) / 100

                Case 7 To 12
                    valueGross = valueLiquid + (model.Value * 20.0) / 100

                Case 13 To 24
                    valueGross = valueLiquid + (model.Value * 17.5) / 1000

                Case Else
                    valueGross = valueLiquid + (model.Value * 15) / 100
            End Select

            Return New CurrencyReturnModel With
            {
                .GrossValue = valueGross,
                .LiquidValue = valueLiquid
            }
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub
    End Class
End Namespace
