using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Notes model which contains the properties of the Notes and the Notes dataset.
    /// 
    /// The properties include NotesId, InvoiceId,EmployeeId,Note, CreatedDate.
    /// The Notes dataset includes a list of 10 Notes records.
    /// </summary>
    public class Note
    {
        public int NotesID { get; set; }
        public int InvoiceID { get; set; }
        public int EmployeeID { get; set; }
        public string InvoiceNotes { get; set; }
        public DateTime CreatedDate { get; set; }

        public static List<Note> NotesDataSet = new List<Note>
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
}




	
	
	
	
	

	
