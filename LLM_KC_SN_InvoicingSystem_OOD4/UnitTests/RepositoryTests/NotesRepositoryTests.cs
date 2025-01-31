using MainCode.Models;
using MainCode.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryTests
{
    public class NotesRepositoryTests
    {
        NotesRepository repository;
        List<Note> notesList;
        List<Note> notesDS;

        [SetUp]
        public void init()
        {
            repository = new NotesRepository();
            notesList = new List<Note>();

            notesDS = new List<Note>
            {
                new Note{NotesID = 1,InvoiceID = 1,EmployeeID =121332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval." , CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =2,InvoiceID = 2,EmployeeID = 471332, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 2 is currently on hold pending approval. ",CreatedDate = new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =3 ,InvoiceID =3,EmployeeID = 357312, InvoiceNotes ="We hope you're doing well. This message is to inform you that invoice 3 is currently on hold pending approval. ",CreatedDate    =new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =4 ,InvoiceID =4,EmployeeID = 925470, InvoiceNotes ="We wanted to express our gratitude for your recent payment of invoice 4. Your promptness is greatly appreciated.",CreatedDate=new DateTime  (2024,4,3,11,34,0)},
                new Note{NotesID =5 ,InvoiceID =5,EmployeeID = 677538, InvoiceNotes ="We wanted to express our gratitude for your recent payment of invoice 5. Your promptness is greatly appreciated.",CreatedDate=  new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =6 ,InvoiceID =6,EmployeeID = 393411, InvoiceNotes ="We wanted to express our gratitude for your recent payment of invoice 6. Your promptness is greatly appreciated.",CreatedDate   =new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID =7 ,InvoiceID =7,EmployeeID = 794744, InvoiceNotes ="We wanted to express our gratitude for your recent payment of invoice 7. Your promptness is greatly appreciated.",CreatedDate=  new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID = 8 ,InvoiceID =8,EmployeeID = 192351, InvoiceNotes ="We hope this message finds you well. We're reaching out to remind you that invoice 8 is now overdue.",CreatedDate= new DateTime (2024,4,3,11,34,0) },
                new Note{NotesID = 9 ,InvoiceID =9 ,EmployeeID = 632724, InvoiceNotes ="We hope this message finds you well. We're reaching out to remind you that invoice 9 is now overdue.",CreatedDate=  new DateTime (2024,4,3,11,34,0)},
                new Note{NotesID = 10 ,InvoiceID =10,EmployeeID = 322829, InvoiceNotes ="We hope this message finds you well. We're reaching out to remind you that invoice 10 is now overdue.",CreatedDate=   new DateTime (2024,4,3,11,34,0)},
            };



        }

        [TearDown]
        public void teardown()
        {
            notesList = null;
            repository = null;
            notesDS = null;
            


        }


        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllNotes10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfNotExpected = 10;
            repository.SetDS(notesDS);

            //Act 
            notesList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfNotExpected, notesList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfNotExpected = 15;
            repository.SetDS(notesDS);

            //Act 
            notesList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfNotExpected, notesList.Count);
        }


        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllNotesTrue_WhenAdded1moreNote()
        {

            //arrange 
            Note note = new Note { NotesID = 11, InvoiceID = 11, EmployeeID = 161332, InvoiceNotes = "We hope you're doing well. This message is to inform you that invoice 1 is currently on hold pending approval.", CreatedDate = new DateTime(2024, 4, 4, 11, 34, 0) };
            bool expected = true;
            repository.SetDS(notesDS);

            //act
            bool actual = repository.AddEntity(note);



            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1Note()
        {

            //arrange 
            int noteID = 10;
            bool expected = true;
            repository.SetDS(notesDS);

            //act
            bool actual = repository.DeleteRow(noteID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _05Test_ReadGetAllRows_ExpectedReadgetallrowsisEqualtoNotesDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 

            List<Note> noteDSList = new List<Note>();
            repository.SetDS(notesDS);

            //Act 
            notesList = repository.ReadGetAllRows();
            noteDSList = Note.NotesDataSet.ToList();
            int noOfNotExpected = noteDSList.Count;

            //Assert 
            Assert.AreEqual(noOfNotExpected, Note.NotesDataSet.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06Test_ReadRowByID_Expected1RowEachTestCase_WhenExistingNoteIDIsPassedIn(int id)
        {
            //Arrange
            Note notes = new Note();
            repository.SetDS(notesDS);

            //Act
            notes = repository.ReadRowByID(id);

            //Assert
            Assert.IsNotNull(notes);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _07Test_ReadRowByID_ExpectedAreTheSameEachTestCase_WhenExistingNoteIDIsPassedIn(int id)
        {
            //Arrange
            Note noteOne = new Note();
            Note theSameNote = new Note();
            repository.SetDS(notesDS);

            //Act
            noteOne = repository.ReadRowByID(id);
            theSameNote = Note.NotesDataSet.FirstOrDefault(c => c.InvoiceID == id);

            //Assert
            Assert.AreEqual(noteOne.NotesID, theSameNote.NotesID);

        }

        [Test]
        public void _08Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(notesDS);


            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }
    }
}
