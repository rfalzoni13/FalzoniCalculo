Imports FalzoniCalculo.Service.Classes
Imports Microsoft.Extensions.DependencyInjection

Public NotInheritable Class DependencyService
    Public Shared Property [ServiceProvider] As ServiceProvider
    Public Shared Sub GetServiceProviders()
        Dim [serviceCollection] = New ServiceCollection()
        [serviceCollection].AddSingleton(Of CalcService)()
        [ServiceProvider] = [serviceCollection].BuildServiceProvider()
    End Sub
End Class
