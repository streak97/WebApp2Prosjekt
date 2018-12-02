namespace WebApp2Prosjekt.Models.ViewModels
{
    /// <summary>
    /// ViewModel for creating a new task
    /// </summary>
    public class PayForTaskViewModel
    {
        public int TasksId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Complete { get; set; }

        public int Lines { get; set; }
    }
}
