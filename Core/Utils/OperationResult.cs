using Core.Enums;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public class OperationResult
    {
        public OperationResult(bool success, string[] messageList = null, object data = null)
        {
            MessageList = messageList;
            Data = data;
            Success = success;
        }

        public OperationResult(bool success, object data = null)
        {
            Data = data;
            Success = success;
        }

        public OperationResult(bool success, string[] messageList)
        {
            MessageList = messageList;
            Success = success;
        }

        public OperationResult(FluentValidation.Results.ValidationResult validationResult)
        {
            Success = validationResult.IsValid;
            MessageList = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
        }

        public bool Success { get; private set; }
        public string[] MessageList { get; private set; }
        public MessageTypeEnum MessageType { get; private set; } = MessageTypeEnum.Success;
        public object Data { get; }
    }
}
