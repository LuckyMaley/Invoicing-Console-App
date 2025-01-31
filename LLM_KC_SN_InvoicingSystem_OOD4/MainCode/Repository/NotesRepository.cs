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
    ///  A summary about NotesRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the NotesRepository class and methods 
    ///  public virtual List&lt;Notes&gt; ReadGetAllRows()
    ///  This method clones the Note from the predefines list note to allnote
    ///  <returns>
    ///  this method returns the list containing all note with variable name note
    ///  </returns> 
    ///  </remarks>
    public class NotesRepository : RepositoryBase<Note>, IRepository<Note>
    {
    
        private List<Note> allNotes;

        public NotesRepository()
        {
           allNotes = ReadGetAllRows(); 
        }

        public virtual Note ReadRowByID(int id)
        {
            loggerMainCode.Info("Notes Repository: ReadRowByID method - passing in an id of the Note");
            Note notes = allNotes.FirstOrDefault(c => c.NotesID == id);
            return notes;
        }

        public virtual bool CheckIfIdExists(int id)
        {
            loggerMainCode.Info("Notes Repository: ChecksIfIdExists method - passes in ID");
            var noteCheck = allNotes.FirstOrDefault(c => c.NotesID == id);
            bool valid = false;
            if (noteCheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public override bool DeleteRow(int id)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Notes Repository: Delete method - deleting a note");
                var ds = allNotes.FirstOrDefault(c => c.NotesID == id);
                if (ds != null)
                {
                    allNotes.RemoveAll(c => c.NotesID == id);
                    Note.NotesDataSet.RemoveAll(c => c.NotesID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete note" + ex.ToString());
                loggerMainCode.Error("Error, cannot delete note" + ex.ToString());
            }

            return returnVal;
        }

        public override bool AddEntity(Note entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Notes Repository: Add method - adds a note");
                Note.NotesDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add note" + ex.ToString());
                loggerMainCode.Error("Error, cannot add note" + ex.ToString());
            }
            return returnVal;

        }

        public override bool UpdateEntity(Note entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Notes Repository: UpdateEntity method - updating note");
                var note = Note.NotesDataSet.FirstOrDefault(c => c.NotesID == entity.NotesID);
                note.NotesID = entity.NotesID;
                note.InvoiceID = entity.InvoiceID;
                note.EmployeeID = entity.EmployeeID;
                note.InvoiceNotes = entity.InvoiceNotes;
                note.CreatedDate = entity.CreatedDate;
                

                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update note" + ex.ToString());
                loggerMainCode.Error("Error, cannot update note" + ex.ToString());
            }

            return returnVal;
        }

        public virtual List<Note> ReadGetAllRows()
        {
            loggerMainCode.Info("Notes Repository: ReadGetAllRows method - gets all notes");

            allNotes = new List<Note>();
            foreach (var nt in Note.NotesDataSet)
            {
                allNotes.Add(new Note()
                {
                    NotesID = nt.NotesID,
                    InvoiceID= nt.InvoiceID,
                    EmployeeID= nt.EmployeeID,
                    InvoiceNotes = nt.InvoiceNotes,
                    CreatedDate= nt.CreatedDate,
                }
                );
            }
            return allNotes;

        }

        public void SetDS(List<Note> notes)
        {
            allNotes = notes;
            Note.NotesDataSet = allNotes;
        }

        public virtual List<Note> ReadRowByDate(string date)
        {
            loggerMainCode.Info("Notes Repository: ReadRowByDate method - passing in an date of the note");

            NotesRepository repository = new NotesRepository();
            List<Note> allOfTheNotes = repository.ReadGetAllRows();

            string defaultDateString = "01/03/2024";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime dateTime;
            if (!DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                dateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }
            IEnumerable<Note> note = allOfTheNotes.Where(c => c.CreatedDate.Date == dateTime.Date);
            List<Note> notes = new List<Note>();
            if (note != null)
            {
                notes = notes.ToList();
            }
            else
            {
                notes = null;
            }
            return notes;
        }

        public virtual List<Note> ReadRowByDate(string beginDate, string endDate)
        {
            loggerMainCode.Info("Notes Repository: ReadRowByDate method - passing in different dates of the note");

            NotesRepository repository = new NotesRepository();
            List<Note> allOfTheNotes = repository.ReadGetAllRows();

            string defaultDateString = "10/02/2024";
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
            IEnumerable<Note> note = allOfTheNotes.Where(c => c.CreatedDate.Date >= beginDateTime.Date && c.CreatedDate.Date <= endDateTime.Date);
            List<Note> notes = new List<Note>();
            if (note != null)
            {
                notes = note.ToList();
            }
            else
            {
                notes = null;
            }
            return notes;
        }
        
    }
}

