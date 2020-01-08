﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;
using Models;
using System.Data;

namespace Data.Contexts
{
    public class MonsterSqlContext : IMonsterContext
    {
        public List<Monster> GetAllMonsters()
        {
            List<Monster> Allmonsters = new List<Monster>();
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * FROM Monster";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                foreach (DataRow dr in dt.Rows)
                {
                    Monster monster = new Monster();

                    int.TryParse(dr[0].ToString(), out int id);
                    monster.Id = id;
                    monster.Name = dr[1].ToString();
                    monster.Description = dr[2].ToString();
                    int.TryParse(dr[3].ToString(), out int stat);
                    monster.RequireStat = stat;

                    Allmonsters.Add(monster);
                }
            }
            return (Allmonsters);
        }


        public Monster GetMonsterByID(int id)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * From Monster WHERE Id=1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Monster monster = new Monster();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monster.Id = (int)reader["Id"];
                        monster.Name = (string)reader["Name"];
                        monster.Description = (string)reader["Description"];
                    }
                }
                return (monster);
            }
        }
    }
}
