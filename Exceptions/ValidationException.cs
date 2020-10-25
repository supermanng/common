﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using FluentValidation.Results;
//
//namespace Etechnosoft.Common.Exceptions
//{
//    public class ValidationException : Exception
//    {
//        public ValidationException()
//            : base("One or more validation failures have occurred.")
//        {
//            Failures = new Dictionary<string, string[]>();
//        }
//
//        public ValidationException(Dictionary<string, string[]> failures)
//        {
//            this.Failures = failures;
//        }
//        public ValidationException(List<ValidationFailure> failures)
//            : this()
//        {
//            var propertyNames = failures
//                .Select(e => e.PropertyName)
//                .Distinct();
//
//            foreach (var propertyName in propertyNames)
//            {
//                var propertyFailures = failures
//                    .Where(e => e.PropertyName == propertyName)
//                    .Select(e => e.ErrorMessage)
//                    .ToArray();
//
//                Failures.Add(propertyName, propertyFailures);
//            }
//        }
//        public Dictionary<string, string[]> Failures { get; }
//    }
//}
