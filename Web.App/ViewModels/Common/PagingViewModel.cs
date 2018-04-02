namespace Web.App.ViewModels.Common
{
    public class PagingViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int ObjectsCount { get; set; }

        public bool IsModelChanged { get; set; }
    }
}