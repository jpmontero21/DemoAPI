using System;
using System.Collections.Generic;

#nullable disable

namespace DemoAPI.Entities.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ApellidoDos { get; set; }
        public int AnnoNacimiento { get; set; }
    }
}
