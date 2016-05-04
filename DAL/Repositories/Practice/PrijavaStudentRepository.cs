﻿using System;
using System.Collections.Generic;
using System.Linq;
using model = DAL.Models;
using domain = LearnByPractice.Domain.Practice;

namespace DAL.Repositories.Practice
{

    public class PrijavaStudentRepository : RepositoryBase
    {
        public PrijavaStudentRepository()
        {
        }
        public domain.PrijavaStudentCollection GetAll()
        {
            model.LearnByPracticeDataContext context = CreateContext();
            IQueryable<model.Prijava_Korisnik> query = context.Prijava_Korisniks;
            domain.PrijavaStudentCollection result = new domain.PrijavaStudentCollection();
            foreach (model.Prijava_Korisnik modelObject in query)
            {
                domain.PrijavaStudent domainObject = new domain.PrijavaStudent();
                domainObject.student.IdKorisnik = modelObject.Korisnik_ID;
                domainObject.prijava.Id = modelObject.Prijava_ID;
                result.Add(domainObject);
            }

            return result;
        }
        public domain.PrijavaStudent Get(int id)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Prijava_Korisnik> query = context.Prijava_Korisniks.Where(c => c.Prijava_ID == id);

                domain.PrijavaStudent domainObject = ToDomain(query.Single());

                return domainObject;
            }
        }

        public domain.PrijavaStudentCollection GetByKorisnikId(int KorisnikId)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Prijava_Korisnik> query = context.Prijava_Korisniks.Where(c => c.Korisnik_ID == KorisnikId);
                domain.PrijavaStudentCollection domainObjects = ToDomainObjects(query.ToList());

                return domainObjects;
            }

        }

        private domain.PrijavaStudentCollection ToDomainObjects(List<model.Prijava_Korisnik> list)
        {
            throw new NotImplementedException();
        }

        public domain.PrijavaStudent Insert(domain.PrijavaStudent domainObject)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                model.Prijava_Korisnik modelObject = new model.Prijava_Korisnik();
                modelObject.Korisnik_ID = domainObject.student.IdKorisnik;
                modelObject.Prijava_ID = domainObject.prijava.Id;
                context.Prijava_Korisniks.InsertOnSubmit(modelObject);
                context.SubmitChanges();
                domain.PrijavaStudent result = ToDomain(modelObject);

                return result;

            }
        }
        public domain.PrijavaStudent Update(domain.PrijavaStudent domainObject)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Prijava_Korisnik> query = context.Prijava_Korisniks.Where(p => p.Korisnik_ID == domainObject.student.IdKorisnik);
                model.Prijava_Korisnik modelObject = query.Single();
                modelObject.Korisnik_ID = domainObject.student.IdKorisnik;
                modelObject.Prijava_ID = domainObject.prijava.Id;
                context.SubmitChanges();
                domain.PrijavaStudent result = ToDomain(modelObject);
                return result;
            }
        }

        private domain.PrijavaStudent ToDomain(model.Prijava_Korisnik modelObject)
        {
            throw new NotImplementedException();
        }
    }

}
