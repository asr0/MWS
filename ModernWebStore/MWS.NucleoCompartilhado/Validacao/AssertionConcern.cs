#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MWS.NucleoCompartilhado.Eventos.Contratos;

#endregion

namespace MWS.NucleoCompartilhado.Validacao
{
    public static class AssertionConcern
    {        
        public static bool IsSatisfiedBy(params NotificacaoDominio[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<NotificacaoDominio> notifications)
        {
            notifications.ToList().ForEach(validation => { EventoDominio.Raise(validation); });
        }

        public static NotificacaoDominio AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            var length = stringValue.Trim().Length;

            return (length < minimum || length > maximum)
                ? new NotificacaoDominio("AssertArgumentLength", message)
                : null;
        }

        public static NotificacaoDominio AssertMatches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue))
                ? new NotificacaoDominio("AssertArgumentLength", message)
                : null;
        }

        public static NotificacaoDominio AssertNotEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue))
                ? new NotificacaoDominio("AssertArgumentNotEmpty", message)
                : null;
        }

        public static NotificacaoDominio AssertNotNull(object object1, string message)
        {
            return (object1 == null)
                ? new NotificacaoDominio("AssertArgumentNotNull", message)
                : null;
        }

        public static NotificacaoDominio AssertIsNull(object object1, string message)
        {
            return (object1 != null)
                ? new NotificacaoDominio("AssertArgumentNull", message)
                : null;
        }

        public static NotificacaoDominio AssertTrue(bool boolValue, string message)
        {
            return (!boolValue)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssertAreEquals(string value, string match, string message)
        {
            return (!(value == match))
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssertIsGreaterThan(int value1, int value2, string message)
        {
            return (!(value1 > value2))
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssertIsGreaterThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 > value2))
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssertIsGreaterOrEqualThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 >= value2))
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssertRegexMatch(string value, string regex, string message)
        {
            return (!Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                ? new NotificacaoDominio("AssertRegexNotMatch", message)
                : null;
        }

        public static NotificacaoDominio AssertEmailIsValid(string email, string message)
        {
            var emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                ? new NotificacaoDominio("AssertEmailIsInvalid", message)
                : null;
        }

        public static NotificacaoDominio AssertUrlIsValid(string url, string message)
        {
            // Do not validate if no URL is provided
            // You can call AssertNotEmpty before this if you want
            if (String.IsNullOrEmpty(url))
                return null;

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            return (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase))
                ? new NotificacaoDominio("AssertUrlIsInvalid", message)
                : null;
        }
    }
}