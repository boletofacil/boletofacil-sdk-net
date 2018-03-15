using System;
using System.Reflection;
using System.Text.RegularExpressions;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;
using BoletoFacilSDK.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests
{
    public abstract class AbstractTests
    {
        protected void AssertResult(string expected, string actual)
        {
            Assert.AreEqual(replaceBlanks(expected), replaceBlanks(actual));
        }
        protected T AssertException<T>(Func<object> func) where T : Exception
        {
            try
            {
                func.Invoke();
            }
            catch (T ex)
            {
                PropertyInfo[] props = ex.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                object[] args = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    args[i] = props[i].GetValue(ex);
                }
                try
                {
                    return (T)Activator.CreateInstance(ex.GetType(), args);
                }
                catch (MissingMethodException)
                {
                    return (T)Activator.CreateInstance(ex.GetType(), ex.Message);
                }
            }
            throw new AssertFailedException($"An exception of type {typeof(T)} was expected, but not thrown");
        }

        string replaceBlanks(string s)
        {
            return Regex.Replace(s, @"\s+", "");
        }

        protected DateTime StartDate => new DateTime(2013, 2, 19, 11, 21, 05);

        protected string BaseUrl => "https://boletofacil";

        protected Payer Payer
        {
            get
            {
                Payer payer = new Payer();
                payer.Name = "Pagador do SDK";
                payer.CpfCnpj = "00922156964";
                return payer;
            }
        }

        protected Charge Charge 
        {
            get
            {
                Charge charge = new Charge();
                charge.Description = "Teste de cobrança pelo SDK .NET";
                charge.Amount = 123.45m;
                charge.DueDate = StartDate;
                charge.Payer = Payer;
                return charge;
            }
        }

        protected Transfer Transfer 
        {
            get
            {
                Transfer transfer = new Transfer();
                return transfer;
            }
        }   

        protected ListChargesDates ListChargesDates 
        {
            get
            {
                ListChargesDates dates = new ListChargesDates();
                dates.BeginDueDate = StartDate.Date;
                dates.EndDueDate = StartDate.Date.AddDays(1);
                return dates;
            }
        }

        protected Person AccountHolder 
        {
            get
            {
                Person accountHolder = new Person();
                accountHolder.Name = "Favorecido do SDK";
                accountHolder.CpfCnpj = "18472019110";
                return accountHolder;
            }
        }   

        protected BankAccount BankAccount 
        {
            get
            {
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankNumber = "237";
                bankAccount.AgencyNumber = "1234";
                bankAccount.AccountNumber = "5678-9";
                bankAccount.BankAccountType = BankAccountType.CHECKING;
                return bankAccount;
            }
        }   

        protected Address Address 
        {
            get
            {
                Address address = new Address();
                address.Street = "Rua Teste SDK";
                address.Number = "S/N";
                address.City = "São Paulo";
                address.State = "SP";
                address.Postcode = "01010-100";
                return address;
            }
        }   

        protected Payee Payee 
        {
            get
            {
                Payee payee = new Payee();
                payee.Name = "Favorecido do SDK";
                payee.CpfCnpj = "18472019110";
                payee.Email = "email@email.com";
                payee.Password = "senha";
                payee.BirthDate = new DateTime(1980, 1, 1);
                payee.Phone = "3232-3232";
                payee.LinesOfBusiness = "Linhas_de_negocio";
                payee.AccountHolder = AccountHolder;
                payee.BankAccount = BankAccount;
                payee.Category = Category.OTHER;
                payee.Address = Address;
                payee.BusinessAreaId = 1000;
                return payee;
            }
        }   

        protected Split Split 
        {
            get
            {
                Split split = new Split();
                split.SplitTriggerAmount = 10;
                return split;
            }
        }   
    }
}
