namespace ToDoApi.Models
{
    public class Note
    {
        private int _id;
        private string _title;
        private string? _description;
        private StatusNote _status;
        private DateTime? _due_date;
        private DateTime _created_at;
        private DateTime _updated_at;
        private DateTime? _completed_at;
        private bool _deleted;

        public Note()
        {
            _id = 0;
            _title = "";
            _description = "";
            _status = Status.Pending;
            _due_date = null;
            _created_at = DateTime.Now;
            _updated_at = DateTime.Now;
            _completed_at = null;
            _deleted = "";
        }

        public Note(id, title, description, status, due_date, created_at, updated_at, completed_at, deleted)
        {
            _id = id;
            _title = title;
            _description = description;
            _status = status;
            _due_date = due_date;
            _created_at = created_at;
            _updated_at = updated_at;
            _completed_at = completed_at;
            _deleted = deleted;
        }

        public Id()
        {
            get{return id;}
            set{id = value;}
        }

        public Title()
        {
            get{return title;}
            set{title = value;}
        }

        public Description()
        {
            get{return description;}
            set{description = value;}
        }

        public Status()
        {
            get{return status;}
            set{status = value;}
        }

        public Due_date()
        {
            get{return due_date;}
            set{due_date = value;}
        }

        public Created_at()
        {
            get{return created_at;}
            set{created_at = value;}
        }

        public Updated_at()
        {
            get{return updated_at;}
            set{updated_at = value;}
        }

        public Completed_at()
        {
            get{return completed_at;}
            set{completed_at = value;}
        }

        public Deleted()
        {
            get{return deleted;}
            set{deleted = value;}
        }

        // Métodos para manipular los datos
        public void MarkAsCompleted()
        {
            _status = TaskStatus.Completed;
            _completedAt = DateTime.Now;
        }

        public void UpdateStatus(string newStatus)
        {
            _status = newStatus;
            _updatedAt = DateTime.Now;
        }

    }
}