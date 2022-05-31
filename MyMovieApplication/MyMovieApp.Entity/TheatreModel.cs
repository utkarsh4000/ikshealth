using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyMovieApp.Entity
{
   
    public class TheatreModel
    {
        public TheatreModel()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheatreId { get; set; }
        public string movie { get; set; }
        public string Location { get; set; }
        public DateTime ShowDateTime { get; set; }
    }
}
