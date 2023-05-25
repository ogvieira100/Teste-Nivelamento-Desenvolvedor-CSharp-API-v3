
using Questao5.Infrastructure.CrossCutting;
namespace Questao5.Domain.Language

{

    public enum LanguageChoice
    { 
        
        Portuguese = 1,
        Ingles = 2,
        French = 3,
    
    }
    public class LanguageSystem: ILanguageSystem
    {

        readonly IConfiguration _configuration;

        LanguageChoice _languageChoice;
        public LanguageSystem(IConfiguration configuration )
        {
            _configuration = configuration;
            ChoiceLanguage();
        }

        void ChoiceLanguage()
        {
            _languageChoice = _configuration.GetSection("Language").Value
                                   .GetEnumToName(LanguageChoice.Portuguese);
        }

        public string SuccessMessage()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Dados Atualizados com Sucesso";
                case LanguageChoice.Ingles:
                    return "Data Updated Successfully";
                case LanguageChoice.French:
                    return "Données mises à jour avec succès";
                default:
                    return "Dados Atualizados com Sucesso";
            }
        }

        public string ErrorMessage()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Ops Houve Algum Problema.";
                case LanguageChoice.Ingles:
                    return "Oops there was a problem";
                case LanguageChoice.French:
                    return "Oups il y a eu un problème";
                default:
                    return "Dados Atualizados com Sucesso";
            }
        }

        public string InvalidAccount()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção conta corrente não cadastrada";
                case LanguageChoice.Ingles:
                    return "Attention not registered checking account";
                case LanguageChoice.French:
                    return "Attention compte courant non enregistré";
                default:
                    return "Atenção conta corrente não cadastrada";
            }
        }

        public string InvalidValue()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção valor inválido";
                case LanguageChoice.Ingles:
                    return "Attention invalid value";
                case LanguageChoice.French:
                    return "Attention valeur invalide";
                default:
                    return "Dados Atualizados com Sucesso";
            }
        }

        public string InactiveAccount()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção conta inativa";
                case LanguageChoice.Ingles:
                    return "Attention inactive account";
                case LanguageChoice.French:
                    return "Attention compte inactif";
                default:
                    return "Atenção conta inativa";
            }
        }

        public string InvalidType()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção tipo da movimentação inválido";
                case LanguageChoice.Ingles:
                    return "Warning Invalid move type";
                case LanguageChoice.French:
                    return "Avertissement Type de mouvement invalide";
                default:
                    return "Atenção tipo da movimentação inválido";
            }
        }
    }
}
