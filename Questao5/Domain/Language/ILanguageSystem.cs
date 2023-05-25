namespace Questao5.Domain.Language
{
    public interface ILanguageSystem
    {

        string SuccessMessage();

        string ErrorMessage();


        string InvalidAccount();

        string InvalidValue();


        string InactiveAccount();

        string InvalidType();


    }
}
