using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Stepforma_BR.Authorization;


public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        IdadeMinima requirement)
    {
        // Recuperando a data de nascimento através do context
        var dataNascimentoClaim = context.User.FindFirst(claim =>
            claim.Type == ClaimTypes.DateOfBirth);

        // Se a data for igual a null
        if(dataNascimentoClaim is null)
        {
            return Task.CompletedTask;
        }

        //Se não for nulo, convertemos a data do token para um datetime.
        var dataNascimento = Convert.ToDateTime(dataNascimentoClaim.Value);

        // Para calcularmos a idade corretamente vamos subtrair o ano atual pela idade
        var idadeUsuario = DateTime.Today.Year - dataNascimento.Year;

        /*
         if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario)):: Esta linha verifica
        se a data de nascimento do usuário é posterior a uma data calculada subtraindo a idade
        do usuário da data atual. Em outras palavras, verifica se o usuário já completou sua última
        idade aniversária.

        Se a condição acima for verdadeira, significa que o usuário ainda não completou seu aniversário
        no ano corrente. Portanto, idadeUsuario--; é executado. Isso decrementa a idade do usuário em 1,
        ajustando-a para a idade correta considerando a data atual e a data de nascimento.
         */
        if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario))idadeUsuario--;

        // Se a idade do nosso usuário for igual ou maior ao requerimento de idade
        if (idadeUsuario >= requirement.Idade)
            context.Succeed(requirement);

        return Task.CompletedTask;

    }
}
