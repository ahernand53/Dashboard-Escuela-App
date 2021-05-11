using System;
using System.ComponentModel.DataAnnotations;

namespace EscuelaApp.Models
{
    public abstract class IModelBase
    {
        public string Id { get; set; }
        public virtual string Nombre { get; set; }

        public IModelBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}