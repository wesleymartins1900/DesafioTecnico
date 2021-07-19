namespace Services
{
    public class ErrorMessages
    {
        // Erros Fluent Validation
        public const string CampoVazioOuInvalido = "O campo está vazio ou inválido!";

        public const string CampoComCaracteresAcimaDoPermitido14 = "O campo permite no máximo 14 caracteres!";
        public const string CampoComCaracteresAcimaDoPermitido100 = "O campo permite no máximo 100 caracteres!";
        public const string CampoComCaracteresAcimaDoPermitido200 = "O campo permite no máximo 200 caracteres!";

        // Erros API Controller
        public const string NaoEPossivelRemoverOFilmeNaoEstaCadastrado = "Não encontramos este filme!";
    }
}