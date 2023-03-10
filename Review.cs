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
        /// Create a new review object
        /// </summary>
        /// <param name="ReviewID">Review ID</param>
        /// <param name="ChocolateBarID">Chocolate Bar ID</param>
        /// <param name="UserID">User ID</param>
        /// <param name="ScoreID">Score out of 10</param>
        /// <param name="Comment">Review Comment</param>
        public Review(int ReviewID, int ChocolateBarID, int UserID, int ScoreID, string Comment)
        {
            this.ReviewID = ReviewID;
            this.ChocolateBarID = ChocolateBarID;
            this.UserID = UserID;
            this.ScoreID = ScoreID;
            this.Comment = Comment;
        }

        /// <summary>
        /// Create a new review object from an SQL reader
        /// </summary>
        /// <param name="r">SqlDataReader object</param>
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
