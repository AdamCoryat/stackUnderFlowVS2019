using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Stack.Models;

namespace Stack.Repositories
{
  public class CatagoriesRepository
  {
    private readonly IDbConnection _db;

    public CatagoriesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Catagory> GetAll()
    {
      string sql = @"
      SELECT
      c.*,
      p.*
      FROM catagories c
      JOIN profiles p on c.creatorId = p.id";
      return _db.Query<Catagory, Profile, Catagory>(sql, (catagory, profile) => { catagory.Creator = profile; return catagory; }, splitOn: "id");
    }

    internal Catagory GetById(int id)
    {
      string sql = @"
      SELECT
      c.*,
      p.*
      FROM catagories c
      JOIN profiles p on c.creatorId = p.id
      WHERE c.id = @id LIMIT 1";
      return _db.Query<Catagory, Profile, Catagory>(sql, (catagory, profile) => { catagory.Creator = profile; return catagory; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Catagory newCatagory)
    {
      string sql = @"
      INSERT INTO Catagories
      (creatorId, title, questions)
      VALUES
      (@CreatorId, @Title, @Questions);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newCatagory);
    }

    internal Catagory Edit(Catagory editCatagory)
    {
      string sql = @"
      UPDATE catagories
      SET
      title = @Title,
      questions = @Questions
      WHERE id = @Id;";
      _db.Execute(sql, editCatagory);
      return editCatagory;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM catagories WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}