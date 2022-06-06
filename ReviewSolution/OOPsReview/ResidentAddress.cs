using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    // struct is a value variable
    //class is a reference variable
    public struct ResidentAddress
    {
        //data memebers
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public ResidentAddress(int Number, string Address1, string Address2, string Unit, string City, string ProvinceState)
        {
            //concern: parameter name is exacly the same as the struct/class field/property

            //soultion: use the keyword THIS. on your instance item

            //the keyword this. references to the instance that you are currently accessing in your program

            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;

            //for a propery, one Must use a fully implemneted property with the data member and assign teh incoming value
            //to the data memeber instead of the property (as can be done in a class)
            _Unit = Unit;
            _City = City;
            this.ProvinceState = ProvinceState;
        }

        public override string ToString()
        {
            return $"{Number},{Address1},{Address2},{Unit},{City},{ProvinceState}";
        }

    }
}
