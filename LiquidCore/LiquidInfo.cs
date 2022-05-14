using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquidCore
{
    public class LiquidINfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? taste { get; set; }
        public Capacity? capacity { get; set; }
        public Company? company { get; set; }
        public Nicotine? nicotine { get; set; }
        public VGPG? vGPG { get; set; }
       
    }
}