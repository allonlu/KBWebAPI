//-----------------------------------------------------------------------
// <copyright file="AuditAttribute.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Auditing
{
    using System;

    public class AuditAttribute : Attribute
    {
        public string Source { get; private set; }

        public AuditAction Action { get; private set; }

        public AuditAttribute(string source, AuditAction action)
        {
            this.Source = source;
            this.Action = action;
        }
    }
}
