//-----------------------------------------------------------------------
// <copyright file="ErrorMessages.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exceptions
{
    public static  class ErrorMessages
    {
        public const string APP_INITIALIZATION_FAILED = "Application initialization failed.";
        public const string ENTITY_NOT_FOUND = "The {0} of {1} is not found!";
        public const string AUTHENTICATION_FAILED = "Authentication failed.";
        public const string INVALIDE_PARAMETERS_SORT_FIELD = "Sort field '{0} is not supported!";
        public const string NO_SUFFICIENT_PERMISSION = "You do not have sufficient permissions";
        public const string NO_SPECIFIED_PERMISSION = "You have no '{0} permission.";
        public const string WRONG_ISOLATION = "The wrong transaction isolation level was specified.";

    }
}
