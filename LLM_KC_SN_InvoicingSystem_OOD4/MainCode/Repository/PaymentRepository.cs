using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MainCode.Utilities.MainCodeStaticObjects;

namespace MainCode.Repository
{

    /// <summary>
    ///  A summary about PaymentRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the PaymentRepository class and methods 
    ///  public virtual List&lt;Payment&gt; ReadGetAllRows()
    ///  This method clones the payments from the predefines list payments to allpayments
    ///  <returns>
    ///  this method returns the list containing all payments with variable name payments
    ///  </returns> 
    ///  </remarks>
    public class PaymentRepository : RepositoryBase<Payment>
    {

        private static List<Payment> allPayments;

        public PaymentRepository()
        {
            allPayments = ReadGetAllRows();
        }
        public virtual List<Payment> ReadGetAllRows()
        {
            loggerMainCode.Info("Payments Repository: ReadGetAll method - gets all payments");

            allPayments = new List<Payment>();
            foreach (var pay in Payment.PaymentsDataset)
            {
                allPayments.Add(new Payment()
                {
                    PaymentID = pay.PaymentID,
                    InvoiceID = pay.InvoiceID,
                    PaymentDate = pay.PaymentDate,
                    PaymentMethod = pay.PaymentMethod,
                    Amount = pay.Amount,

                });
            }

            return allPayments;
        }

        public void SetDS(List<Payment> payments)
        {
            allPayments = payments;
            Payment.PaymentsDataset = allPayments;
        }

        public override bool AddEntity(Payment entity)
        {
            loggerMainCode.Info("Payments Repository: Add method - adds an payments");

            bool returnVal = false;
            try
            {

                Payment.PaymentsDataset.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add payment" + ex.ToString());
                loggerMainCode.Error("Error, cannot add payments" + ex.ToString());
            }
            return returnVal;
        }

        public override bool DeleteRow(int id)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Payments Repository: Delete method - deletes a payments");

                var ds = allPayments.FirstOrDefault(c => c.PaymentID == id);
                if (ds != null)
                {
                    allPayments.RemoveAll(c => c.PaymentID == id);
                    Payment.PaymentsDataset.RemoveAll(c => c.PaymentID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete Payments" + ex.ToString());
                loggerMainCode.Error("Error, cannot delete payments" + ex.ToString());
            }

            return returnVal;
        }

        public override bool UpdateEntity(Payment entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Payments Repository: ReadRowByID method - updating payments");

                var payment = Payment.PaymentsDataset.FirstOrDefault(a => a.PaymentID == entity.PaymentID);
                payment.PaymentID=entity.PaymentID;
                payment.InvoiceID=entity.InvoiceID;
                payment.PaymentDate = entity.PaymentDate;
                payment.PaymentMethod=entity.PaymentMethod;
                payment.Amount=entity.Amount;
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update Payemnt" + ex.ToString());
                loggerMainCode.Error("Error, cannot update payment" + ex.ToString());
            }

            return returnVal;
        }


        public virtual List<Payment> ReadRowByDate(string date)
        {


            loggerMainCode.Info("Payment Repository: ReadRowByDate method - passing in a date of the payment");

            PaymentRepository repository = new PaymentRepository();
            List<Payment> allOfThePayments = repository.ReadGetAllRows();

            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime dateTime;
            if (!DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                dateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }
            IEnumerable<Payment> payment = allOfThePayments.Where(c => c.PaymentDate.Date == dateTime.Date);
            List<Payment> payments = new List<Payment>();
            if (payment != null)
            {
                payments = payment.ToList();
            }
            else
            {
                payments = null;
            }
            return payments;
        }

        public virtual List<Payment> ReadRowByDate(string beginDate, string endDate)
        {
            loggerMainCode.Info("Payments Repository: ReadRowByID method - reads rows all payments between one date and another");

            PaymentRepository repository = new PaymentRepository();
            List<Payment> allOfThePayments = repository.ReadGetAllRows();

            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            if (!DateTime.TryParseExact(beginDate, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime))
            {
                beginDateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }

            DateTime endDateTime;
            if (!DateTime.TryParseExact(endDate, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime))
            {
                endDateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }
            IEnumerable<Payment> payment = allOfThePayments.Where(c => c.PaymentDate.Date >= beginDateTime.Date && c.PaymentDate.Date <= endDateTime.Date);
            List<Payment> payments = new List<Payment>();
            if (payment != null)
            {
                payments = payment.ToList();
            }
            else
            {
                payments = null;
            }
            return payments;
        }
        public List<Payment> ReadRowByPaymentMethod(string method)
        {
            loggerMainCode.Info("Payment Repository: ReadRowByPayment method - passing in a string method ");

            PaymentRepository repository = new PaymentRepository();
            List<Payment> allOfThePayments = repository.ReadGetAllRows();
            IEnumerable<Payment> payment = allOfThePayments.Where(c => c.PaymentMethod == method);
            List<Payment> payments = new List<Payment>();
            if (payment != null)
            {
                payments = payment.ToList();
            }
            else
            {
                payments = null;
            }
            return payments;
        }
    }

    
}
