﻿using LbL.Repository;
using LbLModel.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbLService
{
    class StudentService
    {
        public bool Add(Student student)
        {
            StudentRepository repositoy = new StudentRepository();
            return repositoy.Add(student);
        }
    }
}