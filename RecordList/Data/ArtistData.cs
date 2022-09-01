using RecordList.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using RecordList.Components;

namespace RecordList.Data
{
    public class ArtistData
    {
        #region " Methods "        

        /// <summary>
        /// Get all Artists from Artist table
        /// </summary>
        /// <returns>A List of Artist objects</returns>
        public List<Artist> GetArtists()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "dbo.up_ArtistSelectAll";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                // cmd.Parameters.AddWithValue("@customerID", ActiveCustomerID);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Artist
                        {
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Name = dr["Name"].ToString(),
                            Biography = dr["Biography"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Get artist Id and names.
        /// </summary>
        /// <returns>The <see cref="List"/>List of Artist names.</returns>
        public List<Artist> GetArtistList()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "dbo.up_getArtistListandNone";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Artist
                        {
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            Name = dr["Name"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select all Artist records.
        /// </summary>
        /// <returns>The <see cref="List"/>list of artists.</returns>
        public List<Artist> Select()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_ArtistSelectAll";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Artist
                        {
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Name = dr["Name"].ToString(),
                            Biography = dr["Biography"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select a single Artist by Id
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public Artist Select(int artistId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_ArtistSelectById";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@ArtistId", artistId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var entity =
              (from dr in dt.AsEnumerable()
               select new Artist
               {
                   ArtistId = Convert.ToInt32(dr["ArtistId"]),
                   FirstName = dr["FirstName"].ToString(),
                   LastName = dr["LastName"].ToString(),
                   Name = dr["Name"].ToString(),
                   Biography = dr["Biography"].ToString()
               }).FirstOrDefault();

            return entity;
        }

        /// <summary>
        /// Select all Artist records.
        /// </summary>
        /// <returns>The <see cref="List"/>list of artists.</returns>
        public List<Artist> GetArtistNames()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "dbo.up_ArtistSelectAll";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Artist
                        {
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Name = dr["Name"].ToString(),
                            Biography = dr["Biography"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select all Artists from database
        /// where a biography doesn't exist
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>list of artists with no biography.</returns>
        public List<Artist> SelectArtistWithNoBio()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_selectArtistsWithNoBio";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Artist
                        {
                            ArtistId = Convert.ToInt32(dr["ArtistId"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Name = dr["Name"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Create a new Artist
        /// </summary>
        /// <param name="artist">The artist entity.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public int Insert(Artist artist)
        {
            var artistId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_ArtistInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("FirstName", artist.FirstName);
                cmd.Parameters.AddWithValue("LastName", artist.LastName);
                cmd.Parameters.AddWithValue("Biography", artist.Biography);
                var parArtistId = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(parArtistId);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    artistId = int.Parse(parArtistId.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Create a new Artist
        /// </summary>
        /// <param name="firstName">The first Name.</param>
        /// <param name="lastName">The last Name.</param>
        /// <param name="biography">The biography.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public int Insert(string firstName, string lastName, string biography)
        {
            var artistId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_ArtistInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("FirstName", firstName);
                cmd.Parameters.AddWithValue("LastName", lastName);
                cmd.Parameters.AddWithValue("Biography", biography);
                var parArtistId = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(parArtistId);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    artistId = int.Parse(parArtistId.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Update the current artist record.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="name">The full name.</param>
        /// <param name="biography">The artist biography.</param>
        /// <returns>The <see cref="int"/>artist Id.</returns>
        public int UpdateArtist(int artistId, string firstName, string lastName, string name, string biography)
        {
            var newArtistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistId", artistId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Biography", biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                                                    ParameterDirection
                                                    .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    newArtistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return newArtistId;
        }

        /// <summary>
        /// Update an artist record.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public int UpdateArtist(Artist artist)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistID", artist.ArtistId);
                cmd.Parameters.AddWithValue("@FirstName", artist.FirstName);
                cmd.Parameters.AddWithValue("@LastName", artist.LastName);
                cmd.Parameters.AddWithValue("@Name", artist.Name);
                cmd.Parameters.AddWithValue("@Biography", artist.Biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    artistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Update the current artist record.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="name">The full name.</param>
        /// <param name="biography">The artist biography.</param>
        /// <returns>The <see cref="int"/>artist Id.</returns>
        public int Update(int artistId, string firstName, string lastName, string name, string biography)
        {
            var newArtistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistId", artistId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Biography", biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    newArtistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return newArtistId;
        }

        /// <summary>
        /// Update an artist record.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public int Update(Artist artist)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistID", artist.ArtistId);
                cmd.Parameters.AddWithValue("@FirstName", artist.FirstName);
                cmd.Parameters.AddWithValue("@LastName", artist.LastName);
                cmd.Parameters.AddWithValue("@Name", artist.Name);
                cmd.Parameters.AddWithValue("@Biography", artist.Biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    artistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Get the artist id.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns>The <see cref="int"/> artist Id.</returns>
        public int GetArtistId(string firstName, string lastName)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getArtistId", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("FirstName", string.IsNullOrEmpty(firstName) ? null : firstName);
                cmd.Parameters.AddWithValue("LastName", lastName);

                using (cn)
                {
                    cn.Open();

                    try
                    {
                        artistId = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        artistId = 0;
                    }
                }
            }

            return artistId;
        }

        /// <summary>
        /// Get the artist id.
        /// </summary>
        /// <param name="recordId">The record Id.</param>
        /// <returns>The <see cref="int"/> artist Id.</returns>
        public int GetArtistId(int recordId)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getArtistIdFromRecordId", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);

                using (cn)
                {
                    cn.Open();

                    artistId = (int)cmd.ExecuteScalar();
                }
            }

            return artistId;
        }

        /// <summary>
        /// Delete an existing Artist record.
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public void Delete(int artistId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_deleteArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistId", artistId);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get a biography.
        /// </summary>
        /// <param name="recordId">The record Id.</param>
        /// <returns>
        /// The <see cref="object"/>biography.</returns>
        public string GetBiography(int recordId)
        {
            var biography = string.Empty;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getBiography", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("recordId", recordId);

                using (cn)
                {
                    cn.Open();

                    biography = (string)cmd.ExecuteScalar();
                }
            }

            // add some spacing
            return biography;
        }

        /// <summary>
        /// ToString method shows an instances properties
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>The <see cref="string"/> artist record as a string.</returns>
        public static string ToString(Artist artist)
        {
            var artistDetails = new StringBuilder();

            artistDetails.Append("<strong>ArtistId: </strong>" + artist.ArtistId + "<br/>");

            if (!string.IsNullOrEmpty(artist.FirstName))
            {
                artistDetails.Append("<strong>First Name: </strong>" + artist.FirstName + "<br/>");
            }

            artistDetails.Append("<strong>Last Name: </strong>" + artist.LastName + "<br/>");

            if (!string.IsNullOrEmpty(artist.Name))
            {
                artistDetails.Append("<strong>Name: </strong>" + artist.Name + "<br/>");
            }

            if (!string.IsNullOrEmpty(artist.Biography))
            {
                artistDetails.Append("<strong>Biography: </strong>" + artist.Biography + "<br/>");
            }

            return artistDetails.ToString();
        }

        /// <summary>
        /// Get artist object by record id.
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <returns>The <see cref="Artist"/> artist object.</returns>
        public Artist GetArtistByRecordId(int recordId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "up_ArtistSelectByRecordId";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@RecordId", recordId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var entity =
              (from dr in dt.AsEnumerable()
               select new Artist
               {
                   ArtistId = Convert.ToInt32(dr["ArtistId"]),
                   FirstName = dr["FirstName"].ToString(),
                   LastName = dr["LastName"].ToString(),
                   Name = dr["Name"].ToString(),
                   Biography = dr["Biography"].ToString()
               }).FirstOrDefault();

            return entity;
        }


        #endregion
    }
}