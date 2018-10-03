using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Domain
{
    public class BusinessRuleException : Exception
    {
        public List<BusinessRule> brokenRules { get; set; }

        public BusinessRuleException() : this("", null)
        {

        }

        public BusinessRuleException(string message) : this(message, null)
        {

        }

        public BusinessRuleException(string message, List<BusinessRule> brokenRules) : base(message)
        {
            this.brokenRules = brokenRules;
        }
    }
}
