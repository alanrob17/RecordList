using Heinemann.Components;
using RecordList.Components;
using RecordList.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace RecordList.Data
{
    public class RecordData
    {
        /// <summary>
        /// Select a single Artist by Id
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public Record Select(int recordId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_RecordSelectById";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@RecordId", recordId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var entity =
              (from dr in dt.AsEnumerable()
               select new Record
               {
                   ArtistName = dr["ArtistName"].ToString(),
                   ArtistId = Convert.ToInt32(dr["ArtistId"]),
                   RecordId = Convert.ToInt32(dr["RecordId"]),
                   Name = dr["Name"].ToString(),
                   Field = dr["Field"].ToString(),
                   Recorded = Convert.ToInt32(dr["Recorded"]),
                   Label = dr["Label"].ToString(),
                   Pressing = dr["Pressing"].ToString(),
                   Rating = dr["Rating"].ToString(),
                   Discs = Convert.ToInt32(dr["Discs"]),
                   Media = dr["Media"].ToString(),
                   Bought = DataConvert.ConvertTo<DateTime>(dr["Bought"], default(DateTime)),
                   Cost = DataConvert.ConvertTo<decimal>(dr["Cost"], default(decimal)),
                   CoverName = dr["CoverName"].ToString(),
                   Review = dr["Review"].ToString()
               }).FirstOrDefault();

            return entity;
        }

        /// <summary>
        /// Select all Record records.
        /// </summary>
        /// <returns>The <see cref="List"/>list of all record objects.</returns>
        public List<Record> Select()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_RecordSelectAll";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            // ArtistName = dr["FirstName"].ToString(),
            var query = from dr in dt.AsEnumerable()
                        select new Record
                        {
                            ArtistName = dr["ArtistName"].ToString(),
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            RecordId = Convert.ToInt32(dr["RecordId"]),
                            Name = dr["Name"].ToString(),
                            Field = dr["Field"].ToString(),
                            Recorded = Convert.ToInt32(dr["Recorded"]),
                            Label = dr["Label"].ToString(),
                            Pressing = dr["Pressing"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Discs = Convert.ToInt32(dr["Discs"]),
                            Media = dr["Media"].ToString(),
                            Bought = DataConvert.ConvertTo<DateTime>(dr["Bought"], default(DateTime)),
                            Cost = DataConvert.ConvertTo<decimal>(dr["Cost"], default(decimal)),
                            CoverName = dr["CoverName"].ToString(),
                            Review = dr["Review"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select all Records from database
        /// filter by show parameter
        /// </summary>
        /// <param name="show">parameter variable</param>
        /// <returns>A list of records.</returns>
        public List<Record> Select(string show)
        {
            if (show == null)
            {
                throw new ArgumentNullException("show");
            }

            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_RecordSelectShowNew";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@show", show);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Record
                        {
                            ArtistName = dr["ArtistName"].ToString(),
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            RecordId = Convert.ToInt32(dr["RecordId"]),
                            Name = dr["Name"].ToString(),
                            Field = dr["Field"].ToString(),
                            Recorded = Convert.ToInt32(dr["Recorded"]),
                            Label = dr["Label"].ToString(),
                            Pressing = dr["Pressing"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Discs = Convert.ToInt32(dr["Discs"]),
                            Media = dr["Media"].ToString(),

                            // Bought returns a string -- have to convert
                            Bought = DataConvert.ConvertTo<DateTime>(dr["Bought"], default(DateTime)),
                            Cost = DataConvert.ConvertTo<decimal>(dr["Cost"], default(decimal)),
                            CoverName = dr["CoverName"].ToString(),
                            Review = dr["Review"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select an artist's records.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <returns>The <see cref="List"/> list of records for a particular artist.</returns>
        public List<Record> SelectArtistRecords(int artistId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_getRecordListAndNone";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@ArtistId", artistId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Record
                        {
                            RecordId = Convert.ToInt32(dr["RecordId"]),
                            Name = dr["Name"].ToString(),
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select records reviews.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Record> SelectRecordReviews()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_SelectRecordReviews";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Record
                        {
                            ArtistName = dr["Name"].ToString(),
                            Name = dr["Title"].ToString(),
                            Review = dr["Review"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Delete an existing Record record.
        /// </summary>
        /// <param name="recordId">The record ID.</param>
        public void Delete(int recordId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_DeleteRecord", cn) { CommandType = CommandType.StoredProcedure };

                // Initialize parameters
                cmd.Parameters.AddWithValue("@RecordID", recordId);

                // Execute command
                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert a new record.
        /// </summary>
        /// <param name="record">The record object.</param>
        /// <returns>The <see cref="int"/> record Id.</returns>
        public int Insert(Record record)
        {
            var recordId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_RecordInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);
                cmd.Parameters.AddWithValue("ArtistID", record.ArtistId);
                cmd.Parameters.AddWithValue("Name", record.Name);
                cmd.Parameters.AddWithValue("Field", record.Field);
                cmd.Parameters.AddWithValue("Recorded", record.Recorded);
                cmd.Parameters.AddWithValue("Label", record.Label);
                cmd.Parameters.AddWithValue("Pressing", record.Pressing);
                cmd.Parameters.AddWithValue("Rating", record.Rating);
                cmd.Parameters.AddWithValue("Discs", record.Discs);
                cmd.Parameters.AddWithValue("Media", record.Media);
                cmd.Parameters.AddWithValue("Bought", record.Bought);
                cmd.Parameters.AddWithValue("Cost", record.Cost);
                cmd.Parameters.AddWithValue("CoverName", record.CoverName);
                cmd.Parameters.AddWithValue("Review", record.Review);
                cmd.Parameters.AddWithValue("FreeDBID", string.Empty);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    recordId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Insert a new record.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="name">The record title.</param>
        /// <param name="field">The field of music.</param>
        /// <param name="recorded">The year recorded.</param>
        /// <param name="label">The record label.</param>
        /// <param name="pressing">The country of pressing.</param>
        /// <param name="rating">The album rating.</param>
        /// <param name="discs">The number of discs.</param>
        /// <param name="media">The media type.</param>
        /// <param name="bought">The date bought.</param>
        /// <param name="cost">The cost of the record.</param>
        /// <param name="coverName">The image cover name.</param>
        /// <param name="review">The record review.</param>
        /// <returns>the ID of the record</returns>
        public int Insert(int artistId, string name, string field, int recorded, string label, string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review)
        {
            var recordId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_RecordInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);
                cmd.Parameters.AddWithValue("ArtistId", artistId);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Field", field);
                cmd.Parameters.AddWithValue("Recorded", recorded);
                cmd.Parameters.AddWithValue("Label", label);
                cmd.Parameters.AddWithValue("Pressing", pressing);
                cmd.Parameters.AddWithValue("Rating", rating);
                cmd.Parameters.AddWithValue("Discs", discs);
                cmd.Parameters.AddWithValue("Media", media);
                cmd.Parameters.AddWithValue("Bought", bought);
                cmd.Parameters.AddWithValue("Cost", cost);
                cmd.Parameters.AddWithValue("CoverName", coverName);
                cmd.Parameters.AddWithValue("Review", review);
                cmd.Parameters.AddWithValue("FreeDBID", string.Empty);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    recordId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Update a Record
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <param name="artistId">The artist id.</param>
        /// <param name="name">The record title.</param>
        /// <param name="field">The field of music.</param>
        /// <param name="recorded">The year recorded.</param>
        /// <param name="label">The record label.</param>
        /// <param name="pressing">The country of pressing.</param>
        /// <param name="rating">My rating of this record.</param>
        /// <param name="discs">The number of discs.</param>
        /// <param name="media">The record media - CD, Record, DVD.</param>
        /// <param name="bought">The date bought.</param>
        /// <param name="cost">The cost of this record.</param>
        /// <param name="coverName">The cover name.</param> 
        /// <param name="review">Review of this record.</param>
        /// <returns>The <see cref="int"/>record Id.</returns>
        public int Update(int recordId, int artistId, string name, string field, int recorded, string label, string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review)
        {
            var newRecordId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateRecord", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);
                cmd.Parameters.AddWithValue("ArtistId", artistId);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Field", field);
                cmd.Parameters.AddWithValue("Recorded", recorded);
                cmd.Parameters.AddWithValue("Label", label);
                cmd.Parameters.AddWithValue("Pressing", pressing);
                cmd.Parameters.AddWithValue("Rating", rating);
                cmd.Parameters.AddWithValue("Discs", discs);
                cmd.Parameters.AddWithValue("Media", media);
                cmd.Parameters.AddWithValue("Bought", bought);
                cmd.Parameters.AddWithValue("Cost", cost);
                cmd.Parameters.AddWithValue("CoverName", coverName);
                cmd.Parameters.AddWithValue("Review", review);
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    newRecordId = (int)cmd.Parameters["@Result"].Value;
                }
            }

            return newRecordId;
        }

        /// <summary>
        /// Update a record.
        /// </summary>
        /// <param name="record">The record object.</param>
        /// <returns>The <see cref="int"/> record Id.</returns>
        public int Update(Record record)
        {
            var newRecordId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateRecord", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", record.RecordId);
                cmd.Parameters.AddWithValue("ArtistId", record.ArtistId);
                cmd.Parameters.AddWithValue("Name", record.Name);
                cmd.Parameters.AddWithValue("Field", record.Field);
                cmd.Parameters.AddWithValue("Recorded", record.Recorded);
                cmd.Parameters.AddWithValue("Label", record.Label);
                cmd.Parameters.AddWithValue("Pressing", record.Pressing);
                cmd.Parameters.AddWithValue("Rating", record.Rating);
                cmd.Parameters.AddWithValue("Discs", record.Discs);
                cmd.Parameters.AddWithValue("Media", record.Media);
                cmd.Parameters.AddWithValue("Bought", record.Bought);
                cmd.Parameters.AddWithValue("Cost", record.Cost);
                cmd.Parameters.AddWithValue("CoverName", record.CoverName);
                cmd.Parameters.AddWithValue("Review", record.Review);
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    newRecordId = (int)cmd.Parameters["@Result"].Value;
                }
            }

            return newRecordId;
        }

        /// <summary>
        /// Count number of discs for the browse page.
        /// </summary>
        /// <param name="show">The show querystring value.</param>
        /// <param name="discs">The number of discs.</param>
        /// <returns>The number of Discs.</returns>
        public string CountDiscs(string show)
        {
            int discs = 0;

            if (show == null)
            {
                throw new ArgumentNullException("show");
            }
            else
            {
                using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
                {
                    var cmd = new SqlCommand("up_CountDiscs", cn) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("show", show);

                    using (cn)
                    {
                        cn.Open();
                        discs = (int)cmd.ExecuteScalar();
                    }
                }
            }

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get Artist's total number of discs.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <returns>The <see cref="int"/> number of discs.</returns>
        public string GetArtistNumberOfRecords(int artistId)
        {
            var discs = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_GetArtistNumberOfRecords", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@artistId", artistId);

                using (cn)
                {
                    cn.Open();
                    discs = (int)cmd.ExecuteScalar();
                }
            }

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get the total number of all records, DVD's and CD's for the year.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetRecordedYearNumber(int year)
        {
            var discs = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_GetRecordedYearNumber", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@year", year);

                using (cn)
                {
                    cn.Open();
                    discs = (int)cmd.ExecuteScalar();
                }
            }

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get a list of records with no reviews.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/> List of records without reviews.</returns>
        public List<Record> NoRecordReviews()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_NoRecordReviews";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Record
                        {
                            ArtistName = dr["Name"].ToString(),
                            Name = dr["Record"].ToString(),
                            RecordId = Convert.ToInt32(dr["RecordId"])
                        };

            return query.ToList();
        }

        /// <summary>
        /// Change object to a short date string.
        /// </summary>
        /// <param name="bought">
        /// The bought.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToShortDate(object bought)
        {
            var shortDate = "unk";

            if (bought != null)
            {
                DateTime dt = Convert.ToDateTime(bought);

                shortDate = Dates.ShortDateString(dt);
            }

            return shortDate;
        }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>A listing of the object properties.</returns>
        public static string ToString(Record record)
        {
            var artistData = new ArtistData();
            var artist = artistData.Select(record.ArtistId);
            var str = new StringBuilder();

            str.Append("<strong>RecordId: </strong>" + record.RecordId + "<br/>");
            str.Append("<strong>ArtistId: </strong>" + record.ArtistId + "<br/>");
            str.Append("<strong>ArtistName: </strong>" + artist.Name + "<br/>");
            str.Append("<strong>Name: </strong>" + record.Name + "<br/>");
            str.Append("<strong>Field: </strong>" + record.Field + "<br/>");
            str.Append("<strong>Recorded: </strong>" + record.Recorded + "<br/>");
            str.Append("<strong>Label: </strong>" + record.Label + "<br/>");
            str.Append("<strong>Pressing: </strong>" + record.Pressing + "<br/>");
            str.Append("<strong>Rating: </strong>" + record.Rating + "<br/>");
            str.Append("<strong>Discs: </strong>" + record.Discs + "<br/>");
            str.Append("<strong>Media: </strong>" + record.Media + "<br/>");

            if (record.Bought > DateTime.MinValue)
            {
                str.Append("<strong>Bought: </strong>" + record.Bought.ToShortDateString() + "<br/>");
            }

            if (!string.IsNullOrEmpty(record.Cost.ToString(CultureInfo.InvariantCulture)))
            {
                str.Append("<strong>Cost: </strong>" + record.Cost + "<br/>");
            }

            if (!string.IsNullOrEmpty(record.CoverName))
            {
                str.Append("<strong>CoverName: </strong>" + record.CoverName + "<br/>");
            }

            if (!string.IsNullOrEmpty(record.Review))
            {
                str.Append("<strong>Review: </strong>" + record.Review + "<br/>");
            }

            return str.ToString();
        }

        /// <summary>
        /// Get total cost for each artist.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>list of artists and their total costs.</returns>
        public IEnumerable<Total> GetTotalCosts()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "sp_getTotalsForEachArtist";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Total
                        {
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            Name = dr["Name"].ToString(),
                            TotalDiscs = Convert.ToInt32(dr["TotalDiscs"]),
                            TotalCost = Convert.ToDecimal(dr["TotalCost"])
                        };

            return query.ToList();
        }
    }
}