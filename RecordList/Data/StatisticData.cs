using RecordList.Components;
using RecordList.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RecordList.Data
{
    public class StatisticData
    {
        #region " Methods "

        /// <summary>
        /// Get statistics.
        /// </summary>
        /// <returns>
        /// The <see cref="Statistic"/>list of statistics for the record Db.
        /// </returns>
        public Statistic GetStatistics()
        {
            var statistics = new Statistic();

            var numCds = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Total number of CD's               
                var getValue = new SqlCommand("select sum(discs) from record where media = 'CD'", cn);
                cn.Open();

                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    numCds = (int)getValue.ExecuteScalar();
                }

                cn.Close();
                statistics.TotalCDs = numCds;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Rock Records
                var rockDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Rock'", cn);
                cn.Open();

                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    rockDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.RockDisks = rockDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Folk Records
                var folkDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Folk'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    folkDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.FolkDisks = folkDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Acoustic Records
                var acousticDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Acoustic'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    acousticDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.AcousticDisks = acousticDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Jazz and Fusion Records
                var jazzDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Jazz' or field = 'Fusion'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    jazzDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.JazzDisks = jazzDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Blues Records
                var bluesDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Blues'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    bluesDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.BluesDisks = bluesDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Country Records
                var countryDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Country'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    countryDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.CountryDisks = countryDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Classical Records
                var classicalDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Classical'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    classicalDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.ClassicalDisks = classicalDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Soundtrack Records
                var soundtrackDisks = 0;
                var getValue = new SqlCommand("select sum(discs) from record where field = 'Soundtrack'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    soundtrackDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.SoundtrackDisks = soundtrackDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Four Star Records
                var fourStarDisks = 0;
                var getValue = new SqlCommand("select count(rating) from record where Rating = '****'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    fourStarDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.FourStarDisks = fourStarDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Three Star Records
                var threeStarDisks = 0;
                var getValue = new SqlCommand("select count(rating) from record where Rating = '***'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    threeStarDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.ThreeStarDisks = threeStarDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of Two Star Records
                var twoStarDisks = 0;
                var getValue = new SqlCommand("select count(rating) from record where Rating = '**'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    twoStarDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.TwoStarDisks = twoStarDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for number of One Star Records
                var oneStarDisks = 0;
                var getValue = new SqlCommand("select count(rating) from record where Rating = '*'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    oneStarDisks = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.OneStarDisks = oneStarDisks;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on records
                var recordCost = 0.0m;
                var getValue = new SqlCommand("select sum(cost) from record where media = 'R'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    recordCost = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.RecordCost = recordCost;
            }

            var cdCost = 0.0m;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's               
                var getValue = new SqlCommand("select sum(cost) from record where media = 'CD'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cdCost = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.CDCost = cdCost;
            }

            // calculate the average cost of all CDs
            decimal avCdCost = cdCost / numCds;
            statistics.AvCDCost = avCdCost;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on records and CD's
                var totalCost = 0.0m;
                var getValue = new SqlCommand("select sum(cost) from record", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    totalCost = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.TotalCost = totalCost;
            }

            var disks2017 = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of CD's bought in 2017               
                var getValue = new SqlCommand("select sum(discs) from record where bought > '31-Dec-2016' and bought < '01-Jan-2018'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    disks2017 = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.Disks2017 = disks2017;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's in 2017
                var cost2017 = 0.0m;
                var getValue = new SqlCommand("select sum(cost) from record where bought > '31-Dec-2016' and bought < '01-Jan-2018'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cost2017 = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                // this is to stop a divide by zero error if nothing has been bought
                if (cost2017 > 1)
                {
                    statistics.Cost2017 = cost2017;
                    var av2017 = cost2017 / disks2017;
                    statistics.Av2017 = av2017;
                }
                else
                {
                    statistics.Cost2017 = 0.00m;
                    statistics.Av2017 = 0.00m;
                }

                cn.Close();
            }

            var disks2018 = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of CD's bought in 2018              
                var getValue = new SqlCommand("select sum(discs) from record where bought > '31-Dec-2017' and bought < '01-Jan-2019'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    disks2018 = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.Disks2018 = disks2018;
            }

            var cost2018 = 0.0m;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's in 2018                
                var getValue = new SqlCommand("select sum(cost) from record where bought > '31-Dec-2017' and bought < '01-Jan-2019'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cost2018 = decimal.Parse(getValue.ExecuteScalar().ToString());
                    var av2018 = cost2018 / disks2018;
                    statistics.Av2018 = av2018;
                }

                cn.Close();
                statistics.Cost2018 = cost2018;
            }

            var disks2019 = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of CD's bought in 2019
                var getValue = new SqlCommand("select sum(discs) from record where bought > '31-Dec-2018' and bought < '01-Jan-2020'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    disks2019 = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.Disks2019 = disks2019;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's in 2019
                var cost2019 = 0.0m;
                var getValue = new SqlCommand("select sum(cost) from record where bought > '31-Dec-2018' and bought < '01-Jan-2020'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cost2019 = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                // this is to stop a divide by zero error if nothing has been bought
                if (cost2019 > 1)
                {
                    statistics.Cost2019 = cost2019;
                    var av2019 = cost2019 / disks2019;
                    statistics.Av2019 = av2019;
                }
                else
                {
                    statistics.Cost2019 = 0.00m;
                    statistics.Av2019 = 0.00m;
                }

                cn.Close();
            }

            var disks2020 = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of CD's bought in 2020
                var getValue = new SqlCommand("select sum(discs) from record where bought > '31-Dec-2019' and bought < '01-Jan-2021'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    disks2020 = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.Disks2020 = disks2020;
            }

            var cost2020 = 0.0m;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's in 2020
                var getValue = new SqlCommand("select sum(cost) from record where bought > '31-Dec-2019' and bought < '01-Jan-2021'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cost2020 = decimal.Parse(getValue.ExecuteScalar().ToString());
                    var av2020 = cost2020 / disks2020;
                    statistics.Av2020 = av2020;
                }

                cn.Close();
                statistics.Cost2020 = cost2020;
            }

            var disks2021 = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of CD's bought in 2021
                var getValue = new SqlCommand("select sum(discs) from record where bought > '31-Dec-2020' and bought < '01-Jan-2022'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    disks2021 = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.Disks2021 = disks2021;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's in 2021
                var cost2021 = 0.0m;
                var getValue = new SqlCommand("select sum(cost) from record where bought > '31-Dec-2020' and bought < '01-Jan-2022'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cost2021 = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                // this is to stop a divide by zero error if nothing has been bought
                if (cost2021 > 1)
                {
                    statistics.Cost2021 = cost2021;
                    var av2021 = cost2021 / disks2021;
                    statistics.Av2021 = av2021;
                }
                else
                {
                    statistics.Cost2021 = 0.00m;
                    statistics.Av2021 = 0.00m;
                }

                cn.Close();
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of records
                var totalRecords = 0;
                var getValue = new SqlCommand("select sum(discs) from record where media='R'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    totalRecords = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.TotalRecords = totalRecords;
            }

            var disks2022 = 0;
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for Number of CD's bought in 2022
                var getValue = new SqlCommand("select sum(discs) from record where bought > '31-Dec-2021' and bought < '01-Jan-2023'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    disks2022 = int.Parse(getValue.ExecuteScalar().ToString());
                }

                cn.Close();
                statistics.Disks2022 = disks2022;
            }

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                // query for amount spent on CD's in 2022
                var cost2022 = 0.0m;
                var getValue = new SqlCommand("select sum(cost) from record where bought > '31-Dec-2021' and bought < '01-Jan-2023'", cn);

                cn.Open();
                if (getValue.ExecuteScalar() != DBNull.Value)
                {
                    cost2022 = decimal.Parse(getValue.ExecuteScalar().ToString());
                }

                // this is to stop a divide by zero error if nothing has been bought
                if (cost2022 > 1)
                {
                    statistics.Cost2022 = cost2022;
                    var av2022 = cost2022 / disks2022;
                    statistics.Av2022 = av2022;
                }
                else
                {
                    statistics.Cost2022 = 0.00m;
                    statistics.Av2022 = 0.00m;
                }

                cn.Close();
            }

            return statistics;
        }

        #endregion
    }
}