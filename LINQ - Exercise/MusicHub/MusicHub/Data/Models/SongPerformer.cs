using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub
{
    public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public Song Song { get; set; }


        [ForeignKey(nameof(Performer))]
        public int PerforemrId { get; set; }
        public Performer Performer { get; set; }

    }
}
