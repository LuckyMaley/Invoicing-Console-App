using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.EmployeeOptions
{
    public class NotesOptions
    {
        private NotesRepository notesRepository;
        private RepositoryBase<Note> notesRepositoryBase;
        public NotesOptions(NotesRepository _notesRepository, RepositoryBase<Note> _notesRepositoryBase)
        {
            notesRepository = _notesRepository;
            notesRepositoryBase = _notesRepositoryBase;
        }

        public string FindNotesByID(int noteID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            NotesRepository cusRepository = new NotesRepository();
            List<Note> allOfTheNotes = notesRepository.ReadGetAllRows();
            //List<Discount> allOfTheDiscounts = discountsRepository.ReadGetAllRows();
            CultureInfo ci = new CultureInfo("en-za");

            bool valid = notesRepository.CheckIfIdExists(noteID);
            if (valid)
            {
                var note = notesRepository.ReadRowByID(noteID);
                stringBuilder.AppendLine($"ID: {note.NotesID}, Notes: {note.NotesID} , EmployeeID : {note.EmployeeID}, Created Date: {note.CreatedDate.ToString("dd MMMM yyyy HH:mm")}, Invoice ID: {note.InvoiceID},  Note: {note.InvoiceNotes}");

            }
            else
            {
                stringBuilder.AppendLine("Note does not exist, Please try again");
            }

            return stringBuilder.ToString();
        }

        public string FindnotesbyDate(string inputDate)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (inputDate != "")
            {
                List<Note> notes = notesRepository.ReadRowByDate(inputDate);
                if (notes != null)
                {
                    notes.ForEach(b => stringBuilder.AppendLine($"ID: {b.NotesID}, notes Date: {b.CreatedDate.ToString("dd MMMM yyyy HH:mm")}, Message: {b.InvoiceNotes}"));
                }
                else
                {
                    stringBuilder.AppendLine("There is no notes in that date");
                }
            }
            else
            {
                stringBuilder.AppendLine("No Date entered");
            }
            return stringBuilder.ToString();
        }

        public string FindnotesbyBetweenDates(string inputDate, string inputDateTwo)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (inputDate != "" && inputDateTwo != "")
            {
                List<Note> notes = notesRepository.ReadRowByDate(inputDate, inputDateTwo);
                if (notes != null)
                {
                    notes.ForEach(b => stringBuilder.AppendLine($"ID: {b.NotesID}, notes Date: {b.CreatedDate.ToString("dd MMMM yyyy HH:mm")}, Amount: {b.InvoiceNotes}, "));
                }
                else
                {
                    stringBuilder.AppendLine("There are no notes between those dates");
                }
            }
            else
            {
                stringBuilder.AppendLine("Please enter both beginning and end dates");
            }
            return stringBuilder.ToString();
        }

    }
}
