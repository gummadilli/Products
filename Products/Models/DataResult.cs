using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace Products.Models
{
    public class DataResult<T> : ObjectResult where T : class
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model"></param>
        public DataResult(ApiData<T> model) : base(model)
        {
            StatusCode = model.Status;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        public DataResult(int statusCode, T data, ValidationResultModel errors)
            : base(new ApiData<T>(statusCode, data, errors))
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <param name="modelState"></param>
        public DataResult(int statusCode, T data, ModelStateDictionary modelState)
            : base(new ApiData<T>(statusCode, data, modelState))
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        public DataResult(int statusCode, T data)
            : base(new ApiData<T>(statusCode, data))
        {
            StatusCode = statusCode;
        }
    }

    public class ApiData<T>
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public ValidationResultModel Errors { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public int Status { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        public ApiData(int statusCode, T data, ValidationResultModel errors)
        {
            Data = data;
            Errors = errors;
            Status = statusCode;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <param name="modelState"></param>
        public ApiData(int statusCode, T data, ModelStateDictionary modelState)
        {
            Data = data;
            Errors = new ValidationResultModel(modelState);
            Status = statusCode;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        public ApiData(int statusCode, T data)
        {
            Data = data;
            Errors = null;
            Status = statusCode;
        }

        public ApiData()
        {

        }
    }

    public class ValidationResultModel
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// All Errors
        /// </summary>
        public List<ValidationError> Errors { get; set; }

        /// <summary>
        /// Constructor from Model State
        /// </summary>
        /// <param name="modelState"></param>
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }
        /// <summary>
        /// Constructor from Manual Errors
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errors"></param>
        public ValidationResultModel(string message, List<ValidationError> errors = null)
        {
            Message = message;
            Errors = errors;
        }

        /// <summary>
        /// Update A Model State with Errors
        /// </summary>
        /// <param name="modelState"></param>
        public void UpdateModelState(ModelStateDictionary modelState)
        {
            modelState.AddModelError("", Message);
            if (Errors != null)
            {
                Errors.ForEach(e => modelState.AddModelError(e.Field, e.Message));
            }
        }

        public ValidationResultModel()
        {

        }
    }

    public class ValidationError
    {
        /// <summary>
        /// Field Name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="field"></param>
        /// <param name="message"></param>
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }

        public ValidationError()
        {

        }
    }
}
