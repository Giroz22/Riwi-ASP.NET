namespace ToDoApi.dtos.response
{
    public class TaskResponse
    {
        private int _id;
        private string _title;
        private string? _description;
        private string _status;
        private DateTime? _due_date;
        private DateTime _created_at;
        private DateTime _updated_at;
        private DateTime? _completed_at;

        public TaskResponse()
        {
            _id = 0;
            _title = "";
            _description = "";
            _status = "";
            _due_date = null;
            _created_at = DateTime.Now;
            _updated_at = DateTime.Now;
            _completed_at = null;
        }

        public TaskResponse(
            int id,
            string title,
            string? description,
            string status,
            DateTime due_date,
            DateTime created_at,
            DateTime updated_at,
            DateTime completed_at
        )
        {
            _id = id;
            _title = title;
            _description = description;
            _status = status;
            _due_date = due_date;
            _created_at = created_at;
            _updated_at = updated_at;
            _completed_at = completed_at;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string? Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Status
        {
            get{ return _status; }
            set { _status = value; }
        }

        public DateTime? Due_date
        {
            get { return _due_date; }
            set { _due_date = value; }
        }

        public DateTime Created_at
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        public DateTime Updated_at
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }

        public DateTime? Completed_at
        {
            get { return _completed_at; }
            set { _completed_at = value; }
        }
    }    
}