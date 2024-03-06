using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
        public string Scoring { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public Voyage Voyage { get; set; }
        public string VoyageID { get; set; }

    }
}
