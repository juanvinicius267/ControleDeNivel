using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ControleDeNivel.Models.Helpers
{
    [DataContract]
    public class Result<T>
    {
        public Result()
        {
            HasError = true;
            InfoMessages = null;
            ErrorMessage = null;
            FullErrorMessage = null;
        }
        public Result(T _value, bool _hasError, string _infoMessages, string _errorMessage, string _fullErrorMessage)
        {
            Value = _value;
            HasError = _hasError;
            InfoMessages = _infoMessages;
            ErrorMessage = _errorMessage;
            FullErrorMessage = _fullErrorMessage;
        }
        public Result(bool _hasError, string _infoMessages, string _errorMessage, string _fullErrorMessage)
        {
            HasError = _hasError;
            InfoMessages = _infoMessages;
            ErrorMessage = _errorMessage;
            FullErrorMessage = _fullErrorMessage;
        }
        [DataMember]
        public T Value { get; set; }
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        public string InfoMessages { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string FullErrorMessage { get; set; }
    }
}
