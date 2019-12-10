//-----------------------------------------------------------------------
// <copyright file="WrongSoringException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exceptions
{
    using System.Net;

    [HttpStatus(HttpStatusCode.BadRequest)]
    public class WrongSoringException : BaseException
    {
        public WrongSoringException(string by)
            :base(string.Format(ErrorMessages.INVALIDE_PARAMETERS_SORT_FIELD, by))
        {
        }
    }
}

