﻿using RestWithASP_NET5Udemy.Data.Converter.Contract;
using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origem)
        {
            if (origem == null) return null;

            return new Person
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };

        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null) return null;

            return new PersonVO
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}