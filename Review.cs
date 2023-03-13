using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class Review
    {
        public int ReviewID;
        public int ChocolateBarID;
        public int UserID;
        public int Score;
        public string Comment;

        /// <summary>
        /// Create a new review object
        /// </summary>
        /// <param name="ReviewID">Review ID</param>
        /// <param name="ChocolateBarID">Chocolate Bar ID</param>
        /// <param name="UserID">User ID</param>
        /// <param name="Score">Score out of 10</param>
        /// <param name="Comment">Review Comment</param>
        public Review(int ReviewID, int ChocolateBarID, int UserID, int Score, string Comment)
        {
            this.ReviewID = ReviewID;
            this.ChocolateBarID = ChocolateBarID;
            this.UserID = UserID;
            this.Score = Score;
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
            this.Score = (int)r["Score"];
            this.Comment = (string)r["Comment"];
        }

        public override string ToString()
        {
            return $"Review ID: {ReviewID} | ChocolateBarID: {ChocolateBarID} | UserID: {UserID} | Score: {Score} | Comment: {Comment}";
        }
    }

}
