using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeManagement.Services
{
    public class ModelStateWrapper : IValidationDictionary
    {
        private ModelStateDictionary _modelState;

        public ModelStateWrapper(ModelStateDictionary modelstate)
        {
            _modelState = modelstate;
        }

        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return _modelState.IsValid; }
        }
    }
}
