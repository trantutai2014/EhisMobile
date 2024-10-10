﻿using System;

namespace Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        DateTime? DateDeleted { get; set; }
    }
}