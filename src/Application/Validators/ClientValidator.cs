using System.Text.RegularExpressions;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.Validators
{
    public partial class ClientValidator
    {

        public Dictionary<string, List<string>> ValidateCreateClient(Client client)
        {
            var errors = new Dictionary<string, List<string>>();

            var nameErros = ValidateName(client.Nome);
            if (nameErros.Count > 0) errors["name"] = nameErros;

            var bornDateErros = ValidateBornDate(client.DataNascimento);
            if (bornDateErros.Count > 0) errors["bornDate"] = bornDateErros;

            var genderErrors = ValidateGender(client.Sexo);
            if (genderErrors.Count > 0) errors["gender"] = genderErrors;

            var purchaseLimitErrors = ValidatePurchaseLimit(client.LimiteCompra);
            if (purchaseLimitErrors.Count > 0) errors["purchaseLimit"] = purchaseLimitErrors;

            return errors;
        }

        public List<string> ValidateName(string name)
        {
            List<string> errors = [];
            if (name.Length < 3 || name.Length > 150)
            {
                errors.Add("O nome deve ter entre 3 a 150 caracteres");
            }
            if (name != name.Trim())
            {
                errors.Add("O nome não pode ter espaços em branco no início ou no final.");
            }
            if (!MyRegex().IsMatch(name))
            {
                errors.Add("O nome não pode conter caracteres especiais.");
            }
            return errors;
        }

        public List<string> ValidateBornDate(DateTime bornDate)
        {
            List<string> errors = new List<string>();
            if (bornDate > DateTime.Now)
            {
                errors.Add("A data de nascimento não pode ser no futuro.");
            }
            if (bornDate == default(DateTime))
            {
                errors.Add("A data de nascimento não pode ser inválida.");
            }
            return errors;
        }

        public List<string> ValidateGender(bool? gender)
        {
            var errors = new List<string>();

            if (gender == null)
            {
                errors.Add("O campo sexo é obrigatório.");
            }

            return errors;
        }

        public List<string> ValidatePurchaseLimit(decimal? purchaseLimit)
        {
            var errors = new List<string>();

            if (purchaseLimit == null)
            {
                errors.Add("O limite de compra é obrigatório.");
            }
            else if (purchaseLimit < 0)
            {
                errors.Add("O limite de compra não pode ser negativo.");
            }
            else if (decimal.Round(purchaseLimit.Value, 2) != purchaseLimit.Value)
            {
                errors.Add("O limite de compra deve ter no máximo duas casas decimais.");
            }

            return errors;
        }


        [GeneratedRegex(@"^[a-zA-Z0-9\s]+$")]
        private static partial Regex MyRegex();
    }
}