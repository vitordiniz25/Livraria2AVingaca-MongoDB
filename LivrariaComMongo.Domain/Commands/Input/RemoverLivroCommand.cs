using Flunt.Notifications;
using LivrariaComMongo.Infra.Interfaces;
using System.Text.Json.Serialization;

namespace LivrariaComMongo.Domain.Commands.Input
{
    public class RemoverLivroCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public string Id { get; set; }

        public bool ValidarCommand()
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
                AddNotification("Id", "ID é um campo obrigatório");

            return Valid;
        }
    }
}
