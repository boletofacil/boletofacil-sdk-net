using System;
using System.Collections.Generic;
using BoletoFacilSDK.Enums;
using BoletoFacilSDK.Exceptions;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;
using BoletoFacilSDK.Model.Request;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.UsageExample
{
    public class BoletoFacilClient
    {
        BoletoFacil boletoFacil;

        void MainMenu()
        {
            MainMenu(string.Empty);
        }

        public void MainMenu(string token)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine(" Geração de cobrança no ambiente Sandbox ");
            Console.WriteLine("=========================================");

            if (boletoFacil == null)
            {
                while (String.IsNullOrEmpty(token))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Digite o token do favorecido:");
                    token = Console.ReadLine();
                }

                boletoFacil = new BoletoFacil(BoletoFacilEnvironment.Sandbox, token);
            }

            bool validOption = false;
            while (!validOption)
            {
                ConsoleKeyInfo key = MenuOptions();
                validOption = true;

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        IssueCharge();
                        break;
                    case ConsoleKey.D2:
                        FetchBalance();
                        break;
                    case ConsoleKey.D3:
                        RequestTransfer();
                        break;
                    case ConsoleKey.D4:
                        CancelCharge();
                        break;
                    case ConsoleKey.D5:
                        ListCharges();
                        break;
                    case ConsoleKey.D6:
                        CreatePayee();
                        break;
                    case ConsoleKey.D7:
                        CreatePayeeFeeSchema();
                        break;
                    case ConsoleKey.D8:
                        GetPayeeStatus();
                        break;
                    case ConsoleKey.D9:
                        return;
                    default:
                        validOption = false;
                        break;
                }
            }
        }

        ConsoleKeyInfo MenuOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("");
            Console.WriteLine("1) Emitir uma cobrança");
            Console.WriteLine("2) Consultar saldo");
            Console.WriteLine("3) Solicitar transferência");
            Console.WriteLine("4) Cancelar uma cobrança");
            Console.WriteLine("5) Listar cobranças e pagamentos");
            Console.WriteLine("6) Criar um favorecido");
            Console.WriteLine("7) Criar esquema de taxas");
            Console.WriteLine("8) Consultar status de favorecido");
            Console.WriteLine("9) Encerrar o programa");
            Console.WriteLine("");
            Console.WriteLine("Entre a opção desejada:");
            return Console.ReadKey();
        }

        #region Request methods

        void IssueCharge()
        {
            Payer payer = new Payer();
            payer.Name = "Pagador teste - SDK .NET";
            payer.CpfCnpj = "18415256930";

            Charge charge = new Charge();
            charge.Description = "Cobrança teste gerada pelo SDK .NET";
            charge.Amount = 176.45m;
            charge.Payer = payer;
            charge.PaymentTypes = new PaymentType[] { PaymentType.BOLETO, PaymentType.CREDIT_CARD };

            try
            {
                ChargeResponse response = boletoFacil.IssueCharge(charge);
                ShowObjectResponseHeader();
                foreach (Charge c in response.Data.Charges)
                {
                    Console.WriteLine("");
                    Console.WriteLine(c);
                }
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void FetchBalance()
        {
            try
            {
                FetchBalanceResponse response = boletoFacil.FetchBalance(ResponseType.XML);
                ShowObjectResponseHeader();
                Console.WriteLine(response.Data);
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void RequestTransfer()
        {
            Console.WriteLine("");
            Console.WriteLine("Entre o valor (ou deixe em branco para transferir todo o saldo disponível):");
            string amountString = Console.ReadLine();

            decimal amount;
            Transfer transfer = new Transfer();
            if (decimal.TryParse(amountString, out amount))
            {
                transfer.Amount = amount;
            }

            try
            {
                var response = boletoFacil.RequestTransfer(transfer);
                ShowObjectResponseHeader();
                Console.WriteLine(response);
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void CancelCharge()
        {
            string code = null;

            while (String.IsNullOrEmpty(code))
            {
                Console.WriteLine("");
                Console.WriteLine("Entre o código da cobrança:");
                code = Console.ReadLine();
            }

            try
            {
                Charge charge = new Charge();
                charge.Code = code;
                var response = boletoFacil.CancelCharge(charge);
                ShowObjectResponseHeader();
                Console.WriteLine(response);
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void ListCharges()
        {
            ListChargesDates dates = new ListChargesDates();
            dates.BeginDueDate = DateTime.Today.AddDays(1);
            dates.EndDueDate = DateTime.Today.AddDays(5);

            try
            {
                var response = boletoFacil.ListCharges(dates);
                ShowObjectResponseHeader();
                foreach (Charge c in response.Data.Charges)
                {
                    Console.WriteLine("");
                    Console.WriteLine(c);
                }
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void CreatePayee()
        {
            string cpfCnpj = null;
            string email = null;

            while (String.IsNullOrEmpty(cpfCnpj))
            {
                Console.WriteLine("");
                Console.WriteLine("Entre o CPF/CNPJ do novo favorecido:");
                cpfCnpj = Console.ReadLine();
            }

            while (String.IsNullOrEmpty(email))
            {
                Console.WriteLine("");
                Console.WriteLine("Entre o email do novo favorecido:");
                email = Console.ReadLine();
            }

            Payee payee = new Payee();
            payee.Name = "Favorecido do SDK .NET";
            payee.CpfCnpj = cpfCnpj;
            payee.Email = email;
            payee.Password = "abacate";
            payee.BirthDate = DateTime.Today.AddYears(-19);
            payee.Phone = "(41) 99876-5432";
            payee.LinesOfBusiness = "bla";
            payee.AccountHolder = new Person { Name = "Favorecido do SDK .NET", CpfCnpj = cpfCnpj };
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
                Postcode = "80100010"
            };
            payee.BusinessAreaId = 1000;

            try
            {
                var response = boletoFacil.CreatePayee(payee);
                ShowObjectResponseHeader();
                Console.WriteLine(response.Data);
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void CreatePayeeFeeSchema()
        {
            Split split = new Split();
            split.SplitTriggerAmount = 2.25m;
            split.SplitVariable = 30;

            try
            {
                var response = boletoFacil.CreatePayeeFeeSchema(split);
                ShowObjectResponseHeader();
                Console.WriteLine(response.Data);
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        void GetPayeeStatus()
        {
            string cpfCnpj = null;

            while (String.IsNullOrEmpty(cpfCnpj))
            {
                Console.WriteLine("");
                Console.WriteLine("Entre o CPF/CNPJ do favorecido desejado:");
                cpfCnpj = Console.ReadLine();
            }

            Payee payee = new Payee();
            payee.CpfCnpj = cpfCnpj;

            try
            {
                var response = boletoFacil.GetPayeeStatus(payee);
                ShowObjectResponseHeader();
                Console.WriteLine(response.Data);
                ShowResponseSerialized(response);
            }
            catch (BoletoFacilException e)
            {
                HandleException(e);
            }
            finally
            {
                DoneMessage();
            }
        }

        #endregion

        #region Private methods

        void ShowObjectResponseHeader()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Resposta do servidor:");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("OBJETO ----------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
        }

        void ShowResponseSerialized(BaseResponse response)
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("SERIALIZADO EM JSON ---------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(response.ToJson());
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("SERIALIZADO EM XML ----------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(response.ToXml());
            Console.WriteLine("");
        }

        void HandleException(BoletoFacilException e)
        {
            Console.WriteLine("");
            Console.WriteLine(e.Message);
        }

        void DoneMessage()
        {
            Console.WriteLine("");
            Console.WriteLine("Aperte uma tecla para voltar ao menu principal...");
            Console.ReadKey();
            MainMenu();
        }

        #endregion
    }
}
