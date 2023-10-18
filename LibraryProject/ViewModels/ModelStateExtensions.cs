using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryManagement.ViewModel
{
    public static class ModelStateExtensions
    {
        //Having problem with modelState? USe this dictionary!
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}
