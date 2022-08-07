using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity
{
    [Table("PasswordSessionsTest1")]
    public class PasswordRestoreSession
    {
        public int Id { get; set; }
        public int UID { get; set; }
        public string GUID { get; set; }
        public string DateOpened { get; set; }
        public string DateClosed { get; set; }
        public PasswordRestoreSession()
        {
            Id = 0;
            UID = 0;
            GUID = string.Empty;
            DateOpened = string.Empty;
            DateClosed = string.Empty;
        }
        public PasswordRestoreSession(int uid, string guid, string dateOpened, string dateClosed)
        {
            UID = uid;
            GUID = guid;
            DateOpened = dateOpened;
            DateClosed = dateClosed;
        }
        public PasswordRestoreSession(int id, int uid, string guid, string dateOpened, string dateClosed)
        {
            Id = id;
            UID = uid;
            GUID = guid;
            DateOpened = dateOpened;
            DateClosed = dateClosed;
        }
    }
}