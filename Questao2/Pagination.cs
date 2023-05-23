using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questao2
{
    public class Pagination<T> where T:  class 
    {
        public int Page { get; set; }

        public int Per_Page { get; set; }

        public int Total { get; set; }

        public int Total_Pages { get; set; }

        public T? Data { get; set; }


    }
}
