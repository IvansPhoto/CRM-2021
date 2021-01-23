using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRM.Models
{
	public class Objective
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsFinished { get; set; } = false;
		public DateTime CreateDate { get; set; } = new DateTime(DateTime.UtcNow.ToLocalTime().Ticks);
		public DateTime FinishDate { get; set; } = new DateTime(DateTime.UtcNow.ToLocalTime().Ticks);
		public ObjType ObjectType { get; set; } = ObjType.Call;
		public User? ResponsibleUser { get; set; }
		public Company? Company { get; set; }
		public Employee? Employee { get; set; }
		public Project? Project { get; set; }

		public override string ToString()
		{
			return
				$"Id: {Id}, Title: {Title ?? "Not set"}, Description: {Description ?? "Not set"}, IsFinished: {IsFinished}, CreateDate: {CreateDate}, FinishDate: {FinishDate}, ObjectType: {ObjectType}, ResponsibleUser: {ResponsibleUser?.Id}, Company: {Company?.Id}, Employee: {Employee?.Id}, Project: {Project?.Id}";
		}

		public enum ObjType
		{
			Call,
			Visit,
			Meeting,
			Message,
			Demonstration
		}

		public Objective()
		{
		}

		public Objective(string title)
		{
			Title = title;
		}
	}
}