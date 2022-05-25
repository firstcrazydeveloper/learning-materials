using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4.topoligicalSort
{
    public class MovieTopoligicalSort
    {
        public string MovieName { get; set; }
        public float Rating { get; set; }

        public List<MovieTopoligicalSort> SiblingMovieList;
    }
}
