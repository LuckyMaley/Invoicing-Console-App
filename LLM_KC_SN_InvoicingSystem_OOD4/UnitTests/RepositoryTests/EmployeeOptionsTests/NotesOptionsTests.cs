using MainCode.Models;
using MainCode.Repository;
using MainCode.Repository.CustomerOptions;
using MainCode.Repository.EmployeeOptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    [TestFixture]
    public class NotesOptionsTests
    {
        Mock<NotesRepository> _mockNotesrepository;
        Mock<RepositoryBase<Note>> _mockNotesRepositoryBase;


        NotesOptions _notesOptions;

        [SetUp]
        public void SetUp()
        {
            _mockNotesrepository = new Mock<NotesRepository>();
            _mockNotesRepositoryBase = new Mock<RepositoryBase<Note>>();

            _notesOptions = new NotesOptions(_mockNotesrepository.Object, _mockNotesRepositoryBase.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockNotesrepository = null;
            _mockNotesRepositoryBase = null;
            _notesOptions = null;
        }

        [Test]
        public void _01Test_FindNotesByID_ExpectedReadRowByIDNeverOccurs_WhenNotesIDDoesNotExist()
        {
            // Arrange
            int noteId = 11;
            var Note = new Note { NotesID = 11, InvoiceID = 11, EmployeeID = 422829, InvoiceNotes = "We hope this message finds you well. We're reaching out to remind you that invoice 10 is now overdue.", CreatedDate = new DateTime(2025, 4, 3, 11, 34, 0) };
            _mockNotesrepository.Setup(repo => repo.CheckIfIdExists(noteId)).Returns(false);
            _mockNotesrepository.Setup(repo => repo.ReadRowByID(noteId)).Returns(Note);

            // Act
            string NoteDetails = _notesOptions.FindNotesByID(noteId);

            // Assert
            _mockNotesrepository.Verify(c => c.ReadRowByID(noteId), Times.Never);
        }

        [Test]
        public void _02Test_FindNotesByID_ExpectedReadRowByIOccursOnce_WhenNotesIDDoesExist()
        {
            // Arrange
            int noteId = 10;
            var Note = new Note { NotesID = 10, InvoiceID = 10, EmployeeID = 322829, InvoiceNotes = "We hope this message finds you well. We're reaching out to remind you that invoice 10 is now overdue.", CreatedDate = new DateTime(2024, 4, 3, 11, 34, 0) };
            _mockNotesrepository.Setup(repo => repo.CheckIfIdExists(noteId)).Returns(true);
            _mockNotesrepository.Setup(repo => repo.ReadRowByID(noteId)).Returns(Note);

            // Act
            string NoteDetails = _notesOptions.FindNotesByID(noteId);

            // Assert
            _mockNotesrepository.Verify(c => c.ReadRowByID(noteId), Times.Once);
        }

        [Test]
        public void _03Test_FindNoteByID_ExpectedTrue_WhenNoteDetailExist()
        {
            // Arrange
            int noteId = 1;
            var Note = new Note { NotesID = 1, InvoiceID = 1, EmployeeID = 121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval.", CreatedDate = new DateTime(2024, 4, 3, 11, 34, 0) };
            _mockNotesrepository.Setup(repo => repo.CheckIfIdExists(noteId)).Returns(true);
            _mockNotesrepository.Setup(repo => repo.ReadRowByID(noteId)).Returns(Note);

            // Act
            string NoteDetails = _notesOptions.FindNotesByID(noteId);

            // Assert
            Assert.IsTrue(NoteDetails.Contains("ID: 1"));
            Assert.IsTrue(NoteDetails.Contains("Invoice ID: 1"));




        }

        [Test]
        public void _04Test_FindNoteByID_ExpectedTrue_WhenNoteDetailExist()
        {
            // Arrange
            int noteId = 10;
            var Note = new Note { NotesID = 10, InvoiceID = 10, EmployeeID = 322829, InvoiceNotes = "We hope this message finds you well. We're reaching out to remind you that invoice 10 is now overdue.", CreatedDate = new DateTime(2024, 4, 3, 11, 34, 0) };
            _mockNotesrepository.Setup(repo => repo.CheckIfIdExists(noteId)).Returns(false);
            _mockNotesrepository.Setup(repo => repo.ReadRowByID(noteId)).Returns(Note);

            // Act
            string NoteDetails = _notesOptions.FindNotesByID(noteId);


            // Assert
            Assert.IsFalse(NoteDetails.Contains(Note.NotesID.ToString()));
            Assert.IsFalse(NoteDetails.Contains(Note.InvoiceID.ToString()));
            Assert.IsFalse(NoteDetails.Contains(Note.EmployeeID.ToString()));
            Assert.IsFalse(NoteDetails.Contains(Note.InvoiceNotes));
            Assert.IsFalse(NoteDetails.Contains(Note.CreatedDate.ToString()));

        }

        [Test]
        public void _05Test_FindNoteByID_ExpectedTrue_WhenNoteDetailDoesNotExist()
        {
            // Arrange
            int noteId = 10;
            var Note = new Note { NotesID = 10, InvoiceID = 10, EmployeeID = 322829, InvoiceNotes = "We hope this message finds you well. We're reaching out to remind you that invoice 10 is now overdue.", CreatedDate = new DateTime(2024, 4, 3, 11, 34, 0) };
            _mockNotesrepository.Setup(repo => repo.CheckIfIdExists(noteId)).Returns(false);
            _mockNotesrepository.Setup(repo => repo.ReadRowByID(noteId)).Returns(Note);


            // Act
            string NoteDetails = _notesOptions.FindNotesByID(noteId);
            string expected = "Note does not exist, Please try again";


            // Assert
            Assert.IsTrue(NoteDetails.Contains(expected));
        }

        [Test]
        public void _06Test_FindNoteByDate_ExpectedFalse_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "03/04/2024";


            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyDate(date);
            string expected = "There is no note in that date";

            // Assert
            Assert.IsFalse(noteDetails.Contains(expected));
        }

        [Test]
        public void _07Test_FindNoteByDate_ExpectedTrue_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "03/04/2024";


            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyDate(date);
            string expected = "notes Date: 03 April 2024";

            // Assert
            Assert.IsTrue(noteDetails.Contains(expected));
        }


        [Test]
        public void _08Test_FindNoteByDate_ExpectedTrue_WhenInvoiceDateIsEmpty()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "";

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyDate(date);
            string expected = "No Date entered";

            // Assert
            Assert.IsTrue(noteDetails.Contains(expected));
        }

        [Test]
        public void _09Test_FindNoteByDate_ExpectedOccurOnce_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "03/04/2024";

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyDate(date);

            // Assert
            _mockNotesrepository.Verify(c => c.ReadRowByDate(date), Times.Once);
        }


        [Test]
        public void _10Test_FindNoteByDate_ExpectedMoreThanOne_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "03/04/2024";

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act

            string noteDetails = _notesOptions.FindnotesbyDate(date);

            // Assert
            Assert.IsTrue(noteDetails.Contains("ID: 1"));
            Assert.IsTrue(noteDetails.Contains("ID: 2"));
            Assert.IsTrue(noteDetails.Contains("ID: 3"));
        }

        [Test]
        public void _11Test_FindNoteByBetweenDate_ExpectedFalse_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "02/03/2024";
            string dateTwo = "10/03/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyBetweenDates(date, dateTwo);
            string expected = "There is no invoice between those dates";

            // Assert
            Assert.IsFalse(noteDetails.Contains(expected));
        }


        [Test]
        public void _12Test_FindNoteByBetweenDate_ExpectedTrue_WhenNoteDoesNotExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "01/04/2024";
            string dateTwo = "21/11/2024";
            string defaultDateString = "01/01/2018";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date,dateTwo)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyBetweenDates(date, dateTwo);
            string expected = "notes Date: 03 April 2024";

            // Assert
            Assert.IsTrue(noteDetails.Contains(expected)); 
        }

        [Test]
        public void _13Test_FindNoteByBetweenDate_ExpectedTrue_WhenOneNoteDateIsEmpty()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "";
            string dateTwo = "13/11/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyBetweenDates(date, dateTwo);
            string expected = "Please enter both beginning and end dates";

            // Assert
            Assert.IsTrue(noteDetails.Contains(expected));
        }

        [Test]
        public void _14Test_FindNoteByBetweenDate_ExpectedOccurOnce_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "01/04/2023";
            string dateTwo = "13/11/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date,dateTwo)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyBetweenDates(date, dateTwo);

            // Assert
            _mockNotesrepository.Verify(c => c.ReadRowByDate(date,dateTwo), Times.Once);





        }

        [Test]
        public void _15Test_FindNoteByBetweenDate_ExpectedMoreThanOne_WhenNoteDoesExist()
        {
            // Arrange
            List<Note> NotesDataSet = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
            };

            string date = "03/04/2024";
            string dateTwo = "03/04/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockNotesrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(NotesDataSet);
            _mockNotesrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _notesOptions.FindnotesbyBetweenDates(date, dateTwo);

            // Assert
            Assert.IsTrue(noteDetails.Contains("ID: 1"));
            Assert.IsTrue(noteDetails.Contains("ID: 2"));
        }
    }
}

