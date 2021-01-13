using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using StackUnderFlow.Models;

namespace StackUnderFlow.Repositories
{
  public class QuestionsRepository
  {
    private readonly IDbConnection _db;

    public QuestionsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Question> GetAll()
    {
      string sql = @"
      SELECT
      q.*,
      p.*
      FROM questions q
      JOIN profiles p on q.creatorId = p.id";
      return _db.Query<Question, Profile, Question>(sql, (question, profile) => { question.Creator = profile; return question; }, splitOn: "id");
    }

    internal Question GetById(int id)
    {
      string sql = @"
      SELECT
      q.*,
      p.*
      FROM questions q
      JOIN profiles p on q.creatorId = p.id
      WHERE q.id = @id LIMIT 1";
      return _db.Query<Question, Profile, Question>(sql, (question, profile) => { question.Creator = profile; return question; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal IEnumerable<Question> GetQuestionsByCatagoryId(int id)
    {
      string sql = @"
      SELECT
      q.*,
      c.*
      FROM questions q
      JOIN catagories c on q.catagoryId = c.id
      WHERE q.catagoryId = @Id
      ";
      return _db.Query<Question>(sql, new { id });
    }

    internal int Create(Question newQuestion)
    {
      string sql = @"
      INSERT INTO Questions
      (creatorId, title, description, dateCreated, dateClosed, dateUpdated, responses, isSolved, catagoryId)
      VALUES
      (@CreatorId, @Title, @Description, @DateCreated, @DateClosed, @DateUpdated, @Responses, @IsSolved, @CatagoryId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newQuestion);
    }

    internal Question Edit(Question editQuestion)
    {
      string sql = @"
      UPDATE questions
      SET
      title = @Title,
      description = @Description,
      dateClosed = @DateClosed, 
      dateUpdated = @DateUpdated,
      responses = @Responses,
      isSolved = @IsSolved
      WHERE id = @Id;";
      _db.Execute(sql, editQuestion);
      return editQuestion;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM questions WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}