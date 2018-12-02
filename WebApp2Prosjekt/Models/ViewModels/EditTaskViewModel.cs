namespace WebApp2Prosjekt.Models.ViewModels
{
    public class EditTaskViewModel
    {
        public int TasksId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int SpecialityFieldId { get; set; }

        public bool Complete { get; set; }

        public int Lines { get; set; }

    }
}
