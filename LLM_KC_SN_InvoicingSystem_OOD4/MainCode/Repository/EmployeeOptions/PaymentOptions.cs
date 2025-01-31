using MainCode;
using MainCode.Models;
using MainCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.EmployeeOptions
{
    
    public class PaymentOptions
    {
        private PaymentRepository paymentsRepository;
        private RepositoryBase<Payment> paymentsRepositoryBase;
        public PaymentOptions(PaymentRepository _paymentsRepository, RepositoryBase<Payment> _paymentsRepositoryBase)
        {
            paymentsRepository = _paymentsRepository;
            paymentsRepositoryBase = _paymentsRepositoryBase;
        }

        public string FindPaymentsbyDate(string inputDate)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            if (inputDate != "")
            {
                List<Payment> payments = paymentsRepository.ReadRowByDate(inputDate);
                if (payments != null)
                {
                    payments.ForEach(b => stringBuilder.AppendLine($"ID: {b.PaymentID}, Payment Date: {b.PaymentDate.ToString("dd MMMM yyyy HH:mm")}, Payment Method: {b.PaymentMethod}, Amount: {b.Amount}"));
                }
                else
                {
                    stringBuilder.AppendLine("There is no payment in that date");
                }
            }
            else
            {
                stringBuilder.AppendLine("No Date entered");
            }
            return stringBuilder.ToString();
        }

        public string FindPaymentsbyBetweenDates(string inputDate, string inputDateTwo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            if (inputDate != "" && inputDateTwo != "")
            {
                List<Payment> payments = paymentsRepository.ReadRowByDate(inputDate, inputDateTwo);
                if (payments != null)
                {
                    payments.ForEach(b => stringBuilder.AppendLine($"ID: {b.PaymentID}, Payment Date: {b.PaymentDate.ToString("dd MMMM yyyy HH:mm")}, Payment Method: {b.PaymentMethod}, Amount: {b.Amount}, "));
                }
                else
                {
                    stringBuilder.AppendLine("There is no payment between those dates");
                }
            }
            else
            {
                stringBuilder.AppendLine("Please enter both beginning and end dates");
            }
            return stringBuilder.ToString();
        }

        public string FindPaymentsByMethod(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            List<Payment> payments = paymentsRepository.ReadRowByPaymentMethod(input);
            if (payments.Count > 0)
            {
                payments.ForEach(b => stringBuilder.AppendLine($"ID: {b.PaymentID}, Payment Date: {b.PaymentDate.ToString("dd MMMM yyyy HH:mm")}, Payment Method: {b.PaymentMethod}, Amount: {b.Amount}"));
            }
            else
            {
                stringBuilder.AppendLine("There is no payment between those dates");
            }
            return stringBuilder.ToString();
        }

    }
}
