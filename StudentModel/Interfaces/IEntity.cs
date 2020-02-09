using System;

namespace StudentModel.Interfaces
{
    interface IEntity
    {
        string ToCsvString();
        string ToString();
    }
}
