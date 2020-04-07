## SDK .NET para integra��o com o Boleto F�cil

Este SDK (Software Development Kit) para o Boleto F�cil tem como objetivo abstrair, para desenvolvedores de aplica��es na plataforma .NET, os detalhes de comunica��o com a [API do Boleto F�cil](https://www.boletobancario.com/boletofacil/integration/integration.html), tanto com o servidor de [produ��o](https://www.boletobancario.com/boletofacil/) como com o servidor de testes ([sandbox](https://sandbox.boletobancario.com/boletofacil/)), de modo que o desenvolvedor possa se concentrar na l�gica de neg�cio de sua aplica��o.

## Requisitos

* Portable Class Library (.NETFramework 4.5, Windows 8.0)

## Integra��o

#### NuGet

O SDK .NET do Boleto F�cil est� dispon�vel no NuGet: https://www.nuget.org/packages/boletofacilsdk

## Limita��es

O �nico item da API do Boleto F�cil que essa SDK n�o contempla � a [notifica��o de pagamentos](https://www.boletobancario.com/boletofacil/integration/integration.html#notificacao) para aplica��es Web, atrav�s da URL de notifica��o. Nesse caso, tanto a l�gica de captura das requisi��es POST enviadas pelo Boleto F�cil com os dados dos pagamentos como a l�gica da baixa das cobran�as pagas ficam a cargo do sistema integrado com o Boleto F�cil.

## Guia de uso

Para usar o SDK do Boleto F�cil � necess�rio definir dois itens:

1. O ambiente: produ��o (`PRODUCTION`) ou testes (`SANDBOX`)
2. O token do favorecido, o qual deve ser definido na �rea de **integra��o** do ambiente escolhido ([aqui](https://www.boletobancario.com/boletofacil/integration/integration.html#token) para produ��o ou [aqui](https://sandbox.boletobancario.com/boletofacil/integration/integration.html#token) para sandbox)

Exemplo:
```c#
// Cria uma inst�ncia do SDK que ir� enviar requisi��es ao ambiente de testes do Boleto F�cil (Sandbox)
BoletoFacil boletoFacil = new BoletoFacil(BoletoFacilEnvironment.SANDBOX, "XYZ12345"); // XYZ12345 is the API key
```

### Gerando uma cobran�a

`Charge` � a classe que representa uma cobran�a do Boleto F�cil e que cont�m os atributos relacionados a ela, que 
s�o exatamente os atributos disponibilizados pela API do Boleto F�cil e podem ser conferidos [aqui](https://www.boletobancario.com/boletofacil/integration/integration.html#cobrancas). 

Dentre os atributos da cobran�a est�o os dados do pagador, que s�o definidos na classe `Payer`.

```c#
Payer payer = new Payer();
payer.Name = "Pagador teste - SDK .NET";
payer.CpfCnpj = "11122233300";

Charge charge = new Charge();
charge.Description = "Cobran�a teste gerada pelo SDK .NET";
charge.Amount = 176.45m;
charge.Payer = payer;

ChargeResponse response = boletoFacil.IssueCharge(charge);
foreach (Charge c in response.Data.Charges)
{
    Console.WriteLine(c);
}
```

A classe `ChargeResponse` indica se a requisi��o foi bem sucedida ou n�o (da mesma forma que todas as classes que herdam da superclasse `Response` no SDK) e, al�m disso, cont�m a lista de cobran�as que foram geradas pela requisi��o, em uma lista de objetos do tipo `Charge`.


### Consulta de saldo

Por padr�o, as requisi��es feitas pelo SDK desserializam o retorno em **JSON** para popular os objetos com as informa��es das requisi��es, mas o SDK tamb�m prov� a possibilidade de alterar a formata��o do retorno da API para **XML**, conforme pode ser visto no exemplo abaixo:

```c#
FetchBalanceResponse response = boletoFacil.FetchBalance(ResponseType.XML);
Console.WriteLine(response.Data);
```


### Solicita��o de transfer�ncia

Mesmo que se deseje solicitar uma transfer�ncia com o saldo total, � necess�rio passar um par�metro da classe `Transfer`, sem o atributo `amount` definido, no caso.

```c#
Transfer transfer = new Transfer();
TransferResponse response = boletoFacil.RequestTransfer(transfer);
Console.WriteLine(response);
```

Como a resposta de solicita��o transfer�ncia cont�m apenas se a requisi��o foi bem sucedida ou n�o, n�o se aplica o m�todo `getData()` para ela.


### Consulta de pagamentos e cobran�as

Para esta requisi��o, � usado um objeto da classe `ListChargesDates` para definir as datas usadas no filtro da consulta. No exemplo abaixo, s�o usadas apenas as datas de vencimento das cobran�as desejadas.

```c#
ListChargesDates dates = new ListChargesDates();
dates.BeginDueDate = DateTime.Today.AddDays(1);
dates.EndDueDate = DateTime.Today.AddDays(5);

ListChargesResponse response = boletoFacil.listCharges(dates);
foreach (Charge c in response.Data.Charges)
{
    Console.WriteLine(c);
}
```


### Cria��o de favorecido (API Avan�ada)

A API avan�ada tamb�m est� dispon�vel no SDK. Segue abaixo um exemplo de cria��o de favorecido, com os principais atributos (e objetos) relacionados.

```c#
Person person = new Person();
payee.Name = "Favorecido do SDK .NET";
payee.CpfCnpj = "11122233300";
payee.Email = "email@teste.com";
payee.Password = "senha";
payee.BirthDate = DateTime.Today.AddYears(-18);
payee.Phone = "(41) 91234-4321";
payee.LinesOfBusiness = "Linha de neg�cio";
payee.AccountHolder = new Person 
{ 
	Name = "Favorecido do SDK .NET", 
	CpfCnpj = "11122233300" 
};
payee.BankAccount = new BankAccount
{
	BankAccountType = BankAccountType.CHECKING,
    BankNumber = "237",
    AgencyNumber = "123",
    AccountNumber = "4567",
    AccountComplementNumber = 0
};
payee.Category = Category.OTHER;
payee.Address = new Address
{
    Street = "Rua Teste",
    Number = "123",
    City = "4106902",
    State = "PR",
    Postcode = "12345000"
};
payee.BusinessAreaId = 1000;

PayeeResponse response = boletoFacil.createPayee(payee);
if (response.isSuccess()) {
	System.out.println(response.getData());
}
```

A tabela com os c�digos de munic�pio do IBGE pode ser consultada [aqui](http://www.ibge.gov.br/home/geociencias/areaterritorial/area.shtm).

### Tokeniza��o do cart�o de cr�dito (API Avan�ada)

A tokeniza��o permite que o salvamento do cart�o de cr�dito para compras futuras no padr�o PCI. Segue abaixo um exemplo de tokeniza��o. 

```c#
Charge charge = new Charge
{
    CreditCardHash = "d6f15405-5870-4e30-8eee-db0f42bf74ce"
};

TokenizationResponse response = boletoFacil.CardTokenization(charge);
Console.WriteLine(response);
```



## Aplica��o cliente de exemplo

Juntamente com o projeto do SDK h� um outro projeto de um cliente de exemplo (aplica��o console) que cont�m exemplos de todas as chamadas disponibilizadas pelo SDK.


## Suporte

Em caso de d�vidas, problemas ou sugest�es, n�o hesite em contatar nossa [equipe de suporte](mailto:suporte@boletobancario.com).




