namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        //kullanıcıya mesaj dondurerek : 
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //message dondurmeden
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //sadece message alip, default data degeriyle dondurerek
        //aşağıdaki default data'ya karşılık geliyor
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
