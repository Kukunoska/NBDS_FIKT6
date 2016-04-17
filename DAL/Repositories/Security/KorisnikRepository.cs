﻿using System;
using System.Collections.Generic;
using System.Linq;
using model = DAL.Models;
using domain = LearnByPractice.Domain.Security;


namespace DAL.Repositories.Security
{

    public class KorisnikRepository : RepositoryBase
    {

        public KorisnikRepository()
        {
        }

        protected domain.PolEnum ToDomain(char modelPol)
        {
            switch (modelPol)
            {
                case 'M':
                    return domain.PolEnum.Mashki;

                case 'Z':
                    return domain.PolEnum.Zhenski;

                case 'N':
                    return domain.PolEnum.Nepoznat;

                default: throw new ArgumentOutOfRangeException("modelPol", "Неочекувана вредноста на Pol е прочитана од базата на податоци.");
            }
        }

        protected char ToModel(domain.PolEnum domainPol)
        {

            switch (domainPol)
            {
                case domain.PolEnum.Mashki:
                    return 'M';

                case domain.PolEnum.Zhenski:
                    return 'Z';

                case domain.PolEnum.Nepoznat:
                    return 'N';

                default:
                    throw new ArgumentOutOfRangeException("domainPol", "Обид за запишување на неочекувана вредноста на Pol во базата на податоци.");
            }
        }
        public domain.KorisnikCollection GetAll() 
    {
        model.LearnByPracticeDataContext context = CreateContext();
        IQueryable<model.Korisnik> query = context.Korisniks;
                domain.KorisnikCollection result = new domain.KorisnikCollection();
                foreach (model.Korisnik modelObject in query)
                {
                    domain.Korisnik domainObject = new domain.Korisnik();
                    domainObject.IdKorisnik = modelObject.ID;
                    domainObject.Username = modelObject.Korisnichko_Ime;
                    //domainObject.Password = modelObject.Lozinka;
                    domainObject.Ime = modelObject.Ime;
                    domainObject.Prezime = modelObject.Prezime;
                    domainObject.Pol = ToDomain(modelObject.Pol);
                    domainObject.studiskaPrograma.Ime = modelObject.Studiska_Programa.Ime;
                    domainObject.organizacija.Ime = modelObject.Organizacija.Ime;
                    domainObject.Email = modelObject.Email;
                    domainObject.Mobilen = modelObject.Telefonski_Broj;

                    result.Add(domainObject);
                }

                return result;
    }

        private domain.PolEnum ToDomain(string p)
        {
            throw new NotImplementedException();
        }


        public domain.Korisnik Get(int id)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Korisnik> query = context.Korisniks.Where(c => c.ID == id);
               
                domain.Korisnik domainObject = ToDomain(query.Single());

                return domainObject;
            }
        }

        public domain.KorisnikCollection GetByStudiskaProgramaId(int StudiskaProgramaId)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Korisnik> query = context.Korisniks.Where(c => c.Studiska_Programa_ID == StudiskaProgramaId);
                domain.KorisnikCollection domainObjects = ToDomainObjects(query.ToList());

                return domainObjects;
            }
        }

        private domain.KorisnikCollection ToDomainObjects(List<model.Korisnik> list)
        {
            throw new NotImplementedException();
        }

        public domain.Korisnik Insert (domain.Korisnik domainObject)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                model.Korisnik modelObject = new model.Korisnik();
                modelObject.Korisnichko_Ime = domainObject.Username;
                //modelObject.Lozinka = domainObject.Password;
                modelObject.Ime = domainObject.Ime;
                modelObject.Prezime = domainObject.Prezime;
                //modelObject.Pol = ToModel(domainObject.Pol);
                modelObject.Studiska_Programa.Ime = domainObject.studiskaPrograma.Ime;
                modelObject.Organizacija.Ime = domainObject.organizacija.Ime;
                modelObject.Email = domainObject.Email;
                modelObject.Telefonski_Broj = domainObject.Mobilen;
                context.Korisniks.InsertOnSubmit(modelObject);
                context.SubmitChanges();
                domain.Korisnik result = ToDomain(modelObject);
                return result;
            }
        }

        private domain.Korisnik ToDomain(model.Korisnik korisnik)
        {
            throw new NotImplementedException();
        }


    }
}

