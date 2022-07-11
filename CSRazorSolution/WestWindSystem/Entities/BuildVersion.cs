using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities
{
    //we need to point this entity definition to the sql table that it represents.
    // to do  this we use an annotation.
    //annotations are placed IMMEDIATELY before the item in the definition it
    //refers to.

    [Table("BuildVersion")]
    public class BuildVersion
    {
        //auto implemeted properites
        //in sql nvarchar(), varchar, nchar, char is declared as a string in your Entity definition!!!!!!!!
        //sql bit is a bool in C#

        //names of class properties DO NOT need to match the attribute names on your sql table (entity)
        //HOWEVER IF you use diffrent names then order is important in this entity class. It MUST match the order in the sql table.
        //if your property names match than the order within this entity class is not important. However it is much easier to match ypur sql table 
        //to your entity if you maintain the same order for data.

        //annotation to indicate the primary key /property relationship
        //3 syntax forms for the PK annotation
        //1) [KEY] //IDENTITY() PK in SQL

        /// <differents>
        /// differents between 1 and 2 
        /// 2)-SQL PK is not a IDENTITY() PK in SQL
        /// </differents>
        //2) [Key]
        //[DatabaseGeneratedOptions(DatabaseGeneratedOption.None)]

        //3)YOUR sql PK is a compound PK in sql [KEY] [Column(Order = n)]. You will need to add the annotaion in front of each part of the
        //compound key attribute/ property to form the correct PK structur.

        //if you have a foreign and your attribute / property names are the same 
        //the system will already know about FK relationship; therefore
        //you DO NOT use the annotaion [ForeignKey]
        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }

        //you can also create a property within your entity that is NOT data atribute in your sql table.
        //if you do use the [NotMapped] annotation

        //Example
        //Assume you two separete propertoes FirstName and LastName
        // you wish to create a string of FullName
        //you do not wish to force the prgramer to consitently concatenate you wish to make it eaiser for the programmer by
        //doing the concatenation for them

        //create a reado-only property (just a get) and return the concatenation
        //programer than can use the read-only property

        //The system realizes that this is not a database field.

        //[NotMapped]
        //public string FullName {get {return LastName + "," + FirstName;}}

    }
}
