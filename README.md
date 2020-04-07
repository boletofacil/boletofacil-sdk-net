## SDK .NET para integração com o Boleto Fácil

Este SDK (Software Development Kit) para o Boleto Fácil tem como objetivo abstrair, para desenvolvedores de aplicações na plataforma .NET, os detalhes de comunicação com a [API do Boleto Fácil](https://www.boletobancario.com/boletofacil/integration/integration.html), tanto com o servidor de [produção](https://www.boletobancario.com/boletofacil/) como com o servidor de testes ([sandbox](https://sandbox.boletobancario.com/boletofacil/)), de modo que o desenvolvedor possa se concentrar na lógica de negócio de sua aplicação.

## Requisitos

* Portable Class Library (.NETFramework 4.5, Windows 8.0)

## Integração

#### NuGet

O SDK .NET do Boleto Fácil está disponível no NuGet: https://www.nuget.org/packages/boletofacilsdk

## Limitações

O único item da API do Boleto Fácil que essa SDK não contempla é a [notificação de pagamentos](https://www.boletobancario.com/boletofacil/integration/integration.html#notificacao) para aplicações Web, através da URL de notificação. Nesse caso, tanto a lógica de captura das requisições POST enviadas pelo Boleto Fácil com os dados dos pagamentos como a lógica da baixa das cobranças pagas ficam a cargo do sistema integrado com o Boleto Fácil.

## Guia de uso

Para usar o SDK do Boleto Fácil é necessário definir dois itens:

1. O ambiente: produção (`PRODUCTION`) ou testes (`SANDBOX`)
2. O token do favorecido, o qual deve ser definido na área de **integração** do ambiente escolhido ([aqui](https://www.boletobancario.com/boletofacil/integration/integration.html#token) para produção ou [aqui](https://sandbox.boletobancario.com/boletofacil/integration/integration.html#token) para sandbox)

Exemplo:
```c#
// Cria uma instância do SDK que irá enviar requisições ao ambiente de testes do Boleto Fácil (Sandbox)
BoletoFacil boletoFacil = new BoletoFacil(BoletoFacilEnvironment.SANDBOX, "XYZ12345"); // XYZ12345 is the API key
```

### Gerando uma cobrança

`Charge` é a classe que representa uma cobrança do Boleto Fácil e que contém os atributos relacionados a ela, que 
são exatamente os atributos disponibilizados pela API do Boleto Fácil e podem ser conferidos [aqui](https://www.boletobancario.com/boletofacil/integration/integration.html#cobrancas). 

Dentre os atributos da cobrança estão os dados do pagador, que são definidos na classe `Payer`.

```c#
Payer payer = new Payer();
payer.Name = "Pagador teste - SDK .NET";
payer.CpfCnpj = "11122233300";

Charge charge = new Charge();
charge.Description = "Cobrança teste gerada pelo SDK .NET";
charge.Amount = 176.45m;
charge.Payer = payer;

ChargeResponse response = boletoFacil.IssueCharge(charge);
foreach (Charge c in response.Data.Charges)
{
    Console.WriteLine(c);
}
```

A classe `ChargeResponse` indica se a requisição foi bem sucedida ou não (da mesma forma que todas as classes que herdam da superclasse `Response` no SDK) e, além disso, contém a lista de cobranças que foram geradas pela requisição, em uma lista de objetos do tipo `Charge`.


### Consulta de saldo

Por padrão, as requisições feitas pelo SDK desserializam o retorno em **JSON** para popular os objetos com as informações das requisições, mas o SDK também provê a possibilidade de alterar a formatação do retorno da API para **XML**, conforme pode ser visto no exemplo abaixo:

```c#
FetchBalanceResponse response = boletoFacil.FetchBalance(ResponseType.XML);
Console.WriteLine(response.Data);
```


### Solicitação de transferência

Mesmo que se deseje solicitar uma transferência com o saldo total, é necessário passar um parâmetro da classe `Transfer`, sem o atributo `amount` definido, no caso.

```c#
Transfer transfer = new Transfer();
TransferResponse response = boletoFacil.RequestTransfer(transfer);
Console.WriteLine(response);
```

Como a resposta de solicitação transferência contém apenas se a requisição foi bem sucedida ou não, não se aplica o método `getData()` para ela.


### Consulta de pagamentos e cobranças

Para esta requisição, é usado um objeto da classe `ListChargesDates` para definir as datas usadas no filtro da consulta. No exemplo abaixo, são usadas apenas as datas de vencimento das cobranças desejadas.

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


### Criação de favorecido (API Avançada)

A API avançada também está disponível no SDK. Segue abaixo um exemplo de criação de favorecido, com os principais atributos (e objetos) relacionados.

```c#
Person person = new Person();
payee.Name = "Favorecido do SDK .NET";
payee.CpfCnpj = "11122233300";
payee.Email = "email@teste.com";
payee.Password = "senha";
payee.BirthDate = DateTime.Today.AddYears(-18);
payee.Phone = "(41) 91234-4321";
payee.LinesOfBusiness = "Linha de negócio";
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

A tabela com os códigos de município do IBGE pode ser consultada [aqui](http://www.ibge.gov.br/home/geociencias/areaterritorial/area.shtm).

### Tokenização do cartão de crédito (API Avançada)

A tokenização permite que o salvamento do cartão de crédito para compras futuras no padrão PCI. Segue abaixo um exemplo de tokenização. 

```c#
Charge charge = new Charge
{
    CreditCardHash = "d6f15405-5870-4e30-8eee-db0f42bf74ce"
};

TokenizationResponse response = boletoFacil.CardTokenization(charge);
Console.WriteLine(response);
```


## Aplicação cliente de exemplo

Juntamente com o projeto do SDK há um outro projeto de um cliente de exemplo (aplicação console) que contém exemplos de todas as chamadas disponibilizadas pelo SDK.


## Suporte

Em caso de dúvidas, problemas ou sugestões, não hesite em contatar nossa [equipe de suporte](mailto:suporte@boletobancario.com).

