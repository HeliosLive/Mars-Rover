using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class EntryParameters
    {
        public string FirstParameter { get; set; }
        public string SecondParameter { get; set; }
        public string ThirdParameter { get; set; }
        public string FourthParameter { get; set; }
        public string FifthParameter { get; set; }
    }
}

//  Giriş parametreleridir.
//  Test örneği ile eşleştiricek olursak : 
//  FirstParameter : 5 5
//  SecondParameter :1 2 N
//  ThirdParameter : LMLMLMLMM
//  FourthParameter : 3 3 E
//  FifthParameter : MMRMMRMRRM