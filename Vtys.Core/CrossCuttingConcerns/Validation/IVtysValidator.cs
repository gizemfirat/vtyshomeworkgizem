namespace Vtys.Core.CrossCuttingConcerns.Validation
{
    public interface IVtysValidator
    {
        void Validate(object instance);
    }
}
