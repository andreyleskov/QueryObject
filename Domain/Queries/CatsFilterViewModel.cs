using System;

namespace Domain.Queries
{
    //each field can be null
    public class CatsFilterViewModel
    {
        public string NameLike;
        public int? CuteFactorMin;
        public bool? hasOwner;
        public Gender? onwerGender;
        public Tuple<string, OrderDirection>[] FieldsOrdering; 
    }
}