namespace ToDoApi.dtos.request
{
    public class TaskRequest
    {
        private string _title;
        private string? _description;
        private DateTime? _due_date;


        public TaskRequest()
        {            
            _title = "";
            _description = "";  
            _due_date = null;
        }
            
        public TaskRequest(string title, string? description, DateTime due_date)
        {            
            _title = title;
            _description = description;     
            _due_date = due_date;
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

        public DateTime? Due_date
        {
            get { return _due_date; }
            set { _due_date = value; }
        }

    }
}