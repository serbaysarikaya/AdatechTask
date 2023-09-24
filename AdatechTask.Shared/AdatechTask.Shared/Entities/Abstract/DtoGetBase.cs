using AdatechTask.Shared.Utilities.Results.ComplexTypes;

namespace AdatechTask.Shared.Entities.Abstract
{
    public class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
