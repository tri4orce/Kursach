using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract;

namespace Models
{
    public enum CustType {
            CUST,
            PHIS_CUST
    }
    public class Cust
    {
        public CustType Type { get; set; }
        uint id;
        public uint Id { get {return id;} }
        uint room;
        public uint Room { get { return room; } } 
        string name;
        public string Name { get { return name; } set { name = value; } }
        string address;
        public string Address { get { return address; } }
        string chief;
        public string Chief { get {return chief; } }
        public uint GetFloor
        { 
            get 
            {
                uint tmp = room;
                uint result = 0;

                while (tmp > 0)
                {
                    result = tmp % 10;
                    tmp = tmp / 10;
                }

                return result;
            }
        }
        public Cust(uint id = 0, uint room = 0, string name = "", string address = "", string chief = "")
        {
            this.id = id;
            this.room = room;
            this.name = name;
            this.address = address;
            this.chief = chief;
        }
        public Cust(Cust obj)
            :this(obj.id, obj.room, obj.name, obj.address, obj.chief)
        {

        }

        public Cust()
            :this(0, 0, "", "", "")
        {
            Type = CustType.CUST;
        }

        public override string ToString()
        {
            return $"Инн: {id}, название арендатора: {name}, адресс арендатора: {address}, фамилия начальника: {chief}, кабинет начальника: {room}, этаж кабинета: {this.GetFloor}";
        }

        public static bool operator > (Cust c1, Cust c2)
        {
            return c1.Id > c2.Id;
        }

        public static bool operator < (Cust c1, Cust c2)
        {
            return c1.Id < c2.Id;
        }

        public static bool operator == (Cust c1, Cust c2)
        {
            return c1.ToString() == c2.ToString();
        }

        public static bool operator != (Cust c1, Cust c2)
        {
            return c1.ToString() != c2.ToString();
        }

        /*public virtual string ToColumn()
        {
            return $"{"Инн", 10}|{"название арендатора", 20}|{"адресс арендатора", 20}|{"фамилия начальника", 20}|{"кабинет начальника", 18}|{"этаж кабинета", 13}|";
        }
        public virtual string ToRow()
        {
            return $"{Id, 10}|{Name, 20}|{Address, 20}|{Chief, 20}|{Room, 18}|{this.GetFloor, 13}|";
        }*/
    }
}