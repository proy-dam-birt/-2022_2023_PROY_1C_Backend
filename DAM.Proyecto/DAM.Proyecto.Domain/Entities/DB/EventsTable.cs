using DAM.Proyecto.Domain.Entities.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.DB
{
    public class EventsTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long TotalItems { get; set; }
        public long TotalPages { get; set; }
        public long CurrentPage { get; set; }
        public EventoEuskadi[] Items { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public void Update(EventsTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            this.TotalItems = TotalItems;
            this.TotalPages = TotalPages;
            this.CurrentPage = TotalItems;
            this.Items = Items;
            this.UpdatedDateTime = DateTime.Now;
        }
    }
}
