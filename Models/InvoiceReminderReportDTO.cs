using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace Using_Business_Objects_in_the_Report.Models
{
    public class AddressUserReportDTO 
    {
        public string? Name { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressCountry { get; set; }
        public string? AddressLine { get; set; }
        public string? AddressState { get; set; }
        public string? AddressZIP { get; set; }
    }
    public class ThirdPartyUserReportDTO
    {
        public string CustomerCode { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public int CustomerReminderLevel { get; set; } = 0!;
        public AddressUserReportDTO? Address { get; set; }
    }

    public class InvoiceUserReportDTO
    {
        public string InvoiceNumber { get; set; } = null!;
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public DateOnly InvoiceDate { get; set; }
        public DateOnly DueDate { get; set; }
    }

    public class InvoiceReminderUserReportDTO
    {
        public ThirdPartyUserReportDTO Customer { get; set; } = null!;
        public List<InvoiceUserReportDTO> Invoices { get; set; } = new();
        public DateOnly ReminderDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    }
    public static class InvoiceReminderUserReport 
    {
        
        public static IEnumerable<InvoiceReminderUserReportDTO> GetSample() => new List<InvoiceReminderUserReportDTO>()
        {
            new ()
            {
                Customer = new ThirdPartyUserReportDTO
                {
                    Address = new AddressUserReportDTO {AddressCity = "Geneva", AddressState = "Geneva", AddressCountry = "Switzerland"},
                    CustomerCode = "0001",
                    CustomerName = "ACME INC."
                },
                Invoices = new List<InvoiceUserReportDTO>
                {
                    new (){InvoiceNumber = "12345", Amount = 1000.50M, CurrencyCode = "CHF", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(5)), InvoiceDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-20))},
                    new (){InvoiceNumber = "12346", Amount = 990.50M, CurrencyCode = "CHF", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(4)), InvoiceDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-16))},
                    new (){InvoiceNumber = "12347", Amount = 12M, CurrencyCode = "CHF", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(2)), InvoiceDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-45))},
                }
            },
            new ()
            {
                Customer = new ThirdPartyUserReportDTO
                {
                    Address = new AddressUserReportDTO {AddressCity = "Boulder", AddressState = "CO", AddressCountry = "US"},
                    CustomerCode = "0002",
                    CustomerName = "WILL C. LDT"
                },
                Invoices = new List<InvoiceUserReportDTO>
                {
                    new (){InvoiceNumber = "3456", Amount = 1000.50M, CurrencyCode = "USD", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(5)), InvoiceDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-20))},
                    new (){InvoiceNumber = "3457", Amount = 990.50M, CurrencyCode = "USD", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(4)), InvoiceDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-16))},
                    new (){InvoiceNumber = "3458", Amount = 12M, CurrencyCode = "USD", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(2)), InvoiceDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-45))},
                }
            },
        };
    }
}
