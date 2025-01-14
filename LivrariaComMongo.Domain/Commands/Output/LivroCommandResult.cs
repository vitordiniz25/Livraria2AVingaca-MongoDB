﻿using Flunt.Notifications;
using LivrariaComMongo.Infra.Interfaces;

namespace LivrariaComMongo.Domain.Commands.Output
{
    public class LivroCommandResult : Notifiable, ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public LivroCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
