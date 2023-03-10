using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChcolateReviews
{
    class Review
    {
        public int ReviewID;
        public int ChocolateBarID;
        public int UserID;
        public int ScoreID;
        public string Comment;

        /// <summary>
        /// Create a new review object from an SQL reader
        /// </summary>
        /// <param name="r">SqlDataReader object (read from a database)</param>
        public Review(SqlDataReader r)
        {
            this.ReviewID = (int)r["ReviewID"];
            this.ChocolateBarID = (int)r["ChocolateBarID"];
            this.UserID = (int)r["UserID"];
            this.ScoreID = (int)r["ScoreID"];
            this.Comment = (string)r["Comment"];
        }
    }
}
