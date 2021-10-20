using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models
{
public class PhisCust : Cust
    {
        string passport;
        public string Passport { get {return passport; } }
        string snils;
        public string Snils { get {return snils; } }

        public PhisCust(uint id, uint room, string name, string address, string chief, string passport, string snils)
            :base(id, room, name, address, chief)
        {
            this.passport = passport;
            this.snils = snils;
        }

        public PhisCust()
            :base()
        {
            this.Type = CustType.PHIS_CUST;
        }

        public override string ToString()
        {
            return   $"Инн: {Id}, название арендатора: {Name}, адресс арендатора: {Address}, номер паспорта арендатора: {Passport}, снилс арендатора: {snils}, фамилия начальника: {Chief}, кабинет начальника: {Room}, этаж кабинета: {this.GetFloor}";
        }
        /*public override string ToColumn()
        {
            return $"{"Инн", 10}|{"название арендатора", 20}|{"адресс арендатора", 20}|{"номер паспорта", 15}|{"снилс арендатора", 20}|{"фамилия начальника", 20}|{"кабинет начальника", 18}|{"этаж кабинета", 13}|";
        }*/
        /*public override string ToRow()
        {
            return $"{Id, 10}|{Name, 20}|{Address, 20}|{Passport, 15}|{Snils, 20}|{Chief, 20}|{Room, 18}|{this.GetFloor, 13}|";
        }*/
    }
}