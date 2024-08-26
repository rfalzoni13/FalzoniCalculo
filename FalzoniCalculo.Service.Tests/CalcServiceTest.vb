Imports FalzoniCalculo.DI
Imports FalzoniCalculo.Models.Classes
Imports FalzoniCalculo.Service.Classes

Namespace Services
    <TestClass>
    Public Class CalcServiceTest
        Private [CalcService] As CalcService

        <ClassInitialize>
        Public Shared Sub ClassInitialize(testContext As TestContext)
            DependencyService.GetServiceProviders()
        End Sub

        <TestInitialize>
        Public Sub TestInitialize()
            [CalcService] = DependencyService.ServiceProvider.GetService(GetType(CalcService))
        End Sub

        <TestMethod>
        Public Sub TestCalculateCurrency_Success()
            Dim entry = New CurrencyEntryModel With
            {
                .[Date] = DateTime.Now.AddMonths(1),
                .Value = 100.0
            }

            Dim result = [CalcService].CalculateCurrency(entry)

            Assert.AreEqual(123.47, Math.Round(result.GrossValue, 2))
            Assert.AreEqual(100.97, Math.Round(result.LiquidValue, 2))
        End Sub

        <TestMethod>
        Public Sub TestCalculateCurrency_Success_Not_Equal()
            Dim entry = New CurrencyEntryModel With
            {
                .[Date] = DateTime.Now.AddMonths(2),
                .Value = 100.0
            }

            Dim result = [CalcService].CalculateCurrency(entry)

            Assert.AreNotEqual(100.25, result.GrossValue)
            Assert.AreNotEqual(100.97, result.LiquidValue)
        End Sub

        <TestMethod>
        Public Sub TestCalculateCurrency_Success_Date_Failed()
            Dim entry = New CurrencyEntryModel With
            {
                .[Date] = DateTime.Now.AddDays(-1),
                .Value = 50.0
            }

            Assert.ThrowsException(Of ApplicationException)(Sub() [CalcService].CalculateCurrency(entry))
        End Sub

        Public Sub TestCalculateCurrency_Success_Value_Failed()
            Dim entry = New CurrencyEntryModel With
            {
                .[Date] = DateTime.Now.AddDays(3),
                .Value = 0
            }

            Assert.ThrowsException(Of ApplicationException)(Sub() [CalcService].CalculateCurrency(entry))
        End Sub
    End Class
End Namespace
