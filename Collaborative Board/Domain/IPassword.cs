namespace Domain
{
    internal interface IPassword
    {
        string PasswordValue { get; set; }
        string Reset();
    }
}