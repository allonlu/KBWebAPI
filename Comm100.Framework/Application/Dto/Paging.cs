//-----------------------------------------------------------------------
// <copyright file="Paging.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Paging
    {
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; } = 1;

        [Range(10, 100)]
        public int PageSize { get; set; } = 10;
    }
}
