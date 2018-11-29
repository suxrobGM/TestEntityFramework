namespace TestEntityFramework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Windows.Media.Imaging;

    public partial class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }   
        public string Name { get; set; }
        public string Surname { get; set; }

        [Column(name: "DateBirth")]
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }
        public string College { get; set; }
        public int Group { get; set; }
        
        [Column(name: "Photo")]
        public byte[] Photo { get; set; } 
    }
}
