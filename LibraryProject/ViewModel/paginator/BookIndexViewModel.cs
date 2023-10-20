namespace LibraryManagement.ViewModel
{
    public class BookIndexViewModel
    {
        public required List<BookViewModel> Book { get; set; }
        public required PaginationInfoViewModel PaginationInfo { get; set; }
    }
}