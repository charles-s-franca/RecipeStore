using System;
using System.Collections.Generic;

namespace RecipeStore.Domain
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public bool status { get; set; }
        public System.Net.HttpStatusCode code { get; set; }
        public string error_message { get; set; }
        public List<BusinessRule> brokenRules { get; set; }

        public static ApiResponse<T> CreateResponse(bool status, string message, T data, System.Net.HttpStatusCode code = System.Net.HttpStatusCode.Created, List<BusinessRule> rules = null)
        {
            var response = new ApiResponse<T>();
            response.status = status;
            response.error_message = message;
            response.data = data;
            response.brokenRules = rules;
            response.code = code;
            return response;
        }
    }
}
